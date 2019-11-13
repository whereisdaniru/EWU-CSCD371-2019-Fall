using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public List<T> Items { get; set; }
        public int Capacity { get; set; }

        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public Array(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            else
            {
                Capacity = capacity;
                Items = new List<T>(capacity);
            }
        }

        public Array(ICollection<T> items)
        {
            if(items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            if (items.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(items));
            }

            Items = new List<T>(items);
            Capacity = Items.Count;
            
        }

        public void Add(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if(Capacity == Count)
            {
                throw new ArgumentException(nameof(Capacity));
            }
            else
            {
                Items.Add(item);
            }
        }

        public void Clear()
        {
            if (Items is null)
            {
                throw new ArgumentNullException(nameof(Items));
            }
            else
            {
                Items.Clear();
            }
        }

        public bool Contains(T item)
        {
            if (Items is null)
            {
                throw new ArgumentNullException(nameof(Items));
            }
            if (item is null)
            {
                throw new ArgumentNullException(nameof(Items));
            }
            else
            {
                return Items.Contains(item);
            }

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            else if (arrayIndex > Capacity)
            {
                throw new IndexOutOfRangeException(nameof(arrayIndex));
            }
            else if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new IndexOutOfRangeException(nameof(arrayIndex));
            }
            else
            {
                Items.CopyTo(array, arrayIndex);
            }
        }

        public bool Remove(T item)
        {
            if (Items is null)
            {
                throw new ArgumentNullException(nameof(Items));
            }
            else if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Items.Remove(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Items is null)
            {
                throw new NullReferenceException(nameof(Items));
            }
            else
            {
                return Items.GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Items.IndexOf(item);
            }
        }
    }
}
