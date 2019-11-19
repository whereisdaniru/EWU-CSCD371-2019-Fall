using System;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool SortDeleg(int first, int second);
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public static int[] SelectionSort(int[]? a, SortDeleg? comparer)
        {
            if (a is null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            for (int i = 0; i < a.Length; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (comparer(a[j], a[smallest]))
                    {
                        smallest = j;
                    }
                }
                int temp = a[i];
                a[i] = a[smallest];
                a[smallest] = temp;
            }
            return a;
        }
    }
    
}
