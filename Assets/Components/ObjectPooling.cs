using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Pool of objects
/// </summary>
public class ObjectsPool : MonoBehaviour
{
    // TODO: Make list of objects, instead of making several pools for each object
    public GameObject pooledObject;
    public int pooledAmount = 20;
    public bool willGrow = true;

    public List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // TODO: objecttype as parameter, so the pool knows what to get
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i] == null)
            {
                GameObject obj = (GameObject)Instantiate(pooledObject);
                obj.SetActive(false);
                pooledObjects[i] = obj;
                return pooledObjects[i];
            }
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }

}