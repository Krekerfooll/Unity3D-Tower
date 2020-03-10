using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ModifieAnimatorVar))]
public class ModifieAnimatorVarCustomInspector : ExecuteSeveralTimesEveryCustomInspector
{
    SerializedProperty type;
    SerializedProperty boolValue;
    SerializedProperty intValue;
    SerializedProperty floatValue;

    private void OnEnable()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        type = serializedObject.FindProperty("type");
        boolValue = serializedObject.FindProperty("boolValue");
        intValue = serializedObject.FindProperty("intValue");
        floatValue = serializedObject.FindProperty("floatValue");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        GUI.color = new Color(1f, 0.6f, 0.6f);
        EditorGUILayout.BeginVertical(eventSystemStyle);
        GUI.color = new Color(1f, 0.9f, 0.9f);

        switch ((ModifieAnimatorVar.VarTypes)type.enumValueIndex)
        {
            case ModifieAnimatorVar.VarTypes.Bool:
                EditorGUILayout.PropertyField(boolValue);
                break;

            case ModifieAnimatorVar.VarTypes.Int:
                EditorGUILayout.PropertyField(intValue);
                break;

            case ModifieAnimatorVar.VarTypes.Float:
                EditorGUILayout.PropertyField(floatValue);
                break;

            case ModifieAnimatorVar.VarTypes.Trigger:
                break;
        }

        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }
}
