using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Condition), true)]
public class ConditionBaseInspector : EventSystemBaseInspector
{
    private void OnEnable()
    {
        Init();
    }

    public override void Init()
    {
        headerBackground = new Color(0.4f, 0.4f, 1f);
        headerTextColor = Color.black;
        bodyBackground = new Color(0.6f, 0.6f, 1f);
        fieldsColor = new Color(0.9f, 0.9f, 1f);

        base.Init();
    }
}
