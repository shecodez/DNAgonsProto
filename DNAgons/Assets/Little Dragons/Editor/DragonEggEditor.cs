using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DragonEgg))]
public class DragonEggEditor : Editor
{

    private SerializedObject serObj;
    private SerializedProperty key, input, time, click, hatchtype;
    private void OnEnable()
    {
        serObj = new SerializedObject(target);

        hatchtype = serObj.FindProperty("hatchtype");

        input = serObj.FindProperty("input");
        key = serObj.FindProperty("key");
        time = serObj.FindProperty("seconds");

    }

    public override void OnInspectorGUI()
    {
        serObj.Update();
        DrawDefaultInspector();

        DragonEgg MyDragoEgg = (DragonEgg)target;

        DragonEgg.HatchType ht = (DragonEgg.HatchType) hatchtype.enumValueIndex;

        switch (ht)
        {
            case DragonEgg.HatchType.Key:
                EditorGUILayout.PropertyField(key, new GUIContent("Key", "Press a Key to Hatch"));
                break;
            case DragonEgg.HatchType.Time:
                EditorGUILayout.PropertyField(time, new GUIContent("Time", "ammount of Seconds to Hatch"));
                break;
            case DragonEgg.HatchType.Click:
                break;
            case DragonEgg.HatchType.Input:
                EditorGUILayout.PropertyField(input, new GUIContent("Input", "Input assigned in the InputManager to Hatch"));
                break;
            case DragonEgg.HatchType.Event:
                EditorGUILayout.HelpBox("You can send a message using gameObject.SendMessage('CrackEgg'); ", MessageType.Info);
                break;
            default:
                break;
        }
      


        if (GUILayout.Button(new GUIContent("Change Color", "Change the Egg Material")))
        {
            MyDragoEgg.ChangeColor(MyDragoEgg.EggMesh, MyDragoEgg.EggMeshInside);
        }


        serObj.ApplyModifiedProperties();
    }
}
