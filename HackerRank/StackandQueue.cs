using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        static string _stack = "", _queue = "";

        public static void MainStQu(string[] args)
        {
            //string s = Console.ReadLine();
            string s = "abebebesoiqqiosebebeba";
            CheckPalindromeManual(s);
            CheckPalindromeAutomatic(s);
                
            s = "{{[[(())]]}}";//"{[(])}";//"{[()]}";//
            //var isBalance = IsBalanced(s);

            var largestRectangle = LargestRectangle(new long[]{3,2,3});// int[]{1, 2, 3, 4, 5});

            var riddle = Riddle(new long[] {1, 2, 3, 5, 1, 13, 3});//3, 5, 4, 7, 6, 2});//2, 6, 1, 12});//6,3,5,1,12});
        }

        public static string IsBalanced(string s)
        {
            var sLen = s.Length;
            if (sLen%2 == 1)
                return "NO";

            var sArray = s.ToArray().ToList();

            var qu = new Queue(sArray.Take(sLen / 2).ToList());
            var st = new Stack(sArray.Skip(sLen / 2).ToList());

            for (int i = 0; i < sLen / 2; i++)
            {
                var qq = qu.Dequeue().ToString().Replace("{", "}").Replace("(", ")").Replace("[", "]");
                if (st.Pop().ToString() != qq )
                {
                    return "NO";
                }
            }
            return "YES";
        }

        public static long LargestRectangle(long[] arr)
        {
            Array.Sort(arr);
            int len = arr.Length;
            var qu = new Queue(arr);
            var max = 1;
            while (qu.Count>0)
            {
                var he = (int) qu.Dequeue();
                max = Math.Max(max, he*len);
                len--;
            }

            return max;
        }

        public static long[] Riddle(long[] arr)
        {
            var len = arr.Length;
            var result = new long[len];

            for (int winSize = 1; winSize <= len; winSize++)
            {
                var lList = new List<long>();
                for (int i = 0; i <= len-winSize; i++)
                {
                    var aList = new List<long>();
                    for (var j = i; j < i+winSize && j<len; j++)
                    {
                        aList.Add(arr[j]);
                    }

                    var min = aList.Min();
                    lList.Add(min);
                }

                var max = lList.Max();
                result[winSize - 1] = max;
            }

            return result;
        }


        public static void StacksAndQueues()
        {
            Stack st = new Stack();
            Queue queue = new Queue();
            st.Push(12);
            st.Push(13);
            st.Push(new TreeNode(12));
            st.Push(15);
            st.Pop();
            st.Pop();

            Stack<int> sG = new Stack<int>();
            Queue<int> qG = new Queue<int>();

            int a = 12;
            sG.Push(a);
            qG.Enqueue(15);
        }
        
        static void PushCharacter(char ch)
        {
            _stack += ch.ToString();
        }

        static void EnqueueCharacter(char ch)
        {
            _queue += ch.ToString();
        }

        static char PopCharacter()
        {
            var lastItem = _stack.Substring(_stack.Length - 1);
            _stack = _stack.Substring(0, _stack.Length - 1);
            return lastItem[0];
        }

        static char DequeueCharacter()
        {
            var firstItem = _queue.Substring(0, 1);
            _queue = _queue.Substring(1);
            return firstItem[0];
        }

        static void CheckPalindromeManual(string s)
        {
            foreach (char c in s)
            {
                PushCharacter(c);
                EnqueueCharacter(c);
            }

            bool isPalindrome = true;

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (PopCharacter() != DequeueCharacter())
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                Console.Write("The word, {0}, is a palindrome.", s);
            }
            else
            {
                Console.Write("The word, {0}, is not a palindrome.", s);
            }

        }

        public static string CheckPalindromeAutomatic(string s)
        {
            var sLen = s.Length;
            var sArray = s.ToArray().ToList();

            var st = new Stack(sArray.Skip(sLen / 2).ToList());
            var qu = new Queue(sArray.Take(sLen / 2).ToList());

            for (int i = 0; i < sLen / 2; i++)
            {
                if (st.Pop().ToString() != qu.Dequeue().ToString())
                {
                    return "Not Palindrome";
                }
            }
            return "Palindrome";
        }

    }
}
