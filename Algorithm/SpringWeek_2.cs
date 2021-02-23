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

        /// <summary>
        /// 1052. 爱生气的书店老板
        /// 今天，书店老板有一家店打算试营业 customers.length 分钟。每分钟都有一些顾客（customers[i]）会进入书店，所有这些顾客都会在那一分钟结束后离开。
        /// 在某些时候，书店老板会生气。 如果书店老板在第 i 分钟生气，那么 grumpy[i] = 1，否则 grumpy[i] = 0。 当书店老板生气时，那一分钟的顾客就会不满意，不生气则他们是满意的。
        /// 书店老板知道一个秘密技巧，能抑制自己的情绪，可以让自己连续 X 分钟不生气，但却只能使用一次。
        /// 请你返回这一天营业下来，最多有多少客户能够感到满意的数量。
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="grumpy"></param>
        /// <param name="X"></param>
        /// <returns></returns>
        public static int MaxSatisfied(int[] customers, int[] grumpy, int X)
        {
            var baseSum = 0;
            for (int i = 0; i < grumpy.Length; i++) {

                baseSum += (1 - grumpy[i]) * customers[i];
            }

            int maxSum = 0;
            for (int i = 0; i < X; i++) {

                maxSum += grumpy[i] * customers[i];
            }
            int tempSum = maxSum;
            for (int i = 1; i <= grumpy.Length - X; i++) {

                tempSum = tempSum - grumpy[i - 1] * customers[i - 1] + grumpy[i + X - 1] * customers[i + X - 1];
                maxSum = Math.Max(maxSum, tempSum);
            }
            baseSum += maxSum;
            return baseSum;
        }


    }
}
