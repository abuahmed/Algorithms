using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    partial class Solution
    {
        //private static String balancedSums(List arr)
        //{
        //    int n = arr.size();
        //    int i = 0;
        //    int j = n - 1;
        //    int left = 0;
        //    int right = 0;
        //    int totalSum = arr.stream().mapToInt(k->k).sum();

        //    while (i < n && j >= 0)
        //    {
        //        if (left == totalSum || totalSum == right)
        //        {
        //            return "YES";
        //        }
        //        if (left == right && i == j)
        //        {
        //            return "YES";
        //        }
        //        if (left > right)
        //        {
        //            right += arr.get(j);
        //            j--;
        //        }
        //        else
        //        {
        //            left += arr.get(i);
        //            i++;
        //        }
        //    }
        //    return "NO";
        //}

        // Complete the balancedSums function below.
        
        private static string balancedSums(List<int> arr)
        {
            arr.Sort();
            //int n = arr.Count();
            //int i = 0;
            //int j = n - 1;
            //int left = 0;
            //int right = 0;

            int n = arr.Count();
            if (n == 1)
                return "YES";

            int i = 0;
            
            int j = n -1;
            int sum = 0;
            while (i != j)
            {
                if (sum >= 0)
                {
                    sum -= arr[j];
                    j--;
                }
                else
                {
                    sum += arr[i];
                    i++;
                }

            }
            return sum == 0 ? "YES" : "NO";

            //while (i < n && j >= 0)
            //{
            //    if (left == right && i == j)
            //    {
            //        return "YES";
            //    }
            //    if (left > right)
            //    {
            //        right += arr[j];
            //        j--;
            //    }
            //    else //if (left < right)
            //    {
            //        left += arr[i];
            //        i++;
            //    }
            //}
            //if (left == right)
            //{
            //    return "YES";
            //}

            //return "NO";
        }

        //private static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter4.txt", true);

        //    int T = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int TItr = 0; TItr < T; TItr++)
        //    {
        //        int n = Convert.ToInt32(Console.ReadLine().Trim());

        //        List<int> arr =
        //            Console.ReadLine()
        //                .TrimEnd()
        //                .Split(' ')
        //                .ToList()
        //                .Select(arrTemp => Convert.ToInt32(arrTemp))
        //                .ToList();

        //        string result = balancedSums(arr);

        //        textWriter.WriteLine(result);
        //    }

        //    textWriter.Flush();
        //    textWriter.Close();
        //}

        private static int[] MissingNumbers(int[] arr, int[] brr)
        {
            var brrdict = new Dictionary<int, int>();
            foreach (var t in brr)
            {
                if (brrdict.ContainsKey(t))
                    brrdict[t] = brrdict[t] + 1;
                else brrdict.Add(t, 1);
            }

            var arrdict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arrdict.ContainsKey(arr[i]))
                    arrdict[arr[i]] = arrdict[arr[i]] + 1;
                else arrdict.Add(arr[i], 1);
            }

            var list = new List<int>();
            foreach (var i in brrdict)
            {
                var totMissinNumber = 0;
                if (arrdict.ContainsKey(i.Key))
                {
                    if (arrdict[i.Key] != i.Value)
                    {
                        totMissinNumber = i.Value - arrdict[i.Key];
                    }
                }
                else totMissinNumber = i.Value;

                while (totMissinNumber > 0)
                {
                    if (!list.Contains(i.Key))
                        list.Add(i.Key);
                    totMissinNumber--;
                }
            }

            list = list.OrderBy(n => n).ToList();

            return list.ToArray();
        }

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter3.txt", true);
        //    string[] lines = System.IO.File.ReadAllLines("E:\\input02.txt");

        //    int n = Convert.ToInt32(lines[0]);

        //    int[] arr = Array.ConvertAll(lines[1].Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        //    ;
        //    int m = Convert.ToInt32(lines[2]);

        //    int[] brr = Array.ConvertAll(lines[3].Split(' '), brrTemp => Convert.ToInt32(brrTemp))
        //    ;
        //    //int n = Convert.ToInt32(Console.ReadLine());

        //    //int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        //    //;
        //    //int m = Convert.ToInt32(Console.ReadLine());

        //    //int[] brr = Array.ConvertAll(Console.ReadLine().Split(' '), brrTemp => Convert.ToInt32(brrTemp))
        //    //;
        //    int[] result = missingNumbers(arr, brr);

        //    textWriter.WriteLine(string.Join(" ", result));

        //    textWriter.Flush();
        //    textWriter.Close();
        //}

        // Complete the icecreamParlor function below.
        
        private static int[] icecreamParlor(int m, int[] arr)
        {
            var newArray = arr.ToList();
            Array.Sort(arr);
            int[] result = new int[2];

            int len = arr.Length;
            int i = 0;
            int j = len - 1;

            while (j > 0 && i < len)
            {
                if (arr[i] + arr[j] == m)
                {
                    var su = GetIndex(newArray, arr[i], true) + 1;
                    var jo = GetIndex(newArray, arr[j], false) + 1;
                    if (su > jo)
                    {
                        var temp = jo;
                        jo = su;
                        su = temp;
                    }
                    return new[] {su, jo};
                }
                else if (arr[i] + arr[j] > m)
                    j--;
                else if (arr[i] + arr[j] < m)
                    i++;
            }

            return result;
        }

        private static int GetIndex(List<int> list, int num, bool firstIndex)
        {
            //var list = arr.ToList();
            if (firstIndex)
                return list.IndexOf(num);
            else return list.LastIndexOf(num);
        }

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter3.txt", true);

        //    int t = Convert.ToInt32(Console.ReadLine());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        int m = Convert.ToInt32(Console.ReadLine());

        //        int n = Convert.ToInt32(Console.ReadLine());

        //        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        //        ;
        //        int[] result = icecreamParlor(m, arr);

        //        textWriter.WriteLine(string.Join(" ", result));
        //    }

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
    }
}