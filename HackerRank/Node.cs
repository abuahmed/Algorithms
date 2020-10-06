using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace HackerRank
{
    partial class Solution
    {
        public static void MainNode(string[] args)
        {
            int[] nodeData = {2,4,6,8,9};// {5, 3, 2, 4, 6, 9, 1};//, 10, 11, 12, 13, 0, -1, -2, -3, -4, -5, 14, 15, 16, 17, 20, 28, 29};
            //string[] nodeData = { "abebe", "beso", "bela", "chala", "chube", "be", "beso", "chebete" };

            SinglyLinkedListNode<int> singlyLinkedListNode = null;
            
            DoublyLinkedListNode<int> head = null, tail=null;

            foreach (var llist in nodeData)
            {
                singlyLinkedListNode = InsertNode(singlyLinkedListNode, llist);
                
                if (tail == null)
                {
                    head = tail = new DoublyLinkedListNode<int>(llist);
                }
                else
                {
                    tail = new DoublyLinkedListNode<int>(llist, null, tail);
                    tail.Previous.Next = tail;
                }
            }

            //var h = SortedInsert<int>(head, 7);

            var rev = Reverse<int>(head);

            //var hh = InsertNodeAtPosition<int>(singlyLinkedListNode, 7, 6);

            //var nodeLength = GetNodeLength(singlyLinkedListNode);

            //var nod = RemoveDuplicates(node);

            int[] nodeData2 = { 1, 4, 6, 8, 9 };
            SinglyLinkedListNode<int> singlyLinkedListNode2 = null;
            foreach (var llist in nodeData2)
            {
                singlyLinkedListNode2 = InsertNode(singlyLinkedListNode2, llist);
            }
            var merge = FindMergeNode(singlyLinkedListNode, singlyLinkedListNode2);
            
        }

        private static int GetNodeLength<T>(SinglyLinkedListNode<T> head)
        {
            if (head == null)
                return 0;
            return 1 + GetNodeLength<T>(head.Next);
        }

        private static SinglyLinkedListNode<T> RemoveDuplicates<T>(SinglyLinkedListNode<T> head)
        {
            //Write your code here
            var nodeDataList = new List<T>();

            var nextNode = head;
            while (nextNode.Next != null)
            {
                nodeDataList.Add(nextNode.Data);

                if (nodeDataList.Contains(nextNode.Next.Data))
                {
                    nextNode.Next = nextNode.Next.Next;
                }
                else
                {
                    nextNode = nextNode.Next;
                }
            }

            return head;
        }

        private static SinglyLinkedListNode<T> InsertNode<T>(SinglyLinkedListNode<T> singlyLinkedListNode, T data)
        {
            if (singlyLinkedListNode == null)
                return new SinglyLinkedListNode<T>(data);

            singlyLinkedListNode.Next = InsertNode(singlyLinkedListNode.Next, data);

            return singlyLinkedListNode;
        }

        private static SinglyLinkedListNode<int> InsertNodeAtPosition<T>(SinglyLinkedListNode<int> head, int data, int position)
        {
            if (head == null)
                return new SinglyLinkedListNode<int>(data);

            var current = head;
            int pos = 0;
            while (current!=null)
            {
                if (pos == position - 1)
                {
                    var newNode = new SinglyLinkedListNode<int>(data)
                    {
                        Next = current.Next
                    };
                    current.Next = newNode;
                    break;
                }

                current = current.Next;
                pos++;
            }

            return head;
        }

        private static bool HasCycle<T>(SinglyLinkedListNode<int> head)
        {
            var nodelist = new ArrayList();
            while (head!=null)
            {
                if (nodelist.Contains(head.Data))
                    return true;
                else nodelist.Add(head.Data);

                head = head.Next;
            }

            return false;
        }

        private static T FindMergeNode<T>(SinglyLinkedListNode<T> head1, SinglyLinkedListNode<T> head2)
        {
            var curr1 = head1;
            var curr2 = head2;
            var head1List = new List<T>();
            var head2List = new List<T>();

            while (curr1!=null)
            {
                head1List.Add(curr1.Data);
                curr1 = curr1.Next;
            }

            while (curr2 != null)
            {
                head2List.Add(curr2.Data);
                curr2 = curr2.Next;
            }
            var max = Math.Max(head1List.Count, head2List.Count);
            for (int i = max - 1; i >= 0 ; i--)
            {
                if (!head1List[i].Equals(head2List[i]))
                {
                    return head1List[i + 1];
                }
            }

            return head1List[0];
        }

        private static DoublyLinkedListNode<int> SortedInsert<T>(DoublyLinkedListNode<int> head, int data)
        {
            if (head == null)
                return new DoublyLinkedListNode<int>(data);

            var current = head;
            //var found = false;
            while (current!=null)
            {
                if (current.Data > data)
                {
                    //found = true;
                    var newNode = new DoublyLinkedListNode<int>(data)
                    {
                        Previous = current.Previous, Next = current
                    };

                    if (current.Previous != null) current.Previous.Next = newNode;
                    else return newNode;

                    break;
                }
                current = current.Next;
            }

            if (current==null)
            {
                var newNode = new DoublyLinkedListNode<int>(data);
                newNode.Next = null;
                head.Next = newNode;
                //return newNode;
            }

            return head;
        }
        
        private static DoublyLinkedListNode<T> Reverse<T>(DoublyLinkedListNode<T> head)
        { 
            if (head == null)
                return null;

            var tail=new DoublyLinkedListNode<T>(head.Data);
            
            var curr = head.Next;
            while (curr!=null)
            {
                tail = new DoublyLinkedListNode<T>(curr.Data, tail, null);
                tail.Next.Previous = tail;

                curr = curr.Next;
            }
            
            return tail;
        }
         
    }


    internal class SinglyLinkedListNode<T>
    {
        public T Data;
        public SinglyLinkedListNode<T> Next;

        public SinglyLinkedListNode(T d)
        {
            Data = d;
            Next = null;
        }
    }

    internal class DoublyLinkedListNode<T>
    {
        public T Data;
        public DoublyLinkedListNode<T> Next, Previous;

        public DoublyLinkedListNode(T d)
        {
            Data = d;
            Next = Previous = null;
        }
        public DoublyLinkedListNode(T d, DoublyLinkedListNode<T> next, DoublyLinkedListNode<T> previous)
        {
            Data = d;
            Next = next;
            Previous = previous;
        }
    }

}

//class TreeNode
    //{
    //    public int Data;
    //    public TreeNode Left, Right;
    //    public TreeNode(int d)
    //    {
    //        Data = d;
    //        Left = Right = null;
    //    }
    //}

    ////Generics
    //class TreeNodeG<T>
    //{
    //    public T Data;
    //    public TreeNodeG<T> Left;
    //    public TreeNodeG<T> Right;
    //    public TreeNodeG(T d)
    //    {
    //        Data = d;
    //        Left = null;
    //        Right = null;
    //    }
        
    //}

    //public static Node insert(Node head, int data)
    //{
    //    //Complete this method
    //    if (head == null)
    //    {
    //        head = new Node(data);
    //    }
    //    else
    //    {
    //        var newNode = new Node(data);

    //        var currentNode = head;
    //        while (currentNode.next != null)
    //        {
    //            currentNode = currentNode.next;
    //        }
    //        currentNode.next = newNode;
    //    }

    //    return head;
    //}

    //public static void display(Node head)
    //{
    //    Node start = head;
    //    while (start != null)
    //    {
    //        Console.Write(start.data + " ");
    //        start = start.next;
    //    }
    //}

    //static void Main(String[] args)
    //{

    //    Node head = null;
    //    int T = Int32.Parse(Console.ReadLine());
    //    while (T-- > 0)
    //    {
    //        int data = Int32.Parse(Console.ReadLine());
    //        head = insert(head, data);
    //    }
    //    display(head);
    //}
    //public static Node insert(Node head, int data)
    //{
    //    Node p = new Node(data);

    //    if (head == null)
    //        head = p;
    //    else if (head.next == null)
    //        head.next = p;
    //    else
    //    {
    //        Node start = head;
    //        while (start.next != null)
    //            start = start.next;
    //        start.next = p;

    //    }
    //    return head;
    //}

    //public static void display(Node head)
    //{
    //    Node start = head;
    //    while (start != null)
    //    {
    //        Console.Write(start.data + " ");
    //        start = start.next;
    //    }
    //}

    //static void Main(String[] args)
    //{

    //    Node head = null;
    //    int T = Int32.Parse(Console.ReadLine());
    //    while (T-- > 0)
    //    {
    //        int data = Int32.Parse(Console.ReadLine());
    //        head = insert(head, data);
    //    }
    //    head = RemoveDuplicates(head);
    //    display(head);
    //}

    //static int getLeftChild(TreeNode rootTreeNode)
    //{
    //    if (rootTreeNode.left == null)
    //        return -1;
    //    return 1 + getLeftChild(rootTreeNode.left);
    //}

    //static int getRightChild(TreeNode rootTreeNode)
    //{
    //    if (rootTreeNode.right == null)
    //        return -1;
    //    return 1;
    //}

    //int maxleft = 1;
    //int maxright = 1;

    //static int Max(int x, int y)
    //{
    //    return x > y ? x : y;
    //}

    //public static TreeNode InsertTree(TreeNode head, int data)
    //{
    //    //Complete this method
    //    if (head == null)
    //    {
    //        head = new TreeNode(data);
    //    }
    //    else
    //    {
    //        var newTreeNode = new TreeNode(data);
    //        var currentTreeNode = head;

    //        while (currentTreeNode != null)
    //        {
    //            if (data <= currentTreeNode.data)
    //            {
    //                if (currentTreeNode.left == null)
    //                {
    //                    currentTreeNode.left = newTreeNode;
    //                    break;
    //                }
    //                currentTreeNode = currentTreeNode.left;
    //            }
    //            else
    //            {
    //                if (currentTreeNode.right == null)
    //                {
    //                    currentTreeNode.right = newTreeNode;
    //                    break;
    //                }
    //                currentTreeNode = currentTreeNode.right;
    //            }

    //        }

    //    }

    //    return head;
    //}

    //static void Main(String[] args)
    //{
    //    TreeNode root = null;
    //    int T = Int32.Parse(Console.ReadLine());
    //    while (T-- > 0)
    //    {
    //        int data = Int32.Parse(Console.ReadLine());
    //        root = insertTree(root, data);
    //    }
    //    var lo = levelOrder(root);
    //    int height = getHeight(root);
    //    Console.WriteLine(height);

    //}
