using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        private static void Main(string[] args)
        {
//            var nums = new int[] {1, 2, 3};
//            var res = new Combination().CombinationSum4(nums, 100);

            var nums = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
            var res = new Combination().MinCostClimbingStairs(nums);
        }
    }
    
    public class Combination
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            int f1 = 0, f2 = 0;
            for (int i = cost.Length - 1; i >= 0; --i)
            {
                int f0 = cost[i] + Math.Min(f1, f2);
                f2 = f1;
                f1 = f0;
            }
            return Math.Min(f1, f2);
        }

        public int ClimbStairs(int n)
        {
            dict = new Dictionary<int, int>();
            dict.Add(0, 1);
            var candidates=new int[]{1,2};
        
            //_dp[0] = 1;
            return CombinationSum44(candidates, n);
        }

        //private  int[] _dp;
        private Dictionary<int, int> dict; 
        public int CombinationSum4(int[] candidates, int target)
        {
            //_dp=new int[target+1];
            dict=new Dictionary<int, int>();
            dict.Add(0,1);
            //_dp[0] = 1;
            return CombinationSum44(candidates, target);
        }

        public int CombinationSum44(int[] candidates, int target)
        {
            //if (target == 0)
                //return 1;
            //if (_dp[target] != 0)
                //return _dp[target];
            if (dict.ContainsKey(target))
                return dict[target];
            int res = 0;

            for (int i = 0; i < candidates.Length; i++)
            {
                if (target >= candidates[i])
                {
                    res += CombinationSum44(candidates, target - candidates[i] );
                }
            }

            //_dp[target] = res;
            //if(Int32.MaxValue-res>dict[target])
            dict[target] = res;
            
            return res;
        }
    }
}
