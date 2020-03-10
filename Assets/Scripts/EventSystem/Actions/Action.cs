using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis { X, Y, Z }

public abstract class Action : EventSystemBase
{
    [HideInInspector]
    public string actionName = "ACTION";

    public abstract void Execute();
}
