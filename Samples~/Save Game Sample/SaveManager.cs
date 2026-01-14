using UnityEngine;

namespace DBD.SaveGame.Sample
{
    public class SaveManager : BaseSaveManager<SaveManager, DataSave>
    {
        [ContextMenu("SaveData")]
        private void Save()
        {
            SaveData();
        }

        protected override void Migrate(int fromVersion)
        {
        }

        protected override int Version()
        {
            return 0;
        }
    }
}