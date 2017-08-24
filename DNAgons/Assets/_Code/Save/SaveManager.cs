using System;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static SaveManager Instance { get; set; }

    public SaveData data;

    //private ModalWindow modalWindow;
    void Awake ()
    {
        //ResetSave();
        Instance = this;
        //modalWindow = ModalWindow.Instance();
        DontDestroyOnLoad(gameObject);
        Load();
        //Debug.Log(Helper.Serialize<SaveData>(data));
    }

    /// <summary>
    /// Save the SaveState script to PlayerPrefs
    /// </summary>
    public void Save()
    {
        // Serialize SaveData
        PlayerPrefs.SetString("save", Helper.Serialize<SaveData>(data));
    }

    /// <summary>
    /// Load the SaveState script from PlayerPrefs
    /// </summary>
    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            // Deserialize SaveData
            data = Helper.Deserialize<SaveData>(PlayerPrefs.GetString("save"));
        }
        else
        {
            //DisplayNoSaveDataFoundModal();
            data = new SaveData();

            // Give this after tutorial is finished
            data.brokenScales = 325;
            data.intactScales = 10;

            Save();
            Debug.Log("No save file found, creating a new one.");
        }
    }

    void CreateNewSaveFile()
    {
        data = new SaveData();
        Save();
    }

    /*private void DisplayNoSaveDataFoundModal()
    {
        Modal _noSaveDataFoundModal = new Modal();
        _noSaveDataFoundModal.mType = ModalType.Info;
        _noSaveDataFoundModal.question = "No save file found. \nWould you like to create a new one?";

        _noSaveDataFoundModal.modalButton1 = new ModalButton();
        _noSaveDataFoundModal.modalButton1.label = "Yes";
        _noSaveDataFoundModal.modalButton1.action = CreateNewSaveFile;

        _noSaveDataFoundModal.modalButton2 = new ModalButton();
        _noSaveDataFoundModal.modalButton2.label = "No";
        _noSaveDataFoundModal.modalButton2.action = Application.Quit; 

        modalWindow.DisplayModalWindow(_noSaveDataFoundModal);
    }*/

    public bool GetItemBought(int id)
    {
        return FindByID(id).iBought;
    }

    public bool GetItemPlaced(int id)
    {
        return FindByID(id).iPlaced; 
    }

    // Purchase Item
    public bool PurchaseItem (Item item)
    {
        bool _bought = false;
        switch (item.iCurrency)
        {
            case CurrencyType.BrokenScale:
                if (data.brokenScales >= item.iCost)
                {
                    data.brokenScales -= item.iCost;
                    if (item.iCategory == ItemCategory.Exchange)                   
                        data.intactScales += 12;
                    else
                        SetItemBought(item.ID);
                    Save();
                    MenuUI.Instance.UpdateCurrencyText();
                    return true;
                }
                break;
            case CurrencyType.IntactScale:
                if (data.intactScales >= item.iCost)
                {
                    data.intactScales -= item.iCost;
                    if (item.iCategory == ItemCategory.Exchange)
                        data.brokenScales += 525;
                    else
                        SetItemBought(item.ID);
                    Save();
                    MenuUI.Instance.UpdateCurrencyText();
                    return true;
                }
                break;
        }
        return _bought;
    }

    public void AcceptGift (Gift gift)
    {
        if (gift.gCurrencyType == CurrencyType.IntactScale)
            data.intactScales += gift.gAmount;
        else
            data.brokenScales += gift.gAmount;

        Save();
    }

    public void AcceptAllGifts()
    {
        for (int i = 0; i < XMLManager.Ins.giftDB.list.Count; i++)
        {
            switch (XMLManager.Ins.giftDB.list[i].gCurrencyType)
            {
                case CurrencyType.BrokenScale:
                    data.brokenScales += XMLManager.Ins.giftDB.list[i].gAmount;
                    break;
                case CurrencyType.IntactScale:
                    data.intactScales += XMLManager.Ins.giftDB.list[i].gAmount;
                    break;
            }
            Save();
        }
        XMLManager.Ins.giftDB.list.Clear();
        XMLManager.Ins.SaveGifts();
    }

    public void AddGiftToDB(Gift gift)
    {
        XMLManager.Ins.giftDB.list.Add(gift);
    }

    public void RemoveGiftFromDB(Gift gift)
    {
        XMLManager.Ins.giftDB.list.RemoveAll(g => g == gift);
        XMLManager.Ins.SaveGifts();
    }

    public void SetItemBought(int id)
    {
        XMLManager.Ins.itemDB.list[id].iBought = true;
        XMLManager.Ins.SaveItems();
    }

    public void SetItemPlaced(int id, bool place)
    {
        XMLManager.Ins.itemDB.list[id].iPlaced = place;
        XMLManager.Ins.SaveItems();

        /*if (place)
            data.totalItemsPlaced++;

        else if (!place)
            data.totalItemsPlaced--;*/

        data.totalItemsPlaced = Mathf.Clamp(GetTotalItemsPlaced(), 0, data.itemsPlacedMaxCapacity);
        Save();     
    }

    public void MarkItemCarried(int id, bool place)
    {
        XMLManager.Ins.itemDB.list[id].iPlaced = place;

        data.totalItemsPlaced = Mathf.Clamp(GetTotalItemsPlaced(), 0, data.itemsPlacedMaxCapacity);
    }

    public int GetTotalItemsPlaced ()
    {
        int _placed = 0;
        for (int i = 0; i < XMLManager.Ins.itemDB.list.Count; i++)
        {
            if (XMLManager.Ins.itemDB.list[i].iPlaced)
                _placed++;
        }
        return _placed;
    }

    public Item FindByID(int ID)
    {
        for (int i = 0; i < XMLManager.Ins.itemDB.list.Count; i++)
        {
            if (XMLManager.Ins.itemDB.list[i].ID == ID)
                return XMLManager.Ins.itemDB.list[i];
        }
        return null;
    }

    public DNAgon FindDNAgonByID(int ID)
    {
        for (int i = 0; i < XMLManager.Ins.genotypeDB.list.Count; i++)
        {
            if (XMLManager.Ins.genotypeDB.list[i].ID == ID)
                return XMLManager.Ins.genotypeDB.list[i];
        }
        return null;
    }

    public void SetItemDespawnTime (int id, string despawnTime)
    {
        XMLManager.Ins.itemDB.list[id].iDespawnTime = despawnTime;
        XMLManager.Ins.SaveItems();
    }

    public string GetItemDespawnTime (int id)
    {
        return FindByID(id).iDespawnTime;
    }

    public bool GetDNAgonKnown(int id)
    {
        return FindDNAgonByID(id).genotypeKnown;
    }

    public bool GetDNAgonVisited(int id)
    {
        //return XMLManager.Ins.genotypeDB.list[id].visited;
        return FindDNAgonByID(id).genotypeVisited;
    }

    public void SetDNAgonAsKnown (int id)
    {
        //XMLManager.Ins.genotypeDB.list[id].known = true;
        FindDNAgonByID(id).genotypeKnown = true;
        XMLManager.Ins.SaveDNAgonGenotypes();
    }

    public void SetDNAgonVisited(int id)
    {
        FindDNAgonByID(id).genotypeVisited = true;
        XMLManager.Ins.SaveDNAgonGenotypes();
    }

    public void SetDNAgonGenotypeLastVisited (int id)
    {
        FindDNAgonByID(id).lastVisited = DateTime.Now;
        XMLManager.Ins.SaveDNAgonGenotypes();
    }

    public void AddDNAgonToSpawnedDB(DNAgon DNAgon)
    {
        int _index = -1;
        for (int i = 0; i < XMLManager.Ins.spawnedDB.list.Count; i++)
        {
            if (XMLManager.Ins.spawnedDB.list[i].ID == DNAgon.ID)
            {
                _index = i;
                break;
            }
        }
        if (_index >= 0)
            XMLManager.Ins.spawnedDB.list[_index] = DNAgon;
        else
            XMLManager.Ins.spawnedDB.list.Add(DNAgon);

        XMLManager.Ins.SaveSpawnedDNAgons();
    }

    public void RemoveDNAgonFromSpawnedDB(DNAgon DNAgon)
    {
        XMLManager.Ins.spawnedDB.list.RemoveAll(spawnedDNAgon => spawnedDNAgon == DNAgon);
        XMLManager.Ins.SaveSpawnedDNAgons();
    }

    public void SetTimeOnExit()
    {
        data.TimeOnExit = DateTime.Now;
        Save();
    }

    /// <summary>
    /// Reset saved data
    /// </summary>
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }
}

public enum CurrencyType
{
    BrokenScale,
    IntactScale
};
