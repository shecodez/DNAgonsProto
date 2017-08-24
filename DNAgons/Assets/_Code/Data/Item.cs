using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int ID;

    public string iIconPath;
    [XmlIgnore] public Sprite iIcon
    {
        get
        {           
            return Resources.Load<Sprite>(iIconPath) as Sprite;
            //return Resources.LoadAll<Sprite>("Sprites/foodItems")[int.Parse(iIconPath)] as Sprite;
        }
    }

    public string iName;
    public string iDesc;

    public ItemCategory iCategory;
    public CurrencyType iCurrency;
    public int iCost = 1;

    public int iQuantity = 0;
    public bool iStackable = false;
    
    public bool iBought = false;
    public bool iPlaced = false;
    public string iDespawnTime;

    public string iModelPath;
    [XmlIgnore] public GameObject iModel
    {
        get
        {
            return Resources.Load<GameObject>(iModelPath) as GameObject;
        }
    }
    public Vector3 iPosition = Vector3.zero;
}

public enum ItemCategory
{
    All,
    Toy,
    Food,
    Bed,
    Prop,
    Exchange
};
