using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour, IObjectPool
{
    private IObjectDataBase objectsDataBase; // database with different object variants
    private Dictionary<string, List<GameObject>> freeObjects;
    private Dictionary<string, List<GameObject>> occupiedObjects;

    public ObjectPool(IObjectDataBase database)
    {
        // pull creation

        objectsDataBase = database;
        freeObjects = new Dictionary<string, List<GameObject>>();
        occupiedObjects = new Dictionary<string, List<GameObject>>();

        foreach (string item in objectsDataBase.GetTypes())
        {
            freeObjects.Add(item, new List<GameObject>());
            occupiedObjects.Add(item, new List<GameObject>());
        }
    }

    public bool Acquire(string type, out GameObject result)
    {
        List<GameObject> current = new List<GameObject>();

        if (freeObjects.TryGetValue(type, out current))
        {
            if (current.Count > 0)
            {
                result = current[0];
                current.Remove(result);
                if (occupiedObjects.TryGetValue(type, out current))
                    current.Add(result);

                result.SetActive(true);
                return true;
            }
        }

        if (occupiedObjects.TryGetValue(type, out current))
        {
            if (objectsDataBase.CreatePoolingObject(type, out result))
            {
                current.Add(result);
                result.SetActive(true);
                return true;
            }
        }

        result = default;
        return false;
    }

    public bool Release(string type, GameObject poolingObject)
    {
        List<GameObject> current = new List<GameObject>();

        if (occupiedObjects.TryGetValue(type, out current))
        {
            current.Remove(poolingObject);
            if (freeObjects.TryGetValue(type, out current))
                current.Add(poolingObject);

            poolingObject.SetActive(false);
            return true;
        }

        return false;
    }
}
