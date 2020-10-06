using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        static void Main(string[] args)
        {
            //int res = MinimumAbsoluteDiff(5,new[]{1,-3,71,68,17});//10, new[] { -59, -36, -13,1,-53,-92,-2,-96,-54,75 });//(3, new[] {3, -7, 0});
            //int re = LuckBalance(3,2,new[,]{{5,1},{1,1},{4,0}});//(6, 3, new[,] {{5, 1}, {2, 1}, {1, 1}, {8, 1}, {10, 0}, {5, 0}});
            var words = new string[] {"ppp","ypp","wyw"};//"ebacd", "fghij", "olmkn", "trpqs", "xywuv"};
            var res = gridChallenge(words);
        }

        static string gridChallenge(string[] grid)
        {
            if (grid.Length == 0)
                return "YES";
            var previousWord = new string(grid[0].OrderBy(s => s).ToArray());
            for (int i = 1; i < grid.Length; i++)
            {
                var currWord = new string(grid[i].OrderBy(s => s).ToArray());
                for (int j = 0; j < currWord.Length; j++)
                {
                    if (currWord[j] - 'a' < previousWord[j] - 'a')
                        return "NO";
                }
                
            }
            return "YES";
        }

        private static int LuckBalance(int n, int k, int[,] arr)
        {
            int luck = 0;

            IList<int> importantContest=new List<int>();
            
            for (int i = 0; i < n; i++)
            {
                if (arr[i, 1] == 0)
                {
                    luck += arr[i, 0];
                }
                else
                {
                    importantContest.Add(arr[i, 0]);
                }
            }
            importantContest=importantContest.OrderBy(a => a).ToList();
            var dif = importantContest.Count - k ;
            var list=importantContest.Skip(dif).ToList().Sum();
            var minus = importantContest.Take(dif).ToList().Sum();
            return list+luck-minus;
        }

        private static int MinimumAbsoluteDiff(int n, int[] arr)
        {
            Array.Sort(arr);
            var min = (int) Math.Pow(10, 9);
            for (int i = 0; i < n-1; i++)
            {
                min = Math.Min(Math.Abs(arr[i] - arr[i + 1]), min);
            }

            return min;
        }

        private static int maxMin(int k, int[] arr)
        {
            var len = arr.Length;
            int minValue = (int)Math.Pow(10, 9);
            Array.Sort(arr);
            for (int i = 0; i < len; i++)
            {
                var maxValueIndex = i + k - 1;
                if (maxValueIndex == len)
                    break;

                if (minValue == 0)
                    return 0;

                if (arr[maxValueIndex] - arr[i] < minValue)
                    minValue = arr[maxValueIndex] - arr[i];
            }

            return minValue;
        }

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\answers.txt", true);

        //    int n = Convert.ToInt32(Console.ReadLine());

        //    int k = Convert.ToInt32(Console.ReadLine());

        //    int[] arr = new int[n];

        //    for (int i = 0; i < n; i++)
        //    {
        //        int arrItem = Convert.ToInt32(Console.ReadLine());
        //        arr[i] = arrItem;
        //    }

        //    int result = maxMin(k, arr);

        //    textWriter.WriteLine(result);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
    }
}
