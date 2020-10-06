using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        public static void MainRec(string[] args)
        {

            var fib=FibonacciModified(0, 1, 6);
           
            //var supDigit=RecursiveDigitSum(123, 3);

            //ThePowerSum(100, 2);

            var nn = AddDenominators(5);

            var pal = CheckPalindromeStripString("Madam, I'm Adam");//babcdadcbab

            var sc = StrchrExists("abebeeeee", "e");
            var sc2 = StrchrCount("abebeeeee", "e");
            var sc3 = StrchrRemove("abebeeeee", "e");
            
            var d = GrCoD(15, 25);
        }

        private static void ThePowerSum(int x, int n)
        {
            var maxNum = (int) Math.Pow(x, (double) 1/n);
           
            IList<int> arr=new List<int>();
            for (int k = 1; k <= maxNum; k++)
            {
                arr.Add((int)Math.Pow(k, n));
            }

            var result = ThePowerRecursion(arr, x);
        }

        private static int ThePowerRecursion(IList<int> arr, int x)
        {
            var collectValues = new List<int>();
            var maxNum = arr[arr.Count-1];
            
            int i = 0;
            while (maxNum<100)
            {
                maxNum += arr[i];
                i++;
            }
            
            return ThePowerRecursion(arr,x);
        }
            
        private static int RecursiveDigitSum(int n, int k)
        {
            if (n.ToString().Length == 1)
                return n;

            var nstr = n.ToString();
            while (k>1)
            {
                nstr += n.ToString();
                k--;
            }
            
            int[] nums = nstr.ToArray().Select(s=>Convert.ToInt32(s.ToString())).ToArray();
            
            return RecursiveDigitSum(nums.Sum(), 1);
        }

        private static int FibonacciModified(int t1, int t2, int n)
        {
            if (n == 1)
                return t1;
            if (n == 2)
                return t2;
            return FibonacciModified(t1, t2, n - 2) + (int) Math.Pow(FibonacciModified(t1, t2, n - 1),2);
        }

       

        static int GrCoD(int n,int m)
        {   
            if(m<=n && n%m==0)
            return m;
            if (n < m)
                return GrCoD(m, n);
            return GrCoD(m, n%m);
        }

        static bool StrchrExists(string s, string c)
        {
            if (s.Contains(c))
                return true;
            if (s.Length > 1)
            {
                StrchrExists(s.Substring(1), c);
            }

            return false;
        }

        static int StrchrCount(string s, string c)
        {
            if (s.Length == 0)
                return 0;
            var cur = s.Substring(0, 1);
            var sum = cur.Equals(c) ? 1 : 0;
            return sum + StrchrCount(s.Substring(1), c);
        }
        static string StrchrRemove(string s, string c)
        {
            if (s.Length == 0)
                return "";
            var cur = s.Substring(0, 1);
            var sum = cur.Equals(c) ? "" : cur.ToString();
            return sum.ToString() + StrchrRemove(s.Substring(1), c);
        }

        private static int CheckPalindromeStripString(string str)
        {
            var reg = new Regex("[a-zA-Z]+");
            
            var strr = "";
            var s = reg.Matches(str).GetEnumerator();
            while (s.MoveNext())
            {
                strr += s.Current;
            }
            str = strr.ToLower();
            return CheckPalindromes(str,str.Length);
        }

        static int CheckPalindromes(string str,int len)
        {
            if (str.Length == 0 || str.Length == 1)
                return 0;
            else if (str[0] == str[str.Length - 1])
                return 1 + CheckPalindromes(str.Substring(1, str.Length - 2),len);
            else return - len/2;
        }

        static double AddDenominators(int n)
        {
            if (n == 1)
                return 1;
            return (double)1 / n + AddDenominators(n - 1);
        }
    }
}
