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
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
