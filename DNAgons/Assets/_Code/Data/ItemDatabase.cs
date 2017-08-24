using System.Collections.Generic;
using System.Xml.Serialization;

[System.Serializable]
public class ItemDatabase
{
    [XmlArray("ItemData")]
    public List<Item> list = new List<Item>();
}

/*public class ItemDatabase : MonoBehaviour {

    [XmlArray("ItemData")]
    public List<Item> list = new List<Item>();

    public static ItemDatabase Instance { get; set; }

    public TextAsset itemXMLDatabaseFile;
    public static List<Item> itemList = new List<Item>();

    List<Dictionary<string, string>> itemDictionaryList = new List<Dictionary<string, string>>();
    Dictionary<string, string> iDictionary;

    void Awake ()
    {
        Instance = this;

        ParseItemDatabase();
        for (int i = 0; i < itemDictionaryList.Count; i++)
        {            
            itemList.Add(new Item(itemDictionaryList[i]));
        }
    }

    public void ParseItemDatabase()
    {
        XmlDocument _xmlDoc = new XmlDocument();
        if (itemXMLDatabaseFile == null)
        {
            Debug.Log("Item XML file not found!");
            return;
        }
        
        _xmlDoc.LoadXml(itemXMLDatabaseFile.text);
        XmlNodeList _items = _xmlDoc.GetElementsByTagName("Item");

        foreach(XmlNode item in _items)
        {
            XmlNodeList _item = item.ChildNodes;
            iDictionary = new Dictionary<string, string>();

            foreach(XmlNode value in _item)
            {
                iDictionary.Add(value.Name.ToString(), value.InnerText);
            }
            itemDictionaryList.Add(iDictionary);
        }
    }
}*/
