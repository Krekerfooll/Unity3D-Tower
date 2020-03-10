using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOT : Condition
{
    [SerializeField]
    private Condition condition;

    public override bool CheckCondition()
    {
        return !condition.CheckCondition();
    }
}
