using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Button button;
    public Image rBtnIcon;
    public string rBtnName;
    public RadialMenu rMenu;

    Color defaultColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        rMenu.selected = this;
        defaultColor = button.GetComponent<Image>().color;
        button.GetComponent<Image>().color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rMenu.selected = null;
        button.GetComponent<Image>().color = defaultColor;
    }
}
