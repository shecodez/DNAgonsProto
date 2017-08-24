using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public GameObject prefab;
    private Stack<GameObject> inactiveGOs = new Stack<GameObject>();

    /// <summary>
    /// Returns an instance of the prefab
    /// </summary>
    /// <returns>Spawned GO</returns>
    public GameObject GetObject()
    {
        GameObject _spawnedGO;

        if (inactiveGOs.Count > 0)
        {
            _spawnedGO = inactiveGOs.Pop();
        }
        else
        {
            _spawnedGO = (GameObject)GameObject.Instantiate(prefab);

            PooledObject _pooledGO = _spawnedGO.AddComponent<PooledObject>();
            _pooledGO.pool = this; 
        }

        _spawnedGO.transform.SetParent(null);
        _spawnedGO.SetActive(true);

        return _spawnedGO;
    }

    /// <summary>
    /// Return an Instance of the prefab to the pool
    /// </summary>
    /// <param name="toReturn">Prefab to Return</param>
    public void ReturnObject(GameObject toReturn)
    {
        PooledObject _pooledGO = toReturn.GetComponent<PooledObject>();

        if (_pooledGO != null && _pooledGO.pool == this)
        {
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            inactiveGOs.Push(toReturn);
        }
        else
        {
            Debug.LogWarning(toReturn.name + "was returned to a pool it wasn't spawned from... Destroying it!");
            Destroy(toReturn);
        }
    }
}

// Component that simply IDs the pool that a GO came from
internal class PooledObject : MonoBehaviour
{
    public ObjectPool pool;
}