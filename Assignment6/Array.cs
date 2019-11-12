using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public Array<T> Items { get; set; }
        public int Capacity { get; set; }

        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public Array(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            else
            {
                Capacity = capacity;
                Items = new Array<T>(Capacity);
            }
        }
       

        public void Add(T item)
        {
            if(item is null)
            {
                throw new NullReferenceException(nameof(item));
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
                throw new NullReferenceException(nameof(Items));
            }
            else
            {
                Items.Clear();
            }
        }

        public bool Contains(T item)
        {
            if(Items is null)
            {
                throw new NullReferenceException(nameof(Items));
            }
            else 
            {
                return Items.Contains(item);
            }
            
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array is null)
            {
                throw new NullReferenceException(nameof(array));
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

        public bool Remove(T item)
        {
            if (Items is null)
            {
                throw new NullReferenceException(nameof(Items));
            }
            else
            {
                return Items.Remove(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
