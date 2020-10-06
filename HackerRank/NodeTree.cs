using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace HackerRank
{
    partial class Solution
    {
        static int _height, _max = 0;
        static List<int> _vs1, _vs2;
        static bool _isBst = true;

        public static void MainNodeTree(string[] args)
        {
            int[] nodeData = { 5, 3, 2, 4, 6, 9, 1};//, 10, 11, 12, 13, 0, -1, -2, -3, -4, -5, 14, 15, 16, 17, 20, 28, 29 };
            //string[] nodeData = { "abebe", "beso", "bela", "chala", "chube", "be", "beso", "chebete" };
            //Node<int> node = null;
            TreeNode treenode = null;
            foreach (var llist in nodeData)
            {
                treenode = InsertTreeNode(treenode, llist);
            }

            _vs1=new List<int>();
            _vs2=new List<int>();

            //var lca = LowestCommonAncestor(treenode, 11, 13);
            //var postorder = PostOrder(treenode);  //Not Working
            
            var isbst = CheckBst(treenode);

            var traverse = TraverseTreeNode(treenode);

            isbst = CheckBst(treenode);
        }
        
        public static TreeNode TraverseTreeNode(TreeNode head)
        {
            var dat = head.Data;
            if (dat == 9)
                head.Data = 1;

            if (dat == 2)
                head.Data = 7;
            
            if (head.Left != null)
            { 
                head.Left = TraverseTreeNode(head.Left);
            }

            if (head.Right != null)
            {
                head.Right = TraverseTreeNode(head.Right);
            }
            
            return head;
        }

        public static void DecodeHuff(string s, TreeNode head)
        {  

        }

        public static bool CheckBst(TreeNode head)
        {
            CheckBiSearchTree(head);
            return _isBst;
        }

        public static TreeNode CheckBiSearchTree(TreeNode head)
        {
            var dat = head.Data;
            if (_vs1.Contains(dat))
                _isBst = false;
            else _vs1.Add(dat);

            if (head.Left != null)
            {
                if (head.Left.Data > dat)
                {
                    _isBst = false;
                }

                head.Left = CheckBiSearchTree(head.Left);
            }

            if (head.Right != null)
            {
                if (head.Right.Data < dat)
                {
                    _isBst = false;
                }
                head.Right = CheckBiSearchTree(head.Right);
            }

            return head;
        }
        
        static TreeNode LowestCommonAncestor(TreeNode node, int v1, int v2)
        {
            //while (node!=null)
            //{
                if (v1 < node.Data && v2 < node.Data)
                {
                    node = LowestCommonAncestor(node.Left,v1,v2);
                }
                else if (v1 > node.Data && v2 > node.Data)
                {
                    node = LowestCommonAncestor(node.Right,v1,v2);
                }
                else
                {
                    return node;
                }
            //}

            return node;

            //var v1Node = node;
            //var v2Node = node;

            //while (v1Node!=null)
            //{
            //    _vs1.Add(v1Node.Data);
            //    if (v1 == v1Node.Data) break;
            //    if (v1 < v1Node.Data)
            //        v1Node = v1Node.Left;
            //    else
            //        v1Node = v1Node.Right;
            //}

            //while (v2Node != null)
            //{
            //    _vs2.Add(v2Node.Data);
            //    if (v2 == v2Node.Data) break;
            //    if (v2 < v2Node.Data)
            //        v2Node = v2Node.Left;
            //    else
            //        v2Node = v2Node.Right;
            //}

            //var dist = _vs1.Intersect(_vs2).ToList();

            //return dist.Last();
        }
        
        static TreeNode GetTreeHeight(TreeNode head)
        {
            if (head.Left == null && head.Right == null)
            {
                _max = _max < _height ? _height : _max;
                _height = 0;
            }

            if (head.Left != null)
            {
                _height++;
                head.Left = GetTreeHeight(head.Left);
            }

            if (head.Right != null)
            {
                _height++;
                head.Right = GetTreeHeight(head.Right);
            }

            return head;
        }

        static string BreadthFirst(TreeNode rootTreeNode)
        {
            var seq = "";
            var queue1 = new Queue<TreeNode>();
            if (rootTreeNode != null)
            {
                queue1.Enqueue(rootTreeNode);

                while (queue1.Count != 0)
                {
                    var tree = queue1.Dequeue();
                    seq = seq + " " + tree.Data;
                    if (tree.Left != null)
                    {
                        queue1.Enqueue(tree.Left);
                    }
                    if (tree.Right != null)
                    {
                        queue1.Enqueue(tree.Right);
                    }
                }
            }
            Console.WriteLine(seq.TrimStart());
            return seq;
        }

        static string PreOrder(TreeNode rootTreeNode)
        {
            var seq = "";
            var travStack = new Stack<TreeNode>();
            if (rootTreeNode != null)
            {
                travStack.Push(rootTreeNode);
                while (travStack.Count != 0)
                {
                    var tree = travStack.Pop();
                    seq = seq + " " + tree.Data;

                    if (tree.Right != null)
                    {
                        travStack.Push(tree.Right);
                    }

                    if (tree.Left != null)
                    {
                        travStack.Push(tree.Left);
                    }
                }
            }
            return seq;
        }

        private static string PostOrder(TreeNode rootTreeNode)
        {
            var seq = "";
            var travStack = new Stack<TreeNode>();
            TreeNode p = rootTreeNode, q = rootTreeNode;
            while (p != null)
            {
                for (; p.Left!=null; p=p.Left)
                {
                    travStack.Push(p);
                    while (p!=null && (p.Right==null || p.Right==q))
                    {
                        seq = seq + p.Data;
                        q = p;
                        if (travStack.Count == 0)
                            break;
                        p = travStack.Pop();
                    }
                }
                travStack.Push(p);
                p = p.Right;
            }
            return seq;
        }
        
        static TreeNode InsertTreeNode(TreeNode node, int data)
        {
            if (node == null)
                return new TreeNode(data);

            if (data < node.Data)
            {
                node.Left = InsertTreeNode(node.Left, data);
            }
            else
            {
                node.Right = InsertTreeNode(node.Right, data);
            }

            return node;
        }
    }

   
    class TreeNode
    {
        public int Data;
        public TreeNode Left, Right;
        public TreeNode(int d)
        {
            Data = d;
            Left = Right = null;
        }
    }

    //Generics
    class TreeNodeG<T>
    {
        public T Data;
        public TreeNodeG<T> Left;
        public TreeNodeG<T> Right;
        public TreeNodeG(T d)
        {
            Data = d;
            Left = null;
            Right = null;
        }
        
    }

}

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
