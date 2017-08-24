using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static Inventory Instance { set; get; }

    public GameObject inventoryButtonPrefab;
    public Transform contentPanel;
    public GameObject playerHands;
    public ObjectPool buttonObjectPool;
    public Text numbOfPlacedItems;
    public int maxNumbPlacedItems;

    public int selectedItemIndex;
    public InventoryButton SelectedButton { get; set; }
    public bool CarryingItem { get; set; }

    private ModalWindow modalWindow;
    void Awake () {
        Instance = this;
        modalWindow = ModalWindow.Instance();
    }

    void Start ()
    {
        CarryingItem = false;
        maxNumbPlacedItems = SaveManager.Instance.data.itemsPlacedMaxCapacity;
        UpdateTotalItemsPlacedText();
        AddButtons();
    }

    void OnEnable ()
    {
        ResetInventory();
    }

    void ResetInventory ()
    {
        AddButtons();
    }

    // Adds 'ALL' buttons
    void AddButtons ()
    {
        foreach (Transform child in contentPanel.transform)
        {
            buttonObjectPool.ReturnObject(child.gameObject);
        }

        /*for (int i = 0; i < ItemDatabase.itemList.Count; i++)
        {
            if (SaveManager.Instance.GetItemBought(ItemDatabase.itemList[i].ID))
            {
                Item _item = ItemDatabase.itemList[i];
                GameObject _newButton = Instantiate(inventoryButtonPrefab, contentPanel);
                _newButton.transform.SetParent(contentPanel);

                InventoryButton _iButton = _newButton.GetComponent<InventoryButton>();
                _iButton.SetupItem(_item);
            }
        }*/
        for (int i = 0; i < XMLManager.Ins.itemDB.list.Count; i++)
        {
            if (SaveManager.Instance.GetItemBought(XMLManager.Ins.itemDB.list[i].ID) ||
                XMLManager.Ins.itemDB.list[i].iStackable && XMLManager.Ins.itemDB.list[i].iCategory != ItemCategory.Exchange)
            {
                Item _item = XMLManager.Ins.itemDB.list[i];
                GameObject _newButton = buttonObjectPool.GetObject();
                _newButton.transform.SetParent(contentPanel);

                InventoryButton _iButton = _newButton.GetComponent<InventoryButton>();
                _iButton.SetupInventory(this);
                _iButton.SetupItem(_item);
            }
        }
    }

    // Adds buttons by category
    void AddButtons (ItemCategory category)
    {
        if (category == ItemCategory.All)
        {
            AddButtons();
            return;
        }

        foreach (Transform child in contentPanel.transform)
        {
            buttonObjectPool.ReturnObject(child.gameObject);
        }

        for (int i = 0; i < XMLManager.Ins.itemDB.list.Count; i++)
        {
            if (SaveManager.Instance.GetItemBought(XMLManager.Ins.itemDB.list[i].ID) 
                && XMLManager.Ins.itemDB.list[i].iCategory == category)
            {
                Item _item = XMLManager.Ins.itemDB.list[i];
                GameObject _newButton = buttonObjectPool.GetObject();
                _newButton.transform.SetParent(contentPanel);

                InventoryButton _iButton = _newButton.GetComponent<InventoryButton>();
                _iButton.SetupInventory(this);
                _iButton.SetupItem(_item);
            }
        }
    }

    public void DisplayPlaceItemModal(Item item)
    {
        Modal _placeItemModal = new Modal();
        _placeItemModal.mType = ModalType.Info;
        _placeItemModal.question = "Would you like to place " + item.iName + " in your yard?";

        _placeItemModal.modalButton1 = new ModalButton();
        _placeItemModal.modalButton1.label = "Yes";
        _placeItemModal.modalButton1.action = () => { CarryItem(item); };

        _placeItemModal.modalButton2 = new ModalButton();
        _placeItemModal.modalButton2.label = "No";
        _placeItemModal.modalButton2.action = ModalWindow.NoAction;

        modalWindow.DisplayModalWindow(_placeItemModal);
    }

    public void DisplayRemoveItemModal(Item item)//, GameObject itemGO)
    {
        Modal _removeItemModal = new Modal();
        _removeItemModal.mType = ModalType.Info;
        _removeItemModal.question = "Would you like to remove " + item.iName + " from your yard?";

        _removeItemModal.modalButton1 = new ModalButton();
        _removeItemModal.modalButton1.label = "Yes";
        _removeItemModal.modalButton1.action = () => { RemoveItem(item); };

        _removeItemModal.modalButton2 = new ModalButton();
        _removeItemModal.modalButton2.label = "No";
        _removeItemModal.modalButton2.action = ModalWindow.NoAction;

        modalWindow.DisplayModalWindow(_removeItemModal);
    }

    public void CarryItem(Item item)
    {
        int _totalItemsPlaced = SaveManager.Instance.data.totalItemsPlaced;

        if (playerHands.transform.childCount > 0)
        {
            Destroy(playerHands.transform.GetChild(0).gameObject);
            CarryingItem = false;
            SaveManager.Instance.SetItemPlaced(playerHands.transform.GetChild(0).GetComponent<SpawnedItem>().item.ID, false);
        }

        if (!SaveManager.Instance.GetItemPlaced(item.ID) || item.iStackable)
        {
            if (item.iStackable && item.iQuantity <= 0 && item.iCost > 0)
            {
                Invoke("DisplayOutOfStockModal", Time.deltaTime);
                Debug.Log(item.iName + " is out of stock!");
                return;
            }
            
            CarryingItem = true;
            GameObject _itemGO = Instantiate(item.iModel, playerHands.transform);
            _itemGO.transform.localPosition = Vector3.zero;
            _itemGO.GetComponent<SpawnedItem>().item = item;

            if (_totalItemsPlaced + 1 < maxNumbPlacedItems)
            {
                //SaveManager.Instance.SetItemPlaced(item.ID, true);                
                SaveManager.Instance.MarkItemCarried(item.ID, true);
                SelectedButton.SetupItem(item);
                UpdateTotalItemsPlacedText();
            }
            else
            {
                Invoke("DisplayPlacedItemMaxCapacityReachedModal", Time.deltaTime);
            }
        } 
    }

    private void DisplayOutOfStockModal()
    {
        Modal _outOfStockModal = new Modal();
        _outOfStockModal.mType = ModalType.Warning;
        _outOfStockModal.question = "That Item is out of stock!";

        _outOfStockModal.modalButton1 = new ModalButton();
        _outOfStockModal.modalButton1.label = "Ok";
        _outOfStockModal.modalButton1.action = ModalWindow.OkAction;

        modalWindow.DisplayModalWindow(_outOfStockModal);
    }

    public void PutDownItem (GameObject itemGO, Vector3 position)
    {
        // Remove item from players hands 
        itemGO.transform.parent = null;
        CarryingItem = false;
        // put down carried item at mouse click position
        itemGO.transform.position = position;
        itemGO.GetComponent<SpawnedItem>().spawnedItemGO = itemGO;
        // Add item to spawnedItemsManager        
        SpawnedItemManager.Instance.AddItem(itemGO.GetComponent<SpawnedItem>());
        itemGO.GetComponent<SpawnedItem>().item.iPosition = position;
        itemGO.GetComponent<SpawnedItem>().PutDownItem();
        SpawnedItemManager.Instance.AddInstantiatedItem(itemGO);
    }

    private void DisplayPlacedItemMaxCapacityReachedModal()
    {
        Modal _maxCapacityReachedModal = new Modal();
        _maxCapacityReachedModal.mType = ModalType.Warning;
        _maxCapacityReachedModal.question = "You have reached the maximum number of items you can place in your yard.";

        _maxCapacityReachedModal.modalButton1 = new ModalButton();
        _maxCapacityReachedModal.modalButton1.label = "Ok";
        _maxCapacityReachedModal.modalButton1.action = ModalWindow.OkAction;

        modalWindow.DisplayModalWindow(_maxCapacityReachedModal);
    }

    // select and hold to remove
    public void RemoveItem(Item item)//, GameObject itemGO)
    {
        if (SaveManager.Instance.GetItemPlaced(item.ID))
        {
            if (CarryingItem)
            {
                if (playerHands.transform.GetChild(0).GetComponent<SpawnedItem>().item == item)
                {
                    Destroy(playerHands.transform.GetChild(0).gameObject);
                }
            }
            else
            {
                for (int i = 0; i < SpawnedItemManager.Instance.spawnedItems.Count; i++)
                {
                    if (SpawnedItemManager.Instance.spawnedItems[i].item == item)
                    {
                        Destroy(SpawnedItemManager.Instance.spawnedItems[i].spawnedItemGO);
                        SpawnedItemManager.Instance.RemoveItem(SpawnedItemManager.Instance.spawnedItems[i]);
                    }
                    if (SpawnedItemManager.Instance.spawnedItemGOs[i].GetComponent<SpawnedItem>().item == item)
                    {
                        Destroy(SpawnedItemManager.Instance.spawnedItemGOs[i]);
                        SpawnedItemManager.Instance.RemoveInstantiatedItem(SpawnedItemManager.Instance.spawnedItemGOs[i]);
                    }
                }
            }

            CarryingItem = false;           
            SaveManager.Instance.SetItemPlaced(item.ID, false);
            SelectedButton.SetupItem(item);
            UpdateTotalItemsPlacedText();
            Debug.Log("Removing Item: " + item.iName);
        }
    }

    public void UpdateTotalItemsPlacedText()
    {
        numbOfPlacedItems.text = SaveManager.Instance.GetTotalItemsPlaced() + " / " 
            + SaveManager.Instance.data.itemsPlacedMaxCapacity;
    }

    public void SortItemsByCategory (ItemCategory category)
    {
        AddButtons(category);
    }
}
