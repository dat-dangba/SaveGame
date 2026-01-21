#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace DBD.SaveGame
{
    [CustomPropertyDrawer(typeof(SaveValue<>), true)]
    public class SaveValueDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProp = property.FindPropertyRelative("value");

            // Tính chiều cao đúng theo loại dữ liệu
            return EditorGUI.GetPropertyHeight(valueProp, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // SerializedProperty valueProp = property.FindPropertyRelative("value");
            //
            // // Vẽ property "value" như thể nó là field chính
            // EditorGUI.PropertyField(position, valueProp, label, true);

            SerializedProperty valueProp = property.FindPropertyRelative("value");

            bool isVersionField = property.name == "Version";

            bool oldState = GUI.enabled;
            if (isVersionField)
            {
                GUI.enabled = false;
            }

            EditorGUI.PropertyField(position, valueProp, label, true);

            GUI.enabled = oldState;
        }
    }
}
#endif