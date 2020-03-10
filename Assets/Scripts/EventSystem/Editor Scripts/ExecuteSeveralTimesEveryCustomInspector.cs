using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ExecuteSeveralTimesEvery), true)]
public class ExecuteSeveralTimesEveryCustomInspector : ActionBaseInspector
{
    SerializedProperty iterationCount;
    SerializedProperty IterationTime;

    private void OnEnable()
    {
        Init();
    }

    public override void Init()
    {
        iterationCount = serializedObject.FindProperty("iterationCount");
        IterationTime = serializedObject.FindProperty("IterationTime");

        base.Init();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUI.color = new Color(1f, 0.4f, 0.8f);
        EditorGUILayout.Space();
        Rect executeSeveralTimesEveryLabelRect = GUILayoutUtility.GetRect(300, 40);
        GUI.Label(executeSeveralTimesEveryLabelRect, "ITERATOR", eventSystemStyle);

        GUI.color = new Color(1f, 0.6f, 0.8f);
        EditorGUILayout.BeginVertical(eventSystemStyle);
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUI.color = new Color(1f, 0.85f, 1f);
        EditorGUILayout.LabelField("Count", GUILayout.Width(40));
        EditorGUILayout.PropertyField(iterationCount, GUIContent.none, GUILayout.MinWidth(25), GUILayout.MaxWidth(100));
        GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField("Every", GUILayout.Width(40));
        EditorGUILayout.PropertyField(IterationTime, GUIContent.none, GUILayout.MinWidth(25), GUILayout.MaxWidth(100));
        EditorGUILayout.LabelField("sec.", GUILayout.MaxWidth(25));
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}
