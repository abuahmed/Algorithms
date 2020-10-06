using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        //private static void Main(string[] args)
        //{
        //    var arr = new[] {5, 2, 3, 8, 1};
        //    SelectionSort(arr);
        //}

        //Selection Sort
        private static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var least = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[least])
                        least = j;
                }
                if (i != least)
                    Swap(arr, i, least);
            }
        }

        private static void Swap(int[] arr, int i, int i1)
        {
            var temp = arr[i];
            arr[i] = arr[i1];
            arr[i1] = temp;
        }
    }
}