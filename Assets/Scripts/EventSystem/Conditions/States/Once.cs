using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Once : ConditionsBasedCondition
{
    private bool alreadyChecked;

    public override bool CheckCondition()
    {
        if (!alreadyChecked)
        {
            if (GameLogicOperations.CheckConditionsByAndRule(conditions))
            {
                alreadyChecked = true;
                return true;
            }
        }

        return false;
    }
}
