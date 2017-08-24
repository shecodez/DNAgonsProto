using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class DNAgon {

    public int ID;

    public string dIconPath;
    [XmlIgnore] public Sprite dIcon
    {
        get
        {
            return Resources.Load<Sprite>(dIconPath) as Sprite;
        }
    }

    public string dName;
    public int dTrustLv;

    public int dItem_ID;

    public int dType_ID;
    public DNAgonType dType;
    public string dTypeIconPath;
    [XmlIgnore] public Sprite dTypeIcon
    {
        get
        {
            return Resources.Load<Sprite>(dTypeIconPath) as Sprite;
        }
    }
    public string dGenotype;

    public Gender dGender;

    public bool genotypeKnown;
    public bool genotypeVisited;
    public System.DateTime lastVisited;

    public System.DateTime spawnGOTime;
    public System.DateTime despawnTime;

    public string dModelPath;
    [XmlIgnore] public GameObject dModel
    {
        get
        {
            return Resources.Load<GameObject>(dModelPath) as GameObject;
        }
    }
    public Vector3 dPosition = Vector3.zero;
    
    public static Color GetDNAgonBaseColor (DNAgonType type)
    {
        Color _baseColor = Color.clear;

        switch (type)
        {
            case DNAgonType.Flame:
                _baseColor = Color.red;
                break;
            case DNAgonType.Water:
                _baseColor = Color.blue;
                break;
            case DNAgonType.Life:
                _baseColor = Color.green;
                break;
            case DNAgonType.Sky:
                _baseColor = Color.cyan;
                break;
            case DNAgonType.Rock:
                _baseColor = Color.grey;
                break;
            case DNAgonType.Twilight:
                _baseColor = Color.black;
                break;
            case DNAgonType.Solar:
                _baseColor = Color.yellow;
                break;
            case DNAgonType.Crystal:
                _baseColor = Color.white; //Iridescent
                break;
        }
        return _baseColor;
    }

    public static Color GetDNAgonBaseColor(DNAgonType p1Type, DNAgonType p2Type, float mixValue = .5f)
    {
        return  Color.Lerp(GetDNAgonBaseColor(p1Type), GetDNAgonBaseColor(p2Type), mixValue);
    }
}

public enum Gender
{
    Male,
    Female
};

public enum DNAgonType
{
    // base types
    Flame,
    Water,
    Life,
    Sky,
    Rock,
    Twilight,
    Solar,
    Crystal 
};

// TODO: Different Sprite/Model for each stage of life
public enum DNAgonAge
{
    Egg,
    Hatchling,
    Young,
    Adult,
    Elder,
    Ancient
};

