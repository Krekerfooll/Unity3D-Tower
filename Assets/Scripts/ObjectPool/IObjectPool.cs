using UnityEngine;

public interface IObjectPool
{
    bool Acquire(string type, out GameObject poolingObject);
    bool Release(string type, GameObject poolingObject);
}
