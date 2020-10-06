using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    //Note: Can't Instantiate abstract class
    public abstract class Book
    {
        protected String title;
        protected String author;

        protected Book(String t, String a)
        {
            title = t;
            author = a;
        }

        public abstract void display();
    }
    
    public class MyBook : Book
    {
        private int price;

        public MyBook(string title, string author, int price) : base(title, author)
        {
            //this.title = title;
            //this.author = author;
            //this.Book(title,author);
            this.Price = price;
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public override void display()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Price: " + Price.ToString());
        }
    }

    internal class OOPSolution
    {
        private static void Mainoop(String[] args)
        {
            String title = Console.ReadLine();
            String author = Console.ReadLine();
            int price = Int32.Parse(Console.ReadLine());
            Book new_novel = new MyBook(title, author, price);
            new_novel.display();
        }

        private static void Mainoop2(string[] args)
        {
            var t = Convert.ToInt32(Console.ReadLine());
            var phoneBook = new Dictionary<string, string>();
            for (var i = 0; i < t; i++)
            {
                string str = Console.ReadLine();
                if (str != null)
                {
                    phoneBook.Add(str.Split(' ')[0], str.Split(' ')[1]);
                }
            }

            var test = Console.ReadLine();
            while (!string.IsNullOrEmpty(test))
            {
                var value = "";
                if (phoneBook.TryGetValue(test, out value))
                    Console.WriteLine(test + "=" + value);
                else
                    Console.WriteLine("Not found");

                test = Console.ReadLine();
            }

            t = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < t; i++)
            {
                string str = Console.ReadLine();
                var evenStr = "";
                var oddStr = "";
                for (var j = 0; j < str.Length; j++)
                {
                    if (j%2 == 0)
                        evenStr += str.Substring(j, 1);
                    else
                        oddStr += str.Substring(j, 1);
                }
                Console.WriteLine(evenStr + " " + oddStr);
            }
        }
    }
}