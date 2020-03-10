using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : EventSystemBase
{
    [SerializeField]
    private Condition[] conditions;

    [SerializeField]
    private Action[] actions;

    void Update()
    {
        if (GameLogicOperations.CheckConditionsByAndRule(conditions))
        {
            foreach (Action action in actions)
            {
                action.Execute();
            }
        }
    }
}
