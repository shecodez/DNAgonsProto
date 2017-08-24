using System.Collections.Generic;
using System.Xml.Serialization;

[System.Serializable]
public class GenotypeDatabaseTemp
{
    //[XmlArray("DNAgonGenotypeData")]
    //public List<DNAgon> list = new List<DNAgon>();
}

/*public class GenotypeDatabase : MonoBehaviour
{
    public static GenotypeDatabase Instance { get; set; }

    public TextAsset genotypesXMLDatabaseFile;
    public static List<DNAgon> dnagonGenotypesList = new List<DNAgon>();

    List<Dictionary<string, string>> dnagonDictionaryList = new List<Dictionary<string, string>>();
    Dictionary<string, string> dDictionary;

    void Awake ()
    {
        Instance = this;

        ParseDNAgonDatabase();
        for (int i = 0; i < dnagonDictionaryList.Count; i++)
        {
            dnagonGenotypesList.Add(new DNAgon(dnagonDictionaryList[i]));
        }
    }

    private void ParseDNAgonDatabase()
    {
        XmlDocument _xmlDoc = new XmlDocument();
        if (genotypesXMLDatabaseFile == null)
        {
            Debug.Log("Item XML file not found!");
            return;
        }

        _xmlDoc.LoadXml(genotypesXMLDatabaseFile.text);
        XmlNodeList _dnagons = _xmlDoc.GetElementsByTagName("DNAgon");

        foreach (XmlNode dnagon in _dnagons)
        {
            XmlNodeList _dnagon = dnagon.ChildNodes;
            dDictionary = new Dictionary<string, string>();

            foreach (XmlNode value in _dnagon)
            {
                dDictionary.Add(value.Name.ToString(), value.InnerText);
            }
            dnagonDictionaryList.Add(dDictionary);
        }
    }
}*/

