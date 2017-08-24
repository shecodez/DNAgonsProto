using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarEntity
{
    Image icon;
    GameObject self;

    public Image Icon { get; set; }
    public GameObject Self { get; set; }
}

public class RadarController : MonoBehaviour
{

    public Transform player;
    float radarScale = 2f;
    public float radarRadius = 67.0f;

    public static List<RadarEntity> radarBlips = new List<RadarEntity>();

    public static void AddRadarEntity(GameObject go, Image icon)
    {
        Image image = Instantiate(icon);
        radarBlips.Add(new RadarEntity() { Self = go, Icon = image });
    }

    public static void RemoveRadarEntity(GameObject go)
    {
        List<RadarEntity> newList = new List<RadarEntity>();
        for (int i = 0; i < radarBlips.Count; i++)
        {
            if (radarBlips[i].Self == go)
            {
                Destroy(radarBlips[i].Icon);
                continue;
            }
            else
                newList.Add(radarBlips[i]);
        }
        radarBlips.RemoveRange(0, radarBlips.Count); //.Clear();
        radarBlips.AddRange(newList);
    }

    void DrawRadarBlips()
    {
        foreach (var blip in radarBlips)
        {
            Vector3 blipPosition = (blip.Self.transform.position - player.position);
            float distance = Vector3.Distance(player.position, blip.Self.transform.position) * radarScale;
            float deltaY = Mathf.Atan2(blipPosition.x, blipPosition.z) * Mathf.Rad2Deg - 270 - player.eulerAngles.y;
            // Position on a Circle
            blipPosition.x = distance * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
            blipPosition.z = distance * Mathf.Sin(deltaY * Mathf.Deg2Rad);

            blip.Icon.transform.SetParent(this.transform);
            blip.Icon.transform.position = new Vector3(blipPosition.x, blipPosition.z, 0) + this.transform.position;

            if (distance > radarRadius)
            {
                // Clamp blip to the border
                float k = radarRadius / distance;
                blip.Icon.transform.position = new Vector3(blipPosition.x *= k, blipPosition.z *= k, 0)
                    + this.transform.position;
            }
        }
    }

    void Update()
    {
        DrawRadarBlips();
    }
}

public enum Category
{
    
    Item,
    POI,
    DNAgon
};
