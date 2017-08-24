using UnityEngine;

public class GiftMenu : MonoBehaviour
{
    public GameObject giftButtonPrefab;
    public Transform contentPanel;

    void Start ()
    {
        AddButtons();
    }

    void AddButtons ()
    {
        for (int i = 0; i < XMLManager.Ins.giftDB.list.Count; i++)
        {
            Gift _gift = XMLManager.Ins.giftDB.list[i];
            GameObject _newButton = Instantiate(giftButtonPrefab);
            _newButton.transform.SetParent(contentPanel);

            GiftPanelButton _gButton = _newButton.GetComponent<GiftPanelButton>();
            _gButton.SetupGift(_gift);
        }
    }

    //void AcceptGift(Gift gift) { }

    public void AcceptAllGifts()
    {
        if (XMLManager.Ins.giftDB.list.Count == 0) return;

        SaveManager.Instance.AcceptAllGifts();
        MenuUI.Instance.UpdateCurrencyText();

        foreach (Transform child in contentPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}

