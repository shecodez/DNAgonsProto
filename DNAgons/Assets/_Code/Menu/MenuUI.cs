using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {

    public static MenuUI Instance { get; set; }

    public Text currency_brokenScales;
    public Text currency_intactScales;

    public GameObject compassRadar;
    public GameObject virtualJoystick;

    void Awake ()
    {
        Instance = this;
    }

    void Start ()
    { 
        UpdateCurrencyText();
    }

    public void UpdateCurrencyText()
    {
        currency_brokenScales.text = SaveManager.Instance.data.brokenScales.ToString();
        currency_intactScales.text = SaveManager.Instance.data.intactScales.ToString();
    }

    public void ToggleCompassRadarDisplay ()
    {
        //compassRadar.SetActive(!compassRadar.activeSelf);
    }

    void Update ()
    {
        if (MenuManager.Instance.CurrentMenu == null)        
            compassRadar.SetActive(true);
                    
        if (MenuManager.Instance.CurrentMenu == null || MenuManager.Instance.CurrentMenu.mTitle == "Inventory")
            virtualJoystick.SetActive(true);
        else
        {
            compassRadar.SetActive(false);
            virtualJoystick.SetActive(false);
        }
    }
}
