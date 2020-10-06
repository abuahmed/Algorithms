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
        static void MainArrays(string[] args)
        {
            var maxNum = ArrayManuplation(5,3);//(10,3);

            ArrayManuplate();
            //Func<int,bool> func;//=new Func<int, bool>();
            
            var ll=new LinkedList<int>();
            ll.AddFirst(1);
            LinkedListNode<int> getNode = ll.Find(1);
            if(getNode!=null)
            ll.AddAfter(getNode, 2);

            ISet<int> iset=new HashSet<int>();
            iset.Add(3);
            iset.Add(2);
            iset.Add(3);

            ISet<int> isetSort = new SortedSet<int>();
            
            isetSort.Add(3);
            isetSort.Add(2);
            isetSort.Add(3);

            //List<int> il = new List<int>();
            
            var bookll=new LinkedList<MyBook>();
            bookll.AddFirst(new MyBook("a", "b", 120));
            bookll.AddLast(new MyBook("a1", "b1", 121));
            bookll.AddLast(new MyBook("a2", "b2", 122));

            var contains=bookll.Contains<MyBook>(new MyBook("a1", "b1", 121),new BookComaparer());
            bookll.AddLast(new MyBook("a3", "b3", 123));

            LinkedList<MyBook>.Enumerator enumerator = bookll.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var enu = enumerator.Current;
            }
            
            IEnumerable<MyBook> asEnumerable = bookll.AsEnumerable();
            foreach (var myBook in asEnumerable)
            {
                var myB = myBook;
            }

            var result = bookll.Select(a => a.Price).ToList();//.ToDictionary(a=>a+10).ToList();
            var res1 = result.First();

            GetLlLength(bookll);
        }

        private static int ArrayManuplation(int n, int m )
        {
            //int[,] arr = new int[m,3];
            //arr = new int[,] {{1, 5, 3}, {4, 8, 7}, {6, 9, 1}};
            var arr = new[,] { { 1, 2, 100 }, { 2, 5, 100 }, { 3, 4, 100 } };
            var array = new int[n];
            var max = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = arr[i, 0]-1; j <= arr[i, 1]-1; j++)
                {
                    array[j] = array[j] + arr[i, 2];
                    max = Math.Max(max, array[j]);
                }
            }

            return max;
        }

        //private int len = 0;
        static void GetLlLength(LinkedList<MyBook> ll)
        {
            
            var enu = ll.GetEnumerator();
            while (enu.MoveNext())
            {
                
            }
        }
        static void ArrayManuplate()      
        {   
            //int i = 10, j=20;
            //Pointers(ref i,ref j);

            var ay = new Book[4];// {1, 2, 3, 4};
            ay[1] = new MyBook("a", "b", 120);
            ay[3] = ay[1];

            int[, ,] arr =
            {
                {
                    { 1, 2, 3 }, 
                    { 4, 5, 6 }
                },
                {
                    { 11, 12, 13 }, 
                    { 14, 15, 16 }
                }
            };

            int rank = arr.Length;//.Rank;
            int lb = arr.GetLowerBound(0);
            int ub = arr.GetUpperBound(0);

            for (int k = 0; k < 2; k++)
            {
                for (int l = 0; l < 2; l++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        arr[k, l, i] = k + l + i;
                    }
                }
            }

            int[] arrr = { 11, 2, 3, 4 };
            //var ar=Array.Find(arrr, a => a > 2);
            Array.Sort(arrr, new Comp());
            //Converter<int, string> con = null;
            //Array.ConvertAll<int,string>(arrr, con);
            string[] arrstr = { "abebe", "beso", "bela" };
            Array.Clear(arrstr, 0, arrstr.Length);

            var a = Array.CreateInstance(typeof(string), 3, 3);

            //Array.ForEach(arrr);

            //Array.Resize(ref arrr,2);

            Array.Reverse(arrr);

            IList<int> arList = new List<int>();
            arList = arrr.ToList();
            var arLi = arList.Select(l => l + 3).ToList();
            
            //return new int[0];
            //return new[] { 1, 2, 3, 4 };
            //Hashtable ht=new Hashtable();
            //Dictionary<string,int> dict=new Dictionary<string, int>(10);
        }

        static void Pointers(ref int i, ref int j)
        {
            if (i < 100)
                i = 100;
            if (j < 100)
                j = 1000;
        }
    }

    public class BookComaparer : IEqualityComparer<MyBook>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
        public bool Equals(MyBook x, MyBook y)
        {
            if (x.Price > y.Price)
                return true;
            return false;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
        public int GetHashCode(MyBook obj)
        {
            throw new NotImplementedException();
        }
    }

    public class Comp : IComparer<int>
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <returns>
        /// A signed integer that indicates the relative values of 
        /// <paramref name="x"/> and <paramref name="y"/>, 
        /// as shown in the following table.Value Meaning Less than zero<paramref name="x"/> is less than <paramref name="y"/>.Zero<paramref name="x"/> equals <paramref name="y"/>.Greater than zero<paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        /// <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param>
        public int Compare(int x, int y)
        {
            return x - y;
            //if (x == y)
            //    return 0;
            //return x > y ? 1 : -1;
        }
    }

    public class Compa : IComparable<int>
    {
        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(int other)
        {
            throw new NotImplementedException();
        }
    }
}
