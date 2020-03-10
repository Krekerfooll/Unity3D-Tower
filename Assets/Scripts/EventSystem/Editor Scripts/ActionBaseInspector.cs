using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Action), true)]
public class ActionBaseInspector : EventSystemBaseInspector
{
    private void OnEnable()
    {
        Init();
    }

    public override void Init()
    {
        headerBackground = new Color(1f, 0.4f, 0.4f);
        headerTextColor = Color.black;
        bodyBackground = new Color(1f, 0.6f, 0.6f);
        fieldsColor = new Color(1f, 0.9f, 0.9f);

        base.Init();
    }
}
