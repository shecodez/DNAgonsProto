using System.Collections.Generic;
using System.Xml.Serialization;

//public class Database { }
public class DNAgonDatabase { }

[System.Serializable]
public class GenotypeDatabase
{
    [XmlArray("DNAgonGenotypeData")]
    public List<DNAgon> list = new List<DNAgon>();
}

[System.Serializable]
public class CapturedDatabase
{
    [XmlArray("CapturedDNAgonData")]
    public List<DNAgon> list = new List<DNAgon>();
}

[System.Serializable]
public class SpawnedDatabase
{
    [XmlArray("SpawnedDNAgonData")]
    public List<DNAgon> list = new List<DNAgon>();
}

