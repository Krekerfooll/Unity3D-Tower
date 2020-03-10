using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventSystemBase))]
public class EventSystemBaseInspector : Editor
{
    protected GUIStyle eventSystemStyle;

    protected Color headerBackground;
    protected Color headerTextColor;
    protected Color bodyBackground;
    protected Color fieldsColor;

    SerializedProperty elementName;

    private void OnEnable()
    {
        Init();
    }

    public virtual void Init()
    {
        eventSystemStyle = new GUIStyle();
        eventSystemStyle.fontSize = 16;
        eventSystemStyle.fontStyle = FontStyle.Normal;
        eventSystemStyle.alignment = TextAnchor.MiddleCenter;
        eventSystemStyle.normal.background = new Texture2D(300, 30);
        eventSystemStyle.normal.textColor = headerTextColor;

        elementName = serializedObject.FindProperty("elementName");
    }

    public override void OnInspectorGUI()
    {

        GUI.color = headerBackground;
        EditorGUILayout.Space();
        Rect actionLabelRect = GUILayoutUtility.GetRect(300, 40);

        serializedObject.Update();
        elementName.stringValue = GUI.TextField(actionLabelRect, elementName.stringValue, eventSystemStyle);

        serializedObject.ApplyModifiedProperties();

        GUI.color = bodyBackground;
        EditorGUILayout.BeginVertical(eventSystemStyle);
        GUI.color = fieldsColor;
        EditorGUILayout.Space();
        base.OnInspectorGUI();
        EditorGUILayout.EndVertical();
    }
}
