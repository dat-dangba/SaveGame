using System.Collections.Generic;
using UnityEngine;

namespace DBD.SaveGame
{
    [System.Serializable]
    public class SaveValue<T>
    {
        [SerializeField] private T value;

        public SaveValue()
        {
        }

        public SaveValue(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get => value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(this.value, value)) return;
                this.value = value;
                SaveGame.OnValueChanged?.Invoke();
            }
        }

        internal void SetSilently(T value)
        {
            this.value = value;
        }
    }
}