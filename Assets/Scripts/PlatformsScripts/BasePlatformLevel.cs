using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlatformLevel : MonoBehaviour
{
    private PlatformsDataBase platformsDataBase;
    private ObjectPool platformPool;
    private List<string> platforms;

    private int platformsAmount = 5;
    private int holeChance = 10;
    private int maxHolesAmount = 3;


    private void OnEnable()
    {
        
    }


    public void Initialize(PlatformsDataBase platformsDataBase, int platformsAmount, int holeChance, int maxHolesAmount)
    {
        this.platformsDataBase = platformsDataBase;
        this.platformsAmount = platformsAmount;
        this.holeChance = holeChance;
        this.maxHolesAmount = maxHolesAmount;

        platformPool = new ObjectPool(this.platformsDataBase);
        platforms = new List<string>();
    }

    public void CreatePlatforms(Vector3 platformsLevelPosition, Quaternion platformsLevelRotation, Axis axis)
    {
        transform.position = platformsLevelPosition;
        transform.rotation = platformsLevelRotation;
        transform.localScale = Vector3.one;

        float positionStart  = -0.5f;
        float platformLength = 1f / platformsAmount;

        int curHolesAmount = 0;

        // Platforms creation
        for (int i = 0; i < platformsAmount; i++)
        {
            if (maxHolesAmount > curHolesAmount && Random.Range(1, 101) < holeChance)
            {
                curHolesAmount++;
            }
            else
            {
                GameObject platform;
                platforms.Add(platformsDataBase.GetTypes()[Random.Range(0, platformsDataBase.GetTypes().Length)]);
                platformPool.Acquire(platforms[platforms.Count - 1], out platform);

                platform.transform.SetParent(transform);

                platform.transform.localScale = new Vector3(
                    (axis == Axis.X) ? platformLength : 1,
                    (axis == Axis.Y) ? platformLength : 1,
                    (axis == Axis.Z) ? platformLength : 1);

                platform.transform.localPosition = new Vector3(
                    (axis == Axis.X) ? positionStart + platformLength * i + platformLength / 2 : 0,
                    (axis == Axis.Y) ? positionStart + platformLength * i + platformLength / 2 : 0,
                    (axis == Axis.Z) ? positionStart + platformLength * i + platformLength / 2 : 0);

                platform.transform.localRotation = Quaternion.identity;
            }
        }
    }

    public void ReleaseAll()
    {
        for (int i = 0; i < transform.childCount; i++)
            platformPool.Release(platforms[i], transform.GetChild(i).gameObject);

        platforms.Clear();
        transform.DetachChildren();
    }
}
