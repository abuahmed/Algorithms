using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        public static void MainBitwise(String[] args)
        {
            var res = SansaAndXor(new[] {50,13,2});//new[] {3, 4, 5});
            //var sum = SumBits(2147483647, 3);
            //string winner = CounterGame(132);
            //BinaryString("HackerRank");
            //BinaryString(8675309);
        }

        private static int Cipher(string s, int numberOfShifts)
        {
            return 0;
        }

        private static int SansaAndXor(int[] arr)
        {
            int len = arr.Length;

            var lList = new List<int>();
            for (int size = 1; size <= len; size++)
            {
                for (int i = 0; i <= len - size; i++)
                {
                    var aList = new List<int>();
                    for (var j = i; j < i + size && j < len; j++)
                    {
                        aList.Add(arr[j]);
                    }

                    lList.Add(GetXor(aList));
                }
            }

            return GetXor(lList);
        }

        private static int GetXor(List<int> aList)
        {
            var getXor = aList[0];
            if (aList.Count > 1)
            {
                getXor = aList[0] ^ aList[1];
                for (int j = 2; j < aList.Count; j++)
                {
                    getXor = getXor ^ aList[j];
                }
            }

            return getXor;
        }

        private static string CounterGame(int i)
        {
            var gamers = new[] {"Louise","Richard"};
            int turn = 1;

            while (i != 1)
            {
                var iBit = Convert.ToString(i, toBase: 2).ToArray();

                if (iBit.Count(a => a == '1') == 1)
                {
                    i = i/2;
                }
                else
                {
                    var st = string.Join("",iBit);
                    var indexofone = st.IndexOf('1');
                    st = st.Replace('1', '0');
                    var stArray = st.ToArray();
                    stArray[indexofone] = '1';
                    var sst = string.Join("",stArray);
                    i = i - Convert.ToInt32(sst, 2);
                }
                turn++;
            }

            return gamers[turn%2];
        }

        public static int SumBits(int a, int b)
        {
            int nota = ~ a;

            var aBit = Convert.ToString(a, toBase: 2);
            var notaBit=Convert.ToString(nota, toBase: 2);
            
            int y = a ^ b;

            while (b!=0)
            {
                int carryForward = a & b;
                a = a ^ b;
                b = carryForward << 1;
            }
            return a;
        }

        public static int MaxBit(int n, int k)
        {
            var maxlessk = 0;
            for (int i = n - 1; i > 0; i--)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    uint nfir = Convert.ToUInt32(i);
                    var nsec = Convert.ToUInt32(j);

                    var bitwiseand = nfir & nsec;
                    int res = Convert.ToInt32(bitwiseand);
                    if (res < k && res > maxlessk)
                    {
                        maxlessk = res;
                        //return maxlessk;
                    }
                }
            }
            return maxlessk;

            //var maxlessk = 0;
            //for (int i = 1; i < n; i++)
            //{
            //    for (int j = i+1; j <= n; j++)
            //    {
            //        uint nfir = Convert.ToUInt32(i);
            //        var nsec = Convert.ToUInt32(j);

            //        var bitwiseand = nfir & nsec;
            //        int res = Convert.ToInt32(bitwiseand);
            //        if (res < k && res > maxlessk)
            //            maxlessk = res;
            //    }
            //}

            //if (maxlessk != Convert.ToInt32(lines[tItr]))
            //{
            //    maxlessk = -1;
            //}

            //Console.WriteLine(maxlessk);
        }
        
        public static void BinaryString(String str)
        {

            var toByte = Convert.ToByte(str);
            foreach (var st in str)
            {
                string binary = Convert.ToString(st, 2);
                //Convert.ToByte()
            }
            //for( byte b : string.getBytes() ){
            //    System.out.print(Integer.toBinaryString(b) + " ");
            //}
            //System.out.println();
        }

        public static void BinaryString(Int32 integer){
            //System.out.println(Integer.toBinaryString(integer));
        }
        
    }
}
