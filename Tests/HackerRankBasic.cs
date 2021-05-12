using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class HackerRankBasic
    {
        public void FizzBuzz(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                var res = "";
                if (i % 3 == 0)
                    res = "Fizz";
                if (i % 5 == 0)
                    res += "Buzz";

                if (res.Length > 0)
                    Console.WriteLine(res);
                else Console.WriteLine(i);

            }

        }
        //public void ReadCon()
        //{
        //    var read = Console.ReadLine();
        //    Console.WriteLine(read);
        //}
    }
}
