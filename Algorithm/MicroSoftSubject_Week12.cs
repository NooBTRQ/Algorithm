using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week12
    {
        /// <summary>
        /// 721. 账户合并
        /// 给定一个列表 accounts，每个元素 accounts[i] 是一个字符串列表，其中第一个元素 accounts[i][0] 是 名称 (name)，其余元素是 emails 表示该账户的邮箱地址。
        /// 现在，我们想合并这些账户。如果两个账户都有一些共同的邮箱地址，则两个账户必定属于同一个人。
        /// 请注意，即使两个账户具有相同的名称，它们也可能属于不同的人，因为人们可能具有相同的名称。
        /// 一个人最初可以拥有任意数量的账户，但其所有账户都具有相同的名称。
        /// 合并账户后，按以下格式返回账户：每个账户的第一个元素是名称，其余元素是按字符 ASCII 顺序排列的邮箱地址。
        /// 账户本身可以以任意顺序返回。
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            return null;
        }

        /// <summary>
        /// 实现 pow(x, n) ，即计算 x 的 n 次幂函数。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            if (n == 1) return x;
            if (n == -1) return 1 / x;
            var half = MyPow(x, n / 2);
            var rest = MyPow(x, n % 2);
            return  half * half * rest;
        }

        /// <summary>
        /// 560. 和为K的子数组
        /// 给定一个整数数组和一个整数 k，你需要找到该数组中和为 k 的连续的子数组的个数。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int SubarraySum(int[] nums, int k)
        {
            // 暴力
            if (nums == null || nums.Length == 0) return 0;

            // 前缀和优化
            var perSumDic = new Dictionary<int, int>() { { 0, 1 } };
            int result = 0;
            int perSum = 0;
            for (int i = 0; i < nums.Length; i++) {

                perSum += nums[i];
                int tempPerSum = perSum - k;
                if (perSumDic.ContainsKey(tempPerSum)) {

                    result += perSumDic[tempPerSum];
                }
                if (perSumDic.ContainsKey(perSum)) perSumDic[perSum]++;
                else perSumDic[perSum] = 1;
            }
            return result;

            // 暴力
            //int result = 0;
            //int[] sumArr = new int[nums.Length];
            //for (int len = 1; len <= nums.Length; len++) {

            //    for (int i = 0; i + len <= nums.Length; i++) {
            //        sumArr[i] += nums[i + len - 1];
            //        if (sumArr[i] == k) result++;
            //    }
            //}
            //return result;
        }

        /// <summary>
        /// 61. 旋转链表
        /// 给定一个链表，旋转链表，将链表每个节点向右移动 k 个位置，其中 k 是非负数。
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0) return head;
            var tail = head;
            int count = 1;
            while (tail.next != null) {
                tail = tail.next;
                count++;
            }
            tail.next = head;

            k = k % count;
            k = count - k;
            if (k == 0) return head;

            while (k > 1) {

                head = head.next;
                k--;
            }
            var newHead = head.next;
            head.next = null;

            return newHead;
        }

        /// <summary>
        /// 186. 翻转字符串里的单词 II
        /// 
        /// 给定一个字符串，逐个翻转字符串中的每个单词。
        /// 注意：
        ///   单词的定义是不包含空格的一系列字符
        ///   输入字符串中不会包含前置或尾随的空格
        ///   单词与单词之间永远是以单个空格隔开的
        /// 进阶：使用 O(1) 额外空间复杂度的原地解法。
        /// </summary>
        /// <param name="s"></param>
        public static void ReverseWords(char[] s)
        {
            if (s == null || s.Length == 0) return;

            for (int i = 0; i < s.Length / 2; i++) {

                char temp = s[i];
                s[i] = s[s.Length - i - 1];
                s[s.Length - 1 - i] = temp;
            }

            int head = 0;
            int tail = 0;
            while (tail < s.Length) {

                while (tail < s.Length && s[tail] != ' ') {

                    tail++;
                }

                for (int i = head; i < (tail + head) / 2; i++) {
                    char tempChar = s[i];
                    s[i] = s[tail - 1 - (i - head)];
                    s[tail - 1 - (i - head)] = tempChar;
                }

                head = ++tail;
            }
        }
    }
}
