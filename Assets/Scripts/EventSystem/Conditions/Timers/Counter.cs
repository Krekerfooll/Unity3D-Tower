using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : ConditionsBasedCondition
{
    [SerializeField]
    private int CountUpTo;

    private int counter = 0;

    public override bool CheckCondition()
    {
        if (counter < CountUpTo)
        {
            if (GameLogicOperations.CheckConditionsByAndRule(conditions))
                counter++;
        }

        if (counter == CountUpTo)
        {
            counter = 0;
            return true;
        }

        return false;
    }
}
