using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionsBasedCondition : Condition
{
    [SerializeField]
    protected Condition[] conditions;
}
