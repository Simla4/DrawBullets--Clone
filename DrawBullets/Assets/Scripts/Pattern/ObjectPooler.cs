using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoSingleton<ObjectPooler>
{
    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        #region FillQueues

        foreach(var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

        #endregion
    }
    
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objToSpawn = poolDictionary[tag].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }

    #region  PoolClass
    [System.Serializable]
    public  class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #endregion
}
