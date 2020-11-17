using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week1
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
        public static Node CopyRandomList2(Node head)
        {

            if (head == null)
            {
                return null;
            }

            var currentNode = head;
            //先拷贝节点到当前节点的下一节点
            while (currentNode != null) {
                var copyNode = new Node(currentNode.val);   
                copyNode.random = currentNode.random;
                copyNode.next = currentNode.next;
                currentNode.next = copyNode;
                currentNode = currentNode.next.next;
            }
            //替换节点中random的引用
            currentNode = head;
            while (currentNode != null) {
                if (currentNode.next.random != null) {
                    currentNode.next.random = currentNode.next.random.next;
                    
                }
                if (currentNode.next.next != null)
                {
                    currentNode = currentNode.next.next;
                }
                else { 
                    currentNode = null;
                }           
            }
            //分离旧链表
            var currentOldNode = head;
            var currentNewNode = head.next;
            Node newHead = head.next;
            while (currentOldNode != null) {
                currentOldNode.next = currentOldNode.next.next;
                if (currentNewNode.next != null) {
                    currentNewNode.next = currentNewNode.next.next;
                }
               
                currentOldNode = currentOldNode.next;
                currentNewNode = currentNewNode.next;
            }
            return newHead;
        }

        /// <summary>
        /// 5.最长回文子串
        /// 给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindrome(string s)
        {
            //动态规划(将i理解为字符串长度)
            var knowledge = new bool[1000, 1000];
            var result = "";
            if (s == null) {
                return result;
            }
           
            for (int i = 0; i < s.Length; i++) {
                for (int j = 0; i + j < s.Length; j++) {
                    int m = i + j;
                    if (i == 0)
                    {
                        knowledge[j, m] = true;

                    }
                    else if (i == 1)
                    {
                        knowledge[j, m] = (s[j] == s[m]);
                    }
                    else
                    {
                        knowledge[j, m] = (knowledge[j + 1, m - 1] && (s[j] == s[m]));
                    }

                    if (knowledge[j, m] && i+1>result.Length) {
                        result = s.Substring(j, i+1);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 206.反转链表
        /// 反转一个单链表。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseList(ListNode head)
        {
            //迭代
            if (head == null)
            {
                return null;
            }
            var currentNode = head.next;
            var preNode = head;
            while (currentNode != null)
            {             
                var nextNode = currentNode.next;
                currentNode.next = preNode;
                preNode = currentNode;
                currentNode = nextNode;
            }
            head.next = null;
            return preNode;
        }

        /// <summary>
        /// 206.反转链表
        /// 反转一个单链表。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseList1(ListNode head)
        {
            //递归
            if (head == null || head.next == null) return head;
            ListNode p = ReverseList1(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }

        /// <summary>
        /// 21.合并两个有序链表
        /// 将两个升序链表合并为一个新的 升序 链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else {
                l2.next = MergeTwoLists(l2.next, l1);
                return l2;
            }
        }

        /// <summary>
        /// 200.岛屿数量
        /// 给你一个由 '1'（陆地）和 '0'（水）组成的的二维网格，请你计算网格中岛屿的数量。
        ///岛屿总是被水包围，并且每座岛屿只能由水平方向或竖直方向上相邻的陆地连接形成。
        ///此外，你可以假设该网格的四条边均被水包围。
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int NumIslands(char[][] grid)
        {
            //DFS(深度优先搜索)
            //扫描整个二维网络，对每个值为 '1' 的单元格进行深度搜索，将临近的单元格标记为'0'，深度搜索的次数则为岛屿次数
            if (grid == null) return 0;
            int rowCounts = grid.Length;
            if (rowCounts == 0) return 0;
            int columnCounts = grid[0].Length;
            int islandNum = 0;
            for (int i = 0; i < rowCounts; i++) {
                for (int j = 0; j < columnCounts; j++) {
                    if (grid[i][j] == '1') {
                        islandNum++;
                        //进行深度搜索
                        DepthFirstSearch(grid, i, j);
                    }
                }
            }
            return islandNum;
        }
        public static void DepthFirstSearch(char[][] grid,int row,int column) {

            if (grid[row][column] == '0') return;
            grid[row][column] = '0';
            if (row - 1 >= 0) DepthFirstSearch(grid, row - 1, column);
            if (row + 1 < grid.Length) DepthFirstSearch(grid, row + 1, column);
            if (column - 1 >= 0) DepthFirstSearch(grid, row, column - 1);
            if (column + 1 <grid[0].Length) DepthFirstSearch(grid, row, column + 1);
        }
    }

    /// <summary>
    /// 146.LRU缓存机制
    /// 
    /// </summary>
    public class LRUCache
    {

        public Dictionary<int, int> CacheData;
        public List<int> KeyList;
        public int Capacity;

        public LRUCache(int capacity)
        {
            CacheData = new Dictionary<int, int>();
            KeyList = new List<int>();
            Capacity = capacity;
        }

        public int Get(int key)
        {
            if (CacheData.ContainsKey(key)) {

                KeyList.Remove(key);
                KeyList.Add(key);

                return CacheData[key];
            } 
            return -1;
        }

        public void Put(int key, int value)
        {
            if (CacheData.Keys.Count == Capacity && !CacheData.ContainsKey(key)) {
                CacheData.Remove(KeyList[0]);
                KeyList.RemoveAt(0);
            }
            if (CacheData.ContainsKey(key))
            {
                CacheData[key] = value;
                KeyList.Remove(key);
                KeyList.Add(key);
            }
            else {
                CacheData.Add(key, value);
                KeyList.Add(key);
            }
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
