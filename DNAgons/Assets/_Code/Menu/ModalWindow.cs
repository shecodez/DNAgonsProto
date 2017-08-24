using UnityEngine;
using UnityEngine.UI;

public class ModalWindow : MonoBehaviour {

    public Text question;
    public Image iconImg;

    public Button btn1, btn2, btn3;
    public Text btn1Label, btn2Label, btn3Label;

    public GameObject modalPanelGO;

    private static ModalWindow modalWindow;

    public static ModalWindow Instance()
    {
        if (!modalWindow)
        {
            modalWindow = FindObjectOfType(typeof(ModalWindow)) as ModalWindow;
            if (!modalWindow)
                Debug.LogError("There needs to be one active ModalWindow script on a GO in the scene");
        }
        return modalWindow;
    }

    public static void OkAction () { }
    public static void NoAction () { }

    public void DisplayModalWindow (Modal modal)
    {
        modalPanelGO.SetActive(true);

        CleanUp();

        this.question.text = modal.question;

        if (modal.iconImg)
        {
            this.iconImg.sprite = modal.iconImg;
            this.iconImg.gameObject.SetActive(true);
        }

        btn1.onClick.AddListener(modal.modalButton1.action);
        btn1.onClick.AddListener(ClosePanel);
        btn1Label.text = modal.modalButton1.label;
        btn1.gameObject.SetActive(true);

        if (modal.modalButton2 != null)
        {
            btn2.onClick.AddListener(modal.modalButton2.action);
            btn2.onClick.AddListener(ClosePanel);
            btn2Label.text = modal.modalButton2.label;
            btn2.gameObject.SetActive(true);
        }

        if (modal.modalButton3 != null)
        {
            btn3.onClick.AddListener(modal.modalButton3.action);
            btn3.onClick.AddListener(ClosePanel);
            btn3Label.text = modal.modalButton3.label;
            btn3.gameObject.SetActive(true);
        }        
    }

    void CleanUp()
    {
        this.iconImg.gameObject.SetActive(false);
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);

        btn1.onClick.RemoveAllListeners();
        btn2.onClick.RemoveAllListeners();
        btn3.onClick.RemoveAllListeners();
    }

    public void ClosePanel()
    {
        modalPanelGO.SetActive(false);
    }
}
