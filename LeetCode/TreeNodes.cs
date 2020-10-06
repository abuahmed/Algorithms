using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        private static void MainTreeNodes(string[] args)
        {
            FizzBuzz(15);
            int[] nodeData = {4,2,5,1,3};// 1, 0, 1, 0, 1, 0, 1 }; // { 3,5,2,1,4,6,7,8,9,10,11,12,13,14 };// 
            int[] nodeData2 ={ 40,20,60,10,30,50,70 };// {5, 1, 7, 0, 4}; // 
            TreeNode treenode1 = null;
            TreeNode treenode2 = null;
            foreach (var llist in nodeData)
            {
                treenode1 = InsertTreeNode(treenode1, llist);
            }
            foreach (var llist in nodeData2)
            {
                treenode2 = InsertTreeNode(treenode2, llist);
            }
            //var result = GetAllElements(treenode1, treenode2);

            //var res = LowestCommonAncestorItterative(treenode1, treenode1.left, treenode1.left.right);
            //var result = SumRootToLeaf(treenode1);
            //var res = SearchBST(treenode1, 120);
            //var res = InsertIntoBST(treenode2, 25);
            //var res = InorderTraversal(treenode1);
            var res = MinDiffInBST(treenode1);
        }

        private static int MinDiffInBST(TreeNode root)
        {
            IList<int> answer = new List<int>();
            if (root == null)
                return 0;

            int minValue = Int32.MaxValue;
            MinDiffInBST(root,  answer);

            for (int i = 1; i < answer.Count; i++)
            {
                minValue = Math.Min(minValue, Math.Abs(answer[i] - answer[i - 1]));
            }

            return minValue;
        }

        static void MinDiffInBST(TreeNode root,  IList<int> answer)
        {
            if (root.left != null)
                MinDiffInBST(root.left, answer);
            
            answer.Add(root.val);

            if (root.right != null)
                MinDiffInBST(root.right, answer);
            
        }

        static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> answer = new List<int>();
            if (root == null)
                return answer;

            ////Iterative Sol
            //var stack = new Stack<TreeNode>();
            //stack.Push(root);

            //while (stack.Count > 0)
            //{
            //    var node = stack.Pop();
            //    if(node.right==null && node.left==null)
            //        answer.Add(node.val);
            //    if (node.right != null)
            //    {
            //        stack.Push(node.right);
            //    }
                
            //    if (node.left != null)
            //    {
            //        stack.Push(node.left);
            //    }

            //}
            InorderTraversal(root, answer);
            return answer;
        }
        static void InorderTraversal(TreeNode root, IList<int> answer)
        {
            if (root == null)
                return;
            
            if (root.left != null)
                InorderTraversal(root.left, answer);

            answer.Add(root.val);

            if (root.right != null)
                InorderTraversal(root.right, answer);
        }
        static IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> answer = new List<int>();
            if (root == null)
                return answer;

            //Iterative Sol
            var stack=new Stack<TreeNode>();
            stack.Push(root);
            
            while (stack.Count>0)
            {
                var node = stack.Pop();
                answer.Add(node.val);
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
                
            }

            //PreorderTraversal(root, answer);
            return answer;
        }
        public void PreorderTraversal(TreeNode root, IList<int> answer)
        {
            if (root == null)
                return;

            answer.Add(root.val);

            if (root.left != null)
                PreorderTraversal(root.left, answer);

            if (root.right != null)
                PreorderTraversal(root.right, answer);
        }
        public bool IsSymmetric(TreeNode root)
        {
            if(root==null)
                return false;
            if (root.left.val == root.right.val)
            {
                
            }
            return IsSymmetric(root.left) == IsSymmetric(root.right);
        }
        static TreeNode InsertIntoBST(TreeNode root, int val)
        {
            //var node = root;
            if(root==null)
                return new TreeNode(val);
            if (val > root.val)
            {
                if (root.right != null)
                {
                    if (val < root.right.val)
                    {
                        var troot = new TreeNode(val);
                        troot.right = root.right;
                        root.right = troot;
                    }
                    else
                    {
                        root.right = InsertIntoBST(root.right, val);
                    }
                }
                else
                {
                    root.right = new TreeNode(val);
                }
            }
            else if (val < root.val)
            {
                if (root.left != null)
                {
                    if (val > root.left.val)
                    {
                        var troot = new TreeNode(val);
                        troot.left = root.left;
                        root.left = troot;
                    }
                    else
                    {
                        root.left = InsertIntoBST(root.left, val);
                    }
                }
                else
                {
                    root.left = new TreeNode(val);
                }
            }
            return root;

            //if (nextchild == null)
            //{
                
            //}

            //if (val < nextchild.val && val > node.val)
            //{

            //}
            //else
            //{
            //    InsertIntoBST(node.right, node.right.right, val);
            //}

            //if (val > nextchild.val && val < node.val)
            //{

            //}
            //else
            //{
                
            //}

            //if (val > node.val)
            //{
            //    //if (node.right != null)
            //    //{
            //    InsertIntoBST(node, node.right, val);
            //    //}
            //}
            //else if (val < node.val)
            //{
            //    InsertIntoBST(node, node.left, val);
            //}



//            var node = root;
//            while (node != null)
//            {
//
//                if (val == node.val)
//                    return node;
//                node = val < node.val ? node.left : node.right;
//            }
//
//            return node;
        }
        static TreeNode SearchBST(TreeNode root, int val)
        {
            while (root!=null)
            {
                if (val == root.val)
                    return root;
                if (val < root.val)
                    return SearchBST(root.left, val);
                else return SearchBST(root.right, val);
                //root = val < root.val ? root.left : root.right;
            }

            return root;
        }
        static TreeNode LowestCommonAncestorItterative(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            var sm = p.val;
            var lg = q.val;
            if (lg < sm)
            {
                sm = q.val;
                lg = p.val;
            }

            while (root!=null)
            {
                if (root.val >= sm && root.val <= lg)
                    return root;
                else if (sm < root.val)
                {
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
            }
            return root;
        }
        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if(root==null)
                return null;
            var sm = p.val;
            var lg = q.val;
            if (lg < sm)
            {
                sm = q.val;
                lg = p.val;
            }
            if (root.val >= sm && root.val <= lg)
                return root;
            else if (sm < root.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else
            {
                return LowestCommonAncestor(root.right, p, q); 
            }
        }
        private static bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return true;
            return IsValidBST(root, root.val, root.val);
        }

        static bool IsValidBST(TreeNode root,int min,int max)
        {
            if(root==null || (root.left==null && root.right==null))
                return true;

            if (root.left != null)
            {
                if (root.left.val >= min)
                {
                    return false;
                }
                min = Math.Min(min, root.left.val);
            }

            if (root.right != null)
            {
                if (root.right.val <= max)
                {
                    return false;
                }
                max = Math.Max(max, root.right.val);
            }

            return IsValidBST(root.left,min,max) && IsValidBST(root.right,min,max);

            if (root.left != null){
                if(root.left.val < root.val)
                {
                    IsValidBST(root.left);
                }
                else return false;
            }
            if (root.right != null )
            {
                if(root.right.val > root.val)
                {
                    IsValidBST(root.right);
                }else return false;
            }

            return true;
        }

        private static int GetTreeHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + Math.Max(GetTreeHeight(root.left), GetTreeHeight(root.right));

            //OR
            var max = 0;
            var result=GetTreeHeight(root, 1);
            return result;
        }

        static int GetTreeHeight(TreeNode head, int height)
        {
            if (head == null)
                return 0;

            if (head.left == null && head.right == null)
            {
                return height;
            }
            else
            {
                height++;
            }

            return Math.Max(height, Math.Max(GetTreeHeight(head.left, height),GetTreeHeight(head.right, height)));
        }
        private static int SumRootToLeaf(TreeNode head)
        {
            return GetTreeSum(head, 0);
        }
        static int GetTreeSum(TreeNode head, int val)
        {
            if (head == null)
                return 0;

            val = val * 2 + head.val;

            if (head.left == null && head.right == null)
            {
                return val;
            }
            else
            {
                return GetTreeSum(head.left, val) + GetTreeSum(head.right, val);
            }
            
        }
        private static int SumRootToLeaf3(TreeNode root)
        {
            //DFS
            var val = 0; 
            var sum = 0;
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var troot = stack.Pop();
                
                //val = val << 1 | troot.val;
                val = val * 2 + root.val;
                if (troot.left != null)
                {
                    stack.Push(troot.left);
                }
                if (troot.right != null)
                {
                    stack.Push(troot.right);
                }
                if (troot.left == null && troot.right == null)
                {
                    sum += val;
                    val = 0;
                }
            }
            return sum;
        }


        static int SumRootToLeaf2(TreeNode root)
        { 
            var val = "";// root.val.ToString();
            var sum = 0;
            //DFS
            var stack=new Stack<TreeNode>();
            stack.Push(root);
            var stacklist = new List<string>();
            while (stack.Count>0)
            {
                var troot = stack.Pop();
                val = troot.val.ToString();
                if (troot.left != null)
                {
                    troot.left.val = Convert.ToInt32(troot.val.ToString() + troot.left.val.ToString());
                    stack.Push(troot.left);
                }
                if (troot.right != null)
                {
                    troot.right.val = Convert.ToInt32(troot.val.ToString() + troot.right.val.ToString());
                    stack.Push(troot.right);
                }
                if (troot.left == null && troot.right == null)
                {
                    sum += Convert.ToInt32(val);
                    stacklist.Add(val);
                    //val = root.val.ToString();
                }
            }
            
            //foreach (var value in stacklist)
            //{
            //    var va = Convert.ToInt32(value,2);
            //    sum += va;
            //}
            return sum;

            //BFS
            Queue<TreeNode> queue=new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count>0)
            {
                var troot = queue.Dequeue();
                val += troot.val.ToString();
                if(troot.left!=null)
                    queue.Enqueue(troot.left);
                if (troot.right != null)
                    queue.Enqueue(troot.right);
                if(troot.left ==null && troot.right == null)
                {
                    
                }
            }
            return 0;
        }
        //static IList<int> _list;
        private static IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            IList<int> list = new List<int>();
            if (root1 != null)
                TraverseTreeNode(root1, list);
            if (root2 != null)
                TraverseTreeNode(root2, list);

            return list.OrderBy(t => t).ToList();
        }

        public static TreeNode TraverseTreeNode(TreeNode head, IList<int> list)
        {
            var dat = head.val;
            list.Add(dat);

            if (head.left != null)
            {
                head.left = TraverseTreeNode(head.left, list);
            }

            if (head.right != null)
            {
                head.right = TraverseTreeNode(head.right, list);
            }
            return head;
        }

        private static IList<string> FizzBuzz(int n)
        {
            // ans list
            List<String> ans = new List<String>();

            // Hash map to store all fizzbuzz mappings.
            var fizzBizzDict =
                new Dictionary<Int32, String>
                {
                    {3, "Fizz"},
                    {5, "Buzz"}
                };


            for (int num = 1; num <= n; num++)
            {
                String numAnsStr = "";

                foreach (Int32 key in fizzBizzDict.Keys)
                {
                    // If the num is divisible by key,
                    // then add the corresponding string mapping to current numAnsStr
                    if (num%key == 0)
                    {
                        numAnsStr += fizzBizzDict[key];
                    }
                }

                if (numAnsStr.Equals(""))
                {
                    // Not divisible by 3 or 5, add the number
                    numAnsStr += num.ToString();
                }

                // Append the current answer str to the ans list
                ans.Add(numAnsStr);
            }

            return ans;

            IList<String> strList = new List<String>(n);
            for (int i = 1; i <= n; i++)
            {
                string content = "";
                //if (i % 15 == 0)
                //content = "FizzBuzz";
                if (i%3 == 0)
                    content = "Fizz";
                if (i%5 == 0)
                    content += "Buzz";

                if (string.IsNullOrEmpty(content))
                    content = i.ToString();

                strList.Add(content);
            }
            return strList;
        }

        private static TreeNode InsertTreeNode(TreeNode node, int data)
        {
            if (node == null)
                return new TreeNode(data);

            //if (data < node.val && data == 0)
            //{
            //    node.left = InsertTreeNode(node.left, data);
            //}
            //else
            //{
            //    node.right = InsertTreeNode(node.right, data);
            //}
            if (data < node.val)
            {
                node.left = InsertTreeNode(node.left, data);
            }
            else
            {
                node.right = InsertTreeNode(node.right, data);
            }

            return node;
        }
    }

    /*
  Definition for a binary tree node.*/

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}