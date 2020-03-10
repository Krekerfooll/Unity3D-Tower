using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Every : StateConditionBase
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
                    if(GameLogicOperations.CheckConditionsByAndRule(conditions))
                        return true;
                break;

            case State.After:
                if (alreadyChecked)
                    if (GameLogicOperations.CheckConditionsByAndRule(conditions))
                        return true;
                break;
        }

        return false;
    }
}
