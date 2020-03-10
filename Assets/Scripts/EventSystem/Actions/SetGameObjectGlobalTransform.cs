using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameObjectGlobalTransform : Action
{
    private enum TransformTypes { Position, Rotation, Scale }


    [SerializeField]
    private string transformName;

    [SerializeField]
    private Transform objectTransform;

    [Space]

    [SerializeField]
    private TransformTypes transformType;
    [SerializeField]
    private bool localTransform;


    public override void Execute()
    {
        switch (transformType)
        {
            case TransformTypes.Position:
                Shader.SetGlobalVector(transformName, !localTransform ? 
                    objectTransform.position : objectTransform.localPosition);
                break;

            case TransformTypes.Rotation:
                Shader.SetGlobalVector(transformName, !localTransform ? 
                    objectTransform.rotation.eulerAngles : objectTransform.localRotation.eulerAngles);
                break;

            case TransformTypes.Scale:
                Shader.SetGlobalVector(transformName, !localTransform ? 
                    objectTransform.lossyScale : objectTransform.localScale);
                break;
        }
    }
}