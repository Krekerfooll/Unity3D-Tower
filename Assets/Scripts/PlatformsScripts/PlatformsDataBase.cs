using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Database, that create and store different platforms
/// </summary>
[CreateAssetMenu(fileName = "PlatformsDataBase", menuName = "DataBases/PlatformsDataBase")]
public class PlatformsDataBase : ScriptableObject, IObjectDataBase
{
    [SerializeField]
    private List<ScriptablePlatform> scriptablePlatforms;
    [SerializeField]
    private List<int> platformsChances;

    public string[] GetTypes()
    {
        string[] types = new string[scriptablePlatforms.Count];

        for (int i = 0; i < scriptablePlatforms.Count; i++)
        {
            types[i] = scriptablePlatforms[i].Type;
        }

        return types;
    }

    //public int[] GetChances()
    //{
    //    int[]  = new string[scriptablePlatforms.Count];

    //    for (int i = 0; i < scriptablePlatforms.Count; i++)
    //    {
    //        types[i] = scriptablePlatforms[i].Type;
    //    }

    //    return types;
    //}

    public bool CreatePoolingObject(string type, out GameObject result)
    {
        foreach (ScriptablePlatform item in scriptablePlatforms)
        {
            if (item.Type == type)
            {
                result = item.CreatePlatform();
                return true;
            }
        }

        result = null;
        return false;
    }
}