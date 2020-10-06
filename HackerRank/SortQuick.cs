using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        static void MainQS(string[] args)
        {
            var aa = DateTime.Now.Ticks;
            quickSort(new int[] {5,3,7,2,9,1,8,0,10,-23,26,-11,200});
            var bb = DateTime.Now.Ticks;
            var cc = bb - aa;
            //var len = al.Count;
        }
        static ArrayList al=new ArrayList();
        static void quickSort(IList<int> arr)
        {
            var len = arr.Count;

            if (len == 0)
                return;

            int pivot = arr[0];

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 1; i < len; i++)
            {
                if (arr[i] > pivot)
                {
                    right.Add(arr[i]);
                }
                if (arr[i] < pivot)
                {
                    left.Add(arr[i]);
                }
            }

            quickSort(left);
            al.Add(pivot);
            quickSort(right);

            //return al;
        }

        //private static int[] quickSortEntireArray(int[] arr)
        //{
        //    //var firstpivot = arr[0];
        //    //var newArray=quickSort(arr);
            
        //    //if (newArray.Length > 1)
        //    //    quickSort(left);

        //    //if (right.Length > 1)
        //    //    quickSort(right);

        //    return null;
        //}

        //static int[] quickSort2(int[] arr)
        //{
        //    int pivot = arr[0];
        //    var len = arr.Length;
        //    int[] left=new int[arr.Length-1];
        //    int leftIndex = 0;
        //    int[] right = new int[arr.Length - 1];
        //    int rightIndex = 0;

        //    for (int i = 1; i < len; i++)
        //    {
        //        if (arr[i] > pivot)
        //        {
        //            right[rightIndex] = arr[i];
        //            rightIndex++;
        //        }
        //        if (arr[i] < pivot)
        //        {
        //            left[leftIndex] = arr[i];
        //            leftIndex++;
        //        }
        //    }

        //    int[] resArray=new int[len];
        //    for (int i = 0; i < leftIndex; i++)
        //    {
        //        resArray[i] = left[i];
        //    }
        //    resArray[leftIndex] = pivot;
        //    for (int i = 0; i < rightIndex; i++)
        //    {
        //        resArray[i+1+leftIndex] = right[i];
        //    }
        //    return resArray;
        //}

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter3.txt", true);

        //    int n = Convert.ToInt32(Console.ReadLine());

        //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        //    ;
        //    int[] result = quickSort(arr);

        //    textWriter.WriteLine(string.Join(" ", result));

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
    }
}
