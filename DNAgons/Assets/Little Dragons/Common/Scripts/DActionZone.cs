using UnityEngine;
using System.Collections;

public class DActionZone : MonoBehaviour
{
    public DragonController.ActionsEmotions actionEmotions;

    void OnTriggerEnter(Collider other)
    {
        DragonController mydrago = other.GetComponent<DragonController>();

        if (mydrago)    mydrago.ActionID = (int)actionEmotions;
    }

    void OnTriggerExit(Collider other)
    {
        DragonController mydrago = other.GetComponent<DragonController>();

        if (mydrago)    mydrago.ActionID = -1;
    }
}
