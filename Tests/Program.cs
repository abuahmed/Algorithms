using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //new HackerRankBasic().FizzBuzz(15);
            var nums = new int[] { 1, 1, 1, 3, 3, 2, 2 };//1,2,3,4,5};//0,1,2,1,2,3};//
            string[] lines = System.IO.File.ReadAllLines("E:\\input004.txt");

            int n = Convert.ToInt32(lines[0]);

            int[] arr = lines.Select(s => Convert.ToInt32(s)).ToArray();

            int result = 1;
            var res = LongestSubarray(arr.ToList());//,ref result);

            //var res = encryptPassword("43Ah*ck0rr0nk");// decryptPassword("hAck3rr4nk");
            //43Ah*ck0rr0nk
        }


        public static string encryptPassword(string s)
        {
            int i = 0;
            var snew = "";
            Stack<string> intnum = new Stack<string>();
            while (i < s.Length)
            {
                if (Regex.IsMatch(s[i].ToString(), "[A-Z]") && i + 1 < s.Length && Regex.IsMatch(s[i + 1].ToString(), "[a-z]"))
                {
                    snew += s[i + 1].ToString() + s[i].ToString();
                    i = i + 2;
                }
                else if (Regex.IsMatch(s[i].ToString(), "[1-9]"))
                {
                   intnum.Push(s[i].ToString());
                }
                else if (s[i].ToString() == "0")
                {
                    snew += intnum.Pop();
                }
                else
                {
                    snew += s[i].ToString();
                }

                i++;
            }

            return snew;
        }
        public static string decryptPassword(string s)
        {
            int i = 0;
            var snew = "";
            while (i < s.Length)
            {
                if (Regex.IsMatch(s[i].ToString(), "[a-z]") && i + 1 < s.Length && Regex.IsMatch(s[i + 1].ToString(), "[A-Z]"))
                {
                    snew += s[i + 1].ToString() + s[i].ToString() +"*";
                    i = i + 1;
                    
                }
                else if (Regex.IsMatch(s[i].ToString(), "[0-9]"))
                {
                    snew += "0";
                    snew = s[i].ToString() + snew;
                }
                else
                {
                    snew += s[i].ToString();
                }

                i++;
            }

            return snew;
        }
        
        public static void LongestSubarray(List<int> arr,ref int max)
        {
            if (arr.Count == 1)
                return ;
            int firstvalue = arr[0];
            int counter = 1;
            var list = new List<int>();
            list.Add(firstvalue);

            var anotherlist = new List<int>(list);

            for (int i = 1; i < arr.Count; i++)
            {
                if (list.Contains(arr[i]))
                {
                    counter++;
                    anotherlist.Add(arr[i]);
                }
                else if (list.Count < 2 && Math.Abs(arr[i] - firstvalue) == 1)
                {
                    list.Add(arr[i]);
                    anotherlist.Add(arr[i]);
                    counter++;
                }
                else
                {
                    var lastIndofFirstvalue = anotherlist.LastIndexOf(firstvalue) + 1;
                    LongestSubarray(arr.Skip(lastIndofFirstvalue).ToList(),ref max);
                    break;
                }
            }

            max=Math.Max(max,counter);
        }
        public static int LongestSubarray(List<int> arr)
        {
            int max = 0;
            int firstindex = 0;
            var totindexes = 0;
            bool alltaken = false;
            while (firstindex < arr.Count-1 && !alltaken)
            {
                int firstvalue = arr[firstindex];
                int counter = 1;
                var list = new List<int>();
                list.Add(firstvalue);

                var anotherlist = new List<int>(list);

                for (int i = firstindex+1; i < arr.Count; i++)
                {
                    if (list.Contains(arr[i]))
                    {
                        counter++;
                        anotherlist.Add(arr[i]);
                    }
                    else if (list.Count < 2 && Math.Abs(arr[i] - firstvalue) == 1)
                    {
                        list.Add(arr[i]);
                        anotherlist.Add(arr[i]);
                        counter++;
                    }
                    else
                    {
                        var lastIndofFirstvalue = anotherlist.LastIndexOf(firstvalue) + 1;
                        totindexes += lastIndofFirstvalue;
                        firstindex = totindexes;// firstindex + lastIndofFirstvalue;
                        max=Math.Max(max, counter);
                        //LongestSubarray(arr.Skip(lastIndofFirstvalue).ToList(), ref max);
                        break;
                    }
                    if (i == arr.Count-1)
                        alltaken = true;
                }
            }
            return max;
        }
    }
}
