using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        private static void MainBackTrack(string[] args)
        {
            //var res = SequentialDigits(1000,13000);
            //var res = new Purmutation().countArrangement(3);
            //var res = CombinationSum3(9, 45);
            //var res = CombinationSum(new[] {3,1,2,4}, 4);
            //var dtstart = DateTime.Now;
            //var res = CombinationSum2(new[] {2, 5, 2, 1, 2}, 5);//new[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            //var dtend = DateTime.Now;
            //var duration = dtend.Subtract(dtstart).Milliseconds;

            //var res = NumTilePossibilities("");
            //var res = Combine(1, 1);
            //var il=new List<int>();
            //var res = Permute(new[] { 1, 2, 3 ,4});

            //var st = DateTime.Now;
            //var res = GetPermutation(9, 273815);//362779 //273815 = 783269514
            //var en = DateTime.Now;
            //var sub = en.Subtract(st).Milliseconds;

            //var res = LetterCombinations("2");
            var res = CombinationSum42(new[] { 2,4 }, 5);//3524578
            //var res = CombinationSum4(new[] { 1, 2, 4 }, 8);
        }
        
        
        static IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
                return new List<string>();
            string[] keys = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            var numbers = digits.ToArray().Select(s => Convert.ToInt32(s.ToString())).ToArray();

            var lists = new List<string>();
            foreach (var number in numbers)
            {
                lists.Add(keys[number - 2]);
            }

            IList<string> answers = new List<string>();

            LetterCombinations(lists, 0, answers, "");
            return answers;
        }
        private static void LetterCombinations(IList<string> keys, int index, IList<string> answers, string comb)
        {
            for (int i = 0; i < keys[index].Length; i++)
            {
                var ch = keys[index][i];
                var comb2 = comb;
                comb2 += ch;
                if (index < keys.Count - 1)
                {
                    LetterCombinations(keys, index + 1, answers, comb2);
                }
                else
                {
                    answers.Add(comb2);
                }
            }
        }

        private static string GetPermutation(int n, int k)
        {
            var nums = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                nums.Add(i + 1);
            }
            memo = new int[n];
            return GetPermutation(n, k, nums);
        }
        static string GetPermutation(int n, int k, IList<int> leftNumbers)
        {
            if (n == 0)
                return "";

            int getpermute = GetPermute(n);
            int avg = getpermute / n;
            int div = (int)Math.Ceiling(k / (double)avg);

            var num = leftNumbers[div - 1].ToString();
            leftNumbers.Remove(Convert.ToInt32(num));

            var newValue = k - (div - 1) * avg;
            return num + GetPermutation(n - 1, newValue, leftNumbers);
        }
        public static int[] memo;
        private static int GetPermute(int i)
        {
            if (i == 1)
                return 1;
            if (memo[i - 1] != 0)
                return memo[i];
            else memo[i] = i * memo[i - 1];

            return i * GetPermute(i - 1);
        }

        static IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> answers = new List<IList<int>>();

            IList<int> curindexes = new List<int>();
            PermuteUnique(nums, curindexes, answers);

            return answers;
        }
        private static void PermuteUnique(int[] nums, IList<int> curindexes, IList<IList<int>> answers)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (curindexes.Contains(i))
                    continue;

                IList<int> curindexes2 = new List<int>(curindexes);
                curindexes2.Add(i);

                if (curindexes2.Count == nums.Length)
                {
                    IList<int> curanswers2 = curindexes2.Select(i1 => nums[i1]).ToList();
                    if (!answers.Contains(curanswers2, new ListEquality()))
                        answers.Add(curanswers2);
                }

                else if (curindexes2.Count < nums.Length)
                {
                    PermuteUnique(nums, curindexes2, answers);
                }

            }

        }

        static IList<IList<int>> Permute(int[] nums, int k)
        {
            IList<IList<int>> answers = new List<IList<int>>();

            IList<int> curindexes = new List<int>();
            Permute(nums, curindexes, answers, k);

            return answers;
        }
        private static void Permute(int[] nums, IList<int> curindexes, IList<IList<int>> answers, int k)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (curindexes.Contains(i))
                    continue;
                if (answers.Count == k)
                    return;
                IList<int> curindexes2 = new List<int>(curindexes);
                curindexes2.Add(i);

                if (curindexes2.Count == nums.Length)
                {
                    IList<int> curanswers2 = curindexes2.Select(i1 => nums[i1]).ToList();

                    answers.Add(curanswers2);
                }

                else if (curindexes2.Count < nums.Length)
                {
                    Permute(nums, curindexes2, answers, k);
                }

            }

        }

        static string Permute2(int n, int k)
        {
            //IList<IList<int>> answers = new List<IList<int>>();
            string str = "";
            IList<int> curindexes = new List<int>();
            int getpermute = GetPermute(n);
            int avg = getpermute / n;
            int div = k / avg + (k % avg > 0 ? 1 : 0);

            Permute2(n, curindexes, ref str, k);

            return str;
        }
        private static void Permute2(int n, IList<int> curindexes, ref string answers, int k)
        {
            for (var i = 0; i < n; i++)
            {
                if (curindexes.Contains(i))
                    continue;
                //if (answers.Length != 0)
                //    return;
                IList<int> curindexes2 = new List<int>(curindexes);
                curindexes2.Add(i);

                if (curindexes2.Count == n)
                {
                    //IList<int> curanswers2 = curindexes2.Select(i1 => nums[i1]).ToList();
                    string str = "";
                    foreach (var i1 in curindexes2)
                    {
                        str += i1 + 1;
                    }
                    answers = str;
                    //answers.Add(str);
                }

                else if (curindexes2.Count < n)
                {
                    Permute2(n, curindexes2, ref answers, k--);
                }

            }

        }

        static IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> answers = new List<IList<int>>();
            if (k <= n)
            {
                var nums = new int[n];
                for (var i = 0; i < n; i++)
                {
                    nums[i] = i + 1;
                }

                IList<int> curanswers = new List<int>();
                Combine(k, nums, 0, answers, curanswers);
            }
            return answers;
        }
        private static void Combine(int k, int[] nums, int currentIndex, IList<IList<int>> answers, IList<int> curanswers)
        {
            for (var i = currentIndex; i < nums.Length; i++)
            {
                if (curanswers.Count == k - 1)
                {
                    IList<int> curanswers2 = new List<int>(curanswers);

                    curanswers2.Add(nums[i]);
                    answers.Add(curanswers2);
                }

                else if (curanswers.Count < k - 1)
                {
                    IList<int> curanswers2 = new List<int>(curanswers);
                    curanswers2.Add(nums[i]);
                    Combine(k, nums, i + 1, answers, curanswers2);
                }

            }

        }

        static int NumTilePossibilities(string tiles)
        {
            //if (tiles.Length == 0)
            //    return 0;
            IList<int> curindexes = new List<int>();
            HashSet<string> setsHashSet = new HashSet<string>();
            NumTilePossibilities(tiles, "", curindexes, setsHashSet);

            return setsHashSet.Count;
        }
        static void NumTilePossibilities(string tiles, string strconcated, IList<int> curindexes, HashSet<string> setsHashSet)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (curindexes.Contains(i))
                    continue;

                if (!setsHashSet.Contains(tiles[i].ToString()))
                    setsHashSet.Add(tiles[i].ToString());
                var newstr = tiles[i].ToString() + strconcated;
                if (!setsHashSet.Contains(newstr))
                    setsHashSet.Add(newstr);

                if (curindexes.Count < tiles.Length)
                {
                    IList<int> curindexes2 = new List<int>(curindexes);
                    curindexes2.Add(i);
                    NumTilePossibilities(tiles, newstr, curindexes2, setsHashSet);
                }
            }

        }

        static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> answers = new List<IList<int>>();
            IList<int> curanswers = new List<int>();
            IList<int> curindexes = new List<int>();
            Array.Sort(candidates);
            CombinationSum2(target, candidates, answers, curanswers, curindexes, 0);

            return answers;
        }
        private static void CombinationSum2(int target, int[] nums, IList<IList<int>> answers, IList<int> curanswers, IList<int> curindexes, int currentSum)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (curindexes.Contains(i))
                    continue;

                var tempsum = nums[i] + currentSum;

                if (tempsum == target)
                {
                    IList<int> curanswers2 = new List<int>(curanswers);
                    curanswers2.Add(nums[i]);

                    IList<int> curanswers3 = new List<int>(curanswers2);
                    curanswers3 = curanswers3.OrderBy(n => n).ToList();
                    if (!answers.Contains(curanswers3, new ListEquality()))
                        answers.Add(curanswers2);

                }
                else if (tempsum < target)
                {
                    IList<int> curanswers2 = new List<int>(curanswers);
                    curanswers2.Add(nums[i]);
                    IList<int> curindexes2 = new List<int>(curindexes);
                    curindexes2.Add(i);

                    CombinationSum2(target, nums, answers, curanswers2, curindexes2, tempsum);
                }
                //                else if (tempsum > target)
                //                {
                //                    break;
                //                }
            }

        }

        static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> answers = new List<IList<int>>();
            IList<int> curanswers = new List<int>();
            Array.Sort(candidates);
            CombinationSum(target, candidates, answers, curanswers, 0);

            return answers;
        }
        private static void CombinationSum(int target, int[] nums, IList<IList<int>> answers, IList<int> curanswers, int currentSum)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                var tempsum = nums[i] + currentSum;

                if (tempsum == target)
                {
                    IList<int> curanswers2 = new List<int>(curanswers);
                    curanswers2.Add(nums[i]);

                    IList<int> curanswers3 = new List<int>(curanswers2);
                    curanswers3 = curanswers3.OrderBy(n => n).ToList();
                    if (!answers.Contains(curanswers3, new ListEquality()))
                        answers.Add(curanswers2);

                }
                else if (tempsum < target)
                {
                    IList<int> curanswers2 = new List<int>(curanswers);
                    curanswers2.Add(nums[i]);
                    CombinationSum(target, nums, answers, curanswers2, tempsum);
                }
                else if (tempsum > target)
                {
                    break;
                }
            }

        }

        static IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> answers = new List<IList<int>>();
            if (k <= n)
            {
                var nums = new int[n];
                for (var i = 0; i < n; i++)
                {
                    nums[i] = i + 1;
                }

                IList<int> curanswers = new List<int>();
                int currentSum = 0;
                CombinationSum3(k, n, nums, 0, answers, curanswers, currentSum);
            }
            return answers;
        }
        private static void CombinationSum3(int k, int n, int[] nums, int currentIndex, IList<IList<int>> answers, IList<int> curanswers, int currentSum)
        {
            for (var i = currentIndex; i < n; i++)
            {
                var tempsum = nums[i] + currentSum;

                if (tempsum == n)
                {
                    if (curanswers.Count == k - 1 && nums[i] <= 9)
                    {
                        IList<int> curanswers2 = new List<int>(curanswers);

                        curanswers2.Add(nums[i]);
                        answers.Add(curanswers2);
                    }
                }
                else if (tempsum < n && curanswers.Count < k - 1)
                {
                    IList<int> curanswers2 = new List<int>(curanswers);
                    curanswers2.Add(nums[i]);
                    CombinationSum3(k, n, nums, i + 1, answers, curanswers2, tempsum);
                }
                else if (tempsum > n)
                {
                    break;
                }
            }

            //return answers;
        }

        static int CombinationSum4(int[] candidates, int target)
        {
            IList<IList<int>> answers = new List<IList<int>>();
            IList<int> curanswers = new List<int>();
            Array.Sort(candidates);
            CombinationSum4(target, candidates, answers, curanswers, 0);

            return answers.Count;
        }
        static void CombinationSum4(int target, int[] nums, IList<IList<int>> answers, IList<int> curanswers, int currentSum)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                var tempsum = nums[i] + currentSum;

                if (tempsum == target)
                {
                    IList<int> curanswers2 = new List<int>(curanswers);
                    curanswers2.Add(nums[i]);

                    answers.Add(curanswers2);

                }
                else if (tempsum < target)
                {
                    IList<int> curanswers2 = new List<int>(curanswers);
                    curanswers2.Add(nums[i]);
                    CombinationSum4(target, nums, answers, curanswers2, tempsum);
                }
                else if (tempsum > target)
                {
                    break;
                }
            }

        }

        static IList<int> SequentialDigits(int low, int high)
        {
            IList<int> answers = new List<int>();
            //var starting = Convert.ToInt32(low.ToString().ToArray()[0].ToString());
            return SequentialDigits(1, low, high, answers).OrderBy(n => n).ToList();
        }
        private static IList<int> SequentialDigits(int starting, int low, int high, IList<int> answers)
        {
            var curstr = starting.ToString();
            int i = 1;
            while (true)
            {
                if (starting + i == 10)
                    break;
                curstr += (starting + i).ToString();
                i++;
                var currnumber = Convert.ToInt32(curstr);

                if (currnumber >= low && currnumber <= high)
                    answers.Add(currnumber);
                if (currnumber > high)
                    break;
            }

            if (starting < 9)
                SequentialDigits(starting + 1, low, high, answers);

            return answers;
        }

        private static int CombinationSum42(int[] nums, int target)
        {
            if (target == 0) {
                return 1;
            }
            int res = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (target >= nums[i]) {
                    res += CombinationSum42(nums, target - nums[i]);
                }
            }
            return res;

//            int[] dp=new int[target+1];
//            Array.Sort(candidates);
//
//            Array.Copy(candidates,0,dp,1,candidates.Length);
//            dp[0] = 1;
//            for (int i = candidates.Length; i <= target; i++)
//            {
//                var sum = 0;
//                var bottom = i - candidates.Length;
//                for (int j = i-1; j >= bottom; j--)
//                {
//                    sum += dp[j];
//                }
//                dp[i] = sum;
//            }
//
//            return dp[target- 1];
        }
    }
}
