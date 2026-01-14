using System.Collections.Generic;
using UnityEngine;

namespace DBD.SaveGame.Sample
{
    [System.Serializable]
    public class DataSave : BaseDataSave
    {
        public SaveValue<int> Level = new();
        public SaveValue<Color> Color = new(UnityEngine.Color.blue);
        public SaveList<int> Numbers = new(new List<int> { 3, 3, 3 });
        public SaveList<int> Nums = new();
        public SaveList<Vector3> Vectors = new();
    }
}