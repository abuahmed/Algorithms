using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        public static void MainSorting(string[] args)
        {
            int[] nums = new[] { 5, 2, 3, 1 };
            SortArray(nums);
            
        }

        private static int[] CombineArrays(int[] result)
        {
            return result;
        }

        //private static int[] SortArray(int[] nums)
        //{
        //    return SortArray(nums,0,nums.Length-1);
        //}

        static void SortArray(int[] nums)
        {
            int begin=0;
            //int end=nums.Length-1;
            var numsLength = nums.Length;
            if (numsLength == 1)
                return;//nums;
            //if (numsLength == 2)
            //    return swaps(nums);

            var half = nums.Length / 2 + nums.Length % 2;
            int[] L = new int[numsLength / 2];
            Array.Copy(nums,begin,L,0,numsLength/2);

            int[] R = new int[numsLength / 2] ;
            Array.Copy(nums, half, R, 0, numsLength/2);

            SortArray(L);
            SortArray(R);

            int i , j , k;
            i = j = k = 0;

            while (i < L.Length && j < R.Length )
            {
                if (L[i] < R[j])
                {
                    nums[k] = L[i];
                    i += 1;
                } 
                else
                {
                    nums[k] = R[j];
                    j += 1;
                    k += 1;
                }
            }   
            while (i < L.Length  )
            {
                nums[k] = L[i];
                i += 1;
                k += 1;
            }

            while (j < R.Length)
            {
                nums[k] = R[j];
                j += 1;
                k += 1;
            } 
                
            
            //if (end-begin < 3)
            //{
            //    if (numsLength == 1)
            //        return nums;
            //    else return swaps(nums);
            //}
            //else
            //{
            //    //var half = nums.Length/2 + nums.Length%2;

            //    return SortArray(nums, begin, half-1).Concat(SortArray(nums, half, end)).ToArray();
            //}
            
        }

        private static int[] swaps(int[] nums)
        {
            int temp = nums[0];
            nums[0] = nums[1];
            nums[1] = temp;
            return nums;
        }
    }
}
