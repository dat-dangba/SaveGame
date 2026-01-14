using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace DBD.SaveGame
{
    public static class SaveGame
    {
        public static Action OnValueChanged;

        private static string fileSave = "SaveGame.bin";

        public static string LoadData(string file = "SaveGame.bin")
        {
            fileSave = file;
            string dataPath = GetPath();
            if (!File.Exists(dataPath))
            {
                return "";
            }

            string dataEncode = File.ReadAllText(dataPath);
            return Decode(dataEncode);
        }

        public static void SaveData(string data)
        {
            File.WriteAllTextAsync(GetPath(), Encode(data));
        }

        public static void ClearData()
        {
            string dataPath = GetPath();
            if (File.Exists(dataPath))
            {
                File.Delete(dataPath);
            }
        }

        private static string GetPath()
        {
            return $"{Application.persistentDataPath}/{fileSave}";
        }

        private static string Encode(string data)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }

        private static string Decode(string dataEncode)
        {
            byte[] decodedBytes = Convert.FromBase64String(dataEncode);
            return Encoding.UTF8.GetString(decodedBytes);
        }
    }
}