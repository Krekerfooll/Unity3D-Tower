using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : Action
{
    [SerializeField]
    private GameObject target;

    public override void Execute()
    {
        target.SetActive(true);
    }
}
