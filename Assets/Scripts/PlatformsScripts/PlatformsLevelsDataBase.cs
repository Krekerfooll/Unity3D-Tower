using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Database, that create and store different platform levels
/// </summary>
[CreateAssetMenu(fileName = "PlatformsLevelsDataBase", menuName = "DataBases/PlatformsLevelsDataBase")]
public class PlatformsLevelsDataBase : ScriptableObject, IObjectDataBase
{
    [SerializeField]
    private List<ScriptablePlatformLevel> scriptablePlatformLevel;

    public string[] GetTypes()
    {
        string[] types = new string[scriptablePlatformLevel.Count];

        for (int i = 0; i < scriptablePlatformLevel.Count; i++)
        {
            types[i] = scriptablePlatformLevel[i].Type;
        }

        return types;
    }

    public bool CreatePoolingObject(string type, out GameObject result)
    {
        foreach (ScriptablePlatformLevel item in scriptablePlatformLevel)
        {
            if (item.Type == type)
            {
                result = item.CreatePlatformLevel();
                return true;
            }
        }

        result = null;
        return false;
    }
}
