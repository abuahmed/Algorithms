using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace TestDom
{
    using System;

    public class MovingTotal
    {
        List<int> lst = new List<int>();
        //private int first=0, second=0, third=0;
        
        public void Append(int[] list)
        {
            lst=lst.Concat(list.ToList()).ToList();
        }

        public bool Contains(int total)
        {
            var len = lst.Count;
            var newLst = lst.Skip(len - 3).ToList();
            return newLst.Sum() == total;
        }

        public static void Main(string[] args)
        {
            MovingTotal movingTotal = new MovingTotal();

            movingTotal.Append(new int[] { 1, 2, 3 });

            Console.WriteLine(movingTotal.Contains(6));
            Console.WriteLine(movingTotal.Contains(9));

            movingTotal.Append(new int[] { 4 });

            Console.WriteLine(movingTotal.Contains(9));
        }
    }

    public class Node
    {
        public Node LeftChild { get; private set; }
        public Node RightChild { get; private set; }

        public Node(Node leftChild, Node rightChild)
        {
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public int Height()
        {
            var height =GetTreeHeight(this,0);
            return height;
        }

        static int GetTreeHeight(Node rootNode, int height)
        {
            if (rootNode == null)
                return 0;

            if (rootNode.LeftChild == null && rootNode.RightChild == null)
            {
                return height;
            }
                height++;
            return Math.Max(height, Math.Max(GetTreeHeight(rootNode.LeftChild, height), GetTreeHeight(rootNode.RightChild, height)));
        }

        public static void Main(string[] args)
        {
            Node leaf1 = new Node(null, null);
            Node leaf2 = new Node(null, null);
            Node node = new Node(leaf1, null);
            Node root = new Node(node, leaf2);

            Console.WriteLine(root.Height());
        }
    }

    public class Account2
    {
        [Flags]
        public enum Access
        {
            Delete = 1,
            Publish = 2,
            Submit = 4,
            Comment = 8,
            Modify = 16,
            Writer = 4 | 16,
            Editor = 1 | 2 | 8,
            Owner = Writer | Editor
        }

        public static void Main(string[] args)
        {
            
            Console.WriteLine(Access.Writer.HasFlag(Access.Comment)); //Should print: "False"
        }
    }

    [Serializable, XmlRoot("folder")]
    public class folder
    {
        public string name { get; set; }
        public folder fold { get; set; }
    }

    public class Folders
    {
        public static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
           folder folderName=new folder();

           //var result = DeserializeFromXml<Message>(xml);

            //var settings = XmlDeserializeFromString<folder>(xml); 

           var result = (folder)new XmlSerializer(typeof(folder)).Deserialize(new StringReader(xml));

            string pattern = "<folder\\s+name=\"(?<name>" + startingLetter + "[a-zA-z\\s]+)\"?";
            var folderNames = new List<string>();
            MatchCollection matches = Regex.Matches(xml, pattern);
            foreach (Match match in matches)
            {
                var name = match.Groups["name"].Value;
                folderNames.Add(name);
            }

            return folderNames;
        }

        public static T XmlDeserializeFromString<T>(string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }

        public static object XmlDeserializeFromString(string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }

        public static void Main(string[] args)
        {
            string xml =
               "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<folder name=\"c\">" +
                    "<folder name=\"program files\">" +
                        "<folder name=\"uninstall information\" />" +
                    "</folder>" +
                    "<folder name=\"users\" />" +
                "</folder>";

            foreach (string name in Folders.FolderNames(xml, 'u'))
                Console.WriteLine(name);
        }
    }

    public class RoutePlanner2
    {
        private static Queue<string> queue;
        private static HashSet<string> cellsHashSet;
        public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                          bool[,] mapMatrix)
        {
            queue = new Queue<string>();
            cellsHashSet = new HashSet<string>();

            int row = mapMatrix.GetLength(0);
            int column = mapMatrix.GetLength(1);

            var start = fromRow+"_"+fromColumn;

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue().Split('_').Select(c => Convert.ToInt32(c)).ToArray();

                int ii = cell[0], jj = cell[1];
                if (ii == toRow && jj == toColumn)
                    return true;
                GetNeighbors(ii,jj, row, column, mapMatrix);
            }
            return false;
        }

        private static void GetNeighbors(int currentRow,int currentCol, int row, int column, bool[,] mapMatrix)
        {
            if (currentRow - 1 >= 0 && mapMatrix[currentRow - 1, currentCol])
            {
                var newCell = (currentRow - 1) +"_" + currentCol;
                if (!cellsHashSet.Contains(newCell))
                {
                    cellsHashSet.Add(newCell);
                    queue.Enqueue(newCell);
                }
            }
            if (currentCol - 1 >= 0 && mapMatrix[currentRow, currentCol - 1])
            {
                var newCell =  currentRow + "_" + (currentCol - 1);
                if (!cellsHashSet.Contains(newCell))
                {
                    cellsHashSet.Add(newCell);
                    queue.Enqueue(newCell);
                }
            }

            if (currentRow + 1 < row && mapMatrix[currentRow + 1, currentCol])
            {
                var newCell = (currentRow + 1) + "_" + currentCol;
                if (!cellsHashSet.Contains(newCell))
                {
                    cellsHashSet.Add(newCell);
                    queue.Enqueue(newCell);
                }
            }
            if (currentCol + 1 < column && mapMatrix[currentRow, currentCol + 1])
            {
                var newCell = currentRow + "_" + (currentCol + 1);
                if (!cellsHashSet.Contains(newCell))
                {
                    cellsHashSet.Add(newCell);
                    queue.Enqueue(newCell);
                }
            }

        }

        public static void Main(string[] args)
        {
            bool[,] mapMatrix = {
            {true, false, false},
            {true, true, false},
            {false, true, true}
        };

            Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
        }
    }

    public class RoutePlanner
    {
        private static Queue<int[]> queue;
        private static HashSet<int[]> cellsHashSet; 
        public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                          bool[,] mapMatrix)
        {
            queue = new Queue<int[]>();
            cellsHashSet =new HashSet<int[]>();

            int row = mapMatrix.GetLength(0);
            int column = mapMatrix.GetLength(1);
            
            int[] start = new[] {fromRow, fromColumn};
            
            queue.Enqueue(start);

            while (queue.Count>0)
            {
                var curdest = queue.Dequeue();
                if (curdest[0] == toRow && curdest[1] == toColumn)
                    return true;
                GetNeighbors(curdest,row,column, mapMatrix);
            }


            return false;
        }

        private static void GetNeighbors(int[] curdest, int row, int column, bool[,] mapMatrix)
        {

            int currentRow = curdest[0];
            int currentCol = curdest[1];

            if (currentRow - 1 >= 0 && mapMatrix[currentRow - 1, currentCol])
            {
                var newCell = new[] { currentRow - 1, currentCol };
                if (!cellsHashSet.Contains(newCell, new CheckEquality()))
                {
                    cellsHashSet.Add(newCell);
                    queue.Enqueue(newCell);
                }
            }
            if (currentCol - 1 >= 0 && mapMatrix[currentRow, currentCol - 1])
            {
                var newCell = new[] { currentRow, currentCol - 1 };
                if (!cellsHashSet.Contains(newCell, new CheckEquality()))
                {
                    cellsHashSet.Add(newCell);
                    queue.Enqueue(newCell);
                }
            }

            if (currentRow + 1 < row && mapMatrix[currentRow + 1, currentCol])
            {
                var newCell = new[] { currentRow + 1, currentCol };
                if (!cellsHashSet.Contains(newCell, new CheckEquality()))
                {
                    cellsHashSet.Add(newCell);
                    queue.Enqueue(newCell);
                }
            }
            if (currentCol + 1 < column && mapMatrix[currentRow, currentCol + 1])
            {
                var newCell = new[] {currentRow, currentCol + 1};
                if (!cellsHashSet.Contains(newCell, new CheckEquality()))
                {
                    cellsHashSet.Add(newCell);
                    queue.Enqueue(newCell);
                }
            }

        }

        public static void Main(string[] args)
        {
            bool[,] mapMatrix = {
            {true, false, false},
            {true, true, false},
            {false, true, true}
        };

            Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
        }
    }

    internal class CheckEquality : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            return x[0] == y[0] && x[1] == y[1];
        }

        public int GetHashCode(int[] obj)
        {
            throw new NotImplementedException();
        }
    }

    public class AlertService
    {
        private AlertDAO storage;// = new AlertDAO();

        public AlertService(IAlertDAO iAlertDao)
        {
            storage = (AlertDAO)iAlertDao;
        }
        public Guid RaiseAlert()
        {
            return this.storage.AddAlert(DateTime.Now);
        }

        public DateTime GetAlertTime(Guid id)
        {
            return this.storage.GetAlert(id);
        }
    }

    public interface IAlertDAO
    {
        Guid AddAlert(DateTime time);
        DateTime GetAlert(Guid id);
    }
    public class AlertDAO : IAlertDAO
    {
        private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

        public Guid AddAlert(DateTime time)
        {
            Guid id = Guid.NewGuid();
            this.alerts.Add(id, time);
            return id;
        }

        public DateTime GetAlert(Guid id)
        {
            return this.alerts[id];
        }
    }

    public class Song
    {
        private string name;
        public Song NextSong { get; set; }

        public Song(string name)
        {
            this.name = name;
        }

        public bool IsRepeatingPlaylist()
        {
            var songs=new HashSet<string>();
            var song = this;
            while (song.NextSong!=null)
            {
                if (songs.Contains(song.name))
                    return true;
                else
                {
                    songs.Add(song.name);
                    song = song.NextSong;
                }
            }
            return false;
        }

        public static void Main(string[] args)
        {
            Song first = new Song("Hello");
            Song second = new Song("Eye of the tiger");

            first.NextSong = second;
            second.NextSong = first;

            Console.WriteLine(first.IsRepeatingPlaylist());
        }
    }
    public class Cache { }

    public class DiskCache : Cache { }

    public class MemoryCache : Cache { }

    public class OptimizedDiskCache : DiskCache { }

    class Program
    {
        public static void Main(string[] args)
        {
            

//            OptimizedDiskCache optimizedDiskCache = new OptimizedDiskCache();
//            Cache cache = (Cache) optimizedDiskCache;

            MemoryCache memoryCache1 = new MemoryCache();
            Cache cache1 = (Cache)memoryCache1;
            DiskCache diskCache1 = (DiskCache)cache1;

            DiskCache diskCache = new DiskCache();
            OptimizedDiskCache optimizedDiskCache = (OptimizedDiskCache) diskCache;


//            OptimizedDiskCache optimizedDiskCache = new OptimizedDiskCache();
//            DiskCache diskCache = (DiskCache)optimizedDiskCache;
//
            Cache cache = new Cache();
            MemoryCache memoryCache = (MemoryCache)cache;

//            OptimizedDiskCache optimizedDiskCache = new OptimizedDiskCache();
//            Cache cache = (Cache)optimizedDiskCache;
//            DiskCache diskCache = (DiskCache)cache;
        }

    }

//    public class Node
//    {
//        public int Value { get; set; }
//
//        public Node Left { get; set; }
//
//        public Node Right { get; set; }
//
//        public Node(int value, Node left, Node right)
//        {
//            Value = value;
//            Left = left;
//            Right = right;
//        }
//    }

    public class BinarySearchTree
    {
//        public static bool Contains(Node root, int value)
//        {
//            while (root != null)
//            {
//                if(root.Value==value)
//                    return true;
//                root = value > root.Value ? root.Right : root.Left;
//            }
//            return false;
//        }
//
//        public static void Main(string[] args)
//        {
//            Node n1 = new Node(1, null, null);
//            Node n3 = new Node(3, null, null);
//            Node n2 = new Node(2, n1, n3);
//
//            Console.WriteLine(Contains(n2, 3));
//        }
    }
    public class QuadraticEquation
    {
        public static Tuple<double, double> FindRoots(double a, double b, double c)
        {
            var sqrt = (int) Math.Sqrt(b*b - 4*a*c);
            var item1 = (-b + sqrt )/(2*a);
            var item2 = (-b - sqrt) / (2 * a);
            return new Tuple<double, double>(item1,item2);
        }

        public static void Main(string[] args)
        {
            Tuple<double, double> roots = QuadraticEquation.FindRoots(2, 10, 8);
            Console.WriteLine("Roots: " + roots.Item1 + ", " + roots.Item2);
        }
    }

    public class Account
    {
        public double Balance { get; private set; }
        public double OverdraftLimit { get; private set; }

        public Account(double overdraftLimit)
        {
            this.OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
            this.Balance = 0;
        }

        public bool Deposit(double amount)
        {
            if (amount >= 0)
            {
                this.Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(double amount)
        {
            if (this.Balance - amount >= -this.OverdraftLimit && amount >= 0)
            {
                this.Balance -= amount;
                return true;
            }
            return false;
        }
    }
    public class MergeNames
    {
        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            var names = new HashSet<string>();
            foreach (var s in names1)
            {
                if (!names.Contains(s))
                    names.Add(s);
            }
            foreach (var s in names2)
            {
                if (!names.Contains(s))
                    names.Add(s);
            }

            return names.ToArray();
        }

        public static void Main(string[] args)
        {
            string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
            string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
            Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia
        }
    }

}
