using UnityEngine;
using UnityEngine.UI;

public class RadarBlip : MonoBehaviour
{
    public Image Icon;

    void Start()
    {
        RadarController.AddRadarEntity(this.gameObject, Icon);
    }

    void OnDestroy()
    {
        RadarController.RemoveRadarEntity(this.gameObject);
    }
}
