using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        private static void MainSW(string[] args)
        {
            var nums = new[] {1, 2, 3, 4, 5};//9, 4, 2, 10, 7, 8, 6, 7, 6 };// 
            var res2 = new SlidingWindow().MaxTurbulenceSize(nums);
        }

    }

    public class SlidingWindow
    {
        public int MaxTurbulenceSize(int[] nums)
        {
            var len = nums.Length;
            if (len <= 1)
                return len;
            var max = 0;
            var previousFlag = -1;// nums[1] > nums[0];
            int counter = 1;
            int i = 1;
            while (i<len)
            {
                    if (nums[i-1] < nums[i] && (previousFlag == 1||previousFlag == -1))
                    {
                        counter++;
                        previousFlag = 0;
                        i++;
                    }
                    else if (nums[i-1] > nums[i] && (previousFlag == 0 || previousFlag == -1))
                    {
                        counter++;
                        previousFlag = 1;
                        i++;
                    }
                    else
                    {
                        max = Math.Max(counter, max);
                        counter = 2;
                        previousFlag = -1;
                        i++;
                    }

                
            }

            return Math.Max(counter, max); ;
        }
    }
}
