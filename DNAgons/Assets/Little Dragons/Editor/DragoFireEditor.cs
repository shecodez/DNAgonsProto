using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(DragoFire))]
public class DragoFireEditor : Editor
{
    private SerializedObject serObj;
    SerializedProperty
        aimMode,
        fireBallSpeed,
        firePoint,
        fireBall,
        fireBreath;

    private void OnEnable()
    {
        serObj = new SerializedObject(target);

        fireBallSpeed = serObj.FindProperty("FireBallSpeed");
        firePoint = serObj.FindProperty("FirePoint");
        fireBall = serObj.FindProperty("FireBall");
        fireBreath = serObj.FindProperty("FireBreath");
        aimMode = serObj.FindProperty("aimMode");
    }

    public override void OnInspectorGUI()
    {
        serObj.Update();
        if (aimMode.boolValue)
        {
            DrawDefaultInspector();
        }
        else
        {
            EditorGUILayout.PropertyField(fireBallSpeed, new GUIContent("Fire Ball Speed", "Amount of Speed that the fireball will be released"));
            EditorGUILayout.PropertyField(firePoint, new GUIContent("FirePoint", "Reference to the transform where the fire will be positioned"));
            EditorGUILayout.PropertyField(fireBall, new GUIContent("Fire Ball", "Reference to the Fire Ball Prefab"));
            EditorGUILayout.PropertyField(fireBreath, new GUIContent("Fire Breath", "Reference to the Fire Breath Prefab"));
            EditorGUILayout.PropertyField(aimMode, new GUIContent("Aim Mode", "Activate Aim Mode the head will look to the Camera Target"));
        }

        serObj.ApplyModifiedProperties();
    }
}
