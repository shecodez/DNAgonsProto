using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour {

    public Button button;
    public Image mBtnIcon;
    public Text mBtnName;

    public bool Active { get; set; }

    void Update ()
    {
        button.enabled = Active;      
    }
}
