using UnityEditor;
using UnityEngine;

namespace DBD.SaveGame.Editor
{
    public static class SaveGameTool
    {
        [MenuItem("Tools/Save Game/Clear Data")] //%#T Command Shift T
        public static void Clear()
        {
#if UNITY_EDITOR
            Debug.LogWarning($"SaveGame - Clear Data");
#endif
            SaveGame.ClearData();
        }
    }
}