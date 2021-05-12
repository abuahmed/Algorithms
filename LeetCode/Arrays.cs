using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    
    partial class Solution
    {
        private static void MainArrays(string[] args)
        {
            #region Tests
            //var nums = new[] {1};//-2, 1, -3, 4, -1, 2, 1, -5, 4};
            //var maxArray = MaxSubArray(nums);

            //var nums = new[] {2, 1, 1,2};//{ 2, 7, 9, 3, 1 };// 
            //var maxArray = Rob(nums);
            //var len = maxArray;
            ////var result = largestTimeFromDigits(new[] { 2, 0, 6, 6 });

            //            int[] nums1 = { 0 };// {1, 2, 3, 0, 0, 0}, 
            //            int[] nums2 = { 1 };// {2, 5, 6};
            //            const int m = 0;
            //            const int n = 1;
            //            Merge(nums1, m, nums2, n);

            //int[] nums = { 1, 2, 3 };// { 1, 0, 2, 3, 0, 4, 5, 0 };
            //DuplicateZeros(nums);

            //int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
            //var result = RemoveElement(nums, 2);

            //int[] nums = {0, 0, 1, 1, 1, 2, 2, 3, 3, 4};//{1, 1, 2};//
            //var resul = RemoveDuplicates(nums);

            //int[] maxPr ={ 7, 1,3, 5, 3, 6, 3 };// {1, 2, 3, 4, 5};// {7, 1, 5, 3, 6, 4};// 
            //var resmaxPr = MaxProfittotalSum(maxPr);

            //int[] sortedarr = { -4, -1, 0, 3, 10 };// {-7,-3,2,3,11};
            //var resmaxPr = SortedSquaresInPlace(sortedarr);

            //int[] nums = {0,1,2,1,0};// { 0, 2,3,4,5,2,1,0 };
            //var result = ValidMountainArray(nums);

            //int[] nums = { 17};//, 18, 5, 4, 6, 1 };// { 0, 2,3,4,5,2,1,0 };
            //var result = ReplaceElements(nums);

            //int[] nums = { 0, 1, 0, 3, 12 };// { 0, 2,3,4,5,2,1,0 };
            //MoveZeroes(nums);

            //int[] nums = {1, 3};// 3, 1, 2, 4 };// { 0, 2,3,4,5,2,1,0 };
            //var result=SortArrayByParity(nums);

            //int[] sortedarr = { 1, 1, 4, 2, 1, 3 };// {-7,-3,2,3,11};
            //var resmaxPr = HeightChecker(sortedarr);

            //int[] sortedarr = { 1,2, 2, 5,3, 5 };// {-7,-3,2,3,11};
            //var resmaxPr = ThirdMax(sortedarr);

            //int[] nums = { 4, 3, 2, 7, 8, 2, 3, 1 };
            //var resmaxPr = FindDisappearedNumbers(nums);

            //int[] nums = { 4, 3, 5, 7, 8, 2, 6, 1 };
            //var result = ContainsDuplicates(nums);

            //int[] nums = { 1,2,3,4,5,6,7 };
            //var result = Rotate(nums,3);

            //int[] nums = {2, 2, 1};// { 4, 1, 2, 1, 2 };
            //var result = SingleNumber(nums);

            //int[] nums = { 0 };// { 4, 1, 2, 1, 2 };
            //var result = PlusOne(nums);

            //char[,] board = new char[9,9]
            //{
            //    {'5', '3', '.', '.', '7', '.', '.', '.', '.'}, 
            //    {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
            //    {'.', '9', '8', '.', '.', '.', '.', '6', '.'}, 
            //    {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            //    {'4', '.', '.', '8', '.', '3', '.', '.', '1'}, 
            //    {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            //    {'.', '6', '.', '.', '.', '.', '2', '8', '.'}, 
            //    {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            //    {'.', '.', '.', '.', '8', '.', '.', '7', '9'} };
            //IsValidSudoku(board);

            //var nums1 = new[] {-2147483648, 1, 2, 3};//{4, 9, 5};// {1, 2, 2, 1};
            //var nums2 = new[] {1, -2147483648, -2147483648};// {9, 4, 9, 8, 4};// {2, 2};
            //var res = IntersectSorted(nums1, nums2);

            //var nums = new[] { 1, 3, 4, 2, 2 };
            //var res = FindDuplicate(nums);

            //var res = IsPowerOfThree(-3);

            //var nums = new[] {-2, 2, 5, -11, 6};// 5, 7, -3, 2, 9, 6, 16, 22, 21, 29, -14, 10, 12 };
            //var res = KadanesAlgo(nums);
            /*[2147483646,2147483647]33             */
            //var nums = new[] {1, 2, 3, 1 };// 1, 5, 9, 1, 5, 9 };// 4, 1, -1, 6, 5};//1, 5, 9, 1, 5, 9};//7, 1,3 };// 1, 0, 1, 1 };//8,7,15,1,6,1,9,15};//1, 2, 3, 1 };//1, 2, 3, 1, 2, 3};// 
            ////var res = ContainsNearbyDuplicate(nums,1);
            //var res = ContainsNearbyAlmostDuplicate(nums,3, 0);

            //var nums = new[] {1, 1, 2, 2, 3, 4 };//2, 2};//1, 1, 2, 3};// 
            //var res = DistributeCandies(nums);

            //var nums = new[] {1, 2, 3, 4};// 1, 2, 3, 1, 1, 3 };//2, 2};//1, 1, 2, 3};// 
            //var res = NumIdenticalPairs(nums);

            //var result = IsIsomorphic("egg", "add");

            //var nums = new[] {2, 3, -2, 4 };// 2, -5, -2, -4, 3 };// -2, 3, -4 };//-2, 0, -1};// -2, 3, -4};//-1, -2, -3, 0};//
            //var res = MaxProduct(nums);

            //            var nums = new[] {-2147483648,-2147483647};//1, 2, 3, 1 };//1, 2, 1, 3, 5, 6, 4};//4,2,3};// 
            //            var res = FindPeakElement(nums);
            //int[][] mat = new int[0][];
            //mat[0] = new[] {};
            //mat[0] = new[] { 1, 2, 3 };
            //mat[1] = new[] { 4, 5, 6 };
            //mat[2] = new[] { 7, 8, 9 };
            //mat[0] = new[] { 1, 1, 1, 1 };
            //mat[1] = new[] { 1, 1, 1, 1 };
            //mat[2] = new[] { 1, 1, 1, 1 };
            //mat[3] = new[] { 1, 1, 1, 1 };

            //var res = DiagonalSum(mat);
            //var res = FindKthPositive(new[] { 2, 3, 4, 7, 11 }, 6);

            //int[] nums = { 1, 2, 1, 3, 2, 5 };// { 4, 1, 2, 1, 2 };
            //var result = SingleNumber3(nums);

            //int[] nums = {999999998,999999997,999999999};// { 34, 3433 };//{120,12};//{824,8247};// { 3, 30, 34, 5, 9 };// {10, 2};//  
            //var result = LargestNumber(nums); 
            
            
            //int[] nums = { 0, 0, 1, 0, 0 };
            //var result = CanPlaceFlowers(nums,2);

            //int[] nums = { 2, 0, 1, 0, 2 };
            //SortColors(nums);
            #endregion

            //var res = UniquePaths(50, 50);
            var res = FindPairs(new[] {1,3,1,5,4}, 0);//new[] {6,3,5,7,2,3,3,8,2,4}, 2);//new[] { 1, 2, 4, 4, 3, 3, 0, 9, 2, 3 }, 3);//new[] { 3, 1, 4, 1, 5, 3 }, 2);//new[] { 1}, 0);//
        }

        static int FindPairs(int[] nums, int k)
        {
            //Array.Sort(nums);
            var hashSet = new HashSet<int>();
            var hashSetAlreadyCounted = new HashSet<int>();
            var counter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashSetAlreadyCounted.Contains(nums[i]) || hashSetAlreadyCounted.Contains(nums[i]-k))
                    continue;
                
                var maxNum = nums[i] + k;
                var minNum = nums[i] - k;
                
                if (hashSet.Contains(maxNum))
                {
                    counter++;
                    hashSetAlreadyCounted.Add(nums[i]);
                }
                
                if (hashSet.Contains(minNum) && k!=0)
                {
                    counter++;
                    hashSetAlreadyCounted.Add(minNum);
                }

                if (!hashSet.Contains(nums[i]))
                    hashSet.Add(nums[i]);
                
            }
            return counter;
        }

        static int UniquePaths(int m, int n)
        {
            var matrix=new int[m,n];
            var count = 0;
            UniquePaths(m,n,0, 0,m - 1, n - 1, matrix, ref count);
            return count;

        }

        private static void UniquePaths(int m,int n, int startm, int startn, int endm, int endn, int[,] matrix, ref int count)
        {
            if (startm == endm && startn == endn)
            {
                count++;
            }

            if (startm + 1 < m)
            {
                UniquePaths(m, n, startm + 1, startn, endn, endm, matrix, ref count);
            }
            if (startn + 1 < n)
            {
                UniquePaths(m, n, startm, startn + 1, endn, endm, matrix, ref count);
            }

        }


        static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var answers=new double[queries.Count];
            for (int i=0;i<queries.Count;i++)
            {
                var query = queries[i];
                if (query[0] == query[1])
                    answers[i] = values[0]/values[0];

                if (equations.Contains(query))
                {
                    
                }

            }

            return answers;
        }
        static void SortColors(int[] nums)
        {
            var colors = new int[3];
            for (int i = 0; i < nums.Length; i++)
            {
                colors[nums[i]]++;
            }
            int j = 0;

            for (int i = 0; i < colors.Length; i++)
            {
                for (int k = 0; k < colors[i]; k++)
                {
                    nums[j] = i;
                    j++;
                }
            }

        }

        static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0)
                {
                    if ((i==0 || (i - 1 >= 0 && flowerbed[i - 1] == 0)) &&
                        (i == flowerbed.Length-1 || (i + 1 < flowerbed.Length && flowerbed[i + 1] == 0)))
                    {
                        flowerbed[i] = 1;
                        n--;
                    }

                }
            }

            if (n == 0)
                return true;
            return false;
        }
        /*
         * Given a sorted list of already scheduled programs and a list of new programs, write an algorithm to find if the given new programs can be scheduled or not? Each program is a pair of values where 1st value is the starting time and 2nd is the execution time.

            Example 1:

            Input: scheduled = [P1(10, 5), P2(25, 15)], newPrograms = [P3(18, 7), P4(12, 10)]
            Output: [true, false]
            Explanation: P3(18, 7) starts at time 18 and executes for 7 mins i.e., the end time is 18 + 7 = 25.
            So this time slot is free and there is no overlap with already scheduled programs. Hence P3 can be scheduled. 
            As the P4 overlaps with P1, so P4 cannot be scheduled.
            Example 2:

            Input: scheduled = [P1(10, 5), P2(25, 15)], newPrograms = [P3(18, 7), P4(20, 2)]
            Output: [true, false]
            Explanation: P3 can be scheduled so we add it to already scheduled programs. P4 overlaps with P3, so P4 cannot be scheduled.
         */
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            if (timeSeries.Length == 0)
                return 0;

            var total = 0;
            for (int i = 1; i < timeSeries.Length; i++)
            {
                total += Math.Min(timeSeries[i] - timeSeries[i - 1], duration);
            }

            //Add Directly the duration on the Last Attack
            return total + duration;

        }

        static string LargestNumber(int[] nums)
        {
            Array.Sort(nums,new SortMerge());
            var res=string.Join("",nums);
            while (res.Length>1 && res[0]=='0')
            {
                res = res.Substring(1);
            }
            return res;
        }
        static int[] SingleNumber3(int[] nums)
        {
            //int[] answers=new int[2];
            var dict = new Dictionary<int, int>();
            var dict2 = new Dictionary<Dictionary<int,int>, int>();
            dict2.Add(dict,2);
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else dict[num] = 1;
            }
            var keys = dict.Where(k => k.Value == 1).ToList();
            return keys.Select(s=>s.Key).ToArray();

            //var xor = 0;
            //foreach (var num in nums)
            //{
            //    xor ^= num;
            //}
            //int bit = xor & ~(xor - 1);
            //var xorstr = Convert.ToString(xor, 2);
            //int ind=xorstr.IndexOf("1");

            //IList<int> zeros=new List<int>();
            //IList<int> ones=new List<int>();
            //foreach (var num in nums)
            //{
            //    var numstr = Convert.ToString(num, 2);
            //    if (numstr[ind] == '0')
            //    {
            //        zeros.Add(num);
            //    }
            //    else
            //    {
            //        ones.Add(num);
            //    }
            //}
            //var xorzeros = 0;
            //foreach (var zero in zeros)
            //{
            //    xorzeros ^= zero;
            //}
            //answers[0] = xorzeros;
            //var xorones = 0;
            //foreach (var one in ones)
            //{
            //    xorones ^= one;
            //}
            //answers[1] = xorones;
            //return answers;
        }
        static int DiagonalSum(int[][] mat)
        {
            var hashSet = new HashSet<string>();
            int height = mat.Length;
            if (height == 0)
                return 0;
            int width = mat[0].Length;
            if (width == 0)
                return 0;
            var norm = height - 1;
            var sum = 0;
            for (int i = 0; i < height; i++)
            {
                if (!hashSet.Contains(i + "_" + i))
                {
                    hashSet.Add(i + "_" + i);
                    sum += mat[i][i];
                }
                if (!hashSet.Contains(i + "_" + norm))
                {
                    hashSet.Add(i + "_" + norm);
                    sum += mat[i][norm];
                }
                norm--;
            }
            return sum;

        }



        static int FindKthPositive(int[] arr, int k)
        {
            int counter = 1;
            int missedNum = 0;
            int i = 0;
            while (i < arr.Length)
            {
                if (arr[i] != counter)
                {
                    missedNum++;
                    if (missedNum == k)
                        return counter;
                }
                else
                {
                    i++;
                }
                counter++;
            }


            return arr[arr.Length - 1] + k - missedNum;
        }
        static int FindPeakElement(int[] nums)
        {
            Int64 lo = Int64.MinValue;
            string ss = "l";
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > lo)
                {
                    ss += "u";
                }
                else if (nums[i] < lo)
                {
                    ss += "l";
                }
                else ss += "e";//e for same level
                lo = nums[i];

            }
            ss += "l";

            for (int i = 0; i <= ss.Length - 3; i++)
            {
                if (ss.Substring(i, 3) == "uul" || ss.Substring(i, 3) == "lul")
                {
                    return i;
                }
            }

            return 0;
        }
        static int MaxProduct(int[] nums)
        {
            int productmax,curmin;
            var curmax = productmax = curmin = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    var temp = curmax;
                    curmax = curmin;
                    curmin = temp;
                }

                curmin = Math.Min(nums[i], Math.Min(nums[i]*curmin,nums[i]*nums[i-1]));
                curmax = Math.Max(nums[i], Math.Max(nums[i] * curmax, nums[i]*nums[i-1]));


                productmax = Math.Max(productmax, Math.Max(curmax,curmin));
            }

            return productmax;

            var curmaxtotal = nums[0];


            for (int i = 1; i < nums.Length; i++)
            {
                curmaxtotal *= nums[i];
                curmax = Math.Max(Math.Max(nums[i], curmax*nums[i]),curmaxtotal);
                
                productmax = Math.Max(productmax, curmax);
            }
            curmax =curmaxtotal= nums[nums.Length - 1];
            for (int i = nums.Length-2; i >=0; i--)
            {
                curmaxtotal *= nums[i];
                curmax = Math.Max(Math.Max(nums[i], curmax * nums[i]), curmaxtotal);
                
                productmax = Math.Max(productmax, curmax);
            }

            return productmax;
        }
        static int MaxProduct2(int[] nums)
        {
            int productmax;
            var curmax = productmax = nums[0];
            var curmaxtotal = nums[0];
            for (int i=1;i<nums.Length;i++)
            {
                //curmaxtotal *= nums[i];
                if (nums[i] <0)
                {
                    var temp = curmax;
                    curmax = curmaxtotal;
                    curmaxtotal = temp;

                }
                curmax = Math.Max(nums[i], curmax*nums[i]);// Math.Max(Math.Max(nums[i], curmax*nums[i]),curmaxtotal);
                curmaxtotal = Math.Min(nums[i], curmaxtotal * nums[i]);

                productmax = Math.Max(curmaxtotal, curmax);
            }
            return productmax;
        }
        static int NumIdenticalPairs(int[] nums)
        {
            var count = 0;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    count += dict[nums[i]];
                    dict[nums[i]] ++;
                }
                else
                {
                    dict[nums[i]] = 1;
                }
            }
            return count;
        }
        public int NumJewelsInStones(string J, string S)
        {
            return Regex.Replace(S, "[^"+J+"]", "").Count();
        }
        static bool IsIsomorphic(string s, string t)
        {
            var dict = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    if(t[i]!=dict[s[i]])
                        return false;
                }
                else if (dict.ContainsValue(t[i]))
                {
                     return false;
                }
                else
                {
                    dict.Add(s[i],t[i]);
                }
            }
            return true;
        }
        static int DistributeCandies(int[] candies)
        {
            var half = candies.Length / 2;
            var hashSet = new HashSet<int>();
            var countdistinct = 0;
            for (int i = 0; i < candies.Length; i++)
            {
                if (!hashSet.Contains(candies[i]))
                {
                    hashSet.Add(candies[i]);
                    countdistinct++;
                }
                if (countdistinct == half)
                    return countdistinct;
            }
            return countdistinct;
        }
        static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (k > nums.Length)
                k = nums.Length-1;
           
            for (int i = 0; i < nums.Length-1; i++)
            {
                for (int j = i+1; j <= i+k && j<nums.Length; j++)
                {
                    Int64 va = Convert.ToInt64(nums[i]) - Convert.ToInt64(nums[j]);
                    if(Math.Abs(va)<=t)
                        return true;
                }
            }
            return false;

            var hashTable = new Dictionary<int, int>();
            hashTable[nums[0]] = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                var difValue = nums[i] + t;
                var difIndex = i - k;

                if (hashTable.ContainsKey(difValue) && hashTable[difValue]==difIndex)
                {
                    //if (Math.Abs(i - hashTable[nums[i]]) <= k && 
                    //    Math.Abs(nums[i] - nums[hashTable[nums[i]]]) <= t)
                    //{
                        return true;
                    //}
                    //hashTable[nums[i]] = i;
                }
                else
                {
                    hashTable.Add(nums[i], i);
                }
            }

            return false;
        }
        static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var hashTable = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashTable.ContainsKey(nums[i]))
                {
                    if (Math.Abs(i - hashTable[nums[i]]) <= k)
                    {
                        return true;
                    }
                    else
                    {
                        hashTable[nums[i]] = i;
                    }
                }
                else
                {
                    hashTable.Add(nums[i],i);
                }
            }
            
            return false;
        }

        private static int KadanesAlgo(int[] nums)
        {
            int cur_max = 0, totmax=0;
            cur_max = totmax = nums[0];
            int beginindex = 0,lastindex=0;

            for (int i = 1; i < nums.Length; i++)
            {
                //cur_max = Math.Max(nums[i], cur_max + nums[i]);
                if (cur_max + nums[i] < (nums[i]))
                {
                    cur_max = nums[i];
                    beginindex = i;
                }
                if (cur_max < totmax)
                {
                    totmax = cur_max;
                    lastindex = i;
                }
                //totmax = Math.Max(totmax, cur_max);
            }

            return totmax;
        }

        static bool IsPowerOfThree(int n)
        {
            //if (n == 0)
            //    return false;
            var va = Math.Log(n, 3);
            if (double.IsNaN(va) ||double.IsInfinity(va))
                return false;
            return !va.ToString().Contains('.');
        }

        static int FindDuplicate(int[] nums)
        {
            int tortoise = nums[0];
            int hare = nums[0];
            do
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            } while (tortoise != hare);

            // Find the "entrance" to the cycle.
            tortoise = nums[0];
            while (tortoise != hare)
            {
                tortoise = nums[tortoise];
                hare = nums[hare];
            }

            return hare;

            int len = nums.Length - 1;
            var arr = new int[len];

            for (int i = 0; i < nums.Length; i++)
            {
                if (arr[nums[i] - 1] < 0)
                {
                    return nums[i];
                }
                arr[nums[i] - 1] = -1;
            }
            return 0;
        }

        private static int[] IntersectSorted(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            var list = new List<int>();
            int i = 0, j = 0;
            while (i<nums1.Length && j<nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    list.Add(nums1[i]);
                    i++;
                    j++;
                }
                else if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    j++;
                }
            }

            return list.ToArray();
        }

        static int[] Intersect(int[] nums1, int[] nums2)
        {
            var list = new List<int>();
            bool[] nums11 = new bool[nums1.Length];
            bool[] nums22 = new bool[nums2.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] == nums2[j] && nums11[i] != true && nums22[j] != true)
                    {
                        list.Add(nums1[i]);
                        nums11[i] = true;
                        nums22[j] = true;
                    }
                }
            }

            return list.ToArray();

//            //OR
//            HashMap<Integer, Integer> map = new HashMap<Integer, Integer>();
//            ArrayList<Integer> result = new ArrayList<Integer>();
//            for (int i = 0; i < nums1.length; i++)
//            {
//                if (map.containsKey(nums1[i])) map.put(nums1[i], map.get(nums1[i]) + 1);
//                else map.put(nums1[i], 1);
//            }
//
//            for (int i = 0; i < nums2.length; i++)
//            {
//                if (map.containsKey(nums2[i]) && map.get(nums2[i]) > 0)
//                {
//                    result.add(nums2[i]);
//                    map.put(nums2[i], map.get(nums2[i]) - 1);
//                }
//            }
//
//            int[] r = new int[result.size()];
//            for (int i = 0; i < result.size(); i++)
//            {
//                r[i] = result.get(i);
//            }
//
//            return r;
        }

        static bool IsValidSudoku(char[,] board)
        {
            /*if (number != '.')
                if (!seen.add(number + " in row " + i) ||
                    !seen.add(number + " in column " + j) ||
                    !seen.add(number + " in block " + i/3 + "-" + j/3))
                    return false;
             */
            var containsString=new HashSet<string>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var value = board[i,j].ToString();
                    if (value!=".")
                    {
                        var rowVal = "row_" + i +"_" +value;
                        var colVal = "col_" + j + "_" + value;
                        var sqVal = "square_" + value + "_" + i/3 + "_s_"+j/3;

                        if (containsString.Contains(rowVal))
                            return false;
                        else containsString.Add(rowVal);
                        if(containsString.Contains(colVal))
                            return false;
                        else containsString.Add(colVal);
                        if(containsString.Contains(sqVal))
                            return false;
                        else containsString.Add(sqVal);
                    }

                }
                
            }
            return true;
        }
        static int[] PlusOne(int[] digits)
        {
            var lastItem = digits[digits.Length - 1];
            if (lastItem < 9)
                digits[digits.Length - 1] = lastItem + 1;
            else
            {
                digits[digits.Length - 1] = 0;
                int j = digits.Length - 2;
                while (j>=0)
                {
                    if (digits[j] == 9)
                    {
                        digits[j] = 0;
                        j--;
                    }
                    else
                    {
                        digits[j] = digits[j] + 1;
                        break;
                    }
                }
                if (j < 0)
                    return new int[] {1}.Concat(digits).ToArray();
                
            }

            return digits;
            //var dig =Convert.ToInt32(string.Join("", digits))+1;
            //var arrsplited = dig.ToString().ToArray();
            //return arrsplited.Select(s=>Convert.ToInt32(s.ToString())).ToArray();
            
        }
        

        static int SingleNumber(int[] nums)
        {
                int sumOfSet = 0, sumOfNums = 0;
                ISet<Int32> set = new HashSet<Int32>();

                foreach (int num in nums) {
                  if (!set.Contains(num)) {
                    set.Add(num);
                    sumOfSet += num;
                  }
                  sumOfNums += num;
                }
                return 2 * sumOfSet - sumOfNums;

            //OR
             int a = 0;
                foreach (int i in nums) {
                  a ^= i;
                }
                return a;
            //OR
            Array.Sort(nums);
            for (int i = 0; i < nums.Length-1; i=i+2)
            {
                if (nums[i] != nums[i + 1])
                    return nums[i];
            }
            return nums[nums.Length - 1];
        }
        static int[] Rotate(int[] nums, int k)
        {
            var len = nums.Length;
            while (k > 0)
            {
                int lastitem = nums[len - 1];
                for (int i = len-1; i > 0; i--)
                {
                    nums[i] = nums[i - 1];
                }
                nums[0] = lastitem;
                k--;
            }
            return nums;
        }
        private static IList<int> FindDisappearedNumbers(int[] nums)
        {
            int n = nums.Length;
            IList<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if(nums[i]==-1)
                    continue;
                var num = nums[i];
                var indofNum = num - 1;

                if (indofNum != i)
                {
                    //do swapping
                    var tobeswapped = nums[indofNum];
                    nums[indofNum] = -1;
                    while (tobeswapped != -1)
                    {
                        var temp = tobeswapped;
                        tobeswapped = nums[tobeswapped-1];
                        nums[temp - 1] = -1;
                    }
                }
                else
                {
                    nums[indofNum] = -1;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i]>0)
                    list.Add(i+1);
            }
            return list;

            ////Below just to get the repeated values
            //int index = Math.Abs(nums[i]) - 1;
            //if (nums[index] < 0) list.Add(index + 1);
            //nums[index] = -nums[index];
        }

        //static IList<int> FindDisappearedNumbers(int[] nums)
        //{
        //    int n = nums.Length;
        //    IList<int> list=new List<int>();
        //    for (int i = 1; i <= n; i++)
        //    {
        //        bool found = false;
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (i == nums[j])
        //            {
        //                found = true;
        //                break;
        //            }
        //        }
        //        if (!found)
        //        {
        //            list.Add(i);
        //        }
        //    }
            
        //    return list;
        //}
        static int ThirdMax(int[] nums)
        {
            long firstMax = -2147483649, secondMax = -2147483649, thirdMax = -2147483649;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > firstMax)
                {
                    thirdMax = secondMax;
                    secondMax = firstMax;
                    firstMax = nums[i];
                }
                else if (nums[i] > secondMax && nums[i]!=firstMax)
                {
                    thirdMax = secondMax;
                    secondMax = nums[i];
                }
                else if (nums[i] > thirdMax && nums[i] != firstMax && nums[i] != secondMax)
                {
                    thirdMax = nums[i];
                }
            }
            if (thirdMax > -2147483649)
                return (int) thirdMax;
            return (int) firstMax;
        }
        static int HeightChecker(int[] heights)
        {
            var heightssorted = heights.OrderBy(a => a).ToArray();
            var count = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != heightssorted[i])
                    count++;
            }
            return count;
        }
        static int[] SortArrayByParity(int[] arr)
        {
            int i = 0;
            int j = arr.Length - 1;
            if (arr.Length == 1)
                return arr;
            while (i<j)
            {
                if (arr[i]%2 == 1)
                {
                    if (arr[j]%2 == 0)
                    {
                        var temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                        i++;
                        j--;
                    }
                    else
                    {
                        j--;
                    }
                }
                else
                {
                    i++;
                }
            }
            return arr;
        }
        static int[] ReplaceElements(int[] arr)
        {
            if (arr.Length == 1)
                return new[] {-1};
            for (int i = 0; i < arr.Length-1; i++)
            {
                var max = arr[i + 1];
                for (int j = i+2; j < arr.Length; j++)
                {
                    max = Math.Max(max, arr[j]);
                }
                arr[i] = max;
            }
            arr[arr.Length - 1] = -1;
            return arr;
        }
        static bool ValidMountainArray(int[] arr)
        {
            if(arr.Length<3)
                return false;
            bool isincreasing = true;
            if(arr[1]<arr[0])
                return false;
            int i = 1;
            while ( i < arr.Length-1)
            {
                if (arr[i + 1] == arr[i])
                    return false;

                if (arr[i + 1] - arr[i] < 0)
                    isincreasing = false;

                if(!isincreasing && arr[i+1]>arr[i])
                    return false;
                i++;
            }
            if(!isincreasing && i==arr.Length-1)
                return true;

            return false;

            /* Optimal solution
             *         int N = A.length;
        int i = 0;

        // walk up
        while (i+1 < N && A[i] < A[i+1])
            i++;

        // peak can't be first or last
        if (i == 0 || i == N-1)
            return false;

        // walk down
        while (i+1 < N && A[i] > A[i+1])
            i++;

        return i == N-1;
             */
        }
        static bool CheckIfExist(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (i != j)
                    {
                        if(arr[i]==2*arr[j] || arr[j]==2*arr[i])
                            return true;
                    }
                }
            }
            return false;
        }
        static int[] SortedSquares(int[] a)
        {
            int[] asquared = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                asquared[i] = (int)Math.Pow(a[i], 2);
                int j = i - 1;
                while (j >= 0)
                {
                    if (asquared[j + 1] < asquared[j])
                    {
                        int temp = asquared[j];
                        asquared[j] = asquared[j + 1];
                        asquared[j + 1] = temp;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return asquared;
        }
        static int[] SortedSquaresInPlace(int[] a)
        {
            //int[] asquared = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = (int)Math.Pow(a[i], 2);
                int j = i - 1;
                while (j >= 0)
                {
                    if (a[j + 1] < a[j])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return a;
        }
        static string largestTimeFromDigits(int[] A)
        {
            int maxh0 = 2, maxh1 = 3, maxm0 = 5, maxm1 = 9;
            string maxHour = "";
            var aList = new ArrayList(A);

            while (maxh0 >= 0)
            {
                if (aList.Contains(maxh0))
                {
                    int ind = aList.IndexOf(maxh0);
                    maxHour += aList[ind].ToString();
                    aList.RemoveAt(ind);
                    break;
                }
                else { maxh0--; }
            }
            if (maxh0 < 0)
                return "";
            if (maxh0 < 2)
                maxh1 = 9;
            while (maxh1 >= 0)
            {
                if (aList.Contains(maxh1))
                {
                    int ind = aList.IndexOf(maxh1);
                    maxHour += aList[ind].ToString();
                    aList.RemoveAt(ind);
                    break;
                }
                else { maxh1--; }
            }
            if (maxh1 < 0)
                return "";
            while (maxm0 >= 0)
            {
                if (aList.Contains(maxm0))
                {
                    int ind = aList.IndexOf(maxm0);
                    maxHour += ":" + aList[ind].ToString();
                    aList.RemoveAt(ind);
                    break;
                }
                else { maxm0--; }
            }
            if (maxm0 < 0)
                return "";
            while (maxm1 >= 0)
            {
                if (aList.Contains(maxm1))
                {
                    int ind = aList.IndexOf(maxm1);
                    maxHour += aList[ind].ToString();
                    aList.RemoveAt(ind);
                    break;
                }
                else { maxm1--; }
            }
            if (maxm1 < 0)
                return "";


            return maxHour;
        }

        static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                ShiftArrayElements(nums1,nums2[i]);
            }
        }

        private static void ShiftArrayElements(int[] nums1,int target)
        {
            int i = 0;
            while (i < nums1.Length)
            {
                if (nums1[i] > target)
                {
                    for (int j = nums1.Length - 2; j >= i; j--)
                    {
                        nums1[j + 1] = nums1[j];
                    }
                    nums1[i] = target;
                    break;
                    //i = i + 2;
                }else if (i>0 && nums1[i] < nums1[i - 1])
                {
                    nums1[i] = target;
                    break;
                }
                else
                    i++;
            }
            if (i == nums1.Length)
                nums1[i-1] = nums1[i-1]>target?nums1[i-1]:target;
        }

        static void DuplicateZeros(int[] arr)
        {
            int i = 0;
            while (i < arr.Length-1)
            {
                if (arr[i] == 0)
                {
                    for (int j = arr.Length - 2; j > i; j--)
                    {
                        arr[j + 1] = arr[j];
                    }
                    arr[i + 1] = 0;
                    i = i + 2;
                }
                else
                   i++; 
            }

            //int len = arr.Length;
        }
        
        static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            return i;
        }
        static void MoveZeroes(int[] nums)
        {
            //if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            while (i < nums.Length)
            {
                nums[i] = 0;
                i++;
            }
        }
        static int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }

        private static int Rob(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            int length = nums.Length;

            var currentMaxOdd = Int32.MinValue;
            int totalMaxOdd = Int32.MinValue;

            var lasti = 0;
            int i = 0;
            while (i < length)
            {
                if (lasti + 1 < length)
                {
                    if (nums[i] > nums[i + 1])
                        lasti = i;
                    else lasti = i + 1;

                    currentMaxOdd = Math.Max(currentMaxOdd, 0) + Math.Max(nums[i], nums[i + 1] );
                }
                else
                    currentMaxOdd = Math.Max(currentMaxOdd, 0) + nums[i];
                
                i = lasti + 4;
                totalMaxOdd = Math.Max(totalMaxOdd, currentMaxOdd);
            }

            return totalMaxOdd;
        }

        static int Rob2(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            int length = nums.Length;

            var currentMaxOdd = Int32.MinValue;
            int totalMaxOdd = Int32.MinValue;

            var currentMaxEven = Int32.MinValue;
            int totalMaxEven = Int32.MinValue;
            
            for (int i = 0; i < length; i++)
            {
                if (i%2 == 1)
                {
                    currentMaxOdd = Math.Max(currentMaxOdd, 0) + nums[i];
                    totalMaxOdd = Math.Max(totalMaxOdd, currentMaxOdd);
                }
                else
                {
                    currentMaxEven = Math.Max(currentMaxEven, 0) + nums[i];
                    totalMaxEven = Math.Max(totalMaxEven, currentMaxEven);
                }
            }

            return Math.Max(totalMaxOdd, totalMaxEven);
        }
        static int MaxSubArray(int[] nums)
        {
            if (nums.Length ==1)
                return nums[0];
            
            int length = nums.Length;
            
            var dp = new int[length];
            dp[0] = nums[0];
            int totalMax = dp[0];

            for (int i = 1; i < length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], 0) + nums[i];
                totalMax = Math.Max(totalMax, dp[i]);
            }

            return totalMax;
        }
        static int MaxProfit(int[] prices)
        {
            int maxProfit = 0, totalMaxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                maxProfit = Math.Max(0, maxProfit += prices[i] - prices[i - 1]);
                totalMaxProfit = Math.Max(maxProfit, totalMaxProfit);
            }
            return totalMaxProfit;
            
            //int minprice = Integer.MAX_VALUE;
            //int maxprofit = 0;
            //for (int i = 0; i < prices.length; i++) {
            //    if (prices[i] < minprice)
            //        minprice = prices[i];
            //    else if (prices[i] - minprice > maxprofit)
            //        maxprofit = prices[i] - minprice;
            //}
            //return maxprofit;
        }
        static int MaxProfittotalSum(int[] prices) 
        {
           if (prices.Length <= 1)
                return 0;
            int maximumProfit = 0;
            for (int i = 1; i < prices.Length; i++) {
                maximumProfit += Math.Max(0, prices[i] - prices[i - 1]);
            }
            return maximumProfit;
        }
       // static int MaxProfit(int[] prices)
       // {
       //     var len = prices.Length;
       //     var profit = 0;

       //     for (int i = 0; i < len-1; i++)
       //     {
       //         //var tempprofit = 0;
       //         var temparray = new int[len - 1 -i];
       //         Array.ConstrainedCopy(prices,i+1,temparray,0,len-1-i);
       //         //Array.Max(temparray);
       //         var cost = temparray.Max() - prices[i];//[temparray.Length-1]
       //         if (cost > profit)
       //             profit += cost;
                
       //     }

       //     return profit;
       //}

        static int[] mergeArrayBintoArrayA(int[] nums1, int[] nums2, int m, int n)
        {
            int aLen = nums1.Length - 1;
            int i = m - 1, j = n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[aLen] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[aLen] = nums2[j];
                    j--;
                }
                aLen--;
            }
            while (j >= 0)
            {
                nums1[aLen] = nums2[j];
                aLen--;
                j--;
            }
            return nums1;
        }

        static bool ContainsDuplicates(int[] nums)
        {
            
                ISet<Int32> set = new HashSet<Int32>();
                foreach (int x in nums) {
                    if (set.Contains(x)) return true;
                    set.Add(x);
                }
                return false;

            Array.Sort(nums);
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                {
                    return true;
                }
                else i++;
            }

            return false;
        }
    }

    internal class SortMerge : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            int i = 0;
            string xstr = x.ToString();
            string ystr = y.ToString();

            return (int)(Convert.ToInt64(ystr + xstr) - Convert.ToInt64(xstr + ystr));

        }
    }
    public class ListEquality : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> x, IList<int> y)
        {
            if (x.Count != y.Count)
                return false;
            //x=x.OrderBy(n => n).ToList();
            //y = y.OrderBy(n => n).ToList();

            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                    return false;
            }
            return true;
        }

        public int GetHashCode(IList<int> obj)
        {
            throw new NotImplementedException();
        }
    }

    public class Purmutation
    {
        int count = 0;
        public int countArrangement(int N)
        {
            int[] nums = new int[N];
            for (int i = 1; i <= N; i++)
                nums[i - 1] = i;
            permute(nums, 0);
            return count;
        }
        public void permute(int[] nums, int l)
        {
            if (l == nums.Length - 1)
            {
                int i;
                for (i = 1; i <= nums.Length; i++)
                {
                    if (nums[i - 1] % i != 0 && i % nums[i - 1] != 0)
                        break;
                }
                if (i == nums.Length + 1)
                {
                    count++;
                }
            }
            for (int i = l; i < nums.Length; i++)
            {
                swap(nums, i, l);
                permute(nums, l + 1);
                swap(nums, i, l);
            }
        }
        public void swap(int[] nums, int x, int y)
        {
            int temp = nums[x];
            nums[x] = nums[y];
            nums[y] = temp;
        }

    }
}
