using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week4
    {
        /// <summary>
        /// 253. Meeting Rooms II
        /// Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), 
        /// find the minimum number of conference rooms required.
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) {

                return 0;
            }
            intervals = intervals.OrderBy(e => e[0]).ToArray();
            var heap = new MinHeap();
            heap.Add(intervals[0][1]);
            
            for (int i = 1; i < intervals.Count(); i++) {
                if (heap.HeapPeak() <= intervals[i][0]) heap.Poll();
                heap.Add(intervals[i][1]);
            }
            return heap.Count;
        }

        /// <summary>
        /// 22. Generate Parentheses
        /// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        /// Input: n = 3
        /// Output: ["((()))","(()())","(())()","()(())","()()()"]
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<string> GenerateParenthesis(int n)
        {
            if (n == 0) return new List<string>() {};

            var result = new List<string>();
            DFSGenerateParenthesis("", n, n, result);
            return result;
        }

        /// <summary>
        /// 56. Merge Intervals
        /// Given a collection of intervals, merge all overlapping intervals.
        /// Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
        /// Output: [[1,6],[8,10],[15,18]]
        /// Explanation: Since intervals[1, 3] and[2, 6] overlaps, merge them into[1, 6].
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 1) return intervals;
            intervals = intervals.OrderBy(e => e[0]).ToArray();
            var result = new List<int[]>();
            result.Add(intervals[0]);
            for (int i = 1; i < intervals.Count(); i++)
            {
                if (intervals[i][0] <= result.Last()[1]) {

                    int newEnd = Math.Max(intervals[i][1], result.Last()[1]);
                    result.Last()[1] = newEnd;
                    continue;
                }
                result.Add(intervals[i]);
            }

            return result.ToArray();
        }

        /// <summary>
        /// 322. Coin Change
        /// You are given coins of different denominations and a total amount of money amount. 
        /// Write a function to compute the fewest number of coins that you need to make up that amount. 
        /// If that amount of money cannot be made up by any combination of the coins, return -1.
        /// You may assume that you have an infinite number of each kind of coin.
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            int[] tempResut = new int[amount + 1];
            for (int i = 1; i < tempResut.Length; i++) tempResut[i] = amount + 1;
            //状态转移方程：dp[amount] = min(1 + dp[amount - coin[i]]) for i in [0, len - 1] if coin[i] <= amount
            for (int i = 1; i <= amount; i++) {

                for (int j = 0; j < coins.Length; j++) {

                    if (i - coins[j] >= 0 && tempResut[i - coins[j]] != amount + 1) {

                        tempResut[i] = Math.Min(tempResut[i], tempResut[i - coins[j]] + 1);
                    }
                }
            }
            if (tempResut[amount] == amount + 1) {

                return -1;
            }
            return tempResut[amount];
        }

        /// <summary>
        /// 139. Word Break
        /// Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
        /// determine if s can be segmented into a space-separated sequence of one or more dictionary words.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public static bool WordBreak(string s, IList<string> wordDict)
        {
            bool[] dp = new bool[s.Length+1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; i++) {

                foreach (string word in wordDict) {

                    if (i - word.Length >= 0 && dp[i - word.Length] && word == s.Substring(i - word.Length, word.Length)) dp[i] = true;
                }
            }

            return dp[s.Length];
        }

        /// <summary>
        /// 300. Longest Increasing Subsequence
        /// Given an unsorted array of integers, find the length of longest increasing subsequence.
        /// Input: [10,9,2,5,3,7,101,18]
        /// Output: 4 
        /// Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 
        /// Note:
        /// There may be more than one LIS combination, it is only necessary for you to return the length.
        /// Your algorithm should run in O(n2) complexity.
        /// Follow up: Could you improve it to O(n log n) time complexity?
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int maxLen = 1;
            for (int i = 1; i < nums.Length; i++) {
                dp[i] = 1;
                for (int j = 0; j < i; j++) {

                    if (nums[i] > nums[j]) {

                        dp[i] = Math.Max(dp[i],dp[j] + 1);
                    }
                }
                maxLen = Math.Max(dp[i], maxLen);
            }
            return maxLen;
        }

        /// <summary>
        /// 152. Maximum Product Subarray
        /// Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaxProduct(int[] nums)
        {
            int maxProduct = nums[0];
            int minProduct = nums[0];
            int tempMax = 0;
            int tempMin = 0;
            int ans = nums[0];
            for (int i = 1; i < nums.Length; i++) {
                tempMax = maxProduct;
                tempMin = minProduct;
                maxProduct = Math.Max(tempMax * nums[i], Math.Max(nums[i] * tempMin, nums[i]));
                minProduct = Math.Min(tempMin * nums[i], Math.Min(nums[i] * tempMax, nums[i]));
                ans = Math.Max(ans, maxProduct);
            }

            return ans;
        }

        /// <summary>
        /// 91. Decode Ways
        /// A message containing letters from A-Z is being encoded to numbers using the following mapping:
        /// 'A' -> 1
        /// 'B' -> 2
        /// ...
        /// 'Z' -> 26
        /// Given a non-empty string containing only digits, determine the total number of ways to decode it.
        /// The answer is guaranteed to fit in a 32-bit integer.
        /// 1 <= s.length <= 100
        /// s contains only digits and may contain leading zero(s).
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int NumDecodings(string s)
        {
            if (s.Length == 0 || s == null || s == "0") return 0;
            int exampleCount = 0;
            for (int i = 0; i < s.Length; i++) {

                if (s[i] == '0') continue;

                if (exampleCount == 0) {

                    exampleCount++;
                    continue;
                }

                if (s[i-1] != '0' && int.Parse(s.Substring(i-1,2)) <= 26 && exampleCount == 1) {

                    exampleCount++;
                    continue;
                } 
                if (s[i - 1] != '0' && int.Parse(s.Substring(i - 1, 2)) <= 26 && exampleCount > 1) {

                    exampleCount = (exampleCount - 1) * 2;
                    exampleCount++;
                }
                
            }
            return exampleCount;
        }

        public static int UniquePaths(int m, int n)
        {
            if (m * n == 1 || m * n == 2) return 1;
            int[,] matrix = new int[m,n];
            //空间复杂度还可优化到2n或者n
            for (int i = 0; i < m; i++){

                for (int j = 0; j < n; j++) {

                    if (i == 0 && j == 0) { matrix[i, j] = 0; continue; };
                    if (i == 0 || j == 0) { matrix[i, j] = 1; continue; };
                    
                    matrix[i,j] = matrix[i - 1,j] + matrix[i,j-1];
                }
            }

            return matrix[m-1,n-1];
        }

        public static int MinPathSum(int[][] grid)
        {
            int[,] progress = new int[grid.Length, grid[0].Length];
            for (int i = 0; i < progress.GetLength(0); i++) {

                for (int j = 0; j < progress.GetLength(1); j++) {

                    if (i == 0 && j == 0) { progress[i, j] = grid[i][j];continue; }
                    if (i == 0) { progress[i, j] = progress[i, j - 1] + grid[i][j];continue; }
                    if (j == 0) { progress[i, j] = progress[i-1, j] + grid[i][j]; continue; }
                    progress[i, j] = Math.Min(progress[i - 1, j] + grid[i][j], progress[i, j - 1] + grid[i][j]);
                }
            }

            return progress[grid.Length - 1, grid[0].Length - 1];
        }

        public static void DFSGenerateParenthesis(string tmpStr,int left,int right,List<string> res) {

            if (left == 0 && right == 0) { 

                res.Add(tmpStr);
            }

            if (left >right) {

                return;
            }

            if (left > 0) {

                DFSGenerateParenthesis(tmpStr + "(", left - 1, right, res);
            }

            if (right > 0) {

                DFSGenerateParenthesis(tmpStr + ")", left, right - 1, res);
            }
        }
    }

    public class MinHeap {

        private List<int> ItemList;
        public int Count { get { return ItemList.Count-1; } }

        public MinHeap() {

            ItemList = new List<int>() { default};
        }

        public int HeapPeak() {

            if(ItemList.Count>1) return ItemList[1];
            throw new IndexOutOfRangeException();
        }
        public void Poll() {

            ItemList.RemoveAt(1);
            ItemList.Insert(1, ItemList.Last());
            ItemList.RemoveAt(ItemList.Count - 1);
            //堆化
            int currentIndex = 1;
            while (currentIndex <= (ItemList.Count-1) / 2) {

                int nextLeft = currentIndex * 2;
                if (nextLeft + 1 <= ItemList.Count - 1 && ItemList[nextLeft] > ItemList[nextLeft + 1]) {

                    nextLeft++;
                }
                if (ItemList[currentIndex] > ItemList[nextLeft]) {

                    int currentValue = ItemList[currentIndex];
                    ItemList[currentIndex] = ItemList[nextLeft];
                    ItemList[nextLeft] = currentValue;
                    currentIndex = nextLeft;
                    continue;
                }
                break;
            }
        }

        public void Add(int item) {

            ItemList.Add(item);
            //堆化
            int currentIndex = ItemList.Count-1;
            while (currentIndex > 1) {

                int next = currentIndex / 2;
                if (ItemList[currentIndex] >= ItemList[next]) break;
                int currentValue = ItemList[currentIndex];
                ItemList[currentIndex] = ItemList[next];
                ItemList[next] = currentValue;
                currentIndex = next;
            }
        }
    }
}
