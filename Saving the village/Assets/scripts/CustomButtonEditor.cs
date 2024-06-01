using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.UI;
#endif

using UnityEngine;

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(CustomButton))]
[UnityEditor.CanEditMultipleObjects]
public class CustomButtonEditor : ButtonEditor
{
    public override void OnInspectorGUI()
    {
        UnityEditor.EditorGUILayout.PropertyField(serializedObject.FindProperty("_normal"));
        UnityEditor.EditorGUILayout.PropertyField(serializedObject.FindProperty("_select"));
        serializedObject.ApplyModifiedProperties(); 



        base.OnInspectorGUI();
    }
}
#endif
//Включает в редактор наши кнопки.
