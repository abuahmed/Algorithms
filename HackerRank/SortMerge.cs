using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution  
    {
        private static void MainMerge(string[] args)
        {
            //var array2 = new[] {1, 4, 6, 8, 10};
            //var array3 = new[] {2, 3, 5, 22, 25};

            var array22 = new[] {2, 1, 3, 25, 4, 22, 6, 8, 5, 10,11};
            var arr3=MergeSort(array22);

            //var array1 = Merge(array2, array3);
            //var len = array1.Length;
        }

        //private static bool beginMerging = false;
        static IList<int[]> mergel=new List<int[]>(); 
        static int[] MergeSort(int[] array1)
        {
            var len = array1.Length;
            if (len == 3 || len == 4)
            {
                var array22 = new int[len/2];
                Array.Copy(array1, 0, array22, 0, len/2);
                var array33 = new int[(len/2) + len%2];
                Array.Copy(array1, len/2, array33, 0, (len/2) + len%2);

                if (array22.Length > 1)
                    if (array22[0] > array22[1])
                    {
                        var temp = array22[0];
                        array22[0] = array22[1];
                        array22[1] = temp;
                    }

                if (array33[0] > array33[1])
                {
                    var temp = array33[0];
                    array33[0] = array33[1];
                    array33[1] = temp;
                }

                return Merge(array22, array33);
            }
            else if (len == 1)
            {
                mergel.Add(array1);
                return array1;
            }
            else if (len == 2)
            {
                //beginMerging = true;
                if (array1[0] > array1[1])
                {
                    var temp = array1[0];
                    array1[0] = array1[1];
                    array1[1] = temp;
                }
                {
                    mergel.Add(array1);
                    return array1;
                }
            }
            else
            {
                var array2 = new int[len/2];
                Array.Copy(array1, 0, array2, 0, len/2);
                var array3 = new int[(len/2)+len%2];
                Array.Copy(array1, len/2, array3, 0, (len / 2) + len % 2);

                return MergeSort(array2).ToArray().Concat(MergeSort(array3).ToArray()).ToArray();
            }

        }
        static int[] Merge(int[] array2, int[] array3)
        {
            var array1=new int[array2.Length+array3.Length];
            int i1=0, i2=0, i3=0;

            while (i1 < array1.Length)
            {
                if(i2==array2.Length || i3==array3.Length)
                    break;

                if (array2[i2] < array3[i3])
                {
                    array1[i1] = array2[i2];
                    i1++;
                    i2++;
                }
                else
                {
                    array1[i1] = array3[i3];
                    i1++;
                    i3++;
                }
            }

            for (int i = i2; i < array2.Length; i++)
            {
                array1[i1] = array2[i];
                i1++;
            }

            for (int i = i3; i < array3.Length; i++)
            {
                array1[i1] = array3[i];
                i1++;
            }

            return array1;
        }
    }
}
