using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : ExecuteSeveralTimesEvery
{
    [SerializeField]
    private Axis axis;

    [SerializeField]
    private float speed;

    private Vector3 vectorAxis;

    private void Awake()
    {
        if (axis == Axis.X)
            vectorAxis = new Vector3(1, 0, 0);
        else if (axis == Axis.Y)
            vectorAxis = new Vector3(0, 1, 0);
        else if (axis == Axis.Z)
            vectorAxis = new Vector3(0, 0, 1);
    }

    public override void ExecuteEvery()
    {
        TranslateThis();
    }

    private void TranslateThis()
    {
        transform.Translate(vectorAxis * speed, Space.Self);
    }
}
