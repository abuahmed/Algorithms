using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution {
        
        // Complete the powerSum function below.
        static int powerSum(int X, int N)
        {
            //var largestNum = Math.Pow(X, (1/N));
            var possibleLargeNum = Math.Sqrt(X);

            while (Math.Pow(possibleLargeNum,N)>X)
            {
                possibleLargeNum--;
            }

            return 0;
        }

        private int power(int n, int p)
        {
            if (n < 0 || p < 0)
                throw new Exception("n and p should be non-negative");
            return (int)Math.Pow(n, p);
        }
        
        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\answers.txt", true);

        //    int X = Convert.ToInt32(Console.ReadLine());

        //    int N = Convert.ToInt32(Console.ReadLine());

        //    int result = powerSum(X, N);

        //    textWriter.WriteLine(result);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}

        // Complete the maxValue function below.
        //https://www.hackerrank.com/challenges/string-function-calculation/problem
        
        static int maxValue(string t)
        {
            var tLen = t.Length;
            int subLen = 2;
            int maxLen = tLen;

            while (subLen <= tLen/2 + 1)
            {
                for (int i = 0; i < tLen/2; i++)
                {
                    var subs = t.Substring(i, subLen);
                    var tempLen = 1;//subs Count
                    for (int j = i+1; j < tLen/2; j++)
                    {
                        if (subs == t.Substring(j, subLen))
                            tempLen++;
                    }

                    if (tempLen*subs.Length > maxLen)
                        maxLen = tempLen * subs.Length;
                }
                subLen++;
            }
            return maxLen;
        }

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\answers.txt", true);

        //    string t = Console.ReadLine();

        //    int result = maxValue(t);

        //    textWriter.WriteLine(result);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}



        // Complete the pairs function below.
        
        static int pairs(int k, int[] arr)
        {
            var countNums = 0;
            Array.Sort(arr);

            int i = 0, j = 1;

            while (j<arr.Length)
            {
                var dif = arr[j] - arr[i];
                if (dif == k)
                {
                    countNums++;
                    j++;
                }
                else if (dif < k)
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }

            return countNums;
            //int i = 0;

            //for (; i < arr.Length; i++)
            //{
            //    int j = arr.Length - 1;
            //    while (arr[j]-arr[i] > k && j>0)
            //    {
            //        j--;
            //    }
            //    if (arr[j] - arr[i] == k) countNums++;
            //}

            //return countNums;
        }

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\answers.txt", true);

        //    string[] nk = Console.ReadLine().Split(' ');

        //    int n = Convert.ToInt32(nk[0]);

        //    int k = Convert.ToInt32(nk[1]);

        //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        //    ;
        //    int result = pairs(k, arr);

        //    textWriter.WriteLine(result);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
        
    }
}
