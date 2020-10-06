using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoderByte
{
    class Program
    {
        static void Main(string[] args)
        {
            var coderbyte = LongestWord("fun&!! time");
        }

        public static string LongestWord(string sen)
        {

            // code goes here 
            var words = sen.Split(' ');
            int index = 0;
            var max = 0;
            for (int i = 0; i < words.Length; i++)
            {
                var word = Regex.Match(words[i], "[A-Za-z]+");
                if (word.Length > max)
                {
                    max = word.Length;
                    index = i;
                }
            }

            return words[index];

        }
    }
}
