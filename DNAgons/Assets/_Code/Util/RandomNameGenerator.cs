
using System.Globalization;
using System.Text;
using UnityEngine;

public class RandomNameGenerator : MonoBehaviour
{
    public static RandomNameGenerator Instance { get; set; }

    void Awake ()
    {
        Instance = this;
    }

    public string GenerateRandomName ()
    {       
        StringBuilder _name = new StringBuilder();
        int _nameLength = Random.Range(7, 9);

        char[] _chars = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();

        for (int i = 0; i < _nameLength; i++)
        {
            int _rng = Random.Range(0, _chars.Length);
            char letter = _chars[_rng];
            if (i == 0)
                _name.Append(char.ToUpper(letter));
            else
                _name.Append(letter);
        }
        return _name.ToString();
    }
}

