using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifieGlobalFloat : ExecuteSeveralTimesEvery
{
    private enum ModifierOperations { Add, Multiply, Set, Pow }

    [SerializeField]
    private string floatName;

    [SerializeField]
    private ModifierOperations operation;

    [SerializeField]
    private float value;

    public override void ExecuteEvery()
    {
        ModifieGlobalVar();
    }

    private void ModifieGlobalVar()
    {
        switch (operation)
        {
            case ModifierOperations.Add:
                Shader.SetGlobalFloat(floatName, Shader.GetGlobalFloat(floatName) + value);
                break;
            case ModifierOperations.Multiply:
                Shader.SetGlobalFloat(floatName, Shader.GetGlobalFloat(floatName) * value);
                break;
            case ModifierOperations.Set:
                Shader.SetGlobalFloat(floatName, value);
                break;
            case ModifierOperations.Pow:
                Shader.SetGlobalFloat(floatName, Mathf.Pow(Shader.GetGlobalFloat(floatName), value));
                break;
        }
    }
}
