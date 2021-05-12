using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        private static void MainLcs(string[] args)
        {
            var len = new Lcs().LongestPalindrome("cbabd");//aaaaabaaaac
        }
    }

    public class Lcs
    {
        public string LongestPalindrome(string s)
        {
            var max = 0;
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                var len = CountandExpand(s,i,i);
                var len2 = CountandExpand(s, i, i+1);
                max = Math.Max(max, Math.Max(len.Length, len2.Length));

                //var start = i - max;
                //result = s.Substring(start, max);
                //if (Math.Max(len, len2) > max)
                //{
                //    var stlen = 0;
                //    if (len2 >= len)
                //        stlen = 2 * Math.Max(len, len2);
                //    else stlen = 2*Math.Max(len, len2) - 1;

                //    result = s.Substring(i + 1 - Math.Max(len, len2), stlen);
                //}


                //result = s.Substring(i, max);
            }
            return result;
        }

        private string CountandExpand(string s, int l, int r)
        {
            int counter = 0;
            string res = "";// s[l].ToString();
            if (l != r)
            {
                counter = 1;
                //res = s[l].ToString() + s[r].ToString();
            }
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                if (l != r)
                    res = s[l].ToString() + res + s[r].ToString();
                else res = s[l].ToString();
                counter++;
                l--;
                r++;
            }
            //if (l != r)
                //return 2*counter;
            //return 2 * counter - 1;
            return res;//.Length;
        }
    }
}
