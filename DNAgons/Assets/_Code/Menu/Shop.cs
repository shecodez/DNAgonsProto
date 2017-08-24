using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public GameObject shopButtonPrefab;
    public Transform contentPagePanel;
    public Text descriptionDisplay;
    public ObjectPool buttonObjectPool;
    public Text paginationDisplay;

    [SerializeField]
    int currentPage = 1;
    Pager paginationObj;

    List<Item> shopItemList;

    public int selectedItemIndex;
    public ShopItemButton SelectedButton { get; set; }

    private ModalWindow modalWindow;
    void Awake () {
        modalWindow = ModalWindow.Instance();
        shopItemList = XMLManager.Ins.itemDB.list.Skip(1).ToList();
    }

    void Start () {        
        // Set ObjectPool prefab
        if (shopButtonPrefab != null)
            contentPagePanel.GetComponent<ObjectPool>().prefab = shopButtonPrefab;
       
        paginationObj = new Pager(shopItemList.Count, currentPage, 4);
        AddButtons(paginationObj.StartIndex, paginationObj.EndIndex);
        UpdatePaginationText();
        //paginationObj.Print();
        //foreach(var i in ItemDatabase.itemList) { Debug.Log(i.iName); }             
    }

    void OnEnable()
    {
        ResetShop();
    }

    void ResetShop ()
    {
        currentPage = 1;
        SelectedButton = null;
        paginationObj = new Pager(shopItemList.Count, currentPage, 4);
        AddButtons(paginationObj.StartIndex, paginationObj.EndIndex);
        UpdatePaginationText();
    }

    void AddButtons(int startIndex, int endIndex)
    {
        // remove all cur buttons if any
        foreach (Transform child in contentPagePanel.transform)
        {
            buttonObjectPool.ReturnObject(child.gameObject);
        }
        // add buttons per paginationObj
        for (int i = startIndex; i < endIndex; i++)
        {
            Item _item = shopItemList[i];
            GameObject _newButton = buttonObjectPool.GetObject();
            _newButton.transform.SetParent(contentPagePanel);

            ShopItemButton _shopItemButton = _newButton.GetComponent<ShopItemButton>();
            _shopItemButton.SetupShop(this);
            _shopItemButton.SetupItem(_item);
        }
    }

    void Update ()
    {
        if (SelectedButton != null)
        {
            selectedItemIndex = SelectedButton.buttonIndex;
            descriptionDisplay.text = SelectedButton.iDescription.ToString();
        }
        else { descriptionDisplay.text = ""; }
    }

    void UpdatePageButtons ()
    {
        SelectedButton = null;
        paginationObj = new Pager(shopItemList.Count, currentPage, 4);
        AddButtons(paginationObj.StartIndex, paginationObj.EndIndex);
        UpdatePaginationText();
    }

    public void GoToNextPage()
    {
        currentPage++;
        if (currentPage > paginationObj.TotalPages)
            currentPage = paginationObj.TotalPages;

        UpdatePageButtons();
    }

    public void GoToPrevPage()
    {
        currentPage--;
        if (currentPage <= 0)
            currentPage = 1;

        UpdatePageButtons();
    }

    void UpdatePaginationText()
    {
        paginationDisplay.text = paginationObj.CurrentPage + " / " + paginationObj.TotalPages;
    }

    public void PurchaseItem (Item item, ShopItemButton button)
    {
        if (!SaveManager.Instance.GetItemBought(item.ID) || item.iStackable)
        {
            //if (item.iStackable) { Invoke("DisplayAdjustQuantityModal", Time.deltaTime); }
            if (SaveManager.Instance.PurchaseItem(item))
            {
                // Update Item Display Img
                button.SetupItem(item);
                item.iQuantity++;
                //DisplaySetPlaceModal(item);
            }
            else
            {
                Invoke("DisplayNotEnoughFundsModal", Time.deltaTime);
            }
        }    
    }

    /*public void DisplayAdjustQuantityModal ()
    {
        Modal _adjustQuantityModal = new Modal();
        _adjustQuantityModal.mType = ModalType.Info;
        _adjustQuantityModal.question = "How many would you like to purchase?";
        // TODO: add slider to modal (start at 1 end at quantity*icost <= funds)

        _adjustQuantityModal.modalButton1 = new ModalButton();
        _adjustQuantityModal.modalButton1.label = "Purchase";
        _adjustQuantityModal.modalButton1.action = () => { PurchaseItems(item, slider.value); };

        _adjustQuantityModal.modalButton1 = new ModalButton();
        _adjustQuantityModal.modalButton1.label = "Cancel";
        _adjustQuantityModal.modalButton1.action = ModalWindow.NoAction;
    }
    
    public void PurchaseItems(Item item, int amount) 
    {
        if (SaveManager.Instance.PurchaseItems(item, amount))
        {
            // Update Item Display Img
            item.iQuantity += amount;
            button.SetupItem(item);
            //DisplaySetPlaceModal(item);
        }
    }*/

    public void DisplayNotEnoughFundsModal ()
    {      
        Modal _notEnoughFundsModal = new Modal();
        _notEnoughFundsModal.mType = ModalType.Warning;
        _notEnoughFundsModal.question = "Insufficient funds.";

        _notEnoughFundsModal.modalButton1 = new ModalButton();
        _notEnoughFundsModal.modalButton1.label = "OK";
        _notEnoughFundsModal.modalButton1.action = ModalWindow.OkAction;

        modalWindow.DisplayModalWindow(_notEnoughFundsModal);
    }

    public void DisplayPurchaseModal (Item item, ShopItemButton button)
    {
        Modal _purchaseModal = new Modal();
        _purchaseModal.mType = ModalType.Info;
        _purchaseModal.question = "Would you like to purchase " + item.iName + "?";

        _purchaseModal.modalButton1 = new ModalButton();
        _purchaseModal.modalButton1.label = "Yes";
        _purchaseModal.modalButton1.action = () => { PurchaseItem(item, button); };

        _purchaseModal.modalButton2 = new ModalButton();
        _purchaseModal.modalButton2.label = "No";
        _purchaseModal.modalButton2.action = ModalWindow.NoAction;

        modalWindow.DisplayModalWindow(_purchaseModal);
    }
}
