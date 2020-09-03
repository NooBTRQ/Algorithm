using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject
    {
        /// <summary>
        /// 1.返回两数之和
        /// Given an array of integers nums and and integer target, return the indices of the two numbers such that they add up to target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            var intDic = new Dictionary<int, int>();
            for(int i = 0;i<nums.Length;i++) {
                var a = target - nums[i];
                if (intDic.ContainsKey(a)) {
                    return new int[2] { i, intDic[a] };
                }
                if (!intDic.ContainsKey(nums[i])) {
                    intDic.Add(nums[i], i);
                }
            }

            return new int[0];
        }

        /// <summary>
        /// 2.两数相加
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order and each of their nodes contain a single digit. 
        /// Add the two numbers and return it as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) {

            ListNode result = null;
            ListNode lastNode = null;
            int t = 0;
            while (l1 != null || l2 != null || t != 0) {
                if (l1 != null) {
                    t += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null) {
                    t += l2.val;
                    l2 = l2.next;
                }
                var currentNode = new ListNode(t % 10);
                if (result == null)
                {
                    result = currentNode;
                    lastNode = currentNode;
                }
                else {
                    lastNode.next = currentNode;
                    lastNode = currentNode;
                }
                t = t / 10;
                
            }

            return result;
        }


        public static Dictionary<Node, Node> CopyRandomListDic = new Dictionary<Node, Node>();
        /// <summary>
        /// 138.复制带随机指针的链表
        /// 给定一个链表，每个节点包含一个额外增加的随机指针，该指针可以指向链表中的任何节点或空节点。
        /// 要求返回这个链表的 深拷贝。 
        /// 我们用一个由 n 个节点组成的链表来表示输入/输出中的链表。每个节点用一个[val, random_index] 表示：
        /// val：一个表示 Node.val 的整数。
        /// random_index：随机指针指向的节点索引（范围从 0 到 n-1）；如果不指向任何节点，则为 null 。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static Node CopyRandomList(Node head)
        {
            
            if (head == null) {
                return null;
            }

            if (CopyRandomListDic.ContainsKey(head)) {
                return CopyRandomListDic[head];
            }

            var newNode = new Node(head.val);
            CopyRandomListDic.Add(head, newNode);
            newNode.next = CopyRandomList(head.next);
            newNode.random = CopyRandomList(head.random);
            return newNode;
        }

        public static Node CopyRandomList2(Node head)
        {

            if (head == null)
            {
                return null;
            }

            var currentNode = head;
            //先拷贝节点到当前节点的下一节点
            while (currentNode != null) {
                var newNode = new Node(currentNode.val);
                newNode.random = currentNode.random;
                newNode.next = currentNode.next;
                currentNode.next = newNode;
                currentNode = currentNode.next.next;
            }
            //替换节点中random的引用
            currentNode = head;
            while (currentNode != null) {
                if (currentNode.random != null) {
                    currentNode.random = currentNode.random.next;
                }
                
            }
            //分离两个链表
            currentNode = head.next;
            Node newHead = head.next;
            while (currentNode != null) {
                currentNode.next = currentNode.next.next;
                currentNode = currentNode.next;
            }
            return newHead;
        }

        /// <summary>
        /// 最长回文子串
        /// 给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {

        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
