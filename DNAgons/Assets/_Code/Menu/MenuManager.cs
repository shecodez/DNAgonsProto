using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public static MenuManager Instance;
   
    public List<Menu> menus;

    public Transform menuUI;
    public GameObject mainMenu;
    public GameObject shopMenu;
    public GameObject dnagonMenu;
    public GameObject giftMenu;
    public GameObject inventory;
    public RadialMenu radialMenu;

    //public GameObject prevNextBtnPanel;

    public Menu CurrentMenu { get; set; }

    void Awake ()
    {
        Instance = this;
       
        Menu.menuUI = menuUI;
        Menu.mHeader = menuUI.GetChild(0).gameObject;
        Menu.mMain = menuUI.GetChild(1).transform;
        Menu.mFooter = menuUI.GetChild(2).gameObject;
    }

    void Start ()
    {
        CurrentMenu = null;
        Menu _shop = new Menu("Shop", Color.yellow, shopMenu, true);
        menus.Add(_shop);
        Menu _dnagons = new Menu("DNAgons", Color.cyan, dnagonMenu, true);
        menus.Add(_dnagons);
        Menu _inventory = new Menu("Inventory", Color.clear, inventory, false);
        menus.Add(_inventory);
        Menu _gifts = new Menu("Gifts", Color.grey, giftMenu, false);
        menus.Add(_gifts);
    }

    public void OnClickMenuButton(GameObject menuPanel)
    {
        // *Note* Actually Toggles any passed GO...
        menuPanel.SetActive(!menuPanel.activeSelf);
        if (menuPanel.activeSelf == false)
        {
            CurrentMenu = null;
            MainMenu.Instance.EnableMenuButtons();
        }
    }

    public void DisplayRadialMenu(Interactable go)
    {
        RadialMenu _newMenu = Instantiate(radialMenu) as RadialMenu;
        _newMenu.transform.SetParent(transform, false);
        _newMenu.transform.position = Input.mousePosition;
        _newMenu.SpawnButtons(go);
    }

    public void DisplayYard ()
    {
        CleanUp();
        MainMenu.Instance.EnableMenuButtons();
    }    

    public void DisplayShopMenu()
    {
        DisplayMenu(menus[(int)MenuState.Shop]);
    }

    public void DisplayDNAgonsMenu()
    {
        DisplayMenu(menus[(int)MenuState.DNAgons]);
    }

    public void DisplayInventory()
    {
        //DisplayMenu(menus[2]);
        DisplayMenu(menus[(int)MenuState.Inventory]);
    }

    public void DisplayGiftsMenu()
    {
        DisplayMenu(menus[(int)MenuState.Gifts]);
    }

    public void DisplayProfile() { }
    public void DisplayFamilyTree() { }
  
    public void DisplaySettingsMenu() { }
    public void DisplayHelpMenu() { }

    void CleanUp()
    {
        CurrentMenu = null;
  
        menuUI.GetComponent<Image>().color = Color.clear;
        CloseAllChildern(Menu.mMain);

        mainMenu.SetActive(false);
        
        // Remove Pagination
        Menu.mFooter.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void DisplayMenu(Menu menu)
    {
        CleanUp();

        CurrentMenu = menu;
        menuUI.GetComponent<Image>().color = menu.mColor;
        menu.mPrefab.SetActive(true);
               
        Menu.mFooter.transform.GetChild(1).gameObject.SetActive(menu.hasPagination);
    }
  
    void CloseAllChildern(Transform parent)
    {
        foreach (Transform childTransform in parent)
        {
            childTransform.gameObject.SetActive(false);
        }
    }
}

public enum MenuState
{
    //Playing,
    Shop,
    DNAgons,
    Inventory,
    Gifts,
    Profile,
    FamilyTree,
    Settings,
    Help
};
