using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HackerRank
{
    partial class Solution
    {
        public static void MainRegEx(string[] args)
        {
            //var result1 = TestReg("CSaaABCDCDABaaSS");
            //var result2 = CheckProgrammingLanguage("JAVA");
            //var result3 = OrRegex("01.Dr. Ahmed Ibrahim Yassin");
            //var result4= CheckGmailAccounts("ibra.yas@sub.gmail.com");
            //var result5 = MinimumNumber("Ab1!");
            //var result6 = Camelcase("abebeBesoBela");
            //var result7 = CaesarCipher("Abebe", 27);
            //var resilt8 = ForwardReferences("tactactic");
            //DetectHtmlTags();
            //FindaSubWord();
            //AlienUserName();
            //var res=IpAddressValidation();
            //DetectHtmlLinks();
            //FindaWord();
            //NorthAmericaTeleNum();
            //bool isMacAd=CheckMacAddress();
            //FindColorInTheFormat();
            //FindAllNumbers();
            //ParseAnExpression();
            //BackReferences();
            //FindProgrammingLanguages();
            //FindbbtagPairs();
            //FindTheFullTag();
            //CapturingLookAround();
            //FindingNonNegativeNumbers();
            //InsertAfterHead();
            //DetectTheDomainName();
            //BuildingSmartIdeCommentsDetection();
            //BuildingSmartIdeLanguageDetection();

            //DetectValidLatLongPairs();
            //HackerRankTweets();

            BritishAmericanSpellingStyle2();
            //SplitThePhoneNumbers();
        }
       
    
        private static int TestReg(string s)
        {
            Regex rx=new Regex("([A-Z]{2}).*\\1");
            //rx = new Regex("[A-Z]");
            var patExists = rx.IsMatch(s);
            var match = rx.Match(s);
            var split = rx.Split(s);
            MatchCollection matches = rx.Matches(s);
            foreach (var match2 in matches)
            {
                        
            }
            return rx.Matches(s).Count;
        }

        private static int OrRegex(string s)
        {
            var titles = "Mr|Mrs|Dr";

            var rx = new Regex("^\\d+\\.(?:" + titles + ")\\.\\s(?:\\w+\\s*)+$");
            var sp = rx.Split(s);
            var prfoud = rx.IsMatch(s);
            return 0;
        }

        private static int CheckProgrammingLanguage(string s)
        {
            var existingpr = "C:CPP:JAVA:C#:RUBY:PYTHON";
            var rx = new Regex("\\b"+s+"\\b");
            var sp = rx.Split(existingpr);
            var prfoud = rx.IsMatch(existingpr);

            //OR
            existingpr = existingpr.Replace(':', '|');
            rx=new Regex(existingpr);
            sp = rx.Split(existingpr);
            prfoud = rx.IsMatch(s);
            return 0;
        }

        private  bool CheckGmailAccounts(string emailId)
        {
            var regex = new Regex(@"\w@gmail.com$");//Check gmail.com emails ".+@gmail.com$"  "[a-z]+@gmail.com$" 
            regex = new Regex(@"^[a-zA-Z0-9_\\.-]+@(?:\w+\.)*\w+$");//Check Email
            return regex.IsMatch(emailId);
        }
        
        //Medium Level
        private static string DetectEmailAddresses()
        {
            string s = "";
            var regex = new Regex(@"^[a-zA-Z0-9_\\.-]+@(?:\w+\.)*\w+$");
            var hashSet = new HashSet<string>();
            foreach (var match in regex.Matches(s))
            {
                hashSet.Add(match.ToString().Replace("<", ""));
            }

            return string.Join(";", hashSet.OrderBy(ss => ss).ToArray());
        }

        private static string CaesarCipher(string s, int k)
        {
            const string alphabets = "abcdefghijklmnopqrstuvwxyz";
            k = k % 26;
            if (k==0) return s;
            var alphabetsRotated = alphabets.Substring(k) + alphabets.Substring(0, k);
            var cipherd = "";
            var regex = new Regex("[a-z]", RegexOptions.IgnoreCase);
            foreach (char c in s)
            {
                var isUpper = Char.IsUpper(c);
                if (regex.IsMatch(c.ToString(CultureInfo.InvariantCulture), 0))
                {
                    string ch = c.ToString(CultureInfo.InvariantCulture).ToLower();
                    var indexofChar = alphabets.IndexOf(ch);
                    var cipherChar = alphabetsRotated.Substring(indexofChar, 1);
                    if (isUpper)
                        cipherChar = cipherChar.ToUpper();
                    cipherd += cipherChar;
                }
                else
                {
                    cipherd += c.ToString();
                }
            }
            return cipherd;
        }

        private static int MinimumNumber(string password)
        {
            int n = password.Length;
            // Return the minimum number of characters to make the password strong
            var numberOfRequiredChars = 0;
            Regex regex = new Regex("[A-Z]");
            numberOfRequiredChars = !regex.IsMatch(password) ? numberOfRequiredChars + 1 : numberOfRequiredChars;

            regex = new Regex("[a-z]");
            numberOfRequiredChars = !regex.IsMatch(password) ? numberOfRequiredChars + 1 : numberOfRequiredChars;

            regex = new Regex("[0-9]");
            numberOfRequiredChars = !regex.IsMatch(password) ? numberOfRequiredChars + 1 : numberOfRequiredChars;

            regex = new Regex("[!@#$%^&*()\\-+]");
            numberOfRequiredChars = !regex.IsMatch(password) ? numberOfRequiredChars + 1 : numberOfRequiredChars;

            if (n < 6)
            {
                var num = 6 - n;
                if (num > numberOfRequiredChars)
                    numberOfRequiredChars = num;
            }

            return numberOfRequiredChars;
        }

        //Return Number of words in a CamelCased word
        private static int Camelcase(string s)
        {
            var rx = new Regex("[A-Z]");
            return rx.Matches(s).Count + 1;
            //OR
            return Regex.Matches(s, "[A-Z]").Count + 1;
        }

        private static bool ForwardReferences(string s)
        {
            var regex = new Regex("(?:tac){2,}tic[^(?:tic)]");
            return regex.IsMatch(s);
        }

        //Medium Level
        private static void DetectHtmlLinks2()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            //var hashSet = new HashSet<string>();
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s += Console.ReadLine();// "<p> <a href=''>link</a></p>";

            }
            s = s.Replace("\"", "'");
            //const string s = "<p> <a href='/wiki/Main_Page' title='title'><h1><b>Main Page</b></h1></a></p>";
            //var regex = new Regex("<a.+href='(?<href>.+?)'.*>(?<linkName>[A-Za-z\\s]+)<.+</a>");
            var regex = new Regex("<a.+href='(?<href>.+?)'.*?>(?<linkName>[A-Za-z\\s\\.]+)?</a>");//"?(?:</a>)");
            foreach (Match match in regex.Matches(s))
            {
                var href = match.Groups["href"].Value;
                var linkname = match.Groups["linkName"].Value;
                Console.WriteLine(href+","+linkname);
            }
        }
        private static void DetectHtmlLinks()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            //string s = "";
            for (int i = 0; i < n; i++)
            {
                var s = Console.ReadLine();// + "\n";
                s = s.Replace("\"", "'");
            //string s="<li style='-moz-float-edge: content-box'>... that <a href='/wiki/Orval_Overall' title='Orval Overall'>Orval Overall</a> <i>(pictured)</i> is the only <b><a href='/wiki/List_of_Major_League_Baseball_pitchers_who_have_struck_out_four_batters_in_one_inning' title='List of Major League Baseball pitchers who have struck out four batters in one inning'>Major League Baseball player to strike out four batters in one inning</a></b> in the <a href='/wiki/World_Series' title='World Series'>World Series</a>?</li>";
            
            var regex = new Regex("<a.+?</a>");
            var matches = regex.Matches(s);
            foreach (var match in matches)
            {
                var mat = match.ToString();
                var rege = new Regex("href='.+?'");
                var href = rege.Matches(mat)[0].ToString();
                href = href.Substring(href.IndexOf('\'') + 1).Replace("\'", "");

                var reg = new Regex(">[A-Za-z\\s\\.]+<");
                var text_name = reg.Matches(mat)[0].ToString();
                text_name = text_name.Substring(1, text_name.Length - 2);

                Console.WriteLine( href + "," + text_name);
            }}
            
        }

        //Medium Level
        private static void DetectTheDomainName()
        {
            const string s = "https://www.dev.hackerrank.com/contest/domain/datastructure";
            var rege = new Regex("https?://.+?/");
            foreach (var match in rege.Matches(s))
            {
                var mar = match.ToString();
                var str = match.ToString().Substring(mar.IndexOf("//") + 2);
                str = str.Replace("www.", "").Replace("ww2.", "").Replace("/", "");
            }
        }

        //Medium
        private static void BuildingSmartIdeCommentsDetection()
        {
            string s = "";// "//this is a single line comment\n x=1;//a single line comment after code\n/*This is multiline comment*/\n//a single line comment after multileine comment";
            string input = "";// Console.ReadLine();
            while ((input = Console.ReadLine()) != "x")
            {
                // Do whatever you want here with line
                s += input+"\n";
            }
           
            var rege = new Regex("//.+|/\\*.+\\*/");
            var matches = rege.Matches(s);

            //var gr = rege.Match(s).Groups;

            var count = matches.Count;
            foreach (var match in matches)
            {
            }
        }

        //Medium
        private static void BuildingSmartIdeLanguageDetection()
        {
            //java languages
            /*import java.
             * system.out
             */

            //python
            //_def ...
        }

        private static void DetectHtmlTags()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var hashSet = new HashSet<string>();
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s+=Console.ReadLine();// "<p> <a href=''>link</a></p>";
            }
            var regex = new Regex(@"<\w+");
            
            foreach (var match in regex.Matches(s))
            {
                hashSet.Add(match.ToString().Replace("<", ""));
            }
            
            var res = string.Join(";",hashSet.OrderBy(ss=>ss).ToArray());//.Count;
        }

        private static void FindaSubWord()
        {   
            //const string s = "existing pessimist optimist this is";
            //const string i = "is";
            int n = Convert.ToInt32(Console.ReadLine());
            string s = "";
            for (int j = 0; j < n; j++)
            {
                s += Console.ReadLine()+"\n";
                
            }

            int m = Convert.ToInt32(Console.ReadLine());
            for (int k = 0; k < m; k++)
            {
                string i = Console.ReadLine();
                var regex = new Regex("\\w+" + i + "\\w+");
                var count = regex.Matches(s).Count;
                Console.WriteLine(count);
            }
            
        }
        //Medium Level
        private static void FindaWord()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string s = "";
            for (int j = 0; j < n; j++)
            {
                s += Console.ReadLine() + "\n";

            }

            int m = Convert.ToInt32(Console.ReadLine());
            for (int l = 0; l < m; l++)
            {
                string i = Console.ReadLine();
                var regex = new Regex("(?<inside>[^\\w]" + i + "[^\\w])|(?<end>" + "[^\\w]" + i + "$)|(?<begining>^" + i + "[^\\w])");
            
                Console.WriteLine(regex.Matches(s).Count);
            }
        }
        private static void FindaWord2()
        {
            const string s = "foo bar (foo) bar foo-bar foo_bar foo'bar bar-foo bar, foo.";
            const string i = "foo";
            var regex = new Regex("(?<inside>[^\\w]" + i + "[^\\w])|(?<end>" + "[^\\w]" + i + "$)|(?<begining>^" + i + "[^\\w])");

            //var gr = regex.GetGroupNames();//.GroupNumberFromName("inside");
            //var ggr=regex.Match(s).Groups["inside"].Captures;//.Value;

            //Match m = regex.Match(s);
            //while (m.Success)
            //{
            //    for (int j = 1; j <= 3; j++)
            //    {
            //        Group g = m.Groups[j];
            //        var cc = g.Captures;
            //        for (int k = 0; k < cc.Count; k++)
            //        {
            //            var c = cc[k];
            //        }

            //    }
            //    m = m.NextMatch();
            //}
            
            var matches = regex.Matches(s);
            foreach (Match m in matches)
            {
                //while (m.Success)
                //{
                    for (int j = 1; j <= 3; j++)
                    {
                        Group g = m.Groups[j];
                        var cc = g.Captures;
                        for (int k = 0; k < cc.Count; k++)
                        {
                            var c = cc[k];
                        }

                    }
                    //m = m.NextMatch();
                //}
            }
            var count = regex.Matches(s).Count;

        }

        private static void NorthAmericaTeleNum()
        {
            string pattern = @"(?<area>\d{3})-(?<telNum>\d{3}-\d{4})";
            string input = "212-555-6666 906-932-1111 415-222-3333 425-888-9999";
            //var matches = Regex.Matches(input,pattern);
            ////var areacodes = matches.Cast<IEnumerable<Match>>().ToArray();
            //foreach (Match match in matches)
            //{
            //    var arecode = match.Groups["area"].Value;
            //    var telenum = match.Groups["telNum"].Value;
            //}
            //MatchEvaluator target=new MatchEvaluator(WordScrambler);
            //Regex.Replace(input, pattern, new MatchEvaluator(target));

            var rep = Regex.Replace(input, pattern, "${telNum}-${area}");//OR
            //rep = Regex.Replace(input, pattern, "$2-$1--${telNum}");
        }

        private static void AlienUserName()
        {
            string s = "_0898989811abced_";// "_0898989811abced_";//_abce//_09090909abcD0
            //s = ".08__";
            var regex = new Regex("^(_|\\.)\\d+[A-Za-z]*_?$");
            if (regex.IsMatch(s))
            {

            }
            else
            {
                
            }
            //var groups = regex.Match(s).Groups;
            //foreach (var @group in groups)
            //{

            //}
            var res = regex.IsMatch(s);
        }

        private static string IpAddressValidation()
        {
            //0-999 [0-9]|[1-9][0-9]|[1-9][0-9][0-9]
            //1-999 [1-9]|[1-9][0-9]|[1-9][0-9][0-9]
            //1-1000 [1-9]|[1-9][0-9]|[1-9][0-9][0-9]|1000
            //1-9999 [1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]
            //1-10 [1-9]|10
            //1-12 [1-9]|1[0-2]
            //1-16 [1-9]|1[0-6]
            //1-31 [1-9]|[12][0-9]|3[01]
            //1-32 [1-9]|[12][0-9]|3[0-2]
            //0-99 [0-9]|[1-9][0-9]
            //0-100 [0-9]|[1-9][0-9]|100
            //1-100 [1-9]|[1-9][0-9]|100
            //1-127 [1-9]|[1-9][0-9]|1[0-1][0-9]|12[0-7]
            //23:59 00:00 ([01][0-9]|2[0-3]):([0-5][0-9])
            // int n = Convert.ToInt32(Console.ReadLine());
            //string s = "";
            //for (int j = 0; j < n; j++)
            //{
            //    s = Console.ReadLine();
            //}

            string s = "121.18.19.20";
            string reg = "((?:[01]?[0-9][0-9]?|2[0-4][0-9]|25[0-5])\\.?)";
            var regex = new Regex("^"+reg+"{4}"+"$");
            var isipv4=regex.IsMatch(s);
            if (isipv4)
                return "IPv4";
           
            s = "2001:0db8:0000:0000:0000:ff00:0042:8329";
            reg = "((?:[0-9a-f]{1,4})\\:?)";
            regex = new Regex("^" + reg + "{8}" + "$");
            var isipv6 = regex.IsMatch(s);
            if (isipv6)
                return "IPv6";

            return "Neither";
        }

        private static bool CheckMacAddress()
        {
            string input = "01:32:54:67:89:AB";
            string pattern = @"([0-9a-f]{2}:){5}[0-9a-f]{2}";
            return Regex.IsMatch(input,pattern,RegexOptions.IgnoreCase);
        }

        private static void FindColorInTheFormat()
        {
            const string input = "color: #3f3; background-color:#AA00ef; and #abcd";
            const string pattern = @"#(([0-9a-z]{3}){1,2})\b";
            var count = Regex.Matches(input, pattern,RegexOptions.IgnoreCase).Count;
        }

        private static void FindAllNumbers()
        {
            const string input = "-1.5 0 2 -123.4.";
            const string pattern = @"-?\d+(\.\d+)?";
            var count = Regex.Matches(input, pattern, RegexOptions.IgnoreCase).Count;
        }

        private static void ParseAnExpression()
        {
            const string input = "1.2 * 3.4 1.2+3.4";
            const string pattern = @"(-?\d+(?:\.\d+)?)\s*(\+|\*|\-|/)\s*(-?\d+(?:\.\d+)?)";
            var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                var a = match.Groups[1];
                var op = match.Groups[2];
                var b = match.Groups[3];
            }
        }

        private static void BackReferences()
        {
            const string input = "trellis llama webbing dresser swagger";
            const string pattern = @"(?<qoute>\w)\k<qoute>";
            var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                var aa = match.Value + "-" + match.Index;
            }
        }

        private static void FindProgrammingLanguages()
        {
            const string input = "Java, JavaScript, PHP, C++, C";
            string pattern = @"\bJava|JavaScript|PHP|C\+\+|C\b";//OR
            pattern = @"Java(Script)?|PHP|C(\+\+)?";
            var count = Regex.Matches(input, pattern, RegexOptions.IgnoreCase).Count;
        }

        private static void FindbbtagPairs()
        {
            const string input = "..[url][b]http://google.com[/b][/url].[url2][b]http://google.com[/b][/url2].";
            const string pattern = @"((\[(?<tag>\w+\]).*?)\[/)\k<tag>";
            var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                
            }
        }
        
        private static void FindTheFullTag()
        {
            const string input = "<style> <styler> <style test='...' test2='...'>>>";
            const string pattern = @"<style(\s.*?)*>";
            var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {

            }
        }

        private static void CapturingLookAround()
        {
            const string input = "1 turkey costs 30$";
            const string pattern = @"\d+(?=(?<dollarsign>\$))";
            var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                var g = match.Groups["dollarsign"].Value;
            }
        }

        private static void FindingNonNegativeNumbers()
        {
            const string input = "0 12 -5 123 -18";
            string pattern = @"\b(?<!-)\d+\b";//OR
            pattern = @"(?<!-)(?<!\d)\d+";
            var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                
            }
        }
        
        private static void InsertAfterHead()
        {
            const string input = "<html>" +
                                 "<body style='height:200px'> ..." +
                                 "</body>" +
                                 "</html>";
            string pattern = @"<body.*?>";
            var rep = Regex.Replace(input, pattern, "$&<h1>Hello</h1>");
            //OR
            var pattern2 = @"(?<=<body.*?>).";
            var rep2 = Regex.Replace(input, pattern2, "<h1>Hello</h1>");
            
            var matches = Regex.Matches(input, pattern2, RegexOptions.IgnoreCase);
            foreach (var match in matches)
            {
                
            }
        }

        private static void ValidPanFormat()
        {
            //const string input = "ABCDS1234Y";//ABAB12345Y avCDS1234Y
            const string pattern = @"^[A-Z][A-Z][A-Z][A-Z][A-Z]\d\d\d\d[A-Z]$";
            int n = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < n; j++)
            {
                string input = Console.ReadLine(); // "(+090.0, +180.0)";//(90., 180.) (-090.00000, -180.0000)

                if (Regex.IsMatch(input, pattern))
                    Console.WriteLine("YES");
                else
                Console.WriteLine( "NO");
            }
        }

        private static void DetectValidLatLongPairs()
        {
            //-90<=lat<=+90 -180<=long<=180
            string lati = @"((([0-9]|[1-8][0-9])(\.\d+)?)|(90(\.0+)?))";
            string longi=@"((([0-9]|[1-9][0-9]|1[0-7][0-9])(\.\d+)?)|(180(\.0+)?))";
            
            string pattern = @"^\([\+\-]?" + lati + @",\s[\+\-]?" + longi+@"\)$" ;

            int n = Convert.ToInt32(Console.ReadLine());
            
            for (int j = 0; j < n; j++)
            {
                string input = Console.ReadLine();// "(+090.0, +180.0)";//(90., 180.) (-090.00000, -180.0000)
                if (Regex.IsMatch(input, pattern))
                Console.WriteLine("Valid");
                else
                Console.WriteLine("Invalid");
            }
            
        }

        private static int HackerRankTweets()
        {
            //const string input = "I love #HackerRank \n Iscored 27 in #hackerrank challenge.";//ABAB12345Y avCDS1234Y
            const string pattern = @"hackerrank";
            int n = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                string s = Console.ReadLine();
                if(Regex.IsMatch(s,pattern,RegexOptions.IgnoreCase))
                count++;//= Regex.Matches(s, pattern, RegexOptions.IgnoreCase).Count;
            }
            return count;
        }

        private static void BritishAmericanSpellingStyle()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string s = "";
            for (int j = 0; j < n; j++)
            {
                s += Console.ReadLine();// + "\n";
            }
            
            int m = Convert.ToInt32(Console.ReadLine());
            for (int l = 0; l < m; l++)
            {
                string i = Console.ReadLine();
                   i=i.Substring(0,i.Length-2);
                var regex = new Regex(i+@"[sz]e\b");

                Console.WriteLine(regex.Matches(s).Count);
            }

            //int n = Convert.ToInt32(Console.ReadLine());
            //const string pattern = @"[a-z]+[sz]e\b";
            //for (int j = 0; j < n; j++)
            //{
            //     //string input = "hackerrank has such a good ui that it takes no time to familirise its envt\n" +
            //     //                    "to familarize ze oneself with ui of hackerrank is easy";
            //    string input = Console.ReadLine();

            //    var matches = Regex.Matches(input, pattern);
            //    Console.WriteLine(matches.Count);
            //}
            ////foreach (Match match in matches)
            ////{
            ////    var aa = match.Value;
            ////}
                
            ////return matches.Count;
        }

        private static void BritishAmericanSpellingStyle2()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string s = "";
            for (int j = 0; j < n; j++)
            {
                s += Console.ReadLine() + "\n";
            }

            int m = Convert.ToInt32(Console.ReadLine());
            for (int l = 0; l < m; l++)
            {
                string i = Console.ReadLine();
                i = i.Replace("or","ou?r").Replace("our", "ou?r");
                var regex = new Regex(@"\b"+i+@"\b");

                Console.WriteLine(regex.Matches(s).Count);
            }
        }

        private static int SplitThePhoneNumbers()
        {
            const string input = "91-011-23413627";// "1 877 2638277";// "1-425-9854706";
            const string pattern = @"^(?<ccode>\d{1,3})[\s-](?<lacode>\d{1,3})[\s-](?<num>\d{4,10})$";

            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                var ccode = match.Groups["ccode"].Value;
                var lacode = match.Groups["lacode"].Value;
                var num = match.Groups["num"].Value;

                Console.WriteLine("CountryCode="+ccode+",LocalAreaCode="+lacode+",Number="+num);

            }

            return matches.Count;
        }

    }
    
}
