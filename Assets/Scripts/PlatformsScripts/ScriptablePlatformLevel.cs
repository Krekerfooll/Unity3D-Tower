using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "PlatformLevel", menuName = "ScriptableObjects/PlatformLevel")]
public class ScriptablePlatformLevel : ScriptableObject
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
    private PlatformsDataBase platformsDataBase;
    public PlatformsDataBase PlatformsDataBase
    {
        get
        {
            return platformsDataBase;
        }
    }

    [SerializeField]
    private int platformsAmount = 5;
    [SerializeField]
    [Range(0, 100)]
    private int holeChance = 10;
    [SerializeField]
    private int maxHolesAmount = 3;


    public GameObject CreatePlatformLevel()
    {
        GameObject platformLevel = new GameObject("PlatformLevel");

        platformLevel.AddComponent<BasePlatformLevel>().Initialize(platformsDataBase, platformsAmount, holeChance, maxHolesAmount);

        return platformLevel;
    }
}
