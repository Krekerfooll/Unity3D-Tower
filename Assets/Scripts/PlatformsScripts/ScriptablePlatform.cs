using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "Platform", menuName = "ScriptableObjects/Platform")]
public class ScriptablePlatform : ScriptableObject
{
    [SerializeField]
    private string type;
    public string Type
    {
        get
        {
            return type;
        }
    }

    [SerializeField]
    private GameObject platform;

    public GameObject CreatePlatform()
    {
        GameObject platform = Instantiate(this.platform.gameObject, Vector3.zero, Quaternion.identity) as GameObject;

        return platform;
    }
}
