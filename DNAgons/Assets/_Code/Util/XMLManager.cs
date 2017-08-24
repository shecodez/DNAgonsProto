using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public class XMLManager : MonoBehaviour {

    // simple singleton pat
    public static XMLManager Ins;

    void Awake () { Ins = this; }

    // Variables
    public ItemDatabase itemDB;
    public GenotypeDatabase genotypeDB;
    public SpawnedDatabase spawnedDB;
    //public CapturedDatabase capturedDB;
    public GiftDatabase giftDB;

    Encoding encoding = Encoding.GetEncoding("UTF-8");
    
    // Functions
    void Start ()
    {
        /*Load(itemDB, "/StreamingAssets/XML/items.xml");
        Load(genotypeDB, "/StreamingAssets/XML/DNAgon/genotypes.xml");
        Load(spawnedDB, "/StreamingAssets/XML/DNAgon/spawned.xml");
        Load(giftDB, "/StreamingAssets/XML/gifts.xml");*/

        LoadItems(); 
        LoadDNAgonGenotypes();
        LoadSpawnedDNAgons();
        //LoadCapturedDNAgons();
        LoadGifts();
    }

    /// <summary>
    /// Save XML file to StreamingAssets
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="database"></param>
    /// <param name="toPath"></param>
    public void Save<T> (T database, string toPath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        Stream stream = new FileStream(Application.dataPath + toPath, FileMode.Create, FileAccess.Write);
        serializer.Serialize(stream, database);

        stream.Close();  
    }

    /// <summary>
    /// Load XML file from StreamingAssets
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="database"></param>
    /// <param name="fromPath"></param>
    public void Load<T>(T database, string fromPath) where T : class
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        Stream stream = new MemoryStream((Resources.Load(fromPath, typeof(TextAsset)) as TextAsset).bytes);
        StreamReader reader = new StreamReader(stream);

        database = serializer.Deserialize(reader) as T;

        stream.Dispose();
        //stream.Close();
        
        /*if (File.Exists(Application.dataPath + fromPath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream stream = new FileStream(Application.dataPath + fromPath, FileMode.Open);

            database = serializer.Deserialize(stream) as T;

            stream.Close();
        }
        else
        {
            Debug.LogError("Error! File @ " + fromPath + " NOT found.");
        }*/
    }

    public void SaveItems()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        Stream stream = new FileStream(Application.dataPath + "/Resources/XML/items.xml", FileMode.Create, FileAccess.Write);
        serializer.Serialize(stream, itemDB);

        stream.Close();
    }

    public void LoadItems()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        Stream stream = new MemoryStream((Resources.Load("XML/items", typeof(TextAsset)) as TextAsset).bytes);
        StreamReader reader = new StreamReader(stream);

        itemDB = serializer.Deserialize(reader) as ItemDatabase;

        stream.Dispose();
        //stream.Close();    
    }

    public void SaveDNAgonGenotypes()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GenotypeDatabase));
        Stream stream = new FileStream(Application.dataPath + "/Resources/XML/DNAgon/genotypes.xml", FileMode.Create, FileAccess.Write);
        serializer.Serialize(stream, genotypeDB);

        stream.Close();
    }

    public void LoadDNAgonGenotypes()
    {
        
        XmlSerializer serializer = new XmlSerializer(typeof(GenotypeDatabase));
        Stream stream = new MemoryStream((Resources.Load("XML/DNAgon/genotypes", typeof(TextAsset)) as TextAsset).bytes);
        StreamReader reader = new StreamReader(stream);

        genotypeDB = serializer.Deserialize(reader) as GenotypeDatabase;

        stream.Dispose();
        //stream.Close();    
    }

    //public void SaveCapturedDNAgons() { }
    //public void LoadCapturedDNAgons() { }

    public void SaveSpawnedDNAgons()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SpawnedDatabase));
        Stream stream = new FileStream(Application.dataPath + "/Resources/XML/DNAgon/spawned.xml", FileMode.Create, FileAccess.Write);
        serializer.Serialize(stream, spawnedDB);

        stream.Close();
    }

    public void LoadSpawnedDNAgons()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SpawnedDatabase));
        Stream stream = new MemoryStream((Resources.Load("XML/DNAgon/spawned", typeof(TextAsset)) as TextAsset).bytes);
        StreamReader reader = new StreamReader(stream);

        spawnedDB = serializer.Deserialize(reader) as SpawnedDatabase;

        stream.Dispose();
        //stream.Close();   
    }

    public void SaveGifts()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GiftDatabase));
        Stream stream = new FileStream(Application.dataPath + "/Resources/XML/gifts.xml", FileMode.Create, FileAccess.Write);
        serializer.Serialize(stream, giftDB);

        stream.Close();
    }

    public void LoadGifts()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GiftDatabase));
        Stream stream = new MemoryStream((Resources.Load("XML/gifts", typeof(TextAsset)) as TextAsset).bytes);
        StreamReader reader = new StreamReader(stream);

        giftDB = serializer.Deserialize(stream) as GiftDatabase;

        stream.Close();
    }

    // **Note** that iOS applications are usually suspended and do not quit. 
    // Tick "Exit on Suspend" in Player settings for iOS builds to cause the game to quit and not suspend, otherwise you may not see this call. 
    // If "Exit on Suspend" is not ticked then you will see calls to OnApplicationPause instead.

    void OnApplicationQuit()
    {
        /*Save(itemDB, "/StreamingAssets/XML/items.xml");
        Save(genotypeDB, "/StreamingAssets/XML/DNAgon/genotypes.xml");
        Save(spawnedDB, "/StreamingAssets/XML/DNAgon/spawned.xml");
        Save(giftDB, "/StreamingAssets/XML/gifts.xml");*/

        //SaveItems();
        //SaveDNAgonGenotypes();
        //SaveSpawnedDNAgons();
        //SaveCapturedDNAgons();
        //SaveGifts();
    }
}
