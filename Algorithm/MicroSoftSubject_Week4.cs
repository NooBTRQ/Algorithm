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

        /// <summary>
        /// 62. Unique Paths
        /// A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        /// The robot can only move either down or right at any point in time.
        /// The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
        /// How many possible unique paths are there?
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 64. Minimum Path Sum
        /// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, 
        /// which minimizes the sum of all numbers along its path.
        /// Note: You can only move either down or right at any point in time.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int MinPathSum(int[][] grid)
        {
            int[] progress = new int[grid[0].Length];
            for (int i = 0; i < grid.Length; i++) {

                for (int j = 0; j < grid[0].Length; j++) {

                    if (i == 0 && j == 0) { progress[j] = grid[i][j];continue; }
                    if (i == 0) { progress[j] = progress[j - 1] + grid[i][j];continue; }
                    if (j == 0) { progress[j] = progress[j] + grid[i][j]; continue; }
                    progress[j] = Math.Min(progress[j-1] + grid[i][j], progress[j] + grid[i][j]);
                }
            }

            return progress[grid[0].Length - 1];
        }

        /// <summary>
        /// 516. Longest Palindromic Subsequence
        /// Given a string s, find the longest palindromic subsequence's length in s. You may assume that the maximum length of s is 1000.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LongestPalindromeSubseq(string s)
        {
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;
            int[,] tempResult = new int[s.Length,s.Length];

            for (int i = s.Length-1; i >= 0; i--) {

                for (int j = i ; j < s.Length; j++) {

                    if (i == j) { tempResult[i, j] = 1; continue; }
                    if (s[i] == s[j]) tempResult[i, j] = tempResult[i + 1, j - 1] + 2;
                    if (s[i] != s[j]) tempResult[i, j] = Math.Max(tempResult[i, j - 1], tempResult[i + 1, j]);
                }
            }
            return tempResult[0, s.Length - 1];
        }

        /// <summary>
        /// 647. Palindromic Substrings
        /// Given a string, your task is to count how many palindromic substrings in this string.
        /// The substrings with different start indexes or end indexes are counted as different substrings even they consist of same characters.\
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int CountSubstrings(string s)
        {
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;
            //回文中心拓展
            int ans = 0;
            for (int i = 0; i < 2 * s.Length - 1; i++) {

                int l = i / 2;
                int r = i / 2 + i % 2;
                while (l >= 0 && r < s.Length && s[l] == s[r]) {

                    ans++;
                    l--;
                    r++;
                }
            }
            return ans;
        }

        /// <summary>
        /// 5602. 将 x 减到 0 的最小操作数
        /// 给你一个整数数组 nums 和一个整数 x 。每一次操作时，你应当移除数组 nums 最左边或最右边的元素，然后从 x 中减去该元素的值。请注意，需要 修改 数组以供接下来的操作使用。
        /// 如果可以将 x 恰好 减到 0 ，返回 最小操作数 ；否则，返回 -1 。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int MinOperations(int[] nums, int x)
        {
            if (nums.Length == 0) return -1;
            if (nums.Length == 1 && nums[0] != x) return -1;
            if (nums.Length == 1 && nums[0] == x) return 1;

            return MinOperationsDFS(nums, 0, nums.Length - 1, 0, x, 0);
            
        }

        public static int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;
            var tempResult = new int[matrix[0].Length, matrix.Length];
            int maxLenght = 0;
            for (int j = 0; j < matrix.Length; j++) {

                for (int i = 0; i < matrix[0].Length; i++) {
                    if ((i == 0 || j == 0) && matrix[j][i] == '1') { tempResult[i, j] = 1; maxLenght = Math.Max(maxLenght,1); continue; }
                    if (matrix[j][i] == '1') 
                    { 
                        tempResult[i, j] = Math.Min(Math.Min(tempResult[i - 1, j - 1], tempResult[i - 1, j]), tempResult[i, j - 1]) + 1;
                        maxLenght = Math.Max(maxLenght, tempResult[i, j]);
                    }
                        
                }
            }

            return maxLenght * maxLenght;
        }

        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid.Length == 0) return 0;
            var dp = new int[obstacleGrid[0].Length];
            for (int i = 0; i < obstacleGrid.Length; i++) {

                for (int j = 0; j < obstacleGrid[0].Length; j++) {
                    if (i == 0 && j == 0) {

                        if (obstacleGrid[0][0] == 0)
                        {
                            dp[0] = 1;
                        }
                        else
                        {

                            dp[0] = 0;
                        }
                    }
                    else if (i == 0)
                    {
                        if (obstacleGrid[i][j] == 0 && dp[j-1] != 0)
                        {
                            dp[j] = 1;
                        }
                        else
                        {

                            dp[j] = 0;
                        }
                    } else if (j == 0) {

                        if (obstacleGrid[i][j] == 0 && dp[j] != 0)
                        {
                            dp[j] = 1;
                        }
                        else
                        {

                            dp[j] = 0;
                        }
                    }
                    else {

                        if (obstacleGrid[i][j] == 0)
                        {
                            dp[j] = dp[j - 1] + dp[j];
                        }
                        else
                        {

                            dp[j] = 0;
                        }
                    }
                }
            }

            return dp[obstacleGrid[0].Length - 1];
        }

        public static int MinOperationsDFS(int[] nums, int left, int right,int currentSum,int x,int count) {

            var minCount = -1;
            if (left > right) return -1;
            if (currentSum + nums[left] == x || currentSum + nums[right] == x) return count + 1;
            if (currentSum + nums[left] > x && currentSum + nums[right] > x) return -1;
            if (currentSum + nums[left] < x && left < nums.Length) {
                var tempCount1 = MinOperationsDFS(nums, left + 1, right, currentSum + nums[left], x, count+1);
                minCount = tempCount1;
            }
            if (currentSum + nums[right] < x && right > 0) {
                var tempCount2 = MinOperationsDFS(nums, left, right - 1, currentSum + nums[right], x, count+1);
                if (tempCount2 != -1 && minCount != -1) minCount = Math.Min(tempCount2, minCount);
                if (tempCount2 == -1 || minCount == -1) minCount = Math.Max(tempCount2, minCount);
            }
            return minCount;
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
