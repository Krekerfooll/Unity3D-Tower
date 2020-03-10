using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateConditionBase : ConditionsBasedCondition
{
    protected enum State { Before, After}

    [SerializeField]
    protected State state;
}
