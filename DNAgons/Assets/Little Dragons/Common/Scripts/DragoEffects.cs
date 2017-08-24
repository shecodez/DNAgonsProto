using UnityEngine;
using System.Collections;


public class DragoEffects : MonoBehaviour
{

    [Header("This Script is for Playing Animation Clips Events Effects")]

    public Effects[] effect;

    IEnumerator DestroyEffect(GameObject effect, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(effect);
    }

    public void PlayEffect(string name)
    {
        int ID = 0;
        for (int i = 0; i < effect.Length; i++)
        {
            if (effect[i].Name == name)
            {
                ID = i;
                break;
            }

        }
   
            GameObject current_effect = Instantiate(effect[ID].Effect);
            current_effect.transform.position = effect[ID].AttachTo.position;

            if (effect[ID].isChild)
            {
                current_effect.transform.parent = effect[ID].AttachTo;
                current_effect.transform.rotation = effect[ID].AttachTo.rotation;
            }
            if (effect[ID].Direction != Vector3.zero)
            {
                current_effect.transform.rotation = Quaternion.LookRotation(effect[ID].Direction) * transform.rotation;
            }

            StartCoroutine(DestroyEffect(current_effect, effect[ID].LifeTime));
    }



}
