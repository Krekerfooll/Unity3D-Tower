using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Action
{
    [SerializeField]
    private Axis axis;
    [SerializeField]
    private float speed;

    public override void Execute()
    {
        Vector3 vectorAxis = new Vector3(0, 0, 0);

        if (axis == Axis.X)
            vectorAxis = new Vector3(1, 0, 0);
        else if (axis == Axis.Y)
            vectorAxis = new Vector3(0, 1, 0);
        else if (axis == Axis.Z)
            vectorAxis = new Vector3(0, 0, 1);


        transform.Rotate(vectorAxis, speed * Time.deltaTime, Space.Self);
    }
}
