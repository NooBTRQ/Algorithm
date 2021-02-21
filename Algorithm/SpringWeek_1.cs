using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{

    public static class SpringWeek_1
    {
        /// <summary>
        /// 978. 最长湍流子数组
        /// 当 A 的子数组 A[i], A[i+1], ..., A[j] 满足下列条件时，我们称其为湍流子数组：
        ///   若 i <= k<j，当 k 为奇数时， A[k]> A[k + 1]，且当 k 为偶数时，A[k] < A[k + 1]；
        ///   或 若 i <= k<j，当 k 为偶数时，A[k]> A[k + 1] ，且当 k 为奇数时， A[k] < A[k + 1]。
        /// 也就是说，如果比较符号在子数组中的每个相邻元素对之间翻转，则该子数组是湍流子数组。
        /// 返回 A 的最大湍流子数组的长度。
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int MaxTurbulenceSize(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            if (arr.Length == 1) return 1;
            int result = 0;
            int left = 0;
            int right = 1;
            while (right < arr.Length) {
                if (arr[right] != arr[right - 1]) result = Math.Max(result, 2);
                if (arr[right] == arr[right - 1]) 
                { 
                    result = Math.Max(result, 1);
                    left++;
                    right++;
                    continue;
                }
                if (right - 2 >= 0 && arr[right] > arr[right - 1] && arr[right - 1] < arr[right - 2]) right++;
                else if (right - 2 >= 0 && arr[right] < arr[right - 1] && arr[right - 1] > arr[right - 2]) right++;
                else{
                    left = right - 1;
                    right++;
                    continue;
                }
                result = Math.Max(result, right - left);
            }

            return result;
        }

        /// <summary>
        /// 剑指 Offer 10- I. 斐波那契数列
        /// 写一个函数，输入 n ，求斐波那契（Fibonacci）数列的第 n 项（即 F(N)）。斐波那契数列的定义如下：
        /// F(0) = 0,   F(1) = 1
        /// F(N) = F(N - 1) + F(N - 2), 其中 N > 1.
        /// 斐波那契数列由 0 和 1 开始，之后的斐波那契数就是由之前的两数相加而得出。
        /// 答案需要取模 1e9+7（1000000007），如计算初始结果为：1000000008，请返回 1。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int n_2 = 0;
            int n_1 = 1;           
            int result = 0;
            while (n > 1) {

                result = (n_1 + n_2)% 1000000007;
                n_2 = n_1;
                n_1 = result;
                n--;
            }

            return result;
        }

        /// <summary>
        /// 剑指 Offer 10- II. 青蛙跳台阶问题
        /// 一只青蛙一次可以跳上1级台阶，也可以跳上2级台阶。求该青蛙跳上一个 n 级的台阶总共有多少种跳法。
        /// 答案需要取模 1e9+7（1000000007），如计算初始结果为：1000000008，请返回 1。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NumWays(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            if (n == 2) return 2;
            int a = 1;
            int b = 2;
            for (int i = 3; i <= n; i++) {

                int sum = (a + b) % 1000000007;
                a = b;
                b = sum;
            }

            return b;
        }

        /// <summary>
        /// 992. K 个不同整数的子数组
        /// 给定一个正整数数组 A，如果 A 的某个子数组中不同整数的个数恰好为 K，则称 A 的这个连续、不一定独立的子数组为好子数组。
        /// （例如，[1,2,3,1,2] 中有 3 个不同的整数：1，2，以及 3。）
        /// 返回 A 中好子数组的数目。
        /// </summary>
        /// <param name="A"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int SubarraysWithKDistinct(int[] A, int K)
        {
            if (A == null || A.Length == 0) return 0;

            return MostKDistinct(A, K) - MostKDistinct(A, K - 1);
        }

        /// <summary>
        /// 剑指 Offer 11. 旋转数组的最小数字
        /// 把一个数组最开始的若干个元素搬到数组的末尾，我们称之为数组的旋转。输入一个递增排序的数组的一个旋转，输出旋转数组的最小元素。例如，数组 [3,4,5,1,2] 为 [1,2,3,4,5] 的一个旋转，该数组的最小值为1。  
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int MinArray(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;
            int left = 0;
            int right = numbers.Length - 1;

            while (left < right) {

                int mid = (left + right) >> 1;
                if (numbers[mid] > numbers[right]) left = mid + 1;
                else if (numbers[mid] < numbers[right]) right = mid;
                else right--;
            }

            return numbers[left];
        }

        /// <summary>
        /// 154. 寻找旋转排序数组中的最小值 II
        /// 假设按照升序排序的数组在预先未知的某个点上进行了旋转。
        /// (例如，数组[0, 1, 2, 4, 5, 6, 7] 可能变为[4, 5, 6, 7, 0, 1, 2] )。
        /// 请找出其中最小的元素。
        /// 注意数组中可能存在重复的元素。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {

                int mid = (left + right) >> 1;
                if (nums[mid] > nums[right]) left = mid + 1;
                else if (nums[mid] < nums[right]) right = mid;
                else right--;
            }

            return nums[left];
        }

        /// <summary>
        /// 567. 字符串的排列
        /// 给定两个字符串 s1 和 s2，写一个函数来判断 s2 是否包含 s1 的排列。
        /// 换句话说，第一个字符串的排列之一是第二个字符串的子串。
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length == 0 || s2.Length == 0) return false;

            var s1CharDic = new Dictionary<int, int>();
            for (int i = 0; i < s1.Length; i++)
            {

                if (s1CharDic.ContainsKey(s1[i])) s1CharDic[s1[i]]++;
                else s1CharDic.Add(s1[i], 1);
            }
            int left = 0;
            int right = s1.Length - 1;
            var s1CharDicDup = new Dictionary<int, int>(s1CharDic);

            while (right < s2.Length)
            {

                if (s1CharDicDup.Count == 0) return true;
                if (s1CharDicDup.ContainsKey(s2[right]))
                {

                    if (s1CharDicDup[s2[right]] == 1) s1CharDicDup.Remove(s2[right]);
                    else s1CharDicDup[s2[right]]--;
                    right++;
                }
                else
                {
                    right++;
                    s1CharDicDup = new Dictionary<int, int>(s1CharDic);
                }
            }

            return false;

            //char[] pattern = s1.ToCharArray();
            //char[] text = s2.ToCharArray();

            //int pLen = s1.Length;
            //int tLen = s2.Length;

            //int[] pFreq = new int[26];
            //int[] winFreq = new int[26];

            //for (int i = 0; i < pLen; i++)
            //{
            //    pFreq[pattern[i] - 'a']++;
            //}

            //int pCount = 0;
            //for (int i = 0; i < 26; i++)
            //{
            //    if (pFreq[i] > 0)
            //    {
            //        pCount++;
            //    }
            //}

            //int left = 0;
            //int right = 0;
            //// 当滑动窗口中的某个字符个数与 s1 中对应相等的时候才计数
            //int winCount = 0;
            //while (right < tLen)
            //{
            //    if (pFreq[text[right] - 'a'] > 0)
            //    {
            //        winFreq[text[right] - 'a']++;
            //        if (winFreq[text[right] - 'a'] == pFreq[text[right] - 'a'])
            //        {
            //            winCount++;
            //        }
            //    }
            //    right++;

            //    while (pCount == winCount)
            //    {
            //        if (right - left == pLen)
            //        {
            //            return true;
            //        }
            //        if (pFreq[text[left] - 'a'] > 0)
            //        {
            //            winFreq[text[left] - 'a']--;
            //            if (winFreq[text[left] - 'a'] < pFreq[text[left] - 'a'])
            //            {
            //                winCount--;
            //            }
            //        }
            //        left++;
            //    }
            //}
            //return false;
        }

        /// <summary>
        ///  485. 最大连续1的个数
        ///  给定一个二进制数组， 计算其中最大连续1的个数。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int left = 0;
            int right = 0;
            int result = 0;
            while (right < nums.Length) {

                if (nums[right] == 1)
                {

                    result = Math.Max(result,right - left + 1);
                    right++;
                }
                else {

                    left = ++right;
                }
            }

            return result;
        }

        /// <summary>
        /// 561. 数组拆分 I
        /// 给定长度为 2n 的整数数组 nums ，你的任务是将这些数分成 n 对, 
        /// 例如 (a1, b1), (a2, b2), ..., (an, bn) ，使得从 1 到 n 的 min(ai, bi) 总和最大。
        /// 返回该 最大总和 。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ArrayPairSum(int[] nums)
        {
            if (nums == null) return 0;
            var numsList = new List<int>(nums);
            numsList.Sort((x, y) => { if (x < y) return -1;
                else if (x == y) return 0;
                else return 1;
            });
            int result = 0;
            for (int i = 0; i < nums.Length; i = i + 2) {

                result += numsList[i];
            }

            return result;
        }

        /// <summary>
        /// 566. 重塑矩阵
        /// 在MATLAB中，有一个非常有用的函数 reshape，它可以将一个矩阵重塑为另一个大小不同的新矩阵，但保留其原始数据。
        /// 给出一个由二维数组表示的矩阵，以及两个正整数r和c，分别表示想要的重构的矩阵的行数和列数。
        /// 重构后的矩阵需要将原始矩阵的所有元素以相同的行遍历顺序填充。
        /// 如果具有给定参数的reshape操作是可行且合理的，则输出新的重塑矩阵；否则，输出原始矩阵。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int[][] MatrixReshape(int[][] nums, int r, int c)
        {
            if (nums == null || nums.Length == 0 || nums[0].Length == 0) return nums;
            if (nums.Length * nums[0].Length != r * c) return nums;

            var result = new int[r][];
            for (int i = 0; i < r; i++) {

                result[i] = new int[c];
            }

            int count = 0;
            while (count < r * c) {

                result[count / c][count % c] = nums[count / nums[0].Length][count % nums[0].Length];
                count++;
            }

            return result;

        }

        /// <summary>
        /// 995. K 连续位的最小翻转次数
        /// </summary>
        /// <param name="A"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int MinKBitFlips(int[] A, int K)
        {
            int n = A.Length;
            int ans = 0, revCnt = 0;
            for (int i = 0; i < n; ++i)
            {
                if (i >= K && A[i - K] > 1)
                {
                    revCnt ^= 1;
                    A[i - K] -= 2; // 复原数组元素，若允许修改数组 A，则可以省略
                }
                if (A[i] == revCnt)
                {
                    if (i + K > n)
                    {
                        return -1;
                    }
                    ++ans;
                    revCnt ^= 1;
                    A[i] += 2;
                }
            }
            return ans;
        }

        public static int MovingCount(int m, int n, int k)
        {
            if (m == 0 || n == 0) return 0;
            int result = 1;
            var matrix = new bool[m,n];
            matrix[0, 0] = true;
            for (int i = 0; i < m; i++) {

                for (int j = 0; j < n; j++) {

                    if (i / 10 + i % 10 + j / 10 + j % 10 > k) {

                        matrix[i, j] = false;
                        continue;
                    }

                    if (i - 1 >= 0 && matrix[i - 1, j] == true) { 
                        matrix[i, j] = true;
                        result++;
                    }else if (j - 1 >= 0 && matrix[i, j - 1] == true) { 
                        matrix[i, j] = true;
                        result++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 1004. 最大连续1的个数 III
        /// 给定一个由若干 0 和 1 组成的数组 A，我们最多可以将 K 个值从 0 变成 1 。
        /// 返回仅包含 1 的最长（连续）子数组的长度。
        /// </summary>
        /// <param name="A"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int LongestOnes(int[] A, int K)
        {
            if (A == null || A.Length == 0) return 0;
            int res = 0;
            int left = 0;
            int right = 0;
            while (right < A.Length) {

                if (right < left) { 
                    right++;
                    continue;
                }
                if (A[right] == 1) right++;
                else if (A[right] == 0 && K > 0)
                {

                    right++;
                    K--;
                }
                else {

                    res = Math.Max(res, right - left);
                    if (A[left] == 0 && left != right)
                    {
                        left++;
                        K++;
                    }
                    else {

                        left++;
                    }
                }
            }
            res = Math.Max(res, right - left);
            return res;
        }

        /// <summary>
        /// 剪绳子
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CuttingRope(int n)
        {
            int ans = 1;
            if (n < 4) return n - 1; // n <  4时, 两数之和大于两数之积
            while (n > 4)
            {  // n=4时,3*1<3+1,但当n=5时,3*2>3+2
                n -= 3;
                ans *= 3;
            }
            return ans * n;  //最后返回的时候记得乘上最后剩下的n
        }

        /// <summary>
        /// 697. 数组的度
        /// 给定一个非空且只包含非负数的整数数组 nums，数组的度的定义是指数组里任一元素出现频数的最大值。
        /// 你的任务是在 nums 中找到与 nums 拥有相同大小的度的最短连续子数组，返回其长度。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindShortestSubArray(int[] nums)
        {
            var degreeDic = new Dictionary<int, int[]>();
            for (int i = 0; i < nums.Length; i++) {

                if (degreeDic.ContainsKey(nums[i]))
                {

                    degreeDic[nums[i]][0]++;
                    degreeDic[nums[i]][2] = i;
                }
                else {

                    degreeDic.Add(nums[i], new int[] { 1,i,i});
                }
            }

            int maxNum = 0;
            int minLen = 0;
            foreach (var kv in degreeDic) {

                if (kv.Value[0] > maxNum)
                {

                    minLen = kv.Value[2] - kv.Value[1] + 1;
                    maxNum = kv.Value[0];
                }
                else if (kv.Value[0] == maxNum) {

                    minLen = Math.Min(minLen, kv.Value[2] - kv.Value[1] + 1);
                }
            }

            return minLen;
        }

        /// <summary>
        /// 5668. 最长的美好子字符串
        /// 当一个字符串 s 包含的每一种字母的大写和小写形式 同时 出现在 s 中，就称这个字符串 s 是 美好 字符串。
        /// 比方说，"abABB" 是美好字符串，因为 'A' 和 'a' 同时出现了，且 'B' 和 'b' 也同时出现了。
        /// 然而，"abA" 不是美好字符串因为 'b' 出现了，而 'B' 没有出现。
        /// 给你一个字符串 s ，请你返回 s 最长的 美好子字符串 。如果有多个答案，请你返回 最早 出现的一个。
        /// 如果不存在美好子字符串，请你返回一个空字符串。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestNiceSubstring(string s)
        {
            if (s == null || s.Length == 0 || s.Length == 1) return "";

            var upperChar = new HashSet<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            var lowerChar = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            return "";
        }

        public static bool CanChoose(int[][] groups, int[] nums)
        {
            int index = 0;
            for (int i = 0; i < groups.Length; i++) {

                int groupIndex = 0;
                int tempIndex = index;
                while (tempIndex < nums.Length) {
                    if (nums[tempIndex] == groups[i][groupIndex])
                    {

                        tempIndex++;
                        groupIndex++;
                    }
                    else {

                        groupIndex = 0;
                        tempIndex = ++index;
                    }

                    if (groupIndex == groups[i].Length && i == groups.Length - 1) return true;
                    if (groupIndex == groups[i].Length) {

                        index = tempIndex;
                        break;
                    }
                }
            }

            return false;
        }

        public static string MergeAlternately(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1)) return word2;
            if (string.IsNullOrEmpty(word2)) return word1;
            int index = 0;
            var res = new StringBuilder();
            while (index < word1.Length || index < word2.Length) {

                if (index >= word1.Length)
                {

                    res.Append(word2[index]);
                    index++;
                }
                else if (index >= word2.Length)
                {

                    res.Append(word1[index]);
                    index++;
                }
                else {

                    res.Append(word1[index]);
                    res.Append(word2[index]);
                    index++;
                }
            }
            return res.ToString();
        }

        public static int[] MinOperations(string boxes)
        {
            return null;
        }

        public static int MaximumScore(int[] nums, int[] multipliers)
        {
            var dp = new int[nums.Length][];
            for (int i = 0; i < nums.Length; i++) {

                dp[i] = new int[nums.Length];
            }
            return MaximumScoreDFS(nums, multipliers, 0, 0, nums.Length - 1,0);
        }

        public static int MaximumScoreDFS(int[] nums, int[] multipliers,int index, int left, int right,int res) {

            if (index == multipliers.Length) return res;
            var result1 = MaximumScoreDFS(nums, multipliers, index + 1, left + 1, right, res + multipliers[index] * nums[left]);
            var result2 = MaximumScoreDFS(nums, multipliers, index + 1, left, right - 1, res + multipliers[index] * nums[right]);
            return Math.Max(result1,result2);
        }

        /// <summary>
        /// 1438. 绝对差不超过限制的最长连续子数组
        /// 给你一个整数数组 nums ，和一个表示限制的整数 limit，请你返回最长连续子数组的长度，该子数组中的任意两个元素之间的绝对差必须小于或者等于 limit 。
        /// 如果不存在满足条件的子数组，则返回 0 。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static int LongestSubarray(int[] nums, int limit)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;
            int left = 0;
            int right = 1;
            int maxNum = nums[0];
            int minNum = nums[0];
            int res = 1;
            var numIndexDic = new Dictionary<int, List<int>>();
            numIndexDic.Add(nums[0], new List<int>() { 0});
            while (right < nums.Length) {

                if (numIndexDic.ContainsKey(nums[right])) numIndexDic[nums[right]].Add(right);
                else numIndexDic.Add(nums[right], new List<int> { right });

                maxNum = Math.Max(maxNum, nums[right]);
                minNum = Math.Min(minNum, nums[right]);

                if(maxNum - minNum > limit) {                   
                    if (maxNum == nums[right])
                    {
                        left = numIndexDic[minNum][numIndexDic[minNum].Count - 1] + 1;
                        right = left;
                        minNum = nums[left];
                        maxNum = nums[right];
                        numIndexDic.Clear();
                        continue;
                    }
                    else {

                        left = numIndexDic[maxNum][numIndexDic[maxNum].Count - 1] + 1;
                        right = left;
                        minNum = nums[left];
                        maxNum = nums[right];
                        numIndexDic.Clear();
                        continue;
                    }
                }
                right++;
                res = Math.Max(res, right - left);
            }

            return res;
        }

        public static int MostKDistinct(int[] A, int K) {

            int len = A.Length;
            int[] freq = new int[len + 1];

            int left = 0;
            int right = 0;
            // [left, right) 里不同整数的个数
            int count = 0;
            int res = 0;
            // [left, right) 包含不同整数的个数小于等于 K
            while (right < len)
            {
                if (freq[A[right]] == 0)
                {
                    count++;
                }
                freq[A[right]]++;
                right++;

                while (count > K)
                {
                    freq[A[left]]--;
                    if (freq[A[left]] == 0)
                    {
                        count--;
                    }
                    left++;
                }
                // [left, right) 区间的长度就是对结果的贡献
                res += right - left;
            }
            return res;
        }
    }

    /// <summary>
    /// 703. 数据流中的第 K 大元素
    /// 设计一个找到数据流中第 k 大元素的类（class）。注意是排序后的第 k 大元素，不是第 k 个不同的元素。
    /// 请实现 KthLargest 类：
    /// KthLargest(int k, int[] nums) 使用整数 k 和整数流 nums 初始化对象。
    /// int add(int val) 将 val 插入数据流 nums 后，返回当前数据流中第 k 大的元素。
    /// </summary>
    public class KthLargest
    {
        int[] minHeap;
        int count = 1;
        public KthLargest(int k, int[] nums)
        {
            minHeap = new int[k + 1];
            for (int i = 0; i < minHeap.Length; i++) {

                minHeap[i] = int.MinValue;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                heapfy(nums[i]);
            }
        }

        public int Add(int val)
        {

            heapfy(val);
            return minHeap[1];
        }

        private void heapfy(int val)
        {

            if (count < minHeap.Length)
            {

                minHeap[count] = val;
                int index = count;
                while (index > 1)
                {
                    int swapIndex = index;
                    if (minHeap[index] < minHeap[index >> 1]) swapIndex = index / 2;
                    if (swapIndex == index) break;
                    int temp = minHeap[index];
                    minHeap[index] = minHeap[index / 2];
                    minHeap[index / 2] = temp;
                    index = index / 2;
                }
                count++;
            }
            else if (minHeap[1] < val)
            {

                minHeap[1] = val;
                int index = 1;
                while (index < minHeap.Length)
                {
                    int swapIndex = index;
                    if (index * 2 < minHeap.Length && minHeap[index] > minHeap[index * 2]) swapIndex = index * 2;
                    if (index * 2 + 1 < minHeap.Length && minHeap[swapIndex] > minHeap[index * 2 + 1]) swapIndex = index * 2 + 1;
                    if (index == swapIndex) break;
                    int temp = minHeap[index];
                    minHeap[index] = minHeap[swapIndex];
                    minHeap[swapIndex] = temp;
                    index = swapIndex;
                }
            }
        }
    }
}
