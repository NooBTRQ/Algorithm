using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm
{
    public static class MicroSoftSubject_Week10
    {
        /// <summary>
        /// 134. 加油站
        /// 在一条环路上有 N 个加油站，其中第 i 个加油站有汽油 gas[i] 升。
        /// 你有一辆油箱容量无限的的汽车，从第 i 个加油站开往第 i+1 个加油站需要消耗汽油 cost[i] 升。你从其中的一个加油站出发，开始时油箱为空。
        /// 如果你可以绕环路行驶一周，则返回出发时加油站的编号，否则返回 -1。
        /// 说明: 
        ///   如果题目有解，该答案即为唯一答案。
        ///   输入数组均为非空数组，且长度相同。
        ///   输入数组中的元素均为非负数。
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int start = 0;
            int run = 0;
            int rest = 0;
            for (int i = 0; i < gas.Length; i++) {

                rest += (gas[i] - cost[i]);
                run += (gas[i] - cost[i]);

                if (run < 0) {

                    run = 0;
                    start = i + 1;
                }
            }

            return rest < 0 ? -1 : start;
        }

        /// <summary>
        /// 450. 删除二叉搜索树中的节点
        /// 给定一个二叉搜索树的根节点 root 和一个值 key，删除二叉搜索树中的 key 对应的节点，并保证二叉搜索树的性质不变。返回二叉搜索树（有可能被更新）的根节点的引用。
        /// 一般来说，删除节点可分为两个步骤：
        ///   首先找到需要删除的节点；
        ///   如果找到了，删除它。
        /// 说明： 要求算法时间复杂度为 O(h)，h 为树的高度。
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return root;

            if (root.val < key) {

                root.right = DeleteNode(root.right, key);
            } else if (root.val > key) {

                root.left = DeleteNode(root.left, key);
            }else{

                // 删除节点
                if (root.left == null && root.right == null)
                {

                    root = null;
                }
                else if (root.right != null)
                {

                    root.val = SuccessorNode(root);
                    root.right = DeleteNode(root.right, root.val);
                }
                else if (root.left != null) {

                    root.val = PredecessorNode(root);
                    root.left = DeleteNode(root.left, root.val);
                }
            }

            return root;
        }

        /// <summary>
        /// 92. 反转链表 II
        /// 反转从位置 m 到 n 的链表。请使用一趟扫描完成反转。
        /// 说明:
        ///   1 ≤ m ≤ n ≤ 链表长度。
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;

            ListNode g = dummyHead;
            ListNode p = dummyHead.next;

            int step = 0;
            while (step < m - 1)
            {
                g = g.next;
                p = p.next;
                step++;
            }

            for (; m<n; m++)
            {
                ListNode removed = p.next;
                p.next = p.next.next;

                removed.next = g.next;
                g.next = removed;
            }

            return dummyHead.next;
        }

        /// <summary>
        /// 5649. 解码异或后的数组
        /// 未知 整数数组 arr 由 n 个非负整数组成。

        /// 经编码后变为长度为 n - 1 的另一个整数数组 encoded ，其中 encoded[i] = arr[i] XOR arr[i + 1] 。例如，arr = [1,0,2,1]
        /// 经编码后得到 encoded = [1, 2, 3] 。
        /// 给你编码后的数组 encoded 和原数组 arr 的第一个元素 first（arr[0]）。
        /// 请解码返回原数组 arr 。可以证明答案存在并且是唯一的。
        /// </summary>
        /// <param name="encoded"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public static int[] Decode(int[] encoded, int first)
        {
            var result = new int[encoded.Length + 1];
            result[0] = first;
            for (int i = 0; i < encoded.Length; i++) {

                result[i + 1] = encoded[i] ^ result[i];
            }

            return result;
        }

        /// <summary>
        /// 5639. 完成所有工作的最短时间
        /// 给你一个整数数组 jobs ，其中 jobs[i] 是完成第 i 项工作要花费的时间。
        /// 请你将这些工作分配给 k 位工人。所有工作都应该分配给工人，且每项工作只能分配给一位工人。
        /// 工人的 工作时间 是完成分配给他们的所有工作花费时间的总和。
        /// 请你设计一套最佳的工作分配方案，使工人的 最大工作时间 得以 最小化 。
        /// 返回分配方案中尽可能 最小 的 最大工作时间 。
        /// </summary>
        /// <param name="jobs"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int MinimumTimeRequired(int[] jobs, int k)
        {
            var workerTime = new int[k];
            for (int i = 0; i < jobs.Length; i++) {

                int minWorkerTiemIndex = 0;
                int minWorkerTiem = workerTime[0];
                for (int j = 1; j < k; j++) {

                    if (workerTime[j] < minWorkerTiem) {

                        minWorkerTiemIndex = j;
                        minWorkerTiem = workerTime[j];
                    }
                }

                workerTime[minWorkerTiemIndex] += jobs[i];
            }

            int maxTime = 0;
            for (int i = 0; i < k; i++) {

                if (workerTime[i] > maxTime) {

                    maxTime = workerTime[i];
                }
            }

            return maxTime;
        }

        /// <summary>
        /// 5652. 交换链表中的节点
        /// 给你链表的头节点 head 和一个整数 k 。
        /// 交换 链表正数第 k 个节点和倒数第 k 个节点的值后，返回链表的头节点（链表 从 1 开始索引）。
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static ListNode SwapNodes(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;
            var stack = new Stack<ListNode>();
            var temp = head;
            while (temp != null) {

                stack.Push(temp);
                temp = temp.next;
            }
            temp = head;
            while (true) {
                if (k == 1) break;

                temp = temp.next;
                stack.Pop();
                k--;
            }

            var stackNode = stack.Pop();
            int stackNodeVal = stackNode.val;
            stackNode.val = temp.val;
            temp.val = stackNodeVal;

            return head;
        }

        private static int SuccessorNode(TreeNode root) {

            root = root.right;
            while (root.left != null) {

                root = root.left;
            }

            return root.val;
        }

        private static int PredecessorNode(TreeNode root)
        {

            root = root.left;
            while (root.right != null)
            {

                root = root.right;
            }

            return root.val;
        }
    }

    /// <summary>
    /// 208. 实现 Trie (前缀树)
    /// </summary>
    public class Trie
    {
        private CharTree _charTree { set; get; }
        /** Initialize your data structure here. */
        public Trie()
        {
            _charTree = new CharTree();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            CharTree currentNode = _charTree;          
            for (int i = 0; i < word.Length; i++) {
                if (currentNode.NextLetter == null) currentNode.NextLetter = new CharTree[27];
                if (currentNode.NextLetter[word[i] - 'a' + 1] == null)
                {

                    var newNode = new CharTree();
                    currentNode.NextLetter[word[i] - 'a' + 1] = newNode;
                    currentNode = newNode;
                    continue;
                }
                else {

                    currentNode = currentNode.NextLetter[word[i] - 'a' + 1];
                    continue;
                }
            }

            if(currentNode.NextLetter == null) currentNode.NextLetter = new CharTree[27];
            currentNode.NextLetter[0] = new CharTree();
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            if (word == null || word.Length == 0) return false;
            var currentNode = _charTree;
            for (int i = 0; i < word.Length; i++) {

                if (currentNode.NextLetter == null || currentNode.NextLetter[word[i] - 'a' + 1] == null) return false;
                currentNode = currentNode.NextLetter[word[i] - 'a' + 1];
            }
            if (currentNode.NextLetter == null || currentNode.NextLetter[0] == null) return false;
            return true;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            if (prefix == null || prefix.Length == 0) return false;
            var currentNode = _charTree;
            for (int i = 0; i < prefix.Length; i++)
            {

                if (currentNode.NextLetter == null || currentNode.NextLetter[prefix[i] - 'a' + 1] == null) return false;
                currentNode = currentNode.NextLetter[prefix[i] - 'a' + 1];
            }
            return true;
        }
    }

    class CharTree 
    {
        public CharTree[] NextLetter { set; get; }
    }
}
