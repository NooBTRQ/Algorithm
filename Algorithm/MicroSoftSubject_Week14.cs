using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week14
    {
        /// <summary>
        /// 114. 二叉树展开为链表
        /// 给你二叉树的根结点 root ，请你将它展开为一个单链表：
        /// 展开后的单链表应该同样使用 TreeNode ，其中 right 子指针指向链表中下一个结点，而左子指针始终为 null 。
        /// 展开后的单链表应该与二叉树 先序遍历 顺序相同。
        /// </summary>
        /// <param name="root"></param>
        public static void Flatten(TreeNode root)
        {
            if (root == null) return ;
            var currentNode = root;
            while (currentNode != null) {

                if (currentNode.left != null) {

                    var preNode = currentNode.left;
                    while (preNode.right != null) {

                        preNode = preNode.right;
                    }

                    preNode.right = currentNode.right;
                    currentNode.right = currentNode.left;
                    currentNode.left = null;
                    
                }

                currentNode = currentNode.right;
            }
        }

        /// <summary>
        /// 328. 奇偶链表
        /// 给定一个单链表，把所有的奇数节点和偶数节点分别排在一起。请注意，这里的奇数节点和偶数节点指的是节点编号的奇偶性，而不是节点的值的奇偶性。
        /// 请尝试使用原地算法完成。你的算法的空间复杂度应为 O(1)，时间复杂度应为 O(nodes)，nodes 为节点总数。
        /// 说明:
        ///   应当保持奇数节点和偶数节点的相对顺序。
        ///   链表的第一个节点视为奇数节点，第二个节点视为偶数节点，以此类推。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            var current = head.next.next;
            ListNode oddHead = head;
            ListNode evenHead = head.next;
            head.next.next = null;
            head.next = null;
            var tempOdd = oddHead;
            var tempEven = evenHead;
            while (current != null) {

                if (current.next == null) {

                    tempOdd.next = current;
                    tempOdd = tempOdd.next;
                    break;
                }
                tempOdd.next = current;
                tempEven.next = current.next;
                var next = current.next.next;
                current.next.next = null;
                current.next = null;
                tempOdd = tempOdd.next;
                tempEven = tempEven.next;
                current = next;
            }

            tempOdd.next = evenHead;
            return oddHead;
        }

        /// <summary>
        /// 剑指 Offer 03. 数组中重复的数字
        /// 找出数组中重复的数字。
        /// 在一个长度为 n 的数组 nums 里的所有数字都在 0～n-1 的范围内。数组中某些数字是重复的，但不知道有几个数字重复了，也不知道每个数字重复了几次。请找出数组中任意一个重复的数字。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindRepeatNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var numSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++) {

                if (numSet.Contains(nums[i])) return nums[i];
                numSet.Add(nums[i]);
            }

            return 0;
        }

        /// <summary>
        /// 剑指 Offer 04. 二维数组中的查找
        /// 在一个 n * m 的二维数组中，每一行都按照从左到右递增的顺序排序，每一列都按照从上到下递增的顺序排序。
        /// 请完成一个高效的函数，输入这样的一个二维数组和一个整数，判断数组中是否含有该整数。
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool FindNumberIn2DArray(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0 || matrix[0][0] > target) return false;
            int row = 0;
            int column = matrix[0].Length - 1;
            while (row < matrix.Length && column >= 0) {

                if (matrix[row][column] == target) return true;
                else if (matrix[row][column] < target) row++;
                else column--;
            }
            return false;
        }

        /// <summary>
        /// 643. 子数组最大平均数 I
        /// 给定 n 个整数，找出平均数最大且长度为 k 的连续子数组，并输出该最大平均数。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double FindMaxAverage(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || nums.Length < k || k <= 0) return 0;

            int tempSum = 0;           
            double ans = 0;
            for (int i = 0; i < k; i++) {

                tempSum += nums[i];
            }
            ans = tempSum * 1.0 / k;

            int left = 1;
            int right = k;
            while (right < nums.Length) {

                tempSum = tempSum + nums[right] - nums[left - 1];
                ans = Math.Max(ans, tempSum * 1.0 / k);
                left++;
                right++;
            }

            return ans;
        }

        /// <summary>
        /// 剑指 Offer 05. 替换空格
        /// 请实现一个函数，把字符串 s 中的每个空格替换成"%20"。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReplaceSpace(string s)
        {
            if (s == null || s.Length == 0) return "";
            var str = new StringBuilder();
            for (int i = 0; i < s.Length; i++) {

                if (s[i] == ' ')
                {

                    str.Append("%20");
                }
                else {

                    str.Append(s[i]);
                }
            }

            return str.ToString();
        }

        /// <summary>
        /// 剑指 Offer 06. 从尾到头打印链表
        /// 输入一个链表的头节点，从尾到头反过来返回每个节点的值（用数组返回）。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static int[] ReversePrint(ListNode head)
        {
            if (head == null) return new int[0];
            var nodeStack = new Stack<ListNode>();
            while (head != null) {

                nodeStack.Push(head);
                head = head.next;
            }
            var result = new int[nodeStack.Count];
            int index = 0;
            while (nodeStack.Count > 0) {
                var node = nodeStack.Pop();
                result[index] = node.val;
                index++;
            }

            return result;
        }
    }
}
