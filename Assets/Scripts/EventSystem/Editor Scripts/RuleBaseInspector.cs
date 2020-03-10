using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Rule), true)]
public class RuleBaseInspector : EventSystemBaseInspector
{
    private void OnEnable()
    {
        Init();
    }

    public override void Init()
    {
        headerBackground = new Color(0.2f, 0.8f, 0.2f);
        headerTextColor = Color.black;
        bodyBackground = new Color(0.5f, 0.9f, 0.5f);
        fieldsColor = new Color(0.9f, 1f, 0.9f);

        base.Init();
    }
}
