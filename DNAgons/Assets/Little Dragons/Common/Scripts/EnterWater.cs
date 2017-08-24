using UnityEngine;
using System.Collections;

public class EnterWater : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DragonController>())
        {
            other.GetComponent<DragonController>().IsInWater = true;
        }
    }   
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DragonController>())
        {
            other.GetComponent<DragonController>().IsInWater = false;
        }
    }



}
