#if UNITY_EDITOR
using UnityEditor;

namespace DBD.SaveGame.Editor
{
    public class SaveGameAssetPostprocessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            bool needGenerate = false;

            foreach (var path in importedAssets)
            {
                if (!path.EndsWith(".cs")) continue;

                var code = System.IO.File.ReadAllText(path);

                if (code.Contains("SaveValue<") || code.Contains("SaveList<"))
                {
                    needGenerate = true;
                    break;
                }
            }

            if (needGenerate)
            {
                SaveGameGeneratorCode.Generate();
            }
        }
    }
}
#endif