using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, ISelectHandler
{
    public Button button;
    public int buttonIndex;
    public Outline buttonOutline;

    public Image iBtnIcon;
    public Text iBtnName;
    public Image iBtnPlaced;

    public Text iQuantity;

    public Item item;
    Inventory inventory;

    bool selected, focused = false;

    void Start () {
        button.onClick.AddListener(HandleClick);
    }

    public void SetupInventory(Inventory _inventory)
    {
        inventory = _inventory;
    }

    public void SetupItem(Item _item)
    {
        item = _item;

        iBtnIcon.sprite = item.iIcon;
        iBtnName.text = item.iName;
     
        Color _temp = iBtnPlaced.color;
        if (SaveManager.Instance.GetItemPlaced(item.ID))
            _temp.a = 1;
        else
            _temp.a = 0;

        iBtnPlaced.color = _temp;

        if (item.iStackable)
        {
            if (item.iCost > 0)
                iQuantity.text = item.iQuantity.ToString();
            else
                iQuantity.text = "∞";
        }
        else
            iQuantity.text = "";
    }

    public void HandleClick()
    {
        if (inventory != null)
        {
            if (inventory.SelectedButton == this && focused 
                && !SaveManager.Instance.GetItemPlaced(item.ID))
            {
                inventory.DisplayPlaceItemModal(item);
                // TODO: if press and hold add item to radar so player can find it in their yard?
            }
            else if (inventory.SelectedButton == this && focused 
                && SaveManager.Instance.GetItemPlaced(item.ID))
            {
                inventory.DisplayRemoveItemModal(item);
            }
        }
        focused = true;
    }

    public void Update()
    {
        if (inventory.SelectedButton != this && selected)
        {
            Deselect();
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        buttonOutline.enabled = true;
        if (inventory != null)
            inventory.SelectedButton = this;
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
