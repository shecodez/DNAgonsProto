using System;
using UnityEngine;
using UnityEngine.UI;


public class GiftPanelButton : MonoBehaviour
{  
    public Image gGiverIcon;
    public Text gGiverName;
    public Image gGiverType;

    public Image gItemIcon;

    public Image gCurrencyIcon;
    public Text gAmount;

    public Button acceptButton;

    Gift gift;

    void Start()
    {
        acceptButton.onClick.AddListener(HandleClick);
    }

    public void SetupGift (Gift _gift)
    {
        gift = _gift;

        gGiverIcon.sprite = gift.gGiverIcon;
        gGiverName.text = gift.gGiverName;
        gGiverType.sprite = gift.gGiverType;
        gGiverType.color = DNAgon.GetDNAgonBaseColor(gift.gDNAgonType);

        gItemIcon.sprite = gift.gItemIcon;

        if (gift.gCurrencyType == CurrencyType.IntactScale)
            gCurrencyIcon.sprite = Resources.Load<Sprite>("Sprites/Items/ScaleIntact") as Sprite;
        else
            gCurrencyIcon.sprite = Resources.Load<Sprite>("Sprites/Items/ScaleBroken") as Sprite;
        gAmount.text = gift.gAmount.ToString();
    }

    private void HandleClick()
    {
        SaveManager.Instance.AcceptGift(gift);
        MenuUI.Instance.UpdateCurrencyText();
        SaveManager.Instance.RemoveGiftFromDB(gift);
        Destroy(this.gameObject);
    }
}

