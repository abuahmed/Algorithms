using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        static void MainStrings(string[] args)
        {
            //var dt = DateTime.Now;
            //var wp = WordPattern("aaaa", "aa aa aa aa");
            //var dt2 = DateTime.Now;
            //var sub = dt2.Subtract(dt).Milliseconds;

            //var pl = PartitionLabels("ababcbacadefegdehijhklij");//("caedbdedda");//("qiejxqfnqceocmy");//
            //var subsres = RepeatedSubstringPattern("abababab");//"prdttmqtookjbrryiwbouvkhgbrommxyhyscpnphvjllkwawtbwftgzczcrmviwpaacbsfuqpiqiyjwbeesmsbqmorjstvrgvmdizflhkkeumcptccryrkxzzxvygkemhbyfmhpexfoidjqvwfccqitxrppkrxlxrrvkvogcmgzqaivhbbgjtgfgpgspmlhfcgelhovcnamaizcaysvrpsnverowehpiztmedkixsxwzzseaozyzjvpvxetprasbndetckeemhqhfyqcdecgdtraxznlcdlwyxutryycmcxsyyscnutifyjecsudmhbfgpvymiovjwcmgsgzcebovlztfpknmtqlkxychrwxqfaumevtdkgbuqebyrnudvcfjydxqihvauauymxgdfjlemmpozgdzvsatcvemrojmxhvfmfbtdjywwephrzbutnuommunmnhmnqgfxxjwvregecxmqxmrukeynsgfsvkojfchcjuqmyypbndycjknlmxdjafhstcyszbujfxcduojzmynweqshnskjvbcdjhhhwckkrtebyzoqapwbebancwhmqwobvyxcfglwuwvyjfwwumcvovcghypywyiqbwjdgmedyhfppmmyafvwyavtdtuyzbmfxfeljberxdtlpavaxgectauqycnfgkhdcvhteiggngynbnqvpqtoxpktehmddebvbpeigccpnrraomgllylvkalezuprztzdlotldnjtgjywtawkykdjucbfmuwyvrqftrmbyjhfkndsehrlybncisumoczkxaadaleqwvjpqauhqgibmbxcivjdroaghxvwybphqkelwdoidxnygjtguhfqlthemedjmnhoclssfkrkzwalgapnbemkujrshojxqddkbqwfqkismfrxofgqibpqnngroephngywjakiozcceypzzaqcwqogbucjwaybvbmhgljjndcwcrxttkqdfcvacvrnjgwtexmeytarnltfiqqjrtxyfipyrshacohcdkovnktrdhopzdfyripyabgasnzxgpsxcrdhuiwaedcmuoigadrsmeowolpzsvywxihgebyqvuebmxcuoofumbxlntxzlhdexixaafuqrtrwompetjgaqwdlchxsxdtutibhnivvnudtkotiulxngwpgfytzhebjlrroabxcepbqvnnlygsyjhhohttgwvjuthdnrxkxzurxwjpneiglhcneqxgjlckxlmwwutpaionzyhsbmkpitkakbylnhdurxvunqrcwurvgznprfrhwrtpysqfbawwhuqdvjaosgivobaqfzfqfutniwuftxvjjlanuppywvlqnhrtxoezmokdezusxvidvtfkxbwhrkurathgbavskrixzhbjtbitijivamodyzqbnaasoudafojrmqzcmzdgxvhbqcebgdqekwisxpkysblxxgnreabrcowuinszcopghezmuekagcohqcrizdccwaenjfuztrkcxrkcnmxzgrvvjhgsaztaitjxhdaflspbnkhyyqvqwhullodqcbvphffimcsssasvwtqgijbhotypcguoeudqumblxtzxmnggrbhfrsemcatjmwoetgjvydqeykvubvodyexkeqwuvjdpawqvrkcgaqzoykoutlpoiytvseduaxwqhekunupqlvagdfdttbnbjswwbkmrfyceddqngweyfcuzrlgwrbzpypilwsnvkxkcfviybnrfwerbvvqgmqulhukecazlkdewkwtevkjcijbznrejkoilwidafqemxlrhyjmaltrzeojhatrajqbqgycnpudkbvajwwjfwvnhemecppdkeierofqxuisemskpjwihgnqbhrjhfbvatszcudryonznpsuzwsgwpwojhgmtqekelbjecuvachcbnrdzjopyugzyplnvensvobdyqqifyevtwblvwcueiaghnhsaoeqpdovftqhgxgpebzqbhwlcpgunzqeousobxwfzcjnbmrdjuwgfxojacxtczdxzrbnkjmbqbwdufmwqbtmcpvkohwwgozpethrrzzmrucrntxtwhooblrqbwwapsvwogajovblyeaesfrjanjjjhywbmsrnfnhdvqrkfebpwanpmpfzxorvadwaqtsotwtdsuiiizeqmdekntmxupctqzcnvozaitstehyvnakcharcfymsuqzrjmfbksvkezbvvqzdohnfjrbroihypehjiftqmdccprcargjhuoxqjpeckmnqdlaiukzzpdpcvvidkuzeyswefkfzbuyxzdwdstvqwmrnvwmkoyeoozqkpjbaymuwjadzjhhxrsjvxayvjqpynfufltfbgegsqharujbdsyyfqoiigrdomwwcfsqadrlntssbblposlmjbclcbhmeksstorsubikjvvllnhmpvsptzpkioyhrzonxtmfjnkwhshxmdmaigdukdvsqwugsijcwkbbnysiirdpamjxcqxmdecbqjzqygxlmkfuaymisqerabxafdovzbltsgmqybwckcjjzorzztsuvuxpnypwahqnwmbdspacyjtudxrzyiajshcxmozfvgxuopbqbkktskrjszzjylglxtnllwhjxdsavopcnvkkbjihlltkjydfmkhhhcjcvhroqxornqndjlhttvmmrnngubjenxrczwnpzedciiqulctdirosacqspvvbqzlyifoqsnrobbxuxlfreyhtipyqkfxjyfifmgepgxghnqluqgaosyifzabwjeugnxtnbfsmnfelxjdobxenqbmshbyivhitcjuybdzwqhkxyukegquzuenherugnmpbncpsxksffkldueazsiqzodffflmsqcxicwxavoloslttiidhnpnubxwuhbijcumtzfinkdrqursfihdgewyxbrpdpedemsjixjfrwxbpvswudjtecrftgzauljmjtbxsmxyyljjikobccpbzmxmtprxndbwyyhvteorfaemetqaheiffjjmmhmpwswxbzwlilcantsnqzsfxjvxezgoqujcyphlvkasdpjvditefhgllcpebakmfvphhawoxfsjlgympejxvqzvwvgzufujzjqbaytddpwwmrmfnsivjfneimyqcmihdhdeyzzuezcwlgxkvbgrgieticlbbntfbyknvbtuqkseuvmircdoissnbpykkvftovgkjxpjfphcrnaldcdcxcreezxjqnjztdmszjglqwmrllxehsirybojbnmvrrbclildtbxoswuqtqdassfljztyciqdbjipezfqgjzpbfjmyynxcfybmqckyohglxlpgpeibntumploqwpmabdbvddcbxynetamjqxtngdyhqwgzshyhyryhdoggclagdlnvvdidywvuosmajhdvlzkeixvtexskqsmvbnguaisovclsbxavomxatlrfbcnnddjpdvmqzrtleaqejvdfnersivuekyttucwfthashmzjtlmsedpecgxlpyxwnypvmbwfjdbdfbgofzpgljsprebqwloksghfqgdswbfhzxfmkddsdrysuwyoncnrmgybucxishzldhaybrqttrysvhdhouzkiepynplphlybwjpetdwgkgzneodvvtnxcatmkuborfmhsqbafsyikxiygevuuefxgcxygqjuykboanzklvacgjbbtejslubaugkwgmkrohoxaorospwucgprunuawlnruyfkfwnnbjvwdkhbixnwkasdrpintwarnphyyktemsyllyacjqvxskippmnykqutxswrggmtypwmkipkbaxlrdmenhoduaajlusrtumjvtuxrmtoqznzzkvaifmsnfobwdzohmvtaqvjrtirvqnjcslnmgbvjelnbdrptusjwbpwqfhwbhsvewywvcrwsfhcvkrvfpaayogwyxtsglwcyqrbdbpovvjsscouqwltbhxuvpuxemqwrpxgbqwjhxukxdvgcrzbabjvtgpjbdukfxozjzyujfunpdcrvvttvplnbvypweapjgxjqsxkmfggofrxwakgohgiwibeluoccycjcpolxzvedzftrqajrswxhjdqgunmdvcqmsyzinibdvdqsngojsjwnsqwgfxmutamuceczwlxwbvijdjhnmzdjtktzqjdmizirlyvjrapdqbueplmcegacybchhjvurzrrdybgscmlvptriuonzvklzysohkajfyzozryaqftxhldiwwplzuaasbuqmgnysfqdthtfrrkjdidgazpeiozyaduulzmovofzptcvnabaiwemxzmtqtkybldwesksefxqsllbwjnnawmnljxcdqjhamtjdsretstvwympscdqfvzdsneawsbkxufkqvbzonftrjpsefhilnizsjwsovoytsdzktbrbuuqmagjvmuhtloqpszqtjpytlkxkqdcrvhkadtjnzbkniddydbwswtgnaplplnuegmczqjrojttlwtplzmrqqlaotvkgpxujkjlpemflvagkkuyivuugfhvizaitmbhalreplfmvqdkhmrzsxssbqbyhkxnpohnggiicieqekbeuswzzumxozmfqflbfrpfkkqoueqnnrkurfmykyhdgivtdpqqlfetrxdqdaqmmejzejumhuctfpqunrmjzvyxwngkmgbngkvyfylbjxwaqmbiwpfouvavpqjqhljfmbidpglrpuhkjzyzybviqmtmgricwndybtubtzzlpvbpfybamhjqikyvvnnggxgywpdhphkqfqecztrqfrqadcnejyomqianyqesytdwswqegktwmbxcjykrpkaulljalolnamyqkptoznynuvtyaubltqrjwhwuvgteaqasugkineskqvhakoelxilctqaneeqiczrngtttfrxpusshzwvwibaehjfjohgotqtpboeuzedljzuxvacvrczkuyawworspexrogjizgozlczypodqoejmqnhrzvjkukxyigvimdrnmcteribjmudzoudlysnoziwymmpeopokexeeuhktjgmyztcoxqpoilzyyptmdocdhmtfdirtdkipzucexfvhidhavegjxwwqnygjelsgdhsxqnruivxrtgivnthkygkrshgpgskcwnjedluewwkshgzsxwfpiygevllmpbhcpnqusruwjexazheuxjtdrmjrwezmjiugannbikrrawcdesrpplbieanltzsuqonskyzbxdzqhcaybcvvxbreehirsqdnjwbfrrriabjemqpffuoycfrrjtzrqqbaywxguvxjvnpjdnabojmmxkjfaqrjokcmzrpczjmjhcvjccrxjpyxguorlptneagoazqqrfhetiqamiifzgskglnfamrtkjcqchlrahomuafkeuunxkxbjrtrtmcayqbhqnzivxnwutcbabrvszitdqkglkucyavtpjamuklvhuqmakbpofryolxzyxycmpqqeshdatfhohioupwbkmrgcpcdlykzysujzflhcfajkllbhtewpuyjdwsdugexzvswaoqhzmlvlwkhjuurwouskzmhdhbzdeazgiipnwnkpxyoneqrobbsfphxbotdyryvihsubeftzcuwkygfrywpxdwgrirltqraohhspkxfvbydnvtwjxhoirsmzqdzndsusgiiidfoplojknsmnexfrvneatxfdfmuyqxgceyjzchlobndkqhivsgwyipwowjsuqpvlgxefghkxhbunabmaskzdmlkcyjqyylsyobnsflvavwyazhowhqgjrzycigwxtqpbxnvfshxlilewesxzdwcyvlioxhusfydgsfdmrwraroxgxiwucyvhkrnoxjgsfqmbkkbzjxyumlnsksuhknlpucxbywkbcfsgkapidqnlzlskkaiyclfvpttqhnsgnjqsyffnazdxvuzwappgybwhqiluurxuaacxgyqgoqbkgnovaebrqjfobygfxmeznolfspubponvjjsbojgicphxkbmyeahzglbqqaqxkzbovoawazgnducnzmhnmozkbzeqowvdrbubrawlzcbjxpperibygnrwpqzmfhpgryzrmfhfwagjzxcahoplyglhwojshzhsinxltoxrdgmtdzyjuzujnhybctjlovbnfvqhvtajstsmrpuvvohinqfvtmidwlcjpssiclsihoosoutxdtbotadvgjhlyvexsokafilnifnckjiuwxbeawaljepsnxpgpheauwbqyynlvukxrwradqnbskigbufwecvywhhdarivicutghivvfizhwxzincmnusbeitswwdbwhzxsajmpvaqqwuhzlpznmnqlenxavppyuznklialvwninnbnrgcxfdgnodzavujzjkcgqvxvbdlwhqbwzfsltkwigbzbbzvxghbesfqbzwgvgnysgasoqcpydbkwnckwwmvmgmbvuxoavezyxozvxwleigheznjokxrrsydhoabyerssqhtpjjptdbjxniaxfmbdasjuuwaukbxdgjmomwwftibprmhazdzhyywjvgaylntiewhwcsolmrqvpzuwxhfauggcmyrxdlzoqjcyssakxilorkvvpeymwmahhboejdtyswxzmeoggzyunvrjdajygxxbxpfmnfloeqlmsmrkicgbmtkuuttctgenhhovcjnieherjyjqnmvjpxifytpgztbwgeviridijqwywpetzqcnmzlbuboccxajkvuteaccfgxkrqpjvlrcosvfhmmdyuvsclsfjfiioasyqlarxrvdgiguwropgmhwugvyvvptcjrspfcywcsutpyuhbgdmunptrqqnxfnchafaewkguppkpgfazakofpjophmcwoevqrtipohsbeofywttdvytyfnkliwnhlorgmsptfbxeidzjxfzagrlinnfcmmhfvdyghpzudkuvyajwnlcqbcmhtudagviwsjqisuvahxxvqthaadayzryjtbeolkvqxqgegvacexfhzbvcivqvnzbccgsgnwuyfhzcgebkmlhutuqyzvatxbvztfegzfbvkhkaxhbayoircodkttwvstywqgbhswxmaewxoeornvbergrrjznhcbhaczairodpeifmsdtgszleypppzsnbdikhyalriywxwshrymyeiiazuoqmtxvtgzhwmifmtpxjqgvbjhwakjmgrecahslnniwhtjncyihlziifxhfwyrbsxjvoofpffvetegpinkrkafrdivctwfttvbkjployxjcrkkziuhyqdjqmauavrxmeqpvylkbdrukwbrecniotubrcaheqtmlhfrdismbovtgytzkytsaciznxbbxvnwwjvdnwebshrqzjsocztkjtlcljpgiuliuxbyibcvglqzvyxxcjtrpgiryibkjnhafhfydrqlgeaucnrfcdeqtxupjlluvyiuacjgibdfcgqkiupyhxexqprjkpmxkitwqfrwksunjpzrnlarkwboexznhlqfoflzamsfrqngbqrfglzfgqkhjopipxurmmpnlhgbeawgakgcnwzyoodftwlxxyditdshexokzkerfradivhkuipccvzjjtugbgpuujhzdnvddbwfbtqjvcjnfzmswrsjpyddlfocdneljqmtyrxcguctqirmhxscgdsepaikirtnmikyvokemnpegsvcdtsjaxgouauoqcxswsvpigjdazfukuazrccdvbinlrcjgfnnmdxlptcodahtlfsbwadatfkhcqyiochaiedwyrrrfselwbmhkdjevsubfyixwxmyxwatmpvcobdjlytyznzxbpfjhwdvozjfgcqmpeusljdatvhbvgrxchxfegewzyeckyazsgwwmlgjjfwyjmamfvczkekbxgkyqnatubfzzrmhugmuxkkqiktajkzbrpdzrisanyhvlwvzwiequmhktcpwpgjtxorrofqgwwddsuuojcnpfjublnaaptgbmcgofagsvimixxhbolcigmpwupzevfeajswddkqlyvcncfjhwfqrnwnglelzmwrukweytdihpbjelpdwmcompbcssbbnvtbsfgrodbkaerwnqpdkuilnorqikqtnwezytpznftvylwzimojilxkdveixsvaqwovyanvlcbkbhwpaptwklbddbifxmktzwksjgjampyxcvcmpcpgnuftywtsxrpzedeyywwuunbgtwkvxwezlkuatczqboajaidouwtulrhgirmxsxibthgzkukkofjuldjdmujodypnfcettfyjljozzsctiirnowfyheiwhffehcvwjtovfdpiwfctmalhlwipyklsarbnzhqjaztnfzgulwdtwtjjhukdspqldlellyqpzseqlawmgajrjykvzesrxwaqhizylbxdzlbbmziaagxjtdmkfyysfgqpfuyfrtzrgecceyubkgbqjbbqqdnqvuihonhvmwyunyxdgbmpzamrvyarbcjmjgnexqqthffsaolvaxxejcjqdgziinbczqiibkqcaxeuikmkdblzpdytksfcaekojbckowaieyvdesgdgyxstlptvufjopyovlpojxuiuqcuqmiucezxjnoqedkmwblvrekrheciotaclxbkmuovfbikqqkywheylwmoyrdtzrbrbvsylsibarourbpokcenistxhxixolqdtbbvcoyjykylbalhrajchkafjaasyvssufgufrgntqhwjelkpxhgfekgsucicixmrskyjgphrvtlbldqvqedamgednstdkgwpxliiuvtkbwzqxdzairfrexjtanfsznkllcjnsfnxsrtcrfrluzxvsfsenykesglvmqrjfwxtyzryaqxxmemhwmafoqvplcykvdlgnncxjfmbzhpredyntitupkifgafetupoxjuptkttxgcxdnohueutwzxtmfvdafoymjrtdiigawmhgwyrzbxeaosnzikrsmjylbeeeoqcocncikekkmlcdotujedeosvybkfkfwvrjtstfkyaxtoxoubiurunmgckdzgneqjcmxtfgyandtqmagcwxqjnxkhuxhhwjlkagdyzmgkpspiycqcvm");
            //var res = StrStrIndex("hello", "o", 0);
            //var ress = StrStrCount("hellllo", "llo");
            //var resss = StrStrRemove("hellollo", "llo");

            //ReverseString(new[] {'h', 'e', 'l', 'l', 'o'});
            //var revint = ReverseInt(123);
//            var s = "loveleetcode";
//            var res = FirstUniqChar(s);

            //var res = IsAnagram("anagram", "nagaran");
            //var res = IsPalindrome("0P");//"A man, a plan, a canal: Panama");
            //var res = MyAtoi("     -42");
            //var res = CountAndSay(10);

            //var res = LongestCommonPrefix(new[] {"a"});//"flower", "flow", "flowre"});
            //var res = CompareVersion("1.2.0", "1.2.0.0");
            //var res = GetHint("1807", "7810");//"1122","1222");//"1123","0111");//

            //var res = LengthOfLongestSubstring("ckilbkd");//"dvdf");//"bbbbb");//"pwwkew");//"aabaab!bb");//"ohomm");//"pwwkew");//"abcabcbb");

            //var res = LengthOfLastWord("       ");
            //var res = FindTheDifference("abcd", "abacd");

            //var res = SortByBits(new[] { 0,1, 2, 3, 4, 5, 6, 7, 8 });//new[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 });//
           
        }

        static int[] SortByBits(int[] arr)
        {
            Array.Sort(arr,new SortByBits());
            return arr;
        }
        static char FindTheDifference(string s, string t)
        {
            int[] alphabets=new int[26];

            int xor = 0;
            for (int i = 0; i < s.Length; i++)
            {
                xor = xor ^ t[i] ^ s[i];
                //alphabets[t[i] - 'a']++;
                //alphabets[s[i] - 'a']--;
            }
            xor = xor ^ t[t.Length - 1];
//            alphabets[t[t.Length-1] - 'a']++;
//
//            for (int i = 0; i < 26; i++)
//            {
//                if (alphabets[i] != 0)
//                {
//                 return Convert.ToChar(i + 97);
//                }
//            }
            //var left = 122 - 97;
            //left = left%26;
            return Convert.ToChar(xor);
        }
        static int LengthOfLastWord(string s)
        {
            
            if (s.Length == 0)
                return 0;
            var ssplit = s.Split(' ');
            var len = ssplit.Length - 1;
            while (len >= 0)
            {
                if (!string.IsNullOrWhiteSpace(ssplit[len]))
                    return ssplit[len].Length;
                len--;
            }
            return 0;
        }
        static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            var set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n) {
                // try to extend the range [i, j]
                if (!set.Contains(s[j])){
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else {
                    set.Remove(s[i++]);
                }
            }
            return ans;

            //if (s.Length == 0)
            //    return 0;

            //var hashSet = new HashSet<char>();
            //var max = 1;
            //var ss = s;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (hashSet.Contains(s[i]))
            //    {
            //        var ind = ss.IndexOf(s[i]);
            //        for (int j = ind; j >= 0; j--)
            //        {
            //            hashSet.Remove(ss[j]);
                        
            //        }
            //        ss = ss.Substring(ind+1);
            //    }

            //    hashSet.Add(s[i]);
            //    max = Math.Max(max, hashSet.Count);
            //}

            //return max;
        }
        static string GetHint(string secret, string guess)
        {
            int bulls = 0;
            int cows = 0;
            int[] numbers = new int[10];
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i]) bulls++;
                else
                {
                    var aa = numbers[secret[i] - '0']++;
                    var bb = numbers[guess[i] - '0']--;
                    if (aa < 0) cows++;
                    if (bb > 0) cows++;
                }
            }
            return bulls + "A" + cows + "B";

            var numberofbulls = 0;
            var numberofcows = 0;

            if (secret.Length == 0)
                return "";
            var dict = new Dictionary<char, int>();
            
            var leftguest = new List<char>();

            for (int i=0;i<secret.Length;i++)
            {
                if (guess[i] == secret[i])
                {
                    numberofbulls++;
                }
                else
                {
                    leftguest.Add(guess[i]);

                    var secchar = secret[i];
                    if (dict.ContainsKey(secchar))
                        dict[secchar] = dict[secchar] + 1;
                    else dict[secchar] = 1;
                }

            }

            foreach (var lg in leftguest)
            {
                if (dict.ContainsKey(lg) && dict[lg] > 0)
                {
                    numberofcows++;
                    dict[lg]--;
                }
            }
           

            return numberofbulls.ToString() + "A" + numberofcows.ToString() + "B";
        }
        static int CompareVersion(string version1, string version2)
        {
            var v1Arr = version1.Split('.').Select(s=>Convert.ToInt32(s)).ToArray();
            var v2Arr = version2.Split('.').Select(s => Convert.ToInt32(s)).ToArray();

            var v1Len = v1Arr.Length;
            var v2Len = v2Arr.Length;

            int i = 0, j = 0;
            while (i<v1Len && j<v2Len)
            {
                if (v1Arr[i] > v2Arr[j])
                    return 1;
                if(v1Arr[i] < v2Arr[j])
                    return -1;
                i++;
                j++;
            }
            if (i < v1Len )
            {
                while (i<v1Len)
                {
                    if (v1Arr[i] > 0)
                        return 1;
                    i++;
                }
            }
            if (j < v2Len )
            {
                while (j < v2Len )
                {
                    if (v2Arr[j] > 0)
                        return -1;
                    j++;
                }
            }


            return 0;
        }
        static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0 || strs[0].ToString()=="")
                return "";
            var prefix = "";
            bool continuesearching = true;
            var prindex = 0;
            while (continuesearching)
            {
                for (int i = 1; i < strs.Length; i++)
                {
                    if (prindex == strs[i - 1].Length || prindex == strs[i].Length)
                        return prefix;
                    if (strs[i][prindex] != strs[i-1][prindex])
                        continuesearching = false;
                }

                if (continuesearching)
                {
                    if (strs[0].Length == prindex)
                        return prefix;
                    prefix += strs[0][prindex].ToString();
                }
                prindex++;
            }

            return prefix;
        }
        static string CountAndSay(int n)
        {
            if (n == 1)
                return "1";
            if (n == 2)
                return "11";

            var start = "11";
         
            int i = 3;
            while (i<=n)
            {
                start = getWord(start);
                i++;
            }

            return start;
        }

        static string getWord(string str)
        {
            var answer = "";
            var list = new List<string>();

            var ch = str[0].ToString();
            int j = 1;
            while (j < str.Length)
            {
                if (str[j] == str[j - 1])
                    ch += str[j].ToString();
                else
                {
                    list.Add(ch);
                    ch = str[j].ToString();
                }

                j++;
            }
            if(!string.IsNullOrEmpty(ch))
                list.Add(ch);

            foreach (var li in list)
            {
                var count = li.Length;
                answer += count.ToString() + li[0].ToString();
            }

            return answer;
        }
        
        static int MyAtoi(string str)
        {
            if (Regex.IsMatch(str, "^\\s*[-+]?[0-9]+.*"))
            {
                var match = Regex.Match(str, "^\\s*[-+]?[0-9]+").ToString().Replace(" ", "");

                try
                {
                    return Convert.ToInt32(match);
                }
                catch
                {
                    if (match[0] == '-')
                        return Int32.MinValue;
                    return Int32.MaxValue;
                }
            }
            return 0;
        }

        static bool IsPalindrome(string s)
        {            
            //var matches = Regex.Matches(s, "[A-Za-z]");
            //var sreg = "";
            //foreach (var match in matches)
            //{
            //    sreg += match;
            //}
            //sreg = sreg.ToLower();
            var sreg = Regex.Replace(s, "[^A-Za-z0-9]","").ToLower();

            var len = sreg.Length;
            int i = 0,j=len-1;
            while ( i < len/2 )
            {
                if(!sreg[i].Equals(sreg[j]))
                    return false;
                i++;
                j--;
            }

            return true;
        }
        static bool IsAnagram(string s, string t)
        {
           if (s.Length != t.Length) {
                return false;
            }
            int[] counter = new int[26];
            for (int i = 0; i < s.Length; i++) {
                counter[s[i] - 'a']++;
                counter[t[i]- 'a']--;
            }
            foreach (int count in counter) {
                if (count != 0) {
                    return false;
                }
            }
            return true;

            //string ssreg = matches.Cast<Match>().Aggregate("", (current, match) => current + match);

            var matches = Regex.Matches(s, "[a-z]");
            
            string ssreg = "";
            foreach (Match match in matches)
            {
                ssreg += match;
            }

            matches = Regex.Matches(t, "[a-z]");

            string ttreg = "";
            foreach (Match match in matches)
            {
                ttreg += match;
            }
            
            var ssorted = new string(ssreg.OrderBy(ss => ss).ToArray());
            var ttorted = new string(ttreg.OrderBy(ss => ss).ToArray());

            return ssorted==ttorted;
        }
        static int FirstUniqChar(string s)
        {
            var dict = new Dictionary<char, int>();
            var sarray = s.ToArray();
            foreach (var i in sarray)
            {
                if (dict.ContainsKey(i))
                    dict[i] = dict[i] + 1;
                else
                    dict[i] = 1;
            }

            foreach (var i in dict)
            {
                if (i.Value == 1)
                    return s.IndexOf(i.Key);
            }

            return -1;
        }
        static void ReverseString(char[] s)
        {
            var len = s.Length;
            for (int i =0,j = len-1; i<j; i++,j--)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }

        }
        static int ReverseInt(int x)
        {
            bool isNegative = false;
            if (x < 0)
            {
                x = -x;
                isNegative = true;
            }

            char[] s = x.ToString().ToArray();
            var len = s.Length;
            for (int i = 0, j = len - 1; i < j; i++, j--)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }

            var res = string.Join("", s).ToString();
            
            //if (res.Substring(0, 1) == "0")
                //res = res.Substring(1);
            try
            {
                return isNegative ? -Convert.ToInt32(res) : Convert.ToInt32(res);
            }
            catch
            {
                return 0;
            }
        }
        static bool WordPattern(string pattern, string str)
        {
            var patArray = pattern.ToArray();
            var patstr = ""; 
            var strArray = str.Split();
            var strstr = "";
            if (pattern.Length != strArray.Length)
                return false;
            for (int i = 0; i < pattern.Length; i++)
            {
                var pat = patArray[i];
                var substr = pattern.Substring(0, i);
                var indexpt = substr.IndexOf(pat);
                patstr += indexpt.ToString();
          
                var strst = strArray[i];
                var index = -1;

                if (i > 0)
                {
                    //string[] subarray = new string[i];
                    //Array.ConstrainedCopy(strArray, 0, subarray, 0, i);
                    //index = string.Join(" ", subarray).IndexOf(strst);

                    for (int j = 0; j < i; j++)
                    {
                        if (strArray[j] == strst)
                        {
                            index = j;
                            break;
                        }
                    }  
                }
                strstr += index.ToString();
            }
         
            return patstr==strstr;
        }
        static bool WordPatternregex(string pattern, string str)
        {
            var patArray = pattern.ToArray();
            string regPattern = "";
            var listofGroups = new List<int>();
            var ind = 1;
            for (int i=0;i<patArray.Length;i++)
            {
                var pat = patArray[i];
                var substr = pattern.Substring(0, i);
                var index = substr.IndexOf(pat);
                if (index != -1)
                {
                    regPattern += "^(?:\\" + (index + 1) + ")\\s?";
                    
                }
                else
                {
                    regPattern += "([a-z]+)\\s?";
                    listofGroups.Add(ind);
                    ind++;
                }
                
            }
           
            return Regex.IsMatch(str, regPattern);
        }
        static IList<int> PartitionLabels(string s)
        {
            if (s.Length == 0)
                return new[] {0};

            IList<string> subStrings = new List<string>();

            var sarray = s.ToArray();
            
            int i = 0;
            while (i < sarray.Length)
            {
                var currentString = sarray[i];
                var subs = s.Substring(i + 1);
                int maxindex = subs.LastIndexOf(currentString);
                if (maxindex != -1)
                {
                    maxindex++;
                    int j = i + 1;
                    while (j<maxindex + i + 1)
                    {
                        var subchar = s[j];
                        var charindex = s.LastIndexOf(subchar) - i;
                        if (charindex > maxindex)
                        {
                            maxindex = charindex;
                        }
                        j++;
                    }

                    var subssadd = s.Substring(i, maxindex + 1);
                    subStrings.Add(subssadd);
                    i = i + subssadd.Length ;
                }
                else
                {
                    subStrings.Add(s.Substring(i, 1));
                    i++;
                }
                
            }

            return subStrings.Select(ss=>ss.Length).ToList();

            //var subss = s.Substring(i + 1, maxindex + 1).ToList();

            //foreach (var subchar in subss)
            //{
            //    var charindex = s.LastIndexOf(subchar) - i;
            //    if (charindex> maxindex)
            //    {
            //        maxindex = charindex;
            //        if (charindex + 1 > subss.Count)
            //        {
            //            var lenchar = charindex + 1 - subss.Count;
            //            subss.AddRange(s.Substring(subss.Count - 1, lenchar).ToList());
            //        }
            //    }
            //}
        }
        static bool RepeatedSubstringPattern(string s)
        {
            var len = s.Length;
            for (int i = len/2 ; i >0 ; i--)//(int i = 1; i <= len/2; i++)
            {
                if (len%i == 0)
                {
                    var subs = s.Substring(0, i);
                    var repeatitions = len/i;

                    var subsconcat = "";
                    for (int j = 0; j < repeatitions; j++)
                    {
                        subsconcat += subs;
                    }
                    if(subsconcat.Equals(s))
                        return true;
                }
                
            }
            return false;
        }
        static int StrStrIndex(string s, string c, int index)
        {
            if (s.Length == 0)
                return 0;
            else
            {
                if (s.Length < c.Length) return -1;

                var cur = s.Substring(0, c.Length);
                if (cur.Equals(c))
                    return index;
                else
                {
                    index++;
                    return StrStrIndex(s.Substring(1), c, index);
                }
            }
            
        }
        static int StrStrCount(string s, string sub)
        {
            if (s.Length == 0)
                return 0;
            else
            {
                if (s.Length < sub.Length) return 0;

                var cur = s.Substring(0, sub.Length);
                var sum = cur.Equals(sub) ? 1 : 0;
                return sum + StrStrCount(s.Substring(1), sub);
            }

        }
        static string StrStrRemove(string s, string sub)
        {
            if (s.Length == 0)
                return "";
            else
            {
                if (s.Length < sub.Length) return s;

                var cur = s.Substring(0, sub.Length);

                var sum ="";
                var subLen = 1;
                if (cur.Equals(sub))
                {
                    sum = "";
                    subLen = sub.Length;
                }
                else sum = cur.Substring(0,1);

                return sum.ToString() + StrStrRemove(s.Substring(subLen), sub);
            }

        }
        
    }

    internal class SortByBits : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            var xlen = Convert.ToString(x, 2).Count(a=>a=='1');//.Replace("0", "").Length;
            var ylen = Convert.ToString(y, 2).Count(a => a == '1');//.Replace("0", "").Length;
            if (xlen != ylen)
            return xlen -ylen;
            return x - y;
        }
    }
}
