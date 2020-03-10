using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifieAnimatorVar : ExecuteSeveralTimesEvery
{
    public enum VarTypes { Bool, Int, Float, Trigger}

    [Space]

    [SerializeField]
    private Animator animator;

    [Space]

    [SerializeField]
    private VarTypes type;

    [SerializeField]
    private string varName;

    [SerializeField]
    [HideInInspector]
    private bool boolValue;

    [SerializeField]
    [HideInInspector]
    private int intValue;

    [SerializeField]
    [HideInInspector]
    private float floatValue;

    public override void ExecuteEvery()
    {
        switch (type)
        {
            case VarTypes.Bool:
                animator.SetBool(varName, boolValue);
                break;
            case VarTypes.Int:
                animator.SetInteger(varName, intValue);
                break;
            case VarTypes.Float:
                animator.SetFloat(varName, floatValue);
                break;
            case VarTypes.Trigger:
                animator.SetTrigger(varName);
                break;
        }
    }
}
