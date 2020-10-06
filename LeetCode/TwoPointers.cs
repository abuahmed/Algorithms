using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        public static void MainTwoPointer(string[] args)
        {
            //int[] nums = { -2, -1, 0, 1, 2, -4 };
            //var resul = TwoSumTwoPointers(nums, 0);

            //int[] nums = {-1, 0, 1, 2, 3, -4};
            //var resul = ThreeSum(nums);

            int[] nums = { 2, 7, 11, 15 };
            var resul = TwoSum(nums, 9);
        }

        //Conditions: all elements are Distinct
        static IList<IList<int>> TwoSumTwoPointers(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> numberOfcases = new List<IList<int>>();
            var len = nums.Length;
            int i = 0, j = len - 1;

            while (i < j)
            {
                var sum = nums[i] + nums[j];
                var list = new List<int>();
                if (sum == target)
                {
                    list.AddRange(new[] {nums[i],nums[j]});
                    //list.Add(nums[j]);
                    numberOfcases.Add(list);
                    i++;
                    j--;
                }
                if (sum < target)
                {
                    i++;
                }
                if (sum > target)
                {
                    j--;
                }
            }

            return numberOfcases;
        }

        static IList<int> TwoSumForThreeSum(int[] nums, int targetIndex)
        {
            IList<int> list = null;
            var len = nums.Length;
            int i = 0, j = len - 1;
            var target = nums[targetIndex];
            while (i < j)
            {
                if (i == targetIndex)
                {
                    i++;
                    continue;
                }
                var sum = nums[i] + nums[j];
                if (sum + target == 0)
                {
                    list = new List<int> {nums[i], nums[j], target};
                    i++;
                    j--;
                }
                if (sum < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            return list;
        }

        private static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> resultList = new List<IList<int>>();
            int i = 0;
            while (nums[i]<=0)
            {
                var res = TwoSumForThreeSum(nums, i);
                if(res!=null)
                resultList.Add(res);

                i++;
            }

            return resultList;
        }

        public int[] TwoSumBruteForce(int[] nums, int target)
        {
            int[] res = new int[2];
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        res[0] = i;
                        res[1] = j;
                        return res;
                    }
                }
            }
            return res;
        }
        
        //static int[] TwoSum(int[] nums, int target)
        //{
        //    Array.Sort(nums);
            
        //    var len = nums.Length;
        //    int i = 0, j = len - 1;

        //    while (i < j)
        //    {
        //        var sum = nums[i] + nums[j];
                
        //        if (sum == target)
        //        {

        //            return new[] { i, j };
               
        //        }
        //        if (sum < target)
        //        {
        //            i++;
        //        }
        //        if (sum > target)
        //        {
        //            j--;
        //        }
        //    }

        //    return null;
        //}
        static int[] TwoSum(int[] nums, int target)
        {
            var dict=new Dictionary<int, int>();
            
            for (int k = 0; k < nums.Length; k++)
            {
                var reqNum = target - nums[k];
                if (dict.ContainsKey(reqNum))
                    return new[] {dict[reqNum], k};
                dict[nums[k]] = k;
            }

            return null;

            Array.Sort(nums);

            var len = nums.Length;
            int i = 0, j = len - 1;

            while (i < j)
            {
                var sum = nums[i] + nums[j];

                if (sum == target)
                {

                    return new[] { i, j };

                }
                if (sum < target)
                {
                    i++;
                }
                if (sum > target)
                {
                    j--;
                }
            }

            return null;
        }
    }
}
