using System.Collections;
using UnityEngine;

public class SpawnedItem : MonoBehaviour {

    public Item item;
    public GameObject spawnedItemGO;

    public bool timeAffectedItem = false;

    public DNAgon spawnedDNAgon;
    public GameObject sDNAgonGO;

    public bool ItemPutDown { get; set; }
    public System.DateTime DespawnTime { get; set; }

    void Awake () { ItemPutDown = false; }

    void Start () {
        if (item.iCategory == ItemCategory.Food) {
            timeAffectedItem = true;    
        }
    } 

    public void UpdateInventoryButton (Item item)
    {
        InventoryButton[] _buttons = FindObjectsOfType<InventoryButton>() as InventoryButton[];
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_buttons[i].item.ID == item.ID)
            {
                _buttons[i].SetupItem(item);
                return;
            }
        }
    }

    public void PutDownItem ()
    {
        ItemPutDown = true;
        DNAgonManager.Instance.SpawnGeneratedDNAgonViaItem(this);

        if (timeAffectedItem)
        {
            DespawnTime = System.DateTime.Now.AddSeconds(Random.Range(30, 55));
            Debug.Log(item.iName+" Life time: " + DespawnTime.ToLocalTime());
            SaveManager.Instance.SetItemDespawnTime(item.ID, DespawnTime.ToString("o"));
        }
        if (item.iStackable && item.iCost > 0)
        {
            item.iQuantity--;
            UpdateInventoryButton(item);
        }
    }

    void Update ()
    {
        if (ItemPutDown)
        {
            if (timeAffectedItem && System.DateTime.Now >= DespawnTime)
            {
                Despawn(this);
            }
        }
    }

    public void Respawn (Item item)
    {
        var _respawnedItem = Instantiate(item.iModel, item.iPosition, Quaternion.identity);
        _respawnedItem.GetComponent<SpawnedItem>().spawnedItemGO = _respawnedItem;
        _respawnedItem.GetComponent<SpawnedItem>().item = item;
        _respawnedItem.GetComponent<SpawnedItem>().ItemPutDown = true;
        if (item.iCategory == ItemCategory.Food)
        {
            _respawnedItem.GetComponent<SpawnedItem>().timeAffectedItem = true;
            _respawnedItem.GetComponent<SpawnedItem>().DespawnTime = System.DateTime.Parse(
                    SaveManager.Instance.GetItemDespawnTime(item.ID), null, System.Globalization.DateTimeStyles.RoundtripKind);         
        }
         _respawnedItem.AddComponent<DontDestroy>();
        _respawnedItem.transform.parent = null;

        SpawnedItemManager.Instance.AddInstantiatedItem(_respawnedItem);
        if (timeAffectedItem)
            Debug.Log(item.iName + " Respawned @ " + System.DateTime.Now + " & Should despawn @ " + DespawnTime.ToLocalTime());
    }

    public void Despawn (SpawnedItem spawnedItem)
    {
        SpawnedItemManager.Instance.RemoveItem(spawnedItem);
        SpawnedItemManager.Instance.RemoveInstantiatedItem(spawnedItemGO);
        Destroy(spawnedItemGO);
        SaveManager.Instance.SetItemDespawnTime(spawnedItem.item.ID, null);
        Debug.Log(spawnedItem.item.iName + " Despawned @ " + System.DateTime.Now);

        SaveManager.Instance.SetItemPlaced(spawnedItem.item.ID, false);
        UpdateInventoryButton(spawnedItem.item);
        if (Inventory.Instance)
            Inventory.Instance.UpdateTotalItemsPlacedText();       
    }
}
