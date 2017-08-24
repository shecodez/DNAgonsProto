using System.IO;
using System.Xml.Serialization;

public static class Helper
{
    /// <summary>
    /// Serialize data passed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns>Serialized string</returns>
    public static string Serialize<T> (this T data)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringWriter sw = new StringWriter();
        xml.Serialize(sw, data);
        return sw.ToString();
    }

    /// <summary>
    /// DeSerialize data passed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns>Deserialized generic</returns>
    public static T Deserialize<T>(this string data)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringReader sr = new StringReader(data);
        return (T)xml.Deserialize(sr);
    }
}
