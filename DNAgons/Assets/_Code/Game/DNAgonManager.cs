using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAgonManager : MonoBehaviour {

    public List<SpawnedDNAgon> spawnedDNAgons;
    public List<GameObject> spawnedDNAgonGOs; // this list might replace the above as static?

    public static DNAgonManager Instance { get; set; }
	void Awake ()
    {
        Instance = this;
    }

    void Start ()
    {
        //GetSpawnedDNAgonsFromDB();
    }

    void GetSpawnedDNAgonsFromDB()
    {
        List<DNAgon> _dnagonsToRemove = new List<DNAgon>();
        for (int i = 0; i < XMLManager.Ins.spawnedDB.list.Count; i++)
        {
            DNAgon _curDNAgon = XMLManager.Ins.spawnedDB.list[i];
            if (SaveManager.Instance.data.TimeOnExit < _curDNAgon.spawnGOTime &&
                System.DateTime.Now > _curDNAgon.despawnTime)
            {
                SaveManager.Instance.SetDNAgonVisited(_curDNAgon.ID);
                SaveManager.Instance.SetDNAgonGenotypeLastVisited(_curDNAgon.ID);
                // Remove
                _dnagonsToRemove.Add(_curDNAgon);
            }
            else
            {
                // Respawn
                RespawnDNAgonFromDB(_curDNAgon);
            }
        }

        if (_dnagonsToRemove.Count > 0)
            RemoveSpawnedDNAgons(_dnagonsToRemove);
    }

    private void RespawnDNAgonFromDB(DNAgon DNAgon)
    {
        SpawnedDNAgon _spawnedDNAgon = new GameObject().AddComponent<SpawnedDNAgon>();
        _spawnedDNAgon.DNAgon = DNAgon;
        _spawnedDNAgon.name = DNAgon.dName;
        //_spawnedDNAgon.item = SaveManager.Instance.FindByID(DNAgon.item_ID);

        AddSpawnedDNAgon(_spawnedDNAgon);
    }

    private DNAgon GenerateRandomDNAgonViaItem (Item item)
    {
        DNAgon _DNAgon = new DNAgon();
        _DNAgon.ID = item.ID; // TODO: Generate unique ID for captured list?

        
        DNAgon _genotype = XMLManager.Ins.genotypeDB.list
            [Random.Range(0, 3)];//XMLManager.Ins.genotypeDB.list.Count)];
        _DNAgon.dType_ID = _genotype.ID;
        _DNAgon.dType = _genotype.dType;
        _DNAgon.dGenotype = _genotype.dGenotype;

        _DNAgon.dName = RandomNameGenerator.Instance.GenerateRandomName();
        _DNAgon.dTrustLv = Random.Range(0, 100);
        _DNAgon.dGender = (Gender)Random.Range(0, 2);

        _DNAgon.dItem_ID = item.ID;

        _DNAgon.spawnGOTime = System.DateTime.Now.AddSeconds(Random.Range(05, 10)); //change to mins
        _DNAgon.despawnTime = _DNAgon.spawnGOTime.AddSeconds(Random.Range(45, 55));

        // TODO: Procedurally Generate DNAgon icon and 3D model from Genotype information
        //_DNAgon.dTypeIconPath = _genotype.dTypeIconPath;
        _DNAgon.dModelPath = _genotype.dModelPath;
        
        return _DNAgon;
    }

    public void SpawnGeneratedDNAgonViaItem (SpawnedItem spawnedItem)
    {
        SpawnedDNAgon _spawnedDNAgon = new GameObject().AddComponent<SpawnedDNAgon>();
        _spawnedDNAgon.DNAgon = GenerateRandomDNAgonViaItem(spawnedItem.item);
        _spawnedDNAgon.name = _spawnedDNAgon.DNAgon.dName;
        _spawnedDNAgon.item = spawnedItem;

        AddSpawnedDNAgon(_spawnedDNAgon);
    }

    public void AddInstantiatedDNAgon (GameObject spawn)
    {
        spawnedDNAgonGOs.Add(spawn);
        //SaveManager.Instance.AddDNAgonToSpawnedDB(spawn.GetComponent<SpawnedDNAgon>().DNAgon);
    }

    public void RemoveInstantiatedDNAgon (GameObject spawn)
    {
        spawnedDNAgonGOs.RemoveAll(GO => GO == spawn);
        //SaveManager.Instance.RemoveDNAgonToSpawnedDB(spawn.GetComponent<SpawnedDNAgon>().DNAgon);
    }

    internal void AddSpawnedDNAgon(SpawnedDNAgon spawnedDNAgon)
    {
        spawnedDNAgons.Add(spawnedDNAgon);
        SaveManager.Instance.AddDNAgonToSpawnedDB(spawnedDNAgon.DNAgon);
    }

    internal void RemoveSpawnedDNAgon(SpawnedDNAgon spawnedDNAgon)
    {
        spawnedDNAgons.RemoveAll(_spawnedDNAgon => _spawnedDNAgon == spawnedDNAgon);
        SaveManager.Instance.RemoveDNAgonFromSpawnedDB(spawnedDNAgon.DNAgon);
    }

    void RemoveSpawnedDNAgons(List<DNAgon> _dnagonsToRemove)
    {
        for (int i = 0; i < _dnagonsToRemove.Count; i++)
        {
            SaveManager.Instance.RemoveDNAgonFromSpawnedDB(_dnagonsToRemove[i]);
        }
    }

    /*public DNAgon GenerateDNAgonFromParents (DNAgon p1DNAgon, DNAgon p2DNAgon)
    {
        FamilyTree tree = FamilyTree.Instance;

        DNAgon _offspring = new DNAgon();
        _offspring.parent1 = p1DNAgon;
        _offspring.parent2 = p2DNAgon;
        bool _inbreed = tree.CheckForInbreeding(p1DNAgon, p2DNAgon);
        // make siblings a set so only adds unique
        _offspring.siblings = p1DNAgon.Childern + p2DNAgon.Childern;

        if (_inbreed) { AddRandomDefects(); }
        
        p1DNAgon.AddChild(_offspring);
        p2DNAgon.AddChild(_offspring);
        return _offspring;
    }*/
}
