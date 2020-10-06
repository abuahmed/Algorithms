using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        public static void MainDP(string[] args)
        {
            var seq = "GEEKS FOR GEEKS";//"BBABCBCAB"
            var ll=lpsubDP(seq);
            var seqr = new string(seq.ToArray().Reverse().ToArray());
            var leni=lpsub(seq,0,seq.Length-1);//OR
            leni=LcSubStr(seq,seqr,seq.Length,seqr.Length);
            LcSubsequence(new[] { 3, 4, 1, 2, 1, 3 },new[] { 1, 2, 3, 4, 1 });
            var lcs = LcSreturns("ad", "bada");
            var arr = StockMaximize(new[] { 1, 2, 100, 2 });
            var coins = TheCoinChangeProblem(1, new[]{1});//3, new[] {8,3,1,2});//4, new[] {1, 2, 3});//10, new[] { 2, 5, 3 ,6});//
            var subDiff = SubstringDiff("helloworld", "yellomarin", 3);//"abcd","bbca",1);//"abacba","abcaba",0);//"tabriz", "torino", 2);
            var maxi = TheMaximumSubArray(new int[] {-1, 2, 3, -4, 5, 10});//new int[] { -2, -3, -1, -4, -6 });//new int[] { -1, 2, 3, -4,5,10 });//new int[] {1, 2, 3, 4});//new int[]{2,-1,2,3,4,-5});//new int[]{-2,-3,-1,-4,-6};//new int[] {1, 2, 3, 4});
            var aa = Abbrevation("qwaerAzbacfcDE", "ABADE");
            var sum = SamandSubstrings("123");
            
            const string s11 = "abcdefghklhgfedcbaqwouydr";
            //var s22 = "rdyuowqabcdefghlkhgfedcba";
            var len = LongestPalindromeLength(s11);
         
            var s1 = "AGGTAB"; //"HARRY"; 
            var s2 = "GXTXAYB"; //"SALRY";

            s1 = new string(s1.OrderByDescending(a => a).ToArray());
            s2 = new string(s2.OrderByDescending(a => a).ToArray());
            
            var m = s1.Length;
            var n = s2.Length;

            var sequencedSubString = CommonChild(s1, s2);
            var notSequencedSubString = LcSubStr(s1, s2, m, n);

            var max = Math.Max(sequencedSubString, notSequencedSubString);
            //Console.Write("Length of LCS is" + " " + LCSubStr(s1, s2, m, n));
        }

        private static int lpsubDP(string seq)
        {
            int n = seq.Length;
            int i, j, cl;
            var L = new int[n, n];
            for (i = 0; i < n; i++)
                L[i, i] = 1;
            string tt = seq;
            for (cl = 2; cl <= n; cl++)
            {
                if(tt.Length>0)
                tt = tt + "\n";

                for ( i = 0; i < n-cl+1; i++)
                {
                    j = i + cl - 1;
                    if (seq[i] == seq[j] && cl == 2)
                        L[i, j] = 2;
                    else if (seq[i] == seq[j])
                        L[i, j] = L[i + 1, j - 1] + 2;
                    else L[i, j] = Math.Max(L[i, j - 1], L[i + 1, j]);
                    tt = tt + L[i, j].ToString();
                }
            }
            var tt2 = "";
            for (int k = 0; k < n; k++)
            {
                if (tt2.Length > 0)
                    tt2 = tt2 + "\n";
                for (int l = 0; l < n; l++)
                {
                    tt2 = tt2 + L[k, l].ToString();
                }
            }
            
            return L[0,n-1];
        }

        private static int lpsub(string s, int i, int j)
        {
            var sarray = s.ToArray();
           
            if (i == j)
                return 1;

            if (sarray[i] == sarray[j] && i+1==j)
            {
                return 2;
            }

            if (sarray[i] == sarray[j])
             return lpsub(s,i+1,j-1)+2;
          
            return Math.Max(lpsub(s, i + 1, j), lpsub(s, i, j-1));
            
        }
        //The Longest Common Subsequence
        private static int LcSubsequence(int[] a, int[] b)
        {
            var aLen = a.Length;
            var bLen = b.Length;

            var table = new int[aLen + 1, bLen + 1];

            var max = 0;
            var alist = new ArrayList();
            //int maxi = 0;
            //int maxj = 0;
            var tt = "";
            for (var i = 1; i <= aLen; i++)
            {
                if (tt.Length > 0)
                    tt = tt + "\n";
                for (var j = 1; j <= bLen; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        table[i, j] = Math.Max(table[i - 1, j], table[i, j-1]);
                    }

                    if (table[i, j] >= max)
                    {
                        max = table[i, j];
                        alist.Add(max.ToString() +":"+(i-1).ToString() + "_" + (j-1).ToString());
                        //maxi = i - 1;
                        //maxj = j - 1;
                    }

                    tt = tt  + table[i, j].ToString();//+ "_"
                }
            }

            return 0;
        }

        private static int LcSreturns(string a, string b)
        {
            var aLen = a.Length;
            var bLen = b.Length;

            var table = new int[aLen + 1, bLen + 1];

            var max = 0;
            int maxi = 0; int maxj = 0;

            for (var i = 1; i <= aLen; i++)
            {
                for (var j = 1; j <= bLen; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1] + 1;
                    }

                    if (table[i, j] > max)
                    {
                        max = table[i, j];
                        maxi = i - 1;
                        maxj = j - 1;
                    }

                }
            }

            var asub = a.Substring(maxi - max + 1, max);
            var bsub = b.Substring(maxj - max + 1-1, max+2);

            for (int i = 0; i < asub.Length; i++)
            {
                
            }

            for (int ii = maxi - max + 1, jj = maxj - max + 1; ii < aLen && jj < bLen; ii++, jj++)
            {
                var ss1 = a.Substring(ii, 1);
                var ss2 = b.Substring(jj, 1);
            }

            return 0;
        }

        private static int StockMaximize(int[] stocks)
        {
            var len = stocks.Length;
            var profit = 0;
            int totCosts = 0, numberOfStocks = 0;

            for (int i = 0; i < len; i++)
            {
                if (i != len - 1 && stocks[i] < stocks[i + 1]  )
                {
                    numberOfStocks++;
                    totCosts += stocks[i];
                }
                else
                {
                    if (i != 0)
                    {
                        profit += numberOfStocks*stocks[i] - totCosts;
                        numberOfStocks = 0;
                        totCosts = 0;
                    }
                }
            }

            return profit;
           
        }

        private static long TheCoinChangeProblem(int n, int[] coins)
        {
            //var len = coins.Length;
            long numberOfCoins = 0;
            Array.Sort(coins);
            var changeList = new HashSet<int>();

            foreach (var coin in coins)
            {
                if (n%coin == 0)
                    numberOfCoins++;
                
                var sum = -1;
                foreach (var i in changeList)
                {
                    if (n%(coin + i) == 0)
                    {
                        numberOfCoins++;
                        sum = coin + i;
                    }
                }

                if(sum!=-1)
                changeList.Add(sum);

                int totNums = n/coin;
                for (int i = 1; i <= totNums; i++)
                {
                    changeList.Add(i*coin);
                }
            }


            return numberOfCoins;
        }

        private static int SamandSubstrings(string s)
        {
            int n = s.Length;
            var sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    if (i <= j)
                    {
                        sum += Convert.ToInt32(s.Substring(i, j - i));
                    }
                }
            }
            return sum % ((int)Math.Pow(10, 9) + 7);
        }

        private static int SubstringDiff(string s1, string s2, int k)
        {
            var s1Len = s1.Length;
            var s2Len = s2.Length;

            var table = new int[s1Len + 1, s2Len + 1];
            var max = 0;
            int maxi = 0; int maxj = 0;
            //var dict=new Dictionary<int, string>();
            for (var i = 1; i <= s1Len; i++)
            {
                for (var j = 1; j <= s2Len; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1] + 1;
                    }
                    if (table[i, j] > max)
                    {
                        max = table[i, j];
                        maxi = i-1;
                        maxj = j-1;
                    }
                    
                }
            }

            for (int ii = maxi-max+1, jj = maxj-max+1; ii < s1Len && jj<s2Len; ii++ ,jj++)
            {
                var ss1 = s1.Substring(ii, 1);
                var ss2 = s2.Substring(jj, 1);
            }

            return max + k;
        }

        private static int TheMaximumSubArray(int[] arr)
        {
            int len = arr.Length;
            var table = new int[len+1,len+1];
            //table[0, 0] = -10000;
            var max = -10000;
            var subSequenceMax = -10000;
            var tt = "";
            
            for (int i = 1; i <= len; i++)
            {
                if (tt.Length > 0)
                    tt = tt + "\n";
                max = Math.Max(max, arr[i - 1]);

                for (int j = 1; j <= len; j++)
                {
                    if (i == j)
                    {
                        if (arr[i - 1] >= 0)
                            table[i, j] = table[i - 1, j - 1] + arr[i - 1];
                        else
                            table[i, j] = table[i - 1, j - 1];

                        max = Math.Max(max, table[i, j]);
                    }
                    else
                    {
                        if(j>i)
                            table[i, j] = table[i, j - 1] + arr[j - 1] - table[i, i];
                        else
                            table[i, j] = table[i, j - 1]  + arr[j - 1] ;
                        subSequenceMax = Math.Max(subSequenceMax, table[i, j]);
                    }

                    tt = tt +"_"+ table[i, j].ToString();
                }
                
            }

            return max;
        }

        private static string Abbrevation(string a, string b)
        {
            //a=AbcDE
            //b=ABDE
            int alen = a.Length, blen = b.Length;
            var table = new int[alen + 1, blen + 1];

            int max = 0;
            var tt = "";
            //int startindex = 0;
            ArrayList alist=new ArrayList();
            Dictionary<int, int> dict=new Dictionary<int, int>();
            bool isBreaked = false;
            for (var i = 1; i <= alen; i++)
            {
                if (tt.Length > 0)
                    tt = tt + "\n";
                for (var j = 1; j <= blen; j++)
                {
                    if (Equals(a[i - 1].ToString().ToUpper(), b[j - 1].ToString()))
                    {
                        table[i, j] = table[i - 1, j - 1] + 1;
                        //tt = tt +":"+ (i - 1).ToString() + "_" + (j - 1).ToString();
                        alist.Add((i-1).ToString() + "_" + (j-1).ToString());
                        //if (i == 1)
                            //startindex = j-1;
                        if (dict.ContainsKey(j-1) && dict[j-1]<i-1)
                            dict[j-1] = i-1;
                        else dict[j-1] = i-1;
                    }
                    else
                    {
                        table[i, j] = Math.Max(table[i - 1, j],table[i, j - 1]);
                    }
                    tt = tt + table[i, j].ToString();

                    max = Math.Max(table[i, j], max);

                    if (max == blen)
                    {
                        var dic=dict.OrderBy(k => k.Key).ToList();
                        isBreaked = true;
                        break;
                    }
                }
                if(isBreaked)
                    break;
            }
            alist.Sort();
            var aArray = a.ToArray();
            foreach (var i in dict.Values)
            {
                aArray[i] = Convert.ToChar(aArray[i].ToString().ToUpper());
            }
            var astr = new string(aArray);


            astr=Regex.Replace(astr, @"[a-z]","");

            if (astr == b)
                return "YES";

            return "NO";
        }
        
        private static int CommonChild(string s1, string s2)
        {
            var s1Len = s1.Length;
            var s2Len = s2.Length;

            var lcsArray = new int[s1Len + 1, s2Len + 1];
            var lcsRes = 0;

            for (var i = 1; i <= s1Len; i++)
            {
                for (var j = 1; j <= s2Len; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        lcsArray[i, j] = lcsArray[i - 1, j - 1] + 1;
                    }
                    //else
                    //{
                    //    lcsArray[i, j] = Math.Max(lcsArray[i - 1, j], lcsArray[i, j - 1]);
                    //}

                    lcsRes = Math.Max(lcsRes, lcsArray[i, j]);
                }
            }

            return lcsRes;
        }

        private static int LcSubStr(string x, string y, int m, int n)
        {
            // Create a table to store lengths of longest common suffixes of substrings. 
            // Note that LCSuff[i][j] contains length of longest common suffix of X[0..i-1]  
            // and Y[0..j-1]. The first row and first column entries have no logical meaning, 
            // they are used only for simplicity of program
 
            var lcStuff = new int[m + 1, n + 1];

            // To store length of the longest common substring 
            int result = 0;

            // Following steps build LCSuff[m+1][n+1] in bottom up fashion 
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    //if (i == 0 || j == 0)
                    //    LCStuff[i, j] = 0;
                    //else 
                    if (x[i - 1] == y[j - 1])
                    {
                        lcStuff[i, j] = lcStuff[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcStuff[i, j] = Math.Max(lcStuff[i - 1, j], lcStuff[i, j - 1]);
                    }
                    result = Math.Max(result, lcStuff[i, j]);
                    //else
                    //LCStuff[i, j] = 0;
                }
            }

            return result;
        }

        private static int LongestPalindromeLength(string s1)
        {
            var s2 = String.Join("", s1.ToArray().Reverse().ToArray());
            var len = LcSubStr(s1, s2, s1.Length, s2.Length);
            
            len = LcSubStr(s1, s2,s1.Length,s2.Length);
            return len;
        }

        //private static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter.txt", true);

        //    string s1 = Console.ReadLine();

        //    string s2 = Console.ReadLine();

        //    //char[] X = s1.ToCharArray();
        //    //char[] Y = s2.ToCharArray();
        //    //int m = X.Length;
        //    //int n = Y.Length;

        //    //Console.Write("Length of LCS is" + " "
        //    //              + lcs(X, Y, m, n));

        //    int result = commonChild(s1, s2); //LCSubStr(s1, s2, m, n);// 

        //    textWriter.WriteLine(result);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}

        //private static int CommonChild2(string s1, string s2)
        //{
        //    var fs = s1.ToArray();
        //    var ss = s2.ToArray();

        //    var commonfsChars = new List<char>();
        //    List<char> ssHashSet = new List<char>(ss);
        //    for (var i = 0; i < s1.Length; i++)
        //    {
        //        var ind = ssHashSet.IndexOf(fs[i]);
        //        if (ind != -1)
        //        {
        //            commonfsChars.Add(fs[i]);
        //        }
        //    }
        //    var len = commonfsChars.Count;
        //    var s = new string(commonfsChars.ToArray());
        //    //var slen = s.Length;

        //    List<char> fsHashSet2 = new List<char>(commonfsChars);
        //    foreach (char VARIABLE in ss)
        //    {
        //        var ind = fsHashSet2.IndexOf(VARIABLE);
        //        if (ind == -1)
        //        {
        //            ssHashSet.Remove(VARIABLE);
        //        }
        //    }
        //    var ss2 = new string(ssHashSet.ToArray());
        //    //var ss2len = ss2.Length;

        //    for (var len2 = len; len2 > 0; len2--)
        //    {
        //        if (len2 == 15)
        //        {
        //            for (int i = 0; i < len; i++)
        //            {
        //                if (len2 + i <= len)
        //                {
        //                    var subS = s.Substring(i, len2).ToArray();

        //                    bool isFound = true;

        //                    var jj = 0;

        //                    foreach (var subs in subS)
        //                    {
        //                        var isfoundj = false;
        //                        for (int j = jj; j < ss2.Length; j++)
        //                        {
        //                            if (subs == ss2[j])
        //                            {
        //                                jj = j;
        //                                isfoundj = true;
        //                                break;
        //                            }
        //                            jj = j;
        //                        }
        //                        if (!isfoundj) //)jj+1 > ss2.Length
        //                        {
        //                            //not found break loop
        //                            isFound = false;
        //                            break;
        //                        }
        //                    }

        //                    if (isFound)
        //                        return len2;
        //                }
        //            }
        //        }
        //    }

        //    return 0;
        //}
    }

    internal class Comparr : IComparer<char>
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.Value Meaning Less than zero<paramref name="x"/> is less than <paramref name="y"/>.Zero<paramref name="x"/> equals <paramref name="y"/>.Greater than zero<paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        /// <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param>
        public int Compare(char x, char y)
        {
            return x - y;
            //if (x == y)
            //    return 0;
            //if (x < y)
            //    return 1;
            //return -1;
        }
    }
}
