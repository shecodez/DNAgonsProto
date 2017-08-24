using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedDNAgon : MonoBehaviour {

    public DNAgon DNAgon;
    public GameObject DNAgonGO;
    Transform spawnPoint;

    public SpawnedItem item;

    bool spawned = false;

    void Start ()
    {
        spawnPoint = GameObject.Find("DNAgonSpawnPoint").transform;
    }

    void Update ()
    {
        // SpawnGO() @ SpawnGOTime
        if (System.DateTime.Now >= DNAgon.spawnGOTime && System.DateTime.Now < DNAgon.despawnTime)
        {
            if (!spawned) SpawnGO();
        }
      
        // Despawn() @ DespawnTime
        if (System.DateTime.Now >= DNAgon.despawnTime)
        {
            if (spawned) Despawn(this);
        }        
    }

    void SpawnGO ()
    {
        DNAgonGO = Instantiate(DNAgon.dModel, spawnPoint);
        
        DNAgonGO.transform.parent = GameObject.Find(DNAgon.dName).transform;     
        DNAgonGO.GetComponent<MalbersAnimations.AnimalAIControl>().target = item.spawnedItemGO.transform;
        DNAgonManager.Instance.AddInstantiatedDNAgon(DNAgonGO);

        Debug.Log(DNAgon.dType + " (" + DNAgon.dGenotype + ") type " + DNAgon.dGender + " DNAgon Generated");

        SaveManager.Instance.SetDNAgonVisited(DNAgon.dType_ID);
        SaveManager.Instance.SetDNAgonGenotypeLastVisited(DNAgon.dType_ID);
        SaveManager.Instance.SetDNAgonAsKnown(DNAgon.dType_ID);

        spawned = true;       
    }

    public void Respawn () { SpawnGO(); }

    public void Despawn (SpawnedDNAgon spawnedDNAgon)
    {        
        Debug.Log("Despawning " + spawnedDNAgon.DNAgon.dName);

        Gift _newGift = GiftManager.GenerateRandomGift(DNAgon, item.item);
        GiftManager.Instance.AddGiftToDB(_newGift);

        DNAgonManager.Instance.RemoveSpawnedDNAgon(spawnedDNAgon);
        DNAgonManager.Instance.RemoveInstantiatedDNAgon(DNAgonGO);
        //Destroy(DNAgonGO); TODO: Add particle effect 
        spawned = false;
    }
}
