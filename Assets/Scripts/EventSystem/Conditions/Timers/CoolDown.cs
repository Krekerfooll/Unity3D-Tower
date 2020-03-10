using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : Condition
{
    [SerializeField]
    private Condition[] conditions;

    [SerializeField]
    [Min(0f)]
    private float timeInSeconds;

    private float lastTimeCheck;
    private bool isChecked;

    private void Awake()
    {
        // Timer may start work just after Awake()
        lastTimeCheck = -timeInSeconds;
    }

    public override bool CheckCondition()
    {
        if (isChecked)
            return true;

        if (Time.realtimeSinceStartup - lastTimeCheck > timeInSeconds)
        {
            if (GameLogicOperations.CheckConditionsByAndRule(conditions))
            {
                isChecked = true;
                return true;
            }
        }

        return false;
    }

    private void LateUpdate()
    {
        if (isChecked)
        {
            lastTimeCheck = Time.realtimeSinceStartup;
            isChecked = false;
        }
    }
}
