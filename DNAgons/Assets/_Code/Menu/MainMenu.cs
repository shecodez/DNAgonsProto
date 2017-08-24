using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public static MainMenu Instance;

    public Button[] mainMenuButtons;

    public Menu previousMenu = null;

    void Awake()
    {
        Instance = this;
    }

	void Start()
    {
        Transform _mainMenuBG = this.transform.GetChild(1);
        mainMenuButtons = _mainMenuBG.GetComponentsInChildren<Button>();
    }

    public void EnableMenuButtons ()
    {
        for (int i = 0; i < mainMenuButtons.Length; i++)
        {
            mainMenuButtons[i].interactable = true;                           
        }
    }

    public void DisableMenuButton () { }

    void Update ()
    {
        // TODO: not efficient too many for loop calls
        if (MenuManager.Instance.CurrentMenu != null)
        {
            previousMenu = MenuManager.Instance.CurrentMenu;
            switch (MenuManager.Instance.CurrentMenu.mTitle)
            {
                case "Shop":
                    EnableMenuButtons();
                    mainMenuButtons[0].interactable = false;
                    break;
                case "DNAgons":
                    EnableMenuButtons();
                    mainMenuButtons[1].interactable = false;
                    break;
                case "Inventory":
                    EnableMenuButtons();
                    mainMenuButtons[2].interactable = false;
                    break;

                default:
                    EnableMenuButtons();
                    break;
            }
        }
    }
}
