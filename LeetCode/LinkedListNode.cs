using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Solution
    {
        public static void MainLinkedList(string[] args)
        {
            #region Tests
            int[] nodeData = { 6, 5, 4, 3 };//
            //{-21, 10, 17, 8, 4, 26, 5, 35, 33, -7, -16, 27, -12, 6, 29, -12, 5, 9, 20, 14, 14, 2, 13, -24, 21, 23,
            //    -21, 5};// {-9, 3};//   {2, 4, 6, 8, 9};
            int[] nodeData1 = { 1, 3, 4 };//{5, 7};//  { 2, 4, 6, 8, 9 };
            //string[] nodeData = { "abebe", "beso", "bela", "chala", "chube", "be", "beso", "chebete" };

            ListNode singlyLinkedListNode = null;
            ListNode singlyLinkedListNode2 = null;
            foreach (var llist in nodeData)
            {
                singlyLinkedListNode = InsertNode(singlyLinkedListNode, llist);
            }
            foreach (var llist in nodeData1)
            {
                singlyLinkedListNode2 = InsertNode(singlyLinkedListNode2, llist);
            }

            //DeleteNode(singlyLinkedListNode.next);
            //RemoveNthFromEnd(singlyLinkedListNode, 1);
            //var res=IsPalindrome(singlyLinkedListNode);
            //var res = ReverseList(singlyLinkedListNode);
            //var res = MergeTwoLists(singlyLinkedListNode, singlyLinkedListNode2);
            //var res = HasCycle(singlyLinkedListNode);

            //var res = RevereseLlist(singlyLinkedListNode); 
            #endregion

            var hd = SortList(singlyLinkedListNode);
        }
        static ListNode SortList(ListNode head)
        {
            if (head.next == null)
                return head;

            var node = head;

            ListNode root = null;
            while (node != null)
            {
                if (node.val > node.next.val)
                {
                    var headdata = node.next;
                    node.next = node.next.next;
                    headdata.next = node;

                    if (root == null)
                        root = headdata;
                    else root.next = headdata;

                }
                node = node.next;
            }

            return null;
        }
        private static ListNode RevereseLlist(ListNode singlyLinkedListNode)
        {
            return ReverseList(singlyLinkedListNode, null);
        }

        private static ListNode ReverseList(ListNode singlyLinkedListNode, ListNode reversed)
        {
            ////Recursive
            if (singlyLinkedListNode == null)
                return reversed;

            reversed=ReverseList(singlyLinkedListNode.next,new ListNode(singlyLinkedListNode.val,reversed));

            ////Itereative
            //while (singlyLinkedListNode!=null)
            //{
            //    var temp = reversed;
            //    reversed = new ListNode(singlyLinkedListNode.val);
            //    reversed.next = temp;

            //    singlyLinkedListNode = singlyLinkedListNode.next;
            //}

            return reversed;
        }

        private ListNode HasCycleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    ListNode slow2 = head;
                    while (slow2 != slow)
                    {
                        slow = slow.next;
                        slow2 = slow2.next;
                    }
                    return slow;
                }
            }
            return null;
        }
        static bool HasCycle(ListNode head)
        {
            var hashSet = new HashSet<ListNode>();
            while (head!=null)
            {
                if (hashSet.Contains(head))
                    return true;
                else
                {
                    hashSet.Add(head);
                }
                head = head.next;
            }
            return false;
        }
        static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
            //ListNode lnode = null;
            //while (l1!=null && l2!=null)
            //{
            //    if (l1.val < l2.val)
            //    {
            //        lnode = InsertNode(lnode, l1.val);
            //        l1 = l1.next;
            //    }
            //    else
            //    {
            //        lnode = InsertNode(lnode, l2.val);
            //        l2 = l2.next;
            //    }

            //}
            //while (l1!=null)
            //{
            //    lnode = InsertNode(lnode, l1.val);
            //    l1 = l1.next;
            //}

            //while (l2 != null)
            //{
            //    lnode = InsertNode(lnode, l2.val);
            //    l2 = l2.next;
            //}
            

            //return lnode;
        }

        static ListNode ReverseList(ListNode head)
        {
            ListNode reverseList = null;
            while (head != null)
            {
                ListNode next = head.next;
                head.next = reverseList;
                reverseList = head;
                head = next;
            }
            return reverseList;
        }
        static bool IsPalindrome(ListNode head)
        {
            if (head == null)
                return true;

            var s = new List<int>();
            while (head!=null)
            {
                s.Add(head.val);
                head = head.next;
            }

            var len = s.Count;
            int i = 0, j = len - 1;
            while (i < len / 2)
            {
                if (!s[i].Equals(s[j]))
                    return false;
                i++;
                j--;
            }

            return true;

            //OR
            ListNode fast = head, slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            if (fast != null)
            { // odd nodes: let right half smaller
                slow = slow.next;
            }
            slow = reverse(slow);
            fast = head;

            while (slow != null)
            {
                if (fast.val != slow.val)
                {
                    return false;
                }
                fast = fast.next;
                slow = slow.next;
            }
            return true;
        }

        static ListNode reverse(ListNode head)
        {
            ListNode prev = null;
            while (head != null)
            {
                ListNode next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }
        static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var curr = head;
            if(curr.next==null)
                return null;
            while (curr!=null)
            {
                var newcurr = curr;
                int m = n;
                while (m>0)
                {
                    newcurr = newcurr.next;
                    m--;
                }
                if (newcurr != null)
                {
                    if (curr.next.next == null)
                    {
                        curr.next = null;
                        return head;
                    }

                    curr = curr.next;
                }
                else
                {
                    curr.val = curr.next.val;
                    curr.next = curr.next.next;

                    return head;
                }
            }
            return head;
            //OR
            /*
             *  ListNode dummy = new ListNode(0);
                dummy.next = head;
                ListNode first = dummy;
                ListNode second = dummy;
                // Advances first pointer so that the gap between first and second is n nodes apart
                for (int i = 1; i <= n + 1; i++) {
                    first = first.next;
                }
                // Move first to the end, maintaining the gap
                while (first != null) {
                    first = first.next;
                    second = second.next;
                }
                second.next = second.next.next;
                return dummy.next;
             */
        }
        static void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
            ////OR
            //while (node.next.next!=null)
            //{
            //    node.val = node.next.val;
            //    node = node.next;
            //}
            //node.val = node.next.val;
            //node.next = null;
        }
        
        private static ListNode InsertNode(ListNode singlyLinkedListNode, int data)
        {
            if (singlyLinkedListNode == null)
                return new ListNode(data);

            singlyLinkedListNode.next = InsertNode(singlyLinkedListNode.next, data);

            return singlyLinkedListNode;
        }

    }

    
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
            next = null;
        }
        public ListNode(int x,ListNode nex)
        {
            val = x;
            next = nex;
        }
    }
}