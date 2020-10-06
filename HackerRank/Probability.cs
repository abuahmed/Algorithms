using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        private static void MainProb(string[] args)
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            //List<int> arr =
            //    Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            //MeanMedianMode(n,arr.ToArray());
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> x =
                Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            List<int> w =
                Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            WeightedMean(n, x.ToArray(), w.ToArray());
            //WeightedMean(5, new[] {10, 40, 30, 50, 20}, new[] {1, 2, 3, 4, 5});
            //MeanMedianMode(10,new []{64630,11735,14216,99233,14470,4978,73429,38120,51135,67060});
            //Quartiles(9, new[] {3, 7, 8, 5, 12, 14, 21, 13, 18});
            //InterquartileRange(6, new[] {6, 12, 8, 10, 20, 16}, new[] {5, 4, 3, 2, 1, 5});
            StandardDeviation(5, new[] {10, 40, 30, 50, 20});
        }

        private static void StandardDeviation(int n, int[] x)
        {
            var mean = (float)x.Sum()/n;
            var summ = 0.0;
            for (int i = 0; i < n; i++)
            {
                summ += Math.Pow(x[i] - mean, 2);
            }
            var sd = Math.Sqrt(summ/n);
            Console.WriteLine(sd.ToString("N1"));
        }

        private static void InterquartileRange(int n, int[] x, int[] f)
        {
            var setList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int j = f[i];
                while (j>0)
                {
                    setList.Add(x[i]);
                    j--;
                }
            }
            var count = setList.Count;
            var arr = setList.ToArray();
            Array.Sort(arr);

            var quartiles = Quartiles(count, arr);
            var range = quartiles[2] - quartiles[0];
            Console.WriteLine(range.ToString("N1").Replace(",",""));

        }
        
        private static float[] Quartiles(int n, int[] x)
        {
            Array.Sort(x);
            var answers = new float[3];
            var q2 = GetMedian(n, x);
            var halfLen = n/2;
            var x1 = new int[halfLen];
            var x3 = new int[halfLen];

            Array.ConstrainedCopy(x,0,x1,0,halfLen);
            Array.ConstrainedCopy(x, halfLen+n%2, x3, 0, halfLen);
            var q1 = GetMedian(halfLen, x1);
            var q3 = GetMedian(halfLen, x3);

            answers[0] = q1;
            answers[1] = q2;
            answers[2] = q3;
            Console.WriteLine(q1.ToString("N0"));
            Console.WriteLine(q2.ToString("N0"));
            Console.WriteLine(q3.ToString("N0"));

            return answers;
        }

        private static void WeightedMean(int n, int[] x, int[] w)
        {
            var xwproduct = 0;
            var wsum = 0;
            for (int i = 0; i < n; i++)
            {
                xwproduct += x[i]*w[i];
                wsum += w[i];
            }
            var wm = (decimal)xwproduct / wsum;
            var wmstr = wm.ToString("N1");
            Console.WriteLine(wmstr);
        }

        private static void MeanMedianMode(int n, int[] x)
        {
            var mean = (float) x.Sum()/n;
            var meanstr = mean.ToString("N1").Replace(",","");
            Console.WriteLine(meanstr);
            
            var median = GetMedian(n, x);
            var medianstr = median.ToString("N1");
            Console.WriteLine(medianstr);

            var dict=new Dictionary<int, int>();
            foreach (var i in x)
            {
                if (dict.ContainsKey(i))
                    dict[i] = dict[i] + 1;
                else dict[i] = 1;
            }
            var sorted = dict.OrderByDescending(d => d.Value).ThenBy(d => d.Key);
            var answer = sorted.FirstOrDefault();
            Console.WriteLine(answer.Key);

        }

        private static float GetMedian(int n, int[] x)
        {
            Array.Sort(x);
            float median = 0;
            if (n % 2 == 0)
            {
                var sm = x[n / 2 - 1] + x[n / 2];
                median = (float)sm / 2;
            }
            else
            {
                median = x[n / 2 ];
            }

            return median;
        }
    }
}
