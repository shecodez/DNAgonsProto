using System.Collections.Generic;
using System.Xml.Serialization;

[System.Serializable]
public class GiftDatabase
{
    [XmlArray("GiftData")]
    public List<Gift> list = new List<Gift>();
}
