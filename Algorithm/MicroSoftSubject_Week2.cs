using System;
using System.Collections.Generic;
using System.Globalization;
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
            return string.Join(" ",s.Trim().Split(' ').Where(e => !string.IsNullOrEmpty(e)).Reverse());
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
            var alreadyPass = new int[matrix.Length,matrix[0].Length];
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
            for (int i = 0; i < s.Length;i++) {
                if (i != 0) {

                    charSet.Remove(s[i-1]);
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
    }
}
