using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SpawnedItemManager : MonoBehaviour {

    public List<SpawnedItem> spawnedItems;
    public List<GameObject> spawnedItemGOs; // this list might replace the above as static?

    public static SpawnedItemManager Instance { get; set; }
    void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
        GetSpawnedItemsFromExit();
        UpdateTimeAffectedItems();
    }

    SpawnedItem NewSpawnedItemFromItem (Item item)
    {
        SpawnedItem _spawnedItem = new GameObject().AddComponent<SpawnedItem>();        
        _spawnedItem.item = item;

        return _spawnedItem;
    }

    // So we don't spawn DNAgon if there is no food
    internal bool ContainsFoodItem()
    {
        for (int i = 0; i < spawnedItems.Count; i++)
        {
            if (spawnedItems[i].item.iCategory == ItemCategory.Food)
                return true;
        }
        return false;
    }

    void GetSpawnedItemsFromExit()
    {
        for (int i = 0; i < XMLManager.Ins.itemDB.list.Count; i++)
        {
            //if (!string.IsNullOrEmpty(XMLManager.Ins.itemDB.list[i].iDespawnTime))// || !XMLManager.Ins.itemDB.list[i].iStackable)
            if(XMLManager.Ins.itemDB.list[i].iPlaced)
            {
                spawnedItems.Add(NewSpawnedItemFromItem(XMLManager.Ins.itemDB.list[i]));
            }          
        }
    }

    void UpdateTimeAffectedItems()
    {
        List<SpawnedItem> _itemsToRemove = new List<SpawnedItem>();

        for (int i = 0; i < spawnedItems.Count; i++)
        {
            //if (spawnedItems[i].item.iStackable)
            if(!string.IsNullOrEmpty(spawnedItems[i].item.iDespawnTime))
            {
                spawnedItems[i].DespawnTime = DateTime.Parse(
                    SaveManager.Instance.GetItemDespawnTime(spawnedItems[i].item.ID), null, DateTimeStyles.RoundtripKind);

                if (DateTime.Now >= spawnedItems[i].DespawnTime)
                    _itemsToRemove.Add(spawnedItems[i]);
                else
                    spawnedItems[i].Respawn(spawnedItems[i].item);
            }
            else
            {
                spawnedItems[i].Respawn(spawnedItems[i].item);
            }           
        }

        if (_itemsToRemove.Count > 0)
            RemoveItems(_itemsToRemove);
    }

    public void AddItem(SpawnedItem item)
    {
        spawnedItems.Add(item);
    }

    public void RemoveItem(SpawnedItem item)
    {
        spawnedItems.RemoveAll(spawnedItem => spawnedItem == item);
        //for (int i = spawnedItems.Count - 1; i >= 0;  i--)
        //{
        //    if (spawnedItems[i] == item)
        //    {
        //        spawnedItems.RemoveAt(i);
        //    }
        //}
    }

    private void RemoveItems(List<SpawnedItem> _itemsToRemove)
    {
        for (int i = 0; i < _itemsToRemove.Count; i++)
        {
            _itemsToRemove[i].Despawn(_itemsToRemove[i]);
        }
    }

    public void AddInstantiatedItem(GameObject spawn)
    {
        spawnedItemGOs.Add(spawn);
    }

    public void RemoveInstantiatedItem(GameObject spawn)
    {
        spawnedItemGOs.RemoveAll(GO => GO == spawn);
    }

    //void OnApplicationQuit()
    //{
    //    //SaveManager.Instance.SaveSpawnedItemsOnExit();
    //    Debug.Log("spawned Items on Exit: " + spawnedItems.Count);        
    //}
}
