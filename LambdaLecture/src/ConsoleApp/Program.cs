using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static bool IsGreater(int first, int second)
        {
            return first > second;
        }

        static bool IsSumGreaterThanZero(int first, int second)
        {
            return (first + second) > 0;
        }

        static bool IsLess(int first, int second)
        {
            return first < second;
        }

        static void Main(string[] args)
        {
            int numberOfCompareCalls = 0;
            //MethodInfo myMethod = typeof(Program).GetMethod("IsGreater", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            //List<int> items2 = new List<int> { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
            int[] items = { 1, 3, 5, 7, 9, 2, 4, 6, 8 };

            //Func<int, int, bool> myAnonFunc = delegate (int i, int j)
            //{
            //    return i > j;
            //};
            Func<int, Func<int, bool>> myFunc = null;
            myFunc = (int i) =>
            {
                return j => i < j;
            };

            ////BubbleSortRemote(items, myMethod);
            BubbleSort(items, myFunc);

            foreach (int item in items)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine(numberOfCompareCalls);

            //BubbleSort(items, myFunc);

            //foreach (int item in items)
            //{
            //    Console.Write(item);
            //}
            //Console.WriteLine();
            //Console.WriteLine(numberOfCompareCalls);

            //Console.WriteLine();

            //BubbleSort(items, (i, j) => i < j);

            //foreach (int i in items)
            //{
            //    Console.Write(i);
            //}

            //string[] stooges = new string[] { "Moe", "Larry", "Curley" };
            //List<Action> actions = new List<Action>();

            //foreach (string stooge in stooges)
            //{
            //    actions.Add(() => Console.WriteLine(stooge));
            //}

            //foreach (Action action in actions)
            //{
            //    action();
            //}

            //actions = new List<Action>();
            //int i = 0;
            ////for (i = 0; i < stooges.Length; i++)
            //foreach(var stooge in stooges)
            //{
            //    actions.Add(() => Console.WriteLine(stooges[i]));
            //}
            //i = 1;
            //foreach (Action action in actions)
            //{
            //    action();
            //    i++;
            //}
        }

        static void BubbleSortRemote(int[] items, MethodInfo methodInfo)
        {
            int temp;

            if (items == null)
            {
                return;
            }

            for (int i = items.Length - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if ((bool)methodInfo.Invoke(null, new object[] { items[j - 1], items[j] }))
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        // Func<in T, out T>
        // Func<in T, in T, out T>
        // Action<in T>
        static void BubbleSort(int[] items, Func<int, Func<int, bool>> sortFunc)
        {
            int temp;

            if (items == null)
            {
                return;
            }

            for (int i = items.Length - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (sortFunc(items[j - 1])(items[j]))
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }
    }
}
