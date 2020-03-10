using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExecuteSeveralTimesEvery : Action
{
    [SerializeField]
    [HideInInspector]
    private int iterationCount;

    [SerializeField]
    [HideInInspector]
    private float IterationTime;

    public override void Execute()
    {
        if (!IsInvoking("ExecuteEvery"))
        {
            for (int i = 0; i < iterationCount; i++)
            {
                Invoke("ExecuteEvery", IterationTime * i);
            }
        }
    }

    public abstract void ExecuteEvery();
}
