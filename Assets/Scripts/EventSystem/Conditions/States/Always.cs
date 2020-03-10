using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Always : StateConditionBase
{
    private bool alreadyChecked;

    public override bool CheckCondition()
    {
        if (!alreadyChecked)
            if (GameLogicOperations.CheckConditionsByAndRule(conditions))
                alreadyChecked = true;

        switch (state)
        {
            case State.Before:
                if (!alreadyChecked)
                    return true;
                break;

            case State.After:
                if (alreadyChecked)
                    return true;
                break;
        }

        return false;
    }
}
