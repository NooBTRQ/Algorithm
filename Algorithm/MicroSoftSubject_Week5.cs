using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week5
    {
        /// <summary>
        /// 46. 全排列
        /// 给定一个 没有重复 数字的序列，返回其所有可能的全排列。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length == 0) return result;
            PermuteDfs(nums, new List<int>(),result,new HashSet<int>());

            return result;
        }

        /// <summary>
        /// 445. 两数相加 II
        /// 给你两个 非空 链表来代表两个非负整数。数字最高位位于链表开始位置。它们的每个节点只存储一位数字。将这两数相加会返回一个新的链表。
        /// 你可以假设除了数字 0 之外，这两个数字都不会以零开头。
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null) return null;
            var l1Stack = new Stack<int>();
            var l2Stack = new Stack<int>();
            while (l1 != null || l2 != null) {

                if (l1 != null) 
                { 
                    l1Stack.Push(l1.val);
                    l1 = l1.next;
                }
                if (l2 != null) 
                {
                    l2Stack.Push(l2.val);
                    l2 = l2.next;
                }                
            }

            ListNode result = null;
            int carryNum = 0;
            while (l1Stack.Count != 0 || l2Stack.Count != 0) {               
                int num1 = 0;
                int num2 = 0;
                if (l1Stack.Count > 0) {

                    num1 = l1Stack.Pop();
                }

                if (l2Stack.Count > 0) {

                    num2 = l2Stack.Pop();
                }

                var newNode = new ListNode((num1+num2 + carryNum)%10);
                carryNum = (num1 + num2 + carryNum) / 10;
                newNode.next = result;
                result = newNode;
            }

            if (carryNum > 0) {

                var newNode = new ListNode(carryNum);
                newNode.next = result;
                result = newNode;
            }

            return result;
        }

        /// <summary>
        /// 24. 两两交换链表中的节点
        /// 给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。
        /// 你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            ListNode tempNode = dummyHead;
            ListNode perPoint = null;
            ListNode nextPoint = null;
            while (tempNode.next != null && tempNode.next.next != null) {

                perPoint = tempNode.next;
                nextPoint = tempNode.next.next;

                tempNode.next = nextPoint;
                perPoint.next = nextPoint.next;
                nextPoint.next = perPoint;
                tempNode = perPoint;
            }
            return dummyHead.next;
        }

        /// <summary>
        /// 49. 字母异位词分组
        /// 给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。
        /// 所有输入均为小写字母。
        /// 不考虑答案输出的顺序。
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs.Length == 0) return new List<IList<string>>();
            if (strs.Length == 1) return new List<IList<string>>() { new List<string>() { strs[0] } };
            Dictionary<string, List<string>> dicRes = new Dictionary<string, List<string>>();
            //排序每个字符串的字母

            //foreach (string s in strs) {

            //    var charArr = s.ToCharArray();
            //    Array.Sort(charArr);
            //    var newStr = string.Join("", charArr);
            //    if (dicRes.ContainsKey(newStr))
            //    {

            //        dicRes[newStr].Add(s);
            //    }
            //    else {

            //        var res = new List<string>() { s};
            //        dicRes.Add(newStr, res);
            //    }
            //}

            //var result = new List<IList<string>>(dicRes.Values);

            //return result;

            //计数字母出现次数
            foreach (string s in strs) {

                int[] charCount = new int[26];
                for (int i = 0; i < s.Length; i++) {

                    charCount[s[i] - 'a']++;
                }
                var countStr = string.Join("#", charCount);
                if (dicRes.ContainsKey(countStr))
                {

                    dicRes[countStr].Add(s);
                }
                else {

                    var res = new List<string>() { s};
                    dicRes.Add(countStr, res);
                }
            }
            var result = new List<IList<string>>(dicRes.Values);
            return result;
        }

        private static void PermuteDfs(int[] nums,List<int> path,List<IList<int>> result,HashSet<int> used) {

            if (used.Count == nums.Length) {

                result.Add(new List<int>(path));
            }

            for (int i = 0; i < nums.Length; i++) {

                if (used.Contains(i)) continue;
                path.Add(nums[i]);
                used.Add(i);
                PermuteDfs(nums, path, result, used);
                path.Remove(nums[i]);
                used.Remove(i);
            }
        }
    }
}
