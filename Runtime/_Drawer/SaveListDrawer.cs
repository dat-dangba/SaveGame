#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace SaveGame
{
    [CustomPropertyDrawer(typeof(SaveList<>), true)]
    public class SaveListDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProp = property.FindPropertyRelative("value");

            // Tính chiều cao đúng theo loại dữ liệu
            return EditorGUI.GetPropertyHeight(valueProp, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProp = property.FindPropertyRelative("value");

            // Vẽ property "value" như thể nó là field chính
            EditorGUI.PropertyField(position, valueProp, label, true);
        }
    }
#endif
}