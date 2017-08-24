using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour, ISelectHandler
{

    public Button button;
    public int buttonIndex;
    public Outline buttonOutline;

    public Image iBtnIcon;
    public Text iBtnName;
    public string iDescription;
    public Image iCostIcon;
    public Text iBtnCost;
    public Image iBtnSold;

    Item item;
    Shop shop;

    bool selected, focused = false;
        
	void Start () {
        button.onClick.AddListener(HandleClick);
	}

    public void SetupShop (Shop _shop)
    {
        shop = _shop;
    }

    public void SetupItem (Item _item)
    {
        item = _item;

        buttonIndex = item.ID;       

        iBtnIcon.sprite = item.iIcon;
        iBtnName.text = item.iName;
        iDescription = item.iDesc;
        iBtnCost.text = item.iCost.ToString();
        if (item.iCurrency == CurrencyType.IntactScale)
            iCostIcon.sprite = Resources.Load<Sprite>("Sprites/Items/ScaleIntact") as Sprite;
        else
            iCostIcon.sprite = Resources.Load<Sprite>("Sprites/Items/ScaleBroken") as Sprite;

        Color _temp = iBtnSold.color;
        if (SaveManager.Instance.GetItemBought(item.ID) && !item.iStackable)
            _temp.a = 1;
        else
            _temp.a = 0;

        iBtnSold.color = _temp;
    }
    
    public void HandleClick()
    {
        if (shop != null)
        {
            if ((shop.SelectedButton == this && focused
                && !SaveManager.Instance.GetItemBought(item.ID)) ||
                (shop.SelectedButton == this && focused
                && item.iStackable))
            {
                shop.DisplayPurchaseModal(item, this);
            }         
        }
        focused = true;
    }

    public void Update()
    {
        if (shop.SelectedButton != this && selected)
        {
            // So its only called once
            Deselect();
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        buttonOutline.enabled = true;
        if (shop != null)
            shop.SelectedButton = this;
        selected = true;               
    }

    public void Deselect()
    {
        buttonOutline.enabled = false;
        //if (shop != null)
        //    shop.SelectedButton = null;
        focused = false;
        selected = false;       
    }
}
