using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        private static void MainDH(string[] args)
        {
            //string cm = CheckMagazineHT(6, 4, "give me one grand today night", "give one grand today");
            //int res = CountTriplets(new[] {1, 4, 16, 64}, 4);
            //var count = CountTriplets(new long[]{1, 5, 5, 25, 125},5);//new[] {1, 2, 2, 4}, 2);//new []{1, 3, 9, 9, 27, 81},3);//
        }

        static long CountTriplets(List<long> arr, long ratio)
        {
            var len = arr.Count;
            var count = 0;
            
            for (int i = 0; i < len - 2; i++)
            {
                var jj = arr[i]*ratio;
                var kk = jj*ratio;

                var jlist = arr.ToList().Skip(1).ToList();
                var jc = jlist.Count(a => a == jj);

                var klist = arr.ToList().Skip(2).ToList();
                var kc = klist.Count(a => a == kk);

                count += kc*jc;
            }
            return count;

        }

        private static string CheckMagazine(int n, int m, string s1, string s2)
        {
            List<string> magazines = s1.Split(' ').ToList();
            var ransomes = s2.Split(' ').ToList();
            foreach (var ransome in ransomes)
            {
                if (magazines.Contains(ransome))
                    magazines.Remove(ransome);
                else return "No";
            }

            return "Yes";
        }

        private static string CheckMagazineHT(int n, int m, string s1, string s2)
        {
            var s1Array = s1.Split(' ').ToArray();
            var s2Array = s2.Split(' ').ToArray();
            int[,] table = new int[n + 1, m + 1];
            int max = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s1Array[i-1]==s2Array[j-1])
                        table[i, j] = table[i - 1, j - 1] + 1;
                    else table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);

                    max = Math.Max(max, table[i, j]);
                }
            }

            if (max == m)
                return "Yes";

            return "No";
        }

        private static string TwoStrings(string s1, string s2)
        {
            var fs = s1.ToArray();
            var ss = s2.ToArray();

            var ssHashSet = new HashSet<char>(ss);
            for (var i = 0; i < s1.Length; i++)
            {
                var ind = ssHashSet.Contains(fs[i]);
                if (ind)
                {
                    return "YES";
                }
            }

            return "NO";
        }

        private static int SherlockAndAnagrams(string s)
        {
            var len = s.Length;

            var countNums = 0;

            for (var len2 = 1; len2 < len; len2++)
            {
                var subStrings = new List<string>();
                for (int i = 0; i < len; i++)
                {
                    if (len2 + i <= len)
                    {
                        subStrings.Add(new string(s.Substring(i, len2).OrderBy(c => c).ToArray()));
                    }
                }

                for (int i = 0; i < subStrings.Count - 1; i++)
                {
                    for (int j = i + 1; j < subStrings.Count; j++)
                    {
                        if (subStrings[i] == subStrings[j])
                        {
                            countNums++;
                        }
                    }
                }
            }
            return countNums;
        }
    }
}