using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up, Down, Left, Right}

public abstract class Condition : EventSystemBase
{
    public abstract bool CheckCondition();
}
