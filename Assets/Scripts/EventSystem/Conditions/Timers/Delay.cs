using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : Condition
{
    [SerializeField]
    private Condition[] conditions;

    [SerializeField]
    [Min(0f)]
    private float timeInSeconds;


    private float lastTimeCheck;
    private bool isChecked;

    public override bool CheckCondition()
    {
        if (isChecked)
        {
            if (Time.realtimeSinceStartup - lastTimeCheck > timeInSeconds)
            {
                isChecked = false;
                return true;
            }
        }

        foreach (Condition condition in conditions)
        {
            if (!condition.CheckCondition())
                return false;
        }

        if (!isChecked)
        {
            isChecked = true;
            lastTimeCheck = Time.realtimeSinceStartup;
        }

        return false;
    }
}
