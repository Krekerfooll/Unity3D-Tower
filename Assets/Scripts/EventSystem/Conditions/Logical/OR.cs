using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OR : Condition
{
    [SerializeField]
    private Condition[] conditions;

    public override bool CheckCondition()
    {
        foreach (Condition condition in conditions)
        {
            if (condition.CheckCondition())
                return true;
        }

        return false;
    }
}
