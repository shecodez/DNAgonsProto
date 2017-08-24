using UnityEngine;

public class GiftManager : MonoBehaviour
{
    public static GiftManager Instance { get; set; }
    void Awake()
    {
        Instance = this;
    }

    public static Gift GenerateRandomGift(DNAgon DNAgon, Item item)
    {
        Gift _gift = new Gift();

        _gift.gGiverIconPath = Random.Range(0, 8).ToString(); //DNAgon.dIconPath;
        _gift.gGiverName = DNAgon.dName;
        _gift.gGiverTypePath = "Sprites/DNA"; //DNAgon.dTypeIconPath;
        _gift.gDNAgonType = DNAgon.dType;

        _gift.gItemIconPath = item.iIconPath;

        _gift.gCurrencyType = (CurrencyType)Random.Range(0, 2);
        if (_gift.gCurrencyType == CurrencyType.IntactScale)
            _gift.gAmount = Random.Range(1, 10);
        else
            _gift.gAmount = Random.Range(3, 27);

        return _gift;
    }

    public void AddGiftToDB (Gift gift)
    {
        SaveManager.Instance.AddGiftToDB(gift);
    }
}

