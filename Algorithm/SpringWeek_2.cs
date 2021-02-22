using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class SpringWeek_2
    {
        /// <summary>
        /// 766. 托普利茨矩阵
        /// 给你一个 m x n 的矩阵 matrix 。如果这个矩阵是托普利茨矩阵，返回 true ；否则，返回 false 。
        /// 如果矩阵上每一条由左上到右下的对角线上的元素都相同，那么这个矩阵是 托普利茨矩阵 。
        /// 进阶：
        ///   如果矩阵存储在磁盘上，并且内存有限，以至于一次最多只能将矩阵的一行加载到内存中，该怎么办？
        ///   如果矩阵太大，以至于一次只能将不完整的一行加载到内存中，该怎么办？
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static bool IsToeplitzMatrix(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return true;
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {

                    if (matrix[i][j] != matrix[i - 1][j - 1]) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 剑指 Offer 24. 反转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseList(ListNode head)
        { 
            // 迭代
            if (head == null || head.next == null) return head;
            var currentNode = head.next;
            var preNode = head;
            while (currentNode != null) {
                var nextNode = currentNode.next;
                currentNode.next = preNode;
                preNode = currentNode;
                currentNode = nextNode;
            }
            head.next = null;
            return preNode;
        }

        /// <summary>
        /// 剑指 Offer 24. 反转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseList2(ListNode head)
        {
            // 递归
            if (head.next == null || head.next == null) return head;
            var p = ReverseList2(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }
    }
}
