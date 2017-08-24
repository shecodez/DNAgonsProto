using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace MalbersAnimations
{
    [CustomEditor(typeof(MaterialChanger))]
    public class MaterialChangerEditor : Editor
    {
        private ReorderableList list;
        private MaterialChanger matChan;

        private void OnEnable()
        {
            matChan = ((MaterialChanger)target);

            list = new ReorderableList(serializedObject, serializedObject.FindProperty("materialList"), false, true, true, true);
            list.drawElementCallback = drawElementCallback;
            list.drawHeaderCallback = HeaderCallbackDelegate;
        }



        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.BeginVertical(MalbersEditor.StyleBlue);
            EditorGUILayout.HelpBox("Swap Materials to their Respective Meshes", MessageType.None);
            EditorGUILayout.EndVertical();

            EditorGUI.BeginChangeCheck();
            list.DoLayoutList();
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(target);
            }

            serializedObject.ApplyModifiedProperties();
        }






        void HeaderCallbackDelegate(Rect rect)
        {
            Rect R_1 = new Rect(rect.x + 20, rect.y, (rect.width - 20) / 4 - 23, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(R_1, "Name");
        }

        void drawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            var element = matChan.materialList[index];
            rect.y += 2;
            element.active = EditorGUI.Toggle(new Rect(rect.x, rect.y, 20, EditorGUIUtility.singleLineHeight), element.active);

            Rect R_1 = new Rect(rect.x + 20, rect.y, (rect.width - 20) / 2 - 23, EditorGUIUtility.singleLineHeight);
            GUIStyle a = new GUIStyle();

            a.fontStyle = FontStyle.Normal;
            element.name = EditorGUI.TextField(R_1, element.name, a);


            Rect R_2 = new Rect(rect.x + (rect.width - 20) / 2 + 15, rect.y, (rect.width - 20) / 4, EditorGUIUtility.singleLineHeight);
            if (GUI.Button(R_2, "Change"))
            {
                 ChangeMaterial(index);
            }
        }


        void ChangeMaterial(int index)
        {

        }

    }
}