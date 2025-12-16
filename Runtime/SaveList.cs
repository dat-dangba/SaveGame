using System.Collections.Generic;
using UnityEngine;

namespace SaveGame
{
    [System.Serializable]
    public class SaveList<T>
    {
        [SerializeField] private List<T> value;

        public SaveList()
        {
            value = new List<T>();
        }

        public SaveList(List<T> value)
        {
            this.value = new List<T>(value);
        }

        public SaveList(int capacity)
        {
            value = new List<T>(capacity);
        }

        private void OnValueChanged() => SaveGame.OnValueChanged?.Invoke();

        public IReadOnlyList<T> Value => value;

        public void SetValue(IEnumerable<T> value)
        {
            this.value.Clear();
            this.value.AddRange(value);
            OnValueChanged();
        }

        public int Capacity
        {
            get => value.Capacity;
            set
            {
                this.value.Capacity = value;
                OnValueChanged();
            }
        }

        public int Count => value.Count;

        public T this[int index]
        {
            get => value[index];
            set
            {
                if (EqualityComparer<T>.Default.Equals(this.value[index], value)) return;
                this.value[index] = value;
                OnValueChanged();
            }
        }

        public void Add(T item)
        {
            value.Add(item);
            OnValueChanged();
        }

        public void AddRange(IEnumerable<T> collection)
        {
            value.AddRange(collection);
            OnValueChanged();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<T> AsReadOnly()
        {
            return value.AsReadOnly();
        }

        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            return value.BinarySearch(index, count, item, comparer);
        }

        public int BinarySearch(T item)
        {
            return value.BinarySearch(item);
        }

        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return value.BinarySearch(item, comparer);
        }

        public void Clear()
        {
            value.Clear();
            OnValueChanged();
        }

        public bool Contains(T item)
        {
            return value.Contains(item);
        }

        public List<TOutput> ConvertAll<TOutput>(System.Converter<T, TOutput> converter)
        {
            return value.ConvertAll(converter);
        }

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            value.CopyTo(index, array, arrayIndex, count);
        }

        public void CopyTo(T[] array)
        {
            value.CopyTo(array);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            value.CopyTo(array, arrayIndex);
        }

        public bool Exists(System.Predicate<T> match)
        {
            return value.Exists(match);
        }

        public T Find(System.Predicate<T> match)
        {
            return value.Find(match);
        }

        public List<T> FindAll(System.Predicate<T> match)
        {
            return value.FindAll(match);
        }

        public int FindIndex(int startIndex, int count, System.Predicate<T> match)
        {
            return value.FindIndex(startIndex, count, match);
        }

        public int FindIndex(int startIndex, System.Predicate<T> match)
        {
            return value.FindIndex(startIndex, match);
        }

        public int FindIndex(System.Predicate<T> match)
        {
            return value.FindIndex(match);
        }

        public T FindLast(System.Predicate<T> match)
        {
            return value.FindLast(match);
        }

        public int FindLastIndex(int startIndex, int count, System.Predicate<T> match)
        {
            return value.FindLastIndex(startIndex, count, match);
        }

        public int FindLastIndex(int startIndex, System.Predicate<T> match)
        {
            return value.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(System.Predicate<T> match)
        {
            return value.FindLastIndex(match);
        }

        public void ForEach(System.Action<T> action)
        {
            value.ForEach(action);
        }

        // public IEnumerator<T> GetEnumerator()
        // {
        //     return ((IEnumerable<T>)value).GetEnumerator();
        // }

        public System.Collections.Generic.List<T>.Enumerator GetEnumerator()
        {
            return value.GetEnumerator();
        }

        public List<T> GetRange(int index, int count)
        {
            return value.GetRange(index, count);
        }

        public int IndexOf(T item)
        {
            return value.IndexOf(item);
        }

        public int IndexOf(T item, int index)
        {
            return value.IndexOf(item, index);
        }

        public int IndexOf(T item, int index, int count)
        {
            return value.IndexOf(item, index, count);
        }

        public void Insert(int index, T item)
        {
            value.Insert(index, item);
            OnValueChanged();
        }

        public void InsertRange(int index, IEnumerable<T> collection)
        {
            value.InsertRange(index, collection);
            OnValueChanged();
        }

        public int LastIndexOf(T item, int index)
        {
            return value.LastIndexOf(item, index);
        }

        public int LastIndexOf(T item, int index, int count)
        {
            return value.LastIndexOf(item, index, count);
        }

        public bool Remove(T item)
        {
            bool b = value.Remove(item);
            if (b) OnValueChanged();
            return b;
        }

        public int RemoveAll(System.Predicate<T> match)
        {
            int i = value.RemoveAll(match);
            OnValueChanged();
            return i;
        }

        public void RemoveAt(int index)
        {
            value.RemoveAt(index);
            OnValueChanged();
        }

        public void RemoveRange(int index, int count)
        {
            value.RemoveRange(index, count);
            OnValueChanged();
        }

        public void Reverse()
        {
            value.Reverse();
            OnValueChanged();
        }

        public void Reverse(int index, int count)
        {
            value.Reverse(index, count);
            OnValueChanged();
        }

        public void Sort()
        {
            value.Sort();
            OnValueChanged();
        }

        public void Sort(IComparer<T> comparer)
        {
            value.Sort(comparer);
            OnValueChanged();
        }

        public void Sort(System.Comparison<T> comparison)
        {
            value.Sort(comparison);
            OnValueChanged();
        }

        public void Sort(int index, int count, IComparer<T> comparer)
        {
            value.Sort(index, count, comparer);
            OnValueChanged();
        }

        public T[] ToArray()
        {
            return value.ToArray();
        }

        public void TrimExcess()
        {
            value.TrimExcess();
            OnValueChanged();
        }

        public bool TrueForAll(System.Predicate<T> match)
        {
            return value.TrueForAll(match);
        }
    }
}