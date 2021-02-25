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

        /// <summary>
        /// 832. 翻转图像
        /// 给定一个二进制矩阵 A，我们想先水平翻转图像，然后反转图像并返回结果。
        /// 水平翻转图片就是将图片的每一行都进行翻转，即逆序。例如，水平翻转[1, 1, 0] 的结果是[0, 1, 1]。
        /// 反转图片的意思是图片中的 0 全部被 1 替换， 1 全部被 0 替换。例如，反转[0, 1, 1] 的结果是[1, 0, 0]。
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A.Length; i++) {

                int left = 0;
                int right = A[i].Length - 1;
                while (left <= right) {

                    var leftNum = A[i][left];
                    A[i][left] = A[i][right] ^ 1;
                    A[i][right] = leftNum ^ 1;
                    left++;
                    right--;
                }
            }

            return A;
        }

        /// <summary>
        /// 剑指 Offer 16. 数值的整数次方
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double MyPow(double x, int n)
        {
            //快速幂
            if (x == 0) return 0;
            long b = n;
            double res = 1.0;
            if (b < 0)
            {
                x = 1 / x;
                b = -b;
            }
            while (b > 0)
            {
                if ((b & 1) == 1) res *= x;
                x *= x;
                b >>= 1;
            }
            return res;
        }

        /// <summary>
        /// 剑指 Offer 26. 树的子结构
        /// 输入两棵二叉树A和B，判断B是不是A的子结构。(约定空树不是任意一个树的子结构)
        /// B是A的子结构， 即 A中有出现和B相同的结构和节点值。
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool IsSubStructure(TreeNode A, TreeNode B)
        {
            if (A == null && B == null) return true;
            if (B == null) return false;
            if (A == null) return false;
            return IsSubStructureDFS(A, B, B);
        }

        public static bool IsSubStructureDFS(TreeNode A, TreeNode B,TreeNode originB) {

            if (A == null && B == null) return true;
            if (B == null) return true ;
            if (A == null) return false;

            if (A.val == B.val)
            {
                var res1 = IsSubStructureDFS(A.left, B.left, originB);
                var res2 = IsSubStructureDFS(A.right, B.right, originB);
                var res3 = IsSubStructureDFS(A.left, originB, originB);
                var res4 = IsSubStructureDFS(A.right, originB, originB);
                return (res1 && res2) || res3 || res4;
            }
            else {

                return IsSubStructureDFS(A.left, originB, originB) || IsSubStructureDFS(A.right, originB, originB);
            }
        }

        /// <summary>
        /// 867. 转置矩阵
        /// 给你一个二维整数数组 matrix， 返回 matrix 的 转置矩阵 。
        /// 矩阵的 转置 是指将矩阵的主对角线翻转，交换矩阵的行索引与列索引。
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[][] Transpose(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int[][] transposed = new int[n][];
            for (int i = 0; i < m; i++)
            {
                transposed[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    transposed[j][i] = matrix[i][j];
                }
            }
            return transposed;
        }
    }

    /// <summary>
    /// 剑指 Offer 41. 数据流中的中位数
    /// 如何得到一个数据流中的中位数？如果从数据流中读出奇数个数值，那么中位数就是所有数值排序之后位于中间的数值。
    /// 如果从数据流中读出偶数个数值，那么中位数就是所有数值排序之后中间两个数的平均值。
    /// 例如，
    /// [2,3,4] 的中位数是 3
    /// [2,3] 的中位数是(2 + 3) / 2 = 2.5
    /// 设计一个支持以下两种操作的数据结构：
    /// void addNum(int num) - 从数据流中添加一个整数到数据结构中。
    /// double findMedian() - 返回目前所有元素的中位数。
    /// </summary>
    public class MedianFinder
    {
        private List<int> minHeap;
        private List<int> maxHeap;
        /** initialize your data structure here. */
        public MedianFinder()
        {
            minHeap = new List<int>() { 0};
            maxHeap = new List<int>() { 0};
        }

        public void AddNum(int num)
        {
            if (minHeap.Count == 1 || num >= minHeap[1])
            {

                minHeap.Add(num);
                minHeapfyDownToUp(minHeap);
            }
            else {

                maxHeap.Add(num);
                maxHeapfyDownToUp(maxHeap);
            }

            if (minHeap.Count == maxHeap.Count) return;
            else if (minHeap.Count > maxHeap.Count + 1)
            {

                maxHeap.Add(minHeap[1]);
                maxHeapfyDownToUp(maxHeap);

                minHeap[1] = minHeap[minHeap.Count - 1];
                minHeap.RemoveAt(minHeap.Count - 1);
                minHeapfyUpToDown(minHeap);

            }
            else if (minHeap.Count + 1 < maxHeap.Count) {
                minHeap.Add(maxHeap[1]);
                minHeapfyDownToUp(minHeap);

                maxHeap[1] = maxHeap[maxHeap.Count - 1];
                maxHeap.RemoveAt(maxHeap.Count - 1);
                maxHeapfyUpToDown(maxHeap);
            }
        }

        public double FindMedian()
        {
            if (minHeap.Count == maxHeap.Count) return (minHeap[1] + maxHeap[1]) / 2.0;
            else if (minHeap.Count > maxHeap.Count) return minHeap[1];
            else return maxHeap[1];
        }

        private void minHeapfyDownToUp(List<int> heap) {

            int index = heap.Count - 1;
            int swapIndex = index;
            while (index > 1) {

                if (heap[index] < heap[index >> 1]) {

                    swapIndex = index >> 1;
                }
                if (index == swapIndex) break;
                int temp = heap[index];
                heap[index] = heap[swapIndex];
                heap[swapIndex] = temp;
                index = swapIndex;
            }
        }

        private void maxHeapfyDownToUp(List<int> heap)
        {

            int index = heap.Count - 1;
            int swapIndex = index;
            while (index > 1)
            {

                if (heap[index] > heap[index >> 1])
                {

                    swapIndex = index >> 1;
                }
                if (index == swapIndex) break;
                int temp = heap[index];
                heap[index] = heap[swapIndex];
                heap[swapIndex] = temp;
                index = swapIndex;
            }
        }

        private void minHeapfyUpToDown(List<int> heap) {

            int index = 1;
            int swapIndex = index;
            while (index < heap.Count) {

                if (index * 2 < heap.Count && heap[index] > heap[index * 2]) swapIndex = index * 2;
                if (index * 2 + 1 < heap.Count && heap[swapIndex] > heap[index * 2 + 1]) swapIndex = index * 2 + 1;
                if (index == swapIndex) break;
                int temp = heap[index];
                heap[index] = heap[swapIndex];
                heap[swapIndex] = temp;
                index = swapIndex;
            }
        }

        private void maxHeapfyUpToDown(List<int> heap)
        {

            int index = 1;
            int swapIndex = index;
            while (index < heap.Count)
            {

                if (index * 2 < heap.Count && heap[index] < heap[index * 2]) swapIndex = index * 2;
                if (index * 2 + 1 < heap.Count && heap[swapIndex] < heap[index * 2 + 1]) swapIndex = index * 2 + 1;
                if (index == swapIndex) break;
                int temp = heap[index];
                heap[index] = heap[swapIndex];
                heap[swapIndex] = temp;
                index = swapIndex;
            }
        }
    }
}
