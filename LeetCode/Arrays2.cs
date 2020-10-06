using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        private static void Main(string[] args)
        {
            var interval = new int[1][];
            interval[0] = new[] { 4, 5 };
            //interval[1] = new[] { 1, 4 };

            //interval[0] = new[] { 1, 4 };
            //interval[1]=new[] {0, 2};
            //interval[2] = new[] { 3, 5 };
//            interval[0] = new[] { 15, 18 };
//            interval[2] = new[] { 2, 6 };
//            interval[1] = new[] { 8, 10 };
//            interval[3] = new[] { 1, 3 };

            //var res = Merge(interval);

            //var trips = new int[5][];
            //trips[0] = new[] { 9,3,6};
            //trips[1] = new[] { 8,1,7 };
            //trips[2] = new[] { 6,6,8 };
            //trips[3] = new[] { 8,4,9 };
            //trips[4] = new[] { 4,2,9};
            //[[],[],[],[7,4,5]] 23
            //var trips = new int[3][];
            //trips[0] = new[] { 3, 2, 7 };
            //trips[1] = new[] { 8, 3, 9 };
            //trips[2] = new[] { 3, 7, 9 };
            ////var trips = new int[4][];
            ////trips[0] = new[] { 9, 3, 4 };
            ////trips[1] = new[] { 9, 1, 7 };
            ////trips[2] = new[] { 4, 2, 4 };
            ////trips[3] = new[] { 7, 4, 5 };
           
            //var res = CarPooling(trips, 11);
  
            //var intervals = new int[5][];
            //intervals[0] = new[] { 1,2 };
            //intervals[1] = new[] { 3,5 };
            //intervals[2] = new[] { 6,7 };
            //intervals[3] = new[] { 8,10 };
            //intervals[4] = new[] { 12,16 };
            

            //var res = Insert(intervals, new[] {4,8});
            //var res = MajorityElement(new[] {3, 2, 3});// 2, 2, 1, 1, 1, 2, 2 });
            //var res = CountArrangement(8);
            //var res = ConstructArray(92, 10);

            //var intervals = new int[3][];
            //intervals[0] = new[] { 1, 4 };
            //intervals[1] = new[] { 3, 6 };
            //intervals[2] = new[] { 2, 8 };
            //var res = RemoveCoveredIntervals(intervals);

            var intervals = new int[4][];
            intervals[0] = new[] { 1, 100 };
            intervals[1] = new[] { 11, 22 };

            intervals[2] = new[] { 1, 11 };
            intervals[3] = new[] { 2, 12 };
            var res = EraseOverlapIntervals(intervals);
        }
        static int[] ConstructArray(int n, int k)
        {
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
            }
            IList<int> listofIndexes = new List<int>();
            IList<int> listofDifferences = new List<int>();
            int[] answers = new int[nums.Length];
            ConstructArray(nums, listofIndexes, listofDifferences, k, answers);
            return answers;
        }

        private static void ConstructArray(int[] nums, IList<int> listofIndexes, IList<int> listofDifferences, int k, int[] answers)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if(answers[nums.Length-1]!=0)
                    break;

                if(listofIndexes.Contains(i))
                    continue;

                IList<int> listofIndexes2 = new List<int>(listofIndexes);
                listofIndexes2.Add(i);
                var llLen = listofIndexes2.Count;
                if (llLen > 1)
                {
                    var currentDiff2 = Math.Abs(nums[listofIndexes2[llLen - 1]] - nums[listofIndexes2[llLen - 2]]);

                    IList<int> listofDifferences2 = new List<int>(listofDifferences);
                    if(!listofDifferences2.Contains(currentDiff2))
                        listofDifferences2.Add(currentDiff2);
                    

                    if (listofDifferences2.Count <= k)
                    {
                        if (i < nums.Length - 1)
                            ConstructArray(nums, listofIndexes2, listofDifferences2, k, answers);
                        else if (listofIndexes2.Count == nums.Length && listofDifferences2.Count == k)
                        {
                            for (int j = 0; j < nums.Length; j++)
                            {
                                answers[j] = nums[listofIndexes2[j]];
                            }
                            break;
                            
                        }
                    }
                    else
                    {
                        break;
                    }
                   
                }
                else
                {
                    ConstructArray(nums, listofIndexes2, listofDifferences, k,answers);
                }

            }
            //return answers;
        }

        static int CountArrangement(int n)
        {
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
            }
            
            IList<int> listofIndexes = new List<int>();
            var answers = new List<IList<int>>();
            CountArrangement(nums, listofIndexes, answers);
            return answers.Count;
        }

        static void CountArrangement(int[] nums, IList<int> listofIndexes, IList<IList<int>> answers)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if(listofIndexes.Contains(i))
                    continue;

                IList<int> listofIndexes2 = new List<int>(listofIndexes);
                listofIndexes2.Add(i);
                
                //if (listofIndexes2.Count == nums.Length)
                //{
                int count = CountArrangements(nums, listofIndexes2.ToArray());
                if (count != 0)
                {
                    if (listofIndexes2.Count == nums.Length)
                        answers.Add(listofIndexes2.ToArray());
                    else
                    {
                        if (i < nums.Length)
                        {
                            CountArrangement(nums, listofIndexes2, answers);
                        }
                    }
                }
                //else
                //{
                //    break;
                //}
                    
                //}

//                if (i < nums.Length)
//                {
//                    CountArrangement(nums, listofIndexes2, answers);
//                }
                
            }
   
        }

        static int CountArrangements(int[] nums,int[] arrangements)
        {
            int j = arrangements.Length;
            //for (int j = arrangements.Length; j <= arrangements.Length; j++)
            //{
                bool found = false;
                if (nums[arrangements[j-1]] % j == 0)
                {
                    found = true;
                }
                else if (j % nums[arrangements[j - 1]] == 0)
                {
                    found = true;
                }
                if (!found)
                    return 0;
            //}
            return 1;
        }

        public IList<int> MajorityElement2(int[] nums)
        {
            if (nums.Length == 0)
                return nums;
            IList<int> answers = new List<int>();
            int minQuantity = nums.Length / 3;
            Array.Sort(nums);
            int countRepeation = 1;
            int currentNum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == currentNum)
                {
                    countRepeation++;
                    if (countRepeation > minQuantity)
                    {
                        if (!answers.Contains(nums[i]))
                            answers.Add(nums[i]);
                    }
                }
                else
                {
                    currentNum = nums[i];
                    countRepeation = 1;
                }
            }

            return answers;
        }
        static int MajorityElement(int[] nums)
        {
            int minQuantity = nums.Length/2;
            Array.Sort(nums);
            int countRepeation = 1;
            int currentNum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == currentNum)
                {
                    countRepeation++;
                    if (countRepeation > minQuantity)
                        return nums[i];
                }
                else
                {
                    currentNum = nums[i];
                    countRepeation = 1;
                }
            }

            return countRepeation;
            
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    dict[nums[i]] += 1;
                else dict[nums[i]] = 1;
            }
            var value=dict.FirstOrDefault(v => v.Value > minQuantity);
            return value.Key;
        }
        static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
                return new []{newInterval};
            var list = new List<int[]>();
            bool mergedoradded = false;
            for (int i = 0; i < intervals.Length; i++)
            {
                    if (!mergedoradded && newInterval[0] > intervals[i][0])
                    {
                        //try to merge
                        if (newInterval[0] < intervals[i][1])
                        {
                            intervals[i] = new[] {intervals[i][0], Math.Max(intervals[i][1], newInterval[1])};
                            list.Add(intervals[i]);
                            mergedoradded = true;
                        }
                        else
                        {
                            list.Add(intervals[i]);
                        }
                    }
                    else if (!mergedoradded && newInterval[0] < intervals[i][0])
                    {
                        //try to merge
                        if (newInterval[1] > intervals[i][0])
                        {
                            intervals[i] = new[] {newInterval[0], Math.Max(intervals[i][1], newInterval[1])};
                            list.Add(intervals[i]);
                        }
                        else
                        {
                            list.Add(newInterval);
                            list.Add(intervals[i]);
                        } 
                        mergedoradded = true;
                    }

                    else
                    {
                        list.Add(intervals[i]);
                    }
                
                
               

            }
            if(!mergedoradded)
                list.Add(newInterval);
            return Merge(list.ToArray());
        }

        static bool CarPooling(int[][] trips, int capacity)
        {
            if (trips.Length < 1)
                return false;

            Array.Sort(trips,new SortTrips());
            IList<int[]> lis = new List<int[]>();
            lis.Add(trips[0]);
            if (trips[0][0] > capacity)
                return false;
            for (int i = 1; i < trips.Length; i++)
            {
                if(trips[i][0]>capacity)
                    return false;

                if (trips[i][1] < trips[i - 1][2])
                {
                    var finishedtrips = 0;
                    foreach (var trip in lis)
                    {
                        if (trip[2] <= trips[i][1])
                            finishedtrips += trip[0];
                    }
                    lis.Add(trips[i]);
                    if (trips[i][0] + trips[i - 1][0] - finishedtrips <= capacity)
                    {
                        trips[i] = new[]
                        {(trips[i][0] + trips[i - 1][0]), trips[i - 1][1], Math.Max(trips[i - 1][2], trips[i][2])};
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    lis = new List<int[]>();
                }

            }

            return true;
        }
        static int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length == 1)
                return 0;
            Array.Sort(intervals, new SortRemoveIntervals());
            var countOverlaps = 0;
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][1] <= intervals[i - 1][1])
                {
                    countOverlaps++;
                    //intervals[i] = intervals[i - 1];
                }
            }

            return countOverlaps;
        }
        static int RemoveCoveredIntervals(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;
            if (intervals[0].Length == 0)
                return intervals.Length;
            if (intervals.Length == 1)
                return 1;
            Array.Sort(intervals, (a, b) => a[0]==b[0]?b[0]-a[0]:a[0]-b[0] );// new SortRemoveIntervals());
            var countRemoved = 0;
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][1] <= intervals[i - 1][1])
                {
                    countRemoved++;
                    intervals[i] = intervals[i - 1];
                }
            }
            return intervals.Length-countRemoved;
        }
        static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
                return intervals;
            if (intervals[0].Length == 0)
                return intervals;

            Array.Sort(intervals,new SortMatrix());
            IList<int[]> lis=new List<int[]>();
            
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= intervals[i - 1][1])
                {
                    intervals[i] = new[] {intervals[i - 1][0], Math.Max(intervals[i - 1][1], intervals[i][1])};
                }
                else
                {
                    lis.Add(intervals[i-1]);
                }
            }
            lis.Add(intervals[intervals.Length - 1]);
            return lis.ToArray();
        }
    }

    internal class SortTrips : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[1] - y[1];
        }
    }

    internal class SortMatrix : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[0] - y[0];
        }
    }
    internal class SortRemoveIntervals : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x[0] == y[0])
                return y[1] - x[1];
            return x[0] - y[0];
        }
    }
}
