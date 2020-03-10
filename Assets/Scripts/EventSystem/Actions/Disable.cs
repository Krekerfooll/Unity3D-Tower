using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : Action
{
    public override void Execute()
    {
        gameObject.SetActive(false);
    }
}
