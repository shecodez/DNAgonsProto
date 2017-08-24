using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class Gift
{
    public int ID;

    public string gGiverIconPath;
    [XmlIgnore]
    public Sprite gGiverIcon
    {
        get
        {
            //return Resources.Load<Sprite>(gGiverIconPath) as Sprite;
            return Resources.LoadAll<Sprite>("Sprites/DNAgons/placeHolderDNAgonIcons")[int.Parse(gGiverIconPath)] as Sprite;
        }
    }
    public string gGiverName;
    public string gGiverTypePath;
    public Sprite gGiverType
    {
        get
        {
            return Resources.Load<Sprite>(gGiverTypePath) as Sprite;
        }
    }
    public DNAgonType gDNAgonType;

    public string gItemIconPath;
    public Sprite gItemIcon
    {
        get
        {
            return Resources.Load<Sprite>(gItemIconPath) as Sprite;
        }
    }

    public CurrencyType gCurrencyType;
    public int gAmount;
}
