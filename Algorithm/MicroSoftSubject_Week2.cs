using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week2
    {
        /// <summary>
        /// 151.反转字符串里的单词
        /// 输入: "the sky is blue"
        /// 输出: "blue is sky the"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseWords(string s)
        {
            return string.Join(" ", s.Trim().Split(' ').Where(e => !string.IsNullOrEmpty(e)).Reverse());
        }

        /// <summary>
        /// 54.螺旋矩阵
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            if (matrix == null || matrix.Length == 0) {
                return result;
            }
            int i = 0;
            int j = 0;
            var alreadyPass = new int[matrix.Length, matrix[0].Length];
            return null;
        }

        /// <summary>
        /// 3.无重复字符的最长子串
        /// 给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) {
                return 0;
            }
            if (s.Length == 1) {
                return 1;
            }
            int result = 0;
            //滑动窗口
            var charSet = new HashSet<char>();
            int rIndex = 0;
            for (int i = 0; i < s.Length; i++) {
                if (i != 0) {

                    charSet.Remove(s[i - 1]);
                }
                while (rIndex < s.Length && !charSet.Contains(s[rIndex])) {

                    charSet.Add(s[rIndex]);
                    rIndex++;
                }
                result = Math.Max(result, rIndex - i);
                if (rIndex >= s.Length) {

                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// 8. 字符串转换整数 (atoi)
        /// 请你来实现一个 atoi 函数，使其能将字符串转换成整数。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int MyAtoi(string str)
        {
            ///有限状态机
            var am = new Automaton();
            for (int i = 0; i < str.Length; i++) {
                am.InputChar(str[i]);
            }
            return (int)(am.sign * am.num);
        }

        /// <summary>
        /// 33. 搜索旋转排序数组
        /// 假设按照升序排序的数组在预先未知的某个点上进行了旋转。
        ///(例如，数组[0, 1, 2, 4, 5, 6, 7] 可能变为[4, 5, 6, 7, 0, 1, 2] )。
        ///搜索一个给定的目标值，如果数组中存在这个目标值，则返回它的索引，否则返回 -1 。
        ///你可以假设数组中不存在重复的元素。
        ///你的算法时间复杂度必须是 O(log n) 级别。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) {
                return -1;
            }
            if (nums.Length == 1 && nums[0] != target) {

                return -1;
            }
            if (nums.Length == 1 && nums[0] == target) {
                return 0;
            }

            int l = 0;
            int r = nums.Length - 1;
            int mid = 0;
            while (l <= r) {

                mid = (l + r) / 2;
                if (nums[mid] == target) return mid;
                if (nums[0] <= nums[mid])
                {

                    if (target >= nums[0] && target < nums[mid])
                    {

                        r = mid - 1;
                    }
                    else
                    {

                        l = mid + 1;
                    }
                }
                else {
                    if (target > nums[mid] && target <= nums[nums.Length - 1])
                    {

                        l = mid + 1;
                    }
                    else {

                        r = mid - 1;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 17. 电话号码的字母组合
        /// 给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。
        /// 给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(digits)) {

                return result;
            }
            var numToString = new Dictionary<char, string>() { { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" }, { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }};

            BackTrack(result, numToString, digits, 0, new List<char>());
            return result;
        }

        /// <summary>
        /// 103. 二叉树的锯齿形层次遍历
        /// 给定一个二叉树，返回其节点值的锯齿形层次遍历。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();
            if (root.left == null && root.right == null) return new List<IList<int>>(){ new List<int>(){ root.val}};

            var result = new List<IList<int>>();
            var layerListDic = new Dictionary<int, List<int>>() { { 1,new List<int>() { root.val} },{ 2,new List<int>()} };
            SearchTree(root,2, layerListDic);
            int layer = 1;
            while (true) {

                if (!layerListDic.ContainsKey(layer)) break;

                if (layerListDic[layer].Count > 0) {

                    if (layer % 2 == 1)
                    {
                        result.Add(layerListDic[layer]);
                    }
                    else {
                        layerListDic[layer].Reverse();
                        result.Add(layerListDic[layer]);
                    }
                } 
                layer++;
            }

            return result;
        }

        public static void SearchTree(TreeNode currentNode,int level,Dictionary<int,List<int>> levelListdic)
        {

            if (currentNode == null || (currentNode.left == null && currentNode.right == null))
            {
                return;
            }

            var currentList = levelListdic[level];
            if(!levelListdic.ContainsKey(level +1)) levelListdic.Add(level + 1, new List<int>());

            if (currentNode.left != null) currentList.Add(currentNode.left.val);
            if (currentNode.right != null) currentList.Add(currentNode.right.val);
            SearchTree(currentNode.left, level + 1, levelListdic);
            SearchTree(currentNode.right, level + 1, levelListdic);
        }

        private static void BackTrack(List<string> combinations, Dictionary<char, string> numToString, string digits, int index, List<char> concatenateStr){

            if (index == digits.Length)
            {

                combinations.Add(string.Join("",concatenateStr));
            }
            else {

                var numStr = numToString[digits[index]];
                for (int i = 0; i < numStr.Length; i++) {
                    concatenateStr.Add(numStr[i]);
                    BackTrack(combinations, numToString, digits, index+1, concatenateStr);
                    concatenateStr.RemoveAt(index);
                }
            }
        }
    }

    public class Automaton {

        private string state = "start";
        /// <summary>
        /// 0." "  1.+/-  2.number  3.other
        /// </summary>
        private Dictionary<string,List<string>> stateMap = new Dictionary<string, List<string>>{ 
             {"start",new List<string> { "start","signed","number","end"} },
             {"signed",new List<string>{ "end","end","number","end"} },
             {"number",new List<string>{"end","end","number","end" } },
             {"end",new List<string>{ "end","end","end","end"} } };
        private int ChangeState(char c) {

            if (c == ' ') return 0;
            if (c == '-' || c == '+') return 1;
            int number;
            if (int.TryParse(c.ToString(), out number)) return 2;
            return 3;
        }

        public int sign = 1;
        public long num = 0;
        long minValue = 2147483648;
        public void InputChar(char c) {

            state = stateMap[state][ChangeState(c)];
            if (state == "number")
            {
                num = num * 10 + c - '0';
                
                num = sign == 1 ? Math.Min(num, int.MaxValue) : Math.Min(num, minValue);
                
            }
            else if (state == "signed")
            {
                sign = c == '+' ? 1 : -1;
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
