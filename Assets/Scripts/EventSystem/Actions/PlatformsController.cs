using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : Action
{
    [SerializeField]
    private bool start = false;

    [SerializeField]
    private Axis axis;

    [SerializeField]
    private PlatformsLevelsDataBase platformsLevelsDataBase;
    private ObjectPool platformsLevelsPool;

    [SerializeField]
    private float oneStepHeight = 1;
    [SerializeField]
    private int addSpecificStepsAmountAfterStart;
    [Space]
    [SerializeField]
    private int maxPlatformsLevelsAmount = 1;
    private float curHeightLevel;

    private List<GameObject> platformsLevels;
    private List<string> platformsLevelTypes;

    public override void Execute()
    {
        start = true;
    }

    private void Awake()
    {
        curHeightLevel = transform.position.y;
        platformsLevels = new List<GameObject>();
        platformsLevelTypes = new List<string>();
        platformsLevelsPool = new ObjectPool(platformsLevelsDataBase);

        while (platformsLevels.Count < maxPlatformsLevelsAmount)
        {
            CreateNewLevel(true);
        }

        curHeightLevel += oneStepHeight * addSpecificStepsAmountAfterStart;
    }

    private void Update()
    {
        if (start)
        {
            if (platformsLevelsPool.Release(platformsLevelTypes[0], platformsLevels[0]))
            {
                platformsLevels[0].GetComponent<BasePlatformLevel>().ReleaseAll();
                platformsLevelTypes.RemoveAt(0);
                platformsLevels.RemoveAt(0);
                CreateNewLevel(false);
                start = false;
            }
        }
    }

    private void CreateNewLevel(bool addSpaceHeightBetweenPlatforms)
    {
        GameObject newPlatformLevel;
        string newPlatformLevelType = platformsLevelsDataBase.GetTypes()[Random.Range(0, platformsLevelsDataBase.GetTypes().Length)];
        if (platformsLevelsPool.Acquire(newPlatformLevelType, out newPlatformLevel))
        {
            platformsLevels.Add(newPlatformLevel);
            platformsLevelTypes.Add(newPlatformLevelType);
            newPlatformLevel.transform.SetParent(transform);

            Vector3 platformPosition = new Vector3(
                transform.position.x, 
                curHeightLevel += (addSpaceHeightBetweenPlatforms) ? oneStepHeight : 0, 
                transform.position.z);

            newPlatformLevel.GetComponent<BasePlatformLevel>().CreatePlatforms(platformPosition, transform.rotation, axis);
        }
    }
}
