using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Pool of objects
/// </summary>
public class ObjectPooler : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        /// <summary>
        /// To set identifier, you need to have two inspector-windows/tabs
        /// One that's locked (lock-icon, to the right near the tabs) so you can reach the identifer,
        /// and the other on the objectpooler
        /// </summary>
        public MonoBehaviour Identifier;
        public GameObject PrefabObject;
        public int Size;
    }

    public List<Pool> Pools;
    public Dictionary<MonoBehaviour, Queue<GameObject>> PoolDictionary;

    /// <summary>
    /// Singleton: Shame (bell rings), shame (bell rings)
    /// </summary>
    public static ObjectPooler Instance;

    /// <summary>
    /// On awake, make it a singleton
    /// </summary>
    void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
    }

    /// <summary>
    /// Setup the pool at start
    /// </summary>
    void Start()
    {
        PoolDictionary = new Dictionary<MonoBehaviour, Queue<GameObject>>();

        foreach (var pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (var i = 0; i < pool.Size; i++)
            {
                var go = Instantiate(pool.PrefabObject);
                go.SetActive(false);
                objectPool.Enqueue(go);
            }

            PoolDictionary.Add(pool.Identifier, objectPool);
        }
    }

    /// <summary>
    /// Get item from pool by identifier
    /// </summary>
    /// <param name="identifier">Example of identifer: PlayerController, WeaponSetter and so on</param>
    /// <param name="position">Where to spawn the object</param>
    /// <param name="rotation">Rotation of the object to spawn</param>
    /// <returns></returns>
    public GameObject GetFromPool(MonoBehaviour identifier, Vector2 position, Quaternion rotation)
    {

        if (!PoolDictionary.ContainsKey(identifier))
        {
            Debug.Log("Could not find object in pool by the identifier");
            return null;
        }
            

        var objectToSpawn = PoolDictionary[identifier].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        PoolDictionary[identifier].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}