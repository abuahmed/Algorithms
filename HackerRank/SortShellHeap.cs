using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        private static void MainSSH(string[] args)
        {
            //const int sortNum = 5;
            //var arr = new[] { 10, 8, 6, 20, 4, 3, 22, 1, 0, 15, 16 };
            //ShellSort(arr, sortNum);

            var arr2 = new[] {2, 8, 6, 1, 10, 15, 3, 12, 11};
            var hp=HeapSort(arr2);
        }

        //Shell Sort
        private static void ShellSort(int[] arr,int sortNum)
        {
            for (int i = 0; i < arr.Length/sortNum; i++)
            { 
                IList<int> indexes=new List<int>();
                IList<int> values = new List<int>();

                for (int j = 0; j < arr.Length; j=j+sortNum)
                {
                    indexes.Add(j);
                    values.Add(arr[j]);
                }

                values=values.OrderBy(s => s).ToList();//Here use Insertion Sort

                int q = 0;
                foreach (var index in indexes)
                {
                    arr[index] = values[q];
                    q++;
                }
            }
            if (sortNum > 1)
            {
                sortNum = sortNum - 2;
                ShellSort(arr,sortNum);
            }

            var len = arr.Length;

        }

        //Heap Sort
        private static int[] HeapSort(int[] arr)
        {
            //var arr = new[] {2, 8, 6, 1, 10, 15, 3, 12, 11};
            IList<int[]> trees=new List<int[]>();
            int rank = 1;
            int collected = 0;
            while (collected<arr.Length)
            {
                trees.Add(arr.Skip(collected).Take(rank).ToArray());
                collected += rank;
                rank = rank*2;
            }

            //Transform Array to Heap
            bool swapRequired = true;
            while (swapRequired)
            {
                swapRequired = false;
                for (int i = trees.Count - 1; i > 0; i--)
                {
                    var curin = 0;
                    for (int i1 = 0; i1 < trees[i].Length; i1=i1+2)
                    {
                        curin = i1/2;
                        if (i1 + 1 < trees[i].Length)
                        {
                            if (trees[i][i1] > trees[i - 1][curin] ||
                                trees[i][i1 + 1] > trees[i - 1][curin])
                            {
                                if (trees[i][i1] > trees[i][i1 + 1])
                                {
                                    var temp = trees[i][i1];
                                    trees[i][i1] = trees[i - 1][curin];
                                    trees[i - 1][curin] = temp;
                                }
                                else
                                {
                                    var temp = trees[i][i1 + 1];
                                    trees[i][i1 + 1] = trees[i - 1][curin];
                                    trees[i - 1][curin] = temp;
                                }

                                swapRequired = true;
                            }
                        }
                        else
                        {
                            if (trees[i][i1] > trees[i - 1][curin])
                            {
                                var temp = trees[i][i1];
                                trees[i][i1] = trees[i - 1][curin];
                                trees[i - 1][curin] = temp;
                            }
                        }
                    
                    }

                }

            }

            //Construct Array
            var arrayCosn = new int[arr.Length];
            var arrayCosnin = 0;
            for (int i = 0; i < trees.Count ; i++)
            {
                for (int i1 = 0; i1 < trees[i].Length; i1++)
                {
                    arrayCosn[arrayCosnin] = trees[i][i1];
                    arrayCosnin++;
                }
            }

            var tempp = arrayCosn[0];
            arrayCosn[0] = arrayCosn[arr.Length - 1];
            arrayCosn[arr.Length - 1] = tempp;

            if (arr.Length > 2)
            {
                return HeapSort(arrayCosn.Take(arr.Length - 1).ToArray()).ToArray().Concat(new[] {tempp}).ToArray();
            }
            else return arrayCosn;// new[] {tempp};

            //var len = trees.Count;
            return null;
        }
    }
}
