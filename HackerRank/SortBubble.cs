using System;
using System.Collections.Generic;

namespace HackerRank
{
    partial class Solution
    {
        private static void MainBubble(string[] args)
        {
            //var maxtoys = MaximumToys(50, new[] {1, 12, 5, 111, 200, 1000, 10});
            ////var maxtoys = MaximumToys(7, new[] { 1, 2, 3, 4 });
            //var noofswaps = BubbleSort2(3, new[] {3, 2, 1});
            //BubbleSort( new[] {3, 2, 1});

            var players = new Player[]
            {
                new Player("david",100), 
                new Player("amy",100),
                new Player("heraldo",50),
                new Player("aakansha",75),
                new Player("aleksa",150),
            };

            //Array.Sort(players,new Checker());

            int not = ActivityNotifications(3, new[] {30, 20, 10, 40, 50});//5, new[] {2,3,4,2,3,6,8,4,5});//4, new[] {1,2,3,4,4});//
        }

        private static int ActivityNotifications(int d, int[] expenditure)
        {
            var n = expenditure.Length;

            var maximumActivityNotification = n - d;
            var notifications = 0;
            var checkactivity = 0;

            while (checkactivity<maximumActivityNotification)
            {
                var arr = new int[d];
                var start = checkactivity;
                var end = checkactivity + d;

                Array.ConstrainedCopy(expenditure,start,arr,0,d);

                Array.Sort(arr);
                //BubbleSort(arr);

                var median = d/2;
                if (d%2 == 0)
                {
                    var m = d/2;
                    median = (arr[m - 1] + arr[m])/2;
                }
                
                if (expenditure[end] >= 2 * arr[median])
                    notifications++;

                checkactivity++;
            }
            
            return notifications;
        }

        private static int MaximumToys(int k, int[] arrInts)
        {
            Array.Sort(arrInts);
            int i = 0;
            int sum = 0;
            while (sum<=k)
            {
                sum += arrInts[i];
                i++;
            }
            return i-1;
        }

        private static int BubbleSort2(int n, int[] arrInts)
        {
            int numSwaps = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n-1; j++)
                {
                    if (arrInts[j] > arrInts[j + 1])
                    {
                        numSwaps++;
                        Swap(arrInts,j,j+1);
                    }
                }
            }
            return numSwaps;
        }

        //Bubble Sort
        static void BubbleSort(int[] a)
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            //string[] a_temp = Console.ReadLine().Split(' ');
            //int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            // Write Your Code Here
            var numOfSwaps = 0;
            var swapisRequired = true;
            while (swapisRequired)
            {
                swapisRequired = false;
                for (int i = 0; i < a.Length - 1; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        var temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                        numOfSwaps++;
                        swapisRequired = true;
                    }
                }
            }

            //Console.WriteLine("Array is sorted in " + numOfSwaps + " swaps.");
            //Console.WriteLine("First Element: " + a[0]);
            //Console.WriteLine("Last Element: " + a[n - 1]);
        }

        public class Checker : IComparer<Player>
        {
            public int Compare(Player x, Player y)
            {
                if (x.Score == y.Score)
                {
                    //Convert.ToInt32(x.Name);
                    return new CustomStringComparer().Compare(x.Name, y.Name);
                    //return System.String.CompareOrdinal(x.Name, y.Name);
                }
                if (x.Score < y.Score)
                    return -1;
                return 1;
            }
        }

        public class Player
        {
            public Player(string name, int score)
            {
                Name = name;
                Score = score;
            }

            public string Name { get; set; }

            public int Score { get; set; }
        }

        public class CustomStringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return String.Compare(x, y, StringComparison.Ordinal);
            }
        }
    }
}