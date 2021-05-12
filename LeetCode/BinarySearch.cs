using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        private static void MainBS(string[] args)
        {
            //var nums = new[] { -1, 0, 3,4, 5, 9, 12 };
            //var res = new BinarySearch().Search(nums, 12);

            var res2 = new BinarySearch().MySqrt(8);
        }

    }

    public class BinarySearch
    {
        public double MyPow(double x, int n)
        {
            int left = -10000, right = 10000;
            while (left<=right)
            {
                var m = (left + right)/2;
                if (Math.Log(m, n) == x)
                    return m;
            }
            return 0;
        }
        public int MySqrt(int x)
        {
            int left = 1, right = x;
            while (left<=right)
            {
                var mid = (left + right)/2;
                if ((int)Math.Pow(mid, 2) == x)
                    return mid;
                if ((int)Math.Pow(mid, 2) > x) right = mid - 1;
                else left = mid + 1;
            }
            return right;
        }
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;//nums.Length/2 + nums.Length%2 -1;//
                if (nums[mid] == target)
                    return mid;
                if (target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }
    }
}
