using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        static void MainSortInsertion(string[] args)
        {
            int n = 7;// Convert.ToInt32(Console.ReadLine());
            int[] arr = {7,1,3,2,4,5,6};// Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))};
            var shiftNums=insertionSortCountShifts(n, arr);
        }
        
        public static void insertionSort(int[] A)
        {
            var j = 0;
            for (var i = 1; i < A.Length; i++)
            {
                var value = A[i];
                j = i - 1;
                while (j >= 0 && value < A[j])
                {
                    A[j + 1] = A[j];
                    j = j - 1;
                }
                A[j + 1] = value;

            }
            Console.WriteLine(String.Join(" ", A));
        }

        //static void Main(string[] args)
        //{
        //    Console.ReadLine();
        //    int[] _ar = (from s in Console.ReadLine().Split() select Convert.ToInt32(s)).ToArray();
        //    insertionSort(_ar);
        //}

        private static void insertionSort2(int n, int[] arr)
        {
            int numofShifts = 0;
            for (int i = 2; i <= n; i++)
            {
                arr = insertionSortWhileLoop(i, arr);//OR insertionSort(i,arr);
                printItems(arr);
                //numofShifts += insertionSortCountShifts(i, arr);
            }
        }

        static int insertionSortCountShifts(int n, int[] arr)
        {
            //var len=arr.Length;
            int numofShifts = 0;
            for (int i = 2; i <= n; i++)
            {
                var numtoadd = arr[i - 1];
                int j = i - 2;
                while (j >= 0 && arr[j] > numtoadd)
                {
                    arr[j + 1] = arr[j];
                    numofShifts++;
                    j--;
                }
                arr[j + 1] = numtoadd;
            }
            return numofShifts;
        }

        static int[] insertionSortWhileLoop(int n, int[] arr)
        {
            //var len=arr.Length;
            var numtoadd = arr[n - 1];
            int i = n - 2;
            while (i >= 0 && arr[i] > numtoadd)
            {
                arr[i + 1] = arr[i];
                i--;
            }
            arr[i + 1] = numtoadd;

            return arr;
        }

        static int[] insertionSort(int n, int[] arr)
        {
            //var len=arr.Length;
            var numtoadd = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                if (arr[i] > numtoadd)
                {
                    arr[i + 1] = arr[i];
                }
                else
                {
                    arr[i + 1] = numtoadd;
                    break;
                }

            }

            if (arr[0] > numtoadd)
                arr[0] = numtoadd;

            return arr;
        }

        static void insertionSort1(int n, int[] arr)
        {
            //var len=arr.Length;
            var numtoadd = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                if (arr[i] > numtoadd)
                {
                    arr[i + 1] = arr[i];
                    printItems(arr);
                }
                else
                {
                    arr[i + 1] = numtoadd;
                    break;
                }

            }
            if (arr[0] > numtoadd)
                arr[0] = numtoadd;
            printItems(arr);

        }

        static void printItems(int[] arr)
        {
            var res = "";
            for (int i = 0; i < arr.Length; i++)
            {
                res = res + " " + arr[i];
            }
            Console.WriteLine(res.Trim());
        }

    }
}
