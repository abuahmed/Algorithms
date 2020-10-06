using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;

namespace HackerRank
{
    internal partial class Solution
    {
        static void MainP(string[] args)
        {
            string st = "abebe beso bela";
            int count = StringConstruction(st);
            count = Gemstones(st.Split(' '));

            var sst = "abcdgdcba";
            var res=FunnyString(sst);//Same as Palindrome i.e Funny means IsPalindrome
            int ress = TheLoveLetterMystery(sst);

            ress = PalindromeIndex(sst);
            ress = Anagram("fdhlvosfpafhalll");
            ress = MarsExploration("SOSSOSADGGHTSOKKOSKLS");
            ress = MakingAnagrams("cde", "abc");
            ress = SpecialStringAgain("asasd");//("abcbaba");//("aaaa");//

            res = TwoStrings("ABC", "ADEF");
            res = Pangrams(sst);
            res = SeparateNumbers("99910001001");

            var hr = "hhhhhhackerankkkk";
            res = HackerrankInString(hr);

            count = AlternatingCharacters("AAABBBCDC");
        }
        
        private static int Alternate(string s)
        {
            var sreduced = SuperReducedString2(s);

            var setOfChars = new HashSet<char>(sreduced.ToArray());
            var setOfCharsArray = setOfChars.ToArray().ToList();
            var numOfChars = setOfChars.Count;

            var comChars = new HashSet<string>();
            for (int i = 0; i < numOfChars - 1; i++)
            {
                for (int j = i + 1; j < numOfChars; j++)
                {
                    comChars.Add(setOfCharsArray[i].ToString() + setOfCharsArray[j].ToString());
                }
            }

            List<char> sHashSet = new List<char>(sreduced.ToArray());
            var max = 0;
            foreach (var comChar in comChars)
            {
                var exceptChars = comChar.ToArray();
                foreach (var ofChar in setOfChars)
                {
                    if (ofChar != exceptChars[0] && ofChar != exceptChars[1])
                    {
                        sHashSet.RemoveAll(c => c == ofChar);
                    }
                }

                var freduced = new string(sHashSet.ToArray());
                if (SuperReducedString2(freduced).Length == freduced.Length)
                {
                    if (freduced.Length > max)
                        max = freduced.Length;
                }
                sHashSet = new List<char>(sreduced.ToArray());
            }

            return max;
        }

        private static string SuperReducedString2(string s)
        {
            var sLen = s.Length;

            List<char> sHashSet = new List<char>(s.ToArray());

            int i = 0;
            while (i < sLen - 1)
            {
                if (sHashSet[i] == sHashSet[i + 1])
                {
                    var a = sHashSet[i];
                    sHashSet.RemoveAll(c => c == a);
                    sLen = sHashSet.Count;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            return new string(sHashSet.ToArray());
        }

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter3.txt", true);

        //    int l = Convert.ToInt32(Console.ReadLine().Trim());

        //    string s = Console.ReadLine();

        //    int result = alternate(s);

        //    textWriter.WriteLine(result);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
        // Complete the stringReduction function below.
        
        private static int stringReduction(string s)
        {
            var sArray = s.ToArray();
            int numa = 0, numb = 0, numc = 0;
            foreach (var ch in sArray)
            {
                switch (ch)
                {
                    case 'a':
                        numa++;
                        break;
                    case 'b':
                        numb++;
                        break;
                    case 'c':
                        numc++;
                        break;
                }
            }
            if ((numa == 0 && numb == 0) || (numa == 0 && numc == 0) || (numb == 0 && numc == 0))
                return s.Length;
            if ((numa%2 == 0 && numb%2 == 0 && numc%2 == 0) || (numa%2 == 1 && numb%2 == 1 && numc%2 == 1))
                return 2;

            return 1;
        }

        private static int stringReduction2(string s)
        {
            var sArray = s.ToArray();
            var sLen = s.Length;

            var sTemp = s;
            List<char> sHashSet = new List<char>(sArray);

            //ababbac aabaaabc
            var templist = new List<string>();
            int i = 0;
            while (i < sLen - 1 && (i + 1 < sHashSet.Count))
            {
                if (sHashSet[i] == sHashSet[i + 1])
                {
                    i++;
                }
                else
                {
                    //acabcbbcbabbabcacbaaccb
                    //ccbaccccbcccccbbccbaabaaabcabaabcbbcbccabccbcbacbcccbaccbabcabbcaa
                    var strtoreplace = sTemp.Substring(i, 2);
                    if (!strtoreplace.Contains("a"))
                        strtoreplace = "a";
                    else if (!strtoreplace.Contains("b"))
                        strtoreplace = "b";
                    else if (!strtoreplace.Contains("c"))
                        strtoreplace = "c";
                    sTemp = sTemp.Substring(0, i) + strtoreplace + sTemp.Substring(i + 2);
                    //sTemp = sTemp.Replace(sTemp.Substring(i, 2), strtoreplace);
                    templist.Add(sTemp);
                    sHashSet = new List<char>(sTemp.ToArray());
                    sLen = sLen - 1;
                    i = 0;
                }
            }

            return sTemp.Length;
        }

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter3.txt", true);

        //    int t = Convert.ToInt32(Console.ReadLine());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        string s = Console.ReadLine();

        //        int result = stringReduction(s);

        //        textWriter.WriteLine(result);
        //    }

        //    textWriter.Flush();
        //    textWriter.Close();
        //}

        private static string superReducedString(string s)
        {
            var sArray = s.ToArray();
            var sLen = s.Length;

            var sTemp = s;
            List<char> sHashSet = new List<char>(sArray);

            int i = 0;
            while (i < sLen - 1)
            {
                if (sHashSet[i] == sHashSet[i + 1])
                {
                    sTemp = sTemp.Remove(i, 2);
                    sHashSet = new List<char>(sTemp.ToArray());
                    sLen = sLen - 2;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            if (sTemp.Length > 0)
                return sTemp;
            return "Empty String";
        }

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter.txt", true);

        //    string s = Console.ReadLine();

        //    //string result = superReducedString(s);
        //    int result = stringReduction(s);
        //    textWriter.WriteLine(result);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
        

        private static string IsValid(string s)
        {
            s =
                "ibfdgaeadiaefgbhbdghhhbgdfgeiccbiehhfcggchgghadhdhagfbahhddgg" +
                "hbdehidbibaeaagaeeigffcebfbaieggabcfbiiedcabfihchdfabifahcbhag" +
                "ccbdfifhghcadfiadeeaheeddddiecaicbgigccageicehfdhdgafaddhffadig" +
                "fhhcaedcedecafeacbdacgfgfeeibgaiffdehigebhhehiaahfidibccdcdag" +
                "ifgaihacihadecgifihbebffebdfbchbgigeccahgihbcbcaggebaaafgfedbfg" +
                "agfediddghdgbgehhhifhgcedechahidcbchebheihaadbbbiaiccededchdag" +
                "fhccfdefigfibifabeiaccghcegfbcghaefifbachebaacbhbfgfddeceababbacg" +
                "ffbagidebeadfihaefefegbghgddbbgddeehgfbhafbccidebgehifafgbghafacg" +
                "fdccgifdcbbbidfifhdaibgigebigaedeaaiadegfefbhacgddhchgcbg" +
                "caeaieiegiffchbgbebgbehbbfcebciiagacaiechdigbgbghefcahg" +
                "bhfibhedaeeiffebdiabcifgccdefabccdghehfibfiifdaicfedag" +
                "ahhdcbhbicdgibgcedieihcichadgchgbdcdagaihebbabhibcihicadg" +
                "adfcihdheefbhffiageddhgahaidfdhhdbgciiaciegchiiebfbcbhaeag" +
                "ccfhbfhaddagnfieihghfbaggiffbbfbecgaiiidccdceadbbdfgigibgcg" +
                "chafccdchgifdeieicbaididhfcfdedbhaadedfageigfdehg" +
                "cdaecaebebebfcieaecfagfdieaefdiedbcadchabhebgehiidfcgahcdhcdhg" +
                "chhiiheffiifeegcfdgbdeffhgeghdfhbfbifgidcafbfcd";
            
            var fs = s.ToArray();
            var dict = new Dictionary<char, int>();
            for (var i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(fs[i]))
                {
                    dict[fs[i]] = dict[fs[i]] + 1;
                }
                else
                {
                    dict.Add(fs[i], 1);
                }
            }
            //aaaabbcc 4 2 2
            var val = dict.Values.ToList();
            var valdict = new Dictionary<int, int>();
            for (int j = 0; j < val.Count; j++)
            {
                if (valdict.ContainsKey(val[j]))
                {
                    valdict[val[j]] = valdict[val[j]] + 1;
                }
                else
                {
                    valdict.Add(val[j], 1);
                }
            }

            var values = valdict.Values.ToList();
            var keys = valdict.Keys.ToList();
            if (values.Count == 1)
                return "YES";
            else if (values.Count > 2)
                return "NO";
            else
            {
                if (values[0] > values[1])
                {
                    if (values[1] != 1)
                        return "NO";
                    else
                    {
                        if (keys[1] == 1 || Math.Abs(keys[1] - keys[0]) == 1)
                            return "YES";
                    }
                }
                else
                {
                    if (values[0] != 1)
                        return "NO";
                    else
                    {
                        if (keys[0] == 1 || Math.Abs(keys[1] - keys[0]) == 1)
                            return "YES";
                    }
                }
            }

            return "NO";
        }
        
        //static void Main(string[] args)
        //    {
        //        TextWriter textWriter = new StreamWriter("E:\\textwriter.txt", true);

        //        string s = Console.ReadLine();

        //        string result = isValid(s);

        //        textWriter.WriteLine(result);

        //        textWriter.Flush();
        //        textWriter.Close();
        //    }
        // Complete the stringConstruction function below.
        
        private static int StringConstruction(string s)
        {
            var fs = s.ToArray();

            return fs.Distinct().Count();
            //OR
            return new HashSet<char>(fs).Count;
        }
        
       
        private static int MakingAnagrams(string s1, string s2)
        {
            var numberOfChars = 0;
            var fs = s1.ToArray();
            var ss = s2.ToArray();

            IList ssHashSet = new List<char>(ss);

            var countFromfs = 0;
            for (var i = 0; i < s1.Length; i++)
            {
                var ind = ssHashSet.IndexOf(fs[i]);
                if (ind != -1)
                {
                    countFromfs++;
                    ssHashSet.RemoveAt(ind);
                }
            }
            countFromfs = fs.Length - countFromfs;
            numberOfChars = countFromfs + ssHashSet.Count;
            return numberOfChars;
        }

        private static int SpecialStringAgain(string s)
        {
            var len = s.Length;
            var sArray = s.ToArray();
            var counts = len;
            for (int i = 0; i < len-1; i++)
            {
                int j = i + 1;
                string ss = s[i].ToString();
                while (j<len)
                {
                    if (sArray[i] == sArray[j])
                    {
                        counts++;
                        ss += s[j];
                        j++;
                    }
                    else
                    {
                        var sslen = ss.Length;
                        if (j + 1 + sslen <= len)
                        {
                            var subs = s.Substring(j + 1, sslen);   
                            if (subs == ss)
                            counts++;
                        }
                        break;
                    }
                    
                }
            }
            return counts;
        }

        private static int Anagram(string s)
        {
            //xaxbbbxx
            //fdhlvosfpafhalll
            //fhlf paall
            //aaa bbb
            var len = s.Length;
            if (len%2 == 0)
            {
                var halfLen = s.Length/2;
                var numberOfChars = 0;
                var fs = s.Substring(0, halfLen).ToArray();
                var ss = s.Substring(halfLen).ToArray();

                IList ssHashSet = new List<char>(ss);

                for (var i = 0; i < halfLen; i++)
                {
                    var ind = ssHashSet.IndexOf(fs[i]);
                    if (ind != -1)
                        ssHashSet.RemoveAt(ind);
                    else
                        numberOfChars++;
                }
                return numberOfChars;
            }
            else
                return -1;
        }

        private static int PalindromeIndex(string s)
        {
            var len = s.Length;
            for (int i = 0, j = len - 1; i < len/2; i++, j--)
            {
                if (s[i] != s[j])
                {
                    var removesi = s.Remove(i, 1);
                    var reverseremovesi = String.Join("", removesi.ToArray().Reverse().ToArray());
                    if (removesi.Equals(reverseremovesi))
                        return i;
                    else return j;
                }
            }
            return -1;
        }

        private static int AlternatingCharacters(string s)
        {
            s = s.ToLower();
            var len = s.Length;
            var sArray = s.ToArray();
            var startPos = 0;
            var noOfDeletions = 0;
            //AAABBB
            while (startPos < len)
            {
                var ch = sArray[startPos];
                var i = 0;
                for (i = startPos + 1; i < len; i++)
                {
                    if (ch == sArray[i])
                    {
                        noOfDeletions++;
                    }
                    else
                    {
                        break;
                    }
                }
                startPos = i;
            }

            return noOfDeletions;
        }
        
        private static int Gemstones(string[] arr)
        {
            var len = arr.Length;
            var intersect = arr[0].Intersect(arr[1]).ToArray();
            for (int i = 2; i < len; i++)
            {
                intersect = intersect.Intersect(arr[i]).ToArray();
            }

            return intersect.Length;
        }
        
        private static string FunnyString(string s)
        {
            const string alphabets = "abcdefghijklmnopqrstuvwxyz";
            s = s.ToLower();
            var len = s.Length;
            var sArray = s.ToArray();

            for (int i = 0, j = len - 1; i < len - 1; i++, j--)
            {
                var sIndex = alphabets.IndexOf(sArray[i]) + 97;
                var sNextIndex = alphabets.IndexOf(sArray[i + 1]) + 97;
                var dif = Math.Abs(sIndex - sNextIndex);

                var sRevereseIndex = alphabets.IndexOf(sArray[j]) + 97;
                var sReverseNextIndex = alphabets.IndexOf(sArray[j - 1]) + 97;
                var difReverse = Math.Abs(sRevereseIndex - sReverseNextIndex);

                if (dif != difReverse)
                    return "Not Funny";
            }
            return "Funny";
        }
        
        private static string SeparateNumbers(string s)
        {
            /*
            4
            99910001001
            7891011
            9899100
            999100010001
            123451234612347
            1234567891011121314
         * 
            YES 999
            YES 7
            YES 98
            NO
            YES 12345
            YES 1
         */


            var result = "NO";
            Int64 beginValue = 0;
            for (var i = 0; i < s.Length/2 + 1; i++)
            {
                var intvalue = Convert.ToInt64(s.Substring(0, i + 1));
                string finalres = intvalue.ToString();

                for (int j = 1; j < s.Length; j++)
                {
                    finalres += intvalue + j;
                    if (finalres.Length >= s.Length)
                        break;
                }

                if (!intvalue.ToString().Equals(s) && finalres.Substring(0, finalres.Length).Equals(s))
                {
                    result = "YES";
                    beginValue = intvalue;
                    break;
                }
            }
            if (result.Equals("YES"))
            {
                //Console.WriteLine(result + " " + beginValue);
                return result + " " + beginValue;
            }
            else  return result;//Console.WriteLine(result);//
        }

        //cba → bba → aba.
        //abcd → abcc → abcb → abca → abba.
        //abc → abb → aba.

        private static int TheLoveLetterMystery(string s)
        {
            const string alphabets = "abcdefghijklmnopqrstuvwxyz";
            var len = s.Length/2;
            s = s.ToLower();

            var fs = s.Substring(0, len);
            var ss = s.Length%2 == 1 ? s.Substring(len + 1) : s.Substring(len);

            var fsArray = fs.ToArray();
            var reversedArray = ss.ToArray().Reverse().ToArray();
            var minNumber = 0;

            for (int i = 0; i < s.Length/2; i++)
            {
                if (fsArray[i] != reversedArray[i])
                {
                    var diff = Math.Abs(alphabets.IndexOf(fsArray[i]) - alphabets.IndexOf(reversedArray[i]));
                    minNumber += diff;
                }
            }

            return minNumber;
        }

        private static string[] WeightedUniformStrings(string s, int[] queries)
        {
            const string alphabets = "abcdefghijklmnopqrstuvwxyz";
            s = s.ToLower();
            var answers = new string[queries.Length];

            var prevweight = 0;
            var weights = new HashSet<int>();

            for (int i = 0; i < s.Length; i++)
            {
                var weight = alphabets.IndexOf(s[i]) + 1;
                if (i > 0 && s[i - 1] == s[i])
                {
                    weight = prevweight + weight;
                    prevweight = weight;
                }
                else
                {
                    prevweight = weight;
                }

                weights.Add(weight);
            }

            var ind = 0;
            foreach (var query in queries)
            {
                if (weights.Contains(query))
                {
                    answers[ind] = "Yes";
                }
                else
                {
                    answers[ind] = "No";
                }
                ind++;
            }

            return answers;
        }
        
        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter.txt", false);

        //    string s =  Console.ReadLine();

        //    int queriesCount =  Convert.ToInt32(Console.ReadLine());

        //    int[] queries = new int[queriesCount];

        //    for (int i = 0; i < queriesCount; i++)
        //    {
        //        int queriesItem = Convert.ToInt32(Console.ReadLine());
        //        queries[i] = queriesItem;
        //    }

        //    string[] result = weightedUniformStrings(s, queries);

        //    textWriter.WriteLine(string.Join("\n", result));

        //    textWriter.Flush();
        //    textWriter.Close();
        //}

        private static string Pangrams(string s)
        {
            char[] alphabets = "abcdefghijklmnopqrstuvwxyz".ToArray();
            s = s.ToLower();
            foreach (var alphabet in alphabets)
            {
                if (s.IndexOf(alphabet) == -1)
                    return "not pangram";
            }

            return "pangram";
        }

        private static string HackerrankInString(string s)
        {
            var reg = new Regex("h.*a.*c.*k.*e.*r.*r.*a.*n.*k.*");
            if (reg.IsMatch(s))
                return "YES";
            return "NO";

            //OR

            var hrank = "hackerrank".ToCharArray();
            var ind = 0;
            foreach (var hr in hrank)
            {
                if (ind == s.Length)
                    return "NO";
                var foundindex = s.IndexOf(hr, ind);
                if (foundindex != -1)
                    ind = foundindex + 1;
                else return "NO";
            }
            return "YES";
        }

        private static int MarsExploration(string s)
        {
            var sosLen = s.Length/3;
            var numOfWrongChars = 0;
            for (var i = 0; i < sosLen; i++)
            {
                var sosString = s.Substring(i*3, 3);
                if (!sosString.Equals("SOS"))
                {
                    if (sosString[0] != 'S')
                    {
                        numOfWrongChars++;
                    }
                    if (sosString[1] != 'O')
                    {
                        numOfWrongChars++;
                    }
                    if (sosString[2] != 'S')
                    {
                        numOfWrongChars++;
                    }
                }
            }
            return numOfWrongChars;
        }

        //public static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter("E:\\textwriter.txt", true);

        //    string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        //    int n = Convert.ToInt32(firstMultipleInput[0]);

        //    int m = Convert.ToInt32(firstMultipleInput[1]);

        //    List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        //    List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        //    int total = GetTotalXResult.getTotalX(arr, brr);

        //    textWriter.WriteLine(total);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}

        private static int GetTotalX(List<int> a, List<int> b)
        {
            var asorted = a.OrderBy(x => x).ToList();
            var bsorted = b.OrderBy(x => x).ToList();
            var start = a[asorted.Count - 1];
            var end = b[0];
            var numOfDividers = 0;

            for (int i = start; i <= end; i++)
            {
                var isNot = false;
                foreach (var i1 in asorted)
                {
                    if (i % i1 != 0)
                        isNot = true;
                }
                foreach (var i1 in bsorted)
                {
                    if (i1 % i != 0)
                        isNot = true;
                }
                if (!isNot)
                    numOfDividers++;
            }

            return numOfDividers;
        }
    }
}