using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlop : Condition
{
    [SerializeField]
    private Condition Condition;

    private bool curValue;

    public override bool CheckCondition()
    {
        if (Condition.CheckCondition())
        {
            curValue = !curValue;
        }

        return curValue;
    }
}
