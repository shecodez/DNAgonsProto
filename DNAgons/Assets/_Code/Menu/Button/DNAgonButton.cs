using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DNAgonButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    public Button button;
    
    public int buttonIndex;
    public Outline buttonOutline;

    public Sprite openedScrollBG;
    public Sprite closedScrollBG;

    public Image dBtnImg;
    public Text dBtnName;
    public Text dBtnDate;
        
    DNAgon dnagon;
    GenotypesMenu menu;

    bool focused = false;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(HandleClick);
	}

    public void SetupMenu(GenotypesMenu _dnagonGenotypesMenu)
    {
        menu = _dnagonGenotypesMenu;
    }

    public void SetupDNAgon(DNAgon _dnagon)
    {
        dnagon = _dnagon;

        buttonIndex = dnagon.ID;
        dBtnImg.sprite = dnagon.dIcon;

        Color _temp = dBtnImg.color;
        if (SaveManager.Instance.GetDNAgonVisited(dnagon.ID))
        {
            _temp.a = 1;
            dBtnDate.text = "01 · 10 · 17"; // <-- change to date visited
            button.image.sprite = openedScrollBG;
            dBtnName.text = dnagon.dType.ToString();
            if (SaveManager.Instance.GetDNAgonKnown(dnagon.ID))
            {
                _temp = DNAgon.GetDNAgonBaseColor(dnagon.dType);
                dBtnName.text = dnagon.dGenotype;
            }
            else
                _temp = Color.black;
        }
        else
        {
            _temp.a = 0;
            button.image.sprite = closedScrollBG;
            dBtnDate.text = "";
            dBtnName.text = "???";
        }
        dBtnImg.color = _temp;
    }

    private void HandleClick()
    {
        // Display DNAgon profile menu
        if (menu != null)
        {
            if (menu.SelectedButton == this && focused)
            {
                menu.DNAgonGeneticProfile();
            }
        }
        focused = true;
    }  

    public void OnSelect(BaseEventData eventData)
    {
        buttonOutline.enabled = true;
        if (menu != null)
            menu.SelectedButton = this;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        buttonOutline.enabled = false;
        focused = false;
    }    
}
