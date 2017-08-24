using UnityEngine;

[System.Serializable]
public class Menu
{
    public string mTitle;
    public Color mColor;
    public GameObject mPrefab;
    public bool hasPagination;

    public static Transform menuUI;
    public static GameObject mHeader;
    public static Transform mMain;
    public static GameObject mFooter;

    public Menu (string title, Color color, GameObject menu, bool pagination)
    {
        mTitle = title;
        mColor = color;
        mPrefab = menu;
        hasPagination = 
            pagination;
    }

    public static void Setup (Transform _menuUI, GameObject header, Transform main, GameObject footer)
    {
        menuUI = _menuUI;
        mHeader = header;
        mMain = main;
        mFooter = footer;
    }
}

/*public enum MenuName
    {
        Playing,
        Shop,
        DNAgons,
        Inventory,
        Gifts,
        Profile,
        FamilyTree,
        Settings,
        Help
    };*/


