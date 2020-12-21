using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week6
    {
        /// <summary>
        /// 75. 颜色分类
        /// 给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。
        /// 此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。
        /// 进阶：
        ///    你可以不使用代码库中的排序函数来解决这道题吗？
        ///    你能想出一个仅使用常数空间的一趟扫描算法吗？
        /// </summary>
        /// <param name="nums"></param>
        public static void SortColors(int[] nums)
        {
            int redIndex = 0;
            int blueIndex = nums.Length -1;
            int tempItem = 0;
            for (int i = 0; i <= blueIndex; i++) {

                while (i <= blueIndex && nums[i] == 2) {

                    tempItem = nums[blueIndex];
                    nums[blueIndex] = nums[i];
                    nums[i] = tempItem;
                    blueIndex--;
                }
                if (nums[i] == 0) {

                    tempItem = nums[redIndex];
                    nums[redIndex] = nums[i];
                    nums[i] = tempItem;
                    redIndex++;
                }
            }
        }

        /// <summary>
        /// 238. 除自身以外数组的乘积
        /// 给你一个长度为 n 的整数数组 nums，其中 n > 1，返回输出数组 output ，其中 output[i] 等于 nums 中除 nums[i] 之外其余各元素的乘积。
        /// 提示：题目数据保证数组之中任意元素的全部前缀元素和后缀（甚至是整个数组）的乘积都在 32 位整数范围内。
        /// 说明: 请不要使用除法，且在 O(n) 时间复杂度内完成此题。
        /// 进阶：
        ///   你可以在常数空间复杂度内完成这个题目吗？（ 出于对空间复杂度分析的目的，输出数组不被视为额外空间。）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];

            /// 方法一，构造前缀和后缀乘积数组
            //var LSuffix = new int[nums.Length + 1];
            //var RSuffix = new int[nums.Length + 1];
            //LSuffix[0] = 1;
            //RSuffix[nums.Length] = 1;
            //for (int i = 0; i < nums.Length; i++) {

            //    LSuffix[i + 1] = LSuffix[i] * nums[i];
            //}
            //for (int i = nums.Length - 1; i >= 0; i--) {

            //    RSuffix[i] = RSuffix[i + 1] * nums[i];
            //}
            //for (int i = 0; i < nums.Length; i++) {

            //    result[i] = LSuffix[i] * RSuffix[i + 1];
            //}

            /// 方法二，先构造前缀乘积，再动态构造后缀乘积
            result[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {

                result[i] = result[i - 1] * nums[i - 1];
            }
            int rProduct = 1;
            for (int i = nums.Length - 1; i >= 0; i--) {
                result[i] = result[i] * rProduct;
                rProduct *= nums[i];
            }

            return result;
        }

        /// <summary>
        /// 73. 矩阵置零
        /// </summary>
        /// <param name="matrix"></param>
        public static void SetZeroes(int[][] matrix)
        {
            Boolean isCol = false;
            int R = matrix.Length;
            int C = matrix[0].Length;

            for (int i = 0; i < R; i++)
            {
                if (matrix[i][0] == 0)
                {
                    isCol = true;
                }

                for (int j = 1; j < C; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }
            for (int i = 1; i < R; i++)
            {
                for (int j = 1; j < C; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            if (matrix[0][0] == 0)
            {
                for (int j = 0; j < C; j++)
                {
                    matrix[0][j] = 0;
                }
            }
            if (isCol)
            {
                for (int i = 0; i < R; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }

        /// <summary>
        /// 79. 单词搜索
        /// 给定一个二维网格和一个单词，找出该单词是否存在于网格中。
        /// 单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++) {

                for (int j = 0; j < board[0].Length; j++) {

                    var path = new bool[board[0].Length,board.Length];
                    var result = WordDfs(board, word, 0, path, i, j);
                    if (result)
                    {
                        return result;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 19. 删除链表的倒数第N个节点
        /// 给定一个链表，删除链表的倒数第 n 个节点，并且返回链表的头结点。
        /// 说明：
        ///     给定的 n 保证是有效的。
        /// 进阶：
        ///     你能尝试使用一趟扫描实现吗？
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            // 0 1 2 3 4
            if (head == null) return head;
            if (head.next == null) return null;
            List<ListNode> nodeCollections = new List<ListNode>();
            ListNode currentNode = head;

            while (currentNode != null) {

                nodeCollections.Add(currentNode);
                currentNode = currentNode.next;
            }
            if (n == nodeCollections.Count) {

                return head.next;
            } else if (n == 1)
            {

                nodeCollections[nodeCollections.Count - 2].next = null;
            }
            else {

                nodeCollections[nodeCollections.Count - n - 1].next = nodeCollections[nodeCollections.Count - n + 1];
            }
            return head;
        }

        public static bool WordDfs(char[][] board, string word, int index, bool[,] path, int i,int j) {
            if (board[i][j] != word[index]) return false;
            if (board[i][j] == word[index] && index == word.Length - 1) return true;
            path[j, i] = true;
            bool top = false;
            bool bottom = false;
            bool left = false;
            bool right = false;
            if (i - 1 >= 0 && !path[j,i-1]) top = WordDfs(board, word, index + 1, path, i - 1, j);
            if (i + 1 < board.Length && !path[j, i + 1]) bottom = WordDfs(board, word, index + 1, path, i + 1, j);
            if (j - 1 >= 0 && !path[j - 1, i]) left = WordDfs(board, word, index + 1, path, i, j - 1);
            if (j + 1 < board[0].Length && !path[j + 1, i]) right = WordDfs(board, word, index + 1, path, i, j + 1);

            if (!(top || bottom || left || right)) {

                path[j, i] = false;
            }

            return top || bottom || left || right;
        }
    }
    /// <summary>
    /// 348. 判定井字棋胜负
    /// 请在 n × n 的棋盘上，实现一个判定井字棋（Tic-Tac-Toe）胜负的神器，判断每一次玩家落子后，是否有胜出的玩家。
    /// 在这个井字棋游戏中，会有 2 名玩家，他们将轮流在棋盘上放置自己的棋子。
    /// 在实现这个判定器的过程中，你可以假设以下这些规则一定成立：
    ///   1. 每一步棋都是在棋盘内的，并且只能被放置在一个空的格子里；
    ///   2. 一旦游戏中有一名玩家胜出的话，游戏将不能再继续；
    ///   3. 一个玩家如果在同一行、同一列或者同一斜对角线上都放置了自己的棋子，那么他便获得胜利。
    /// </summary>
    public class TicTacToe
    {
        private int[][] MoveMark;
        private int N;
        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            N = n;
            //[0,n-1] x,[n- 2n-1] y,2n \,2n+1 /
            MoveMark = new int[3][] {new int[1], new int[2 * n + 2], new int[2 * n + 2] };
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            if (N == 1) return player;

            if (MoveMark[player][row] + 1 == N || MoveMark[player][col + N] + 1 == N) return player;
            if (row == col && MoveMark[player][2 * N] + 1 == N) return player;
            if (row == col && N % 2 == 1 && row == N / 2 && MoveMark[player][2 * N + 1] + 1 == N) return player;
            if (row != col && row + col == N - 1 && MoveMark[player][2 * N + 1] + 1 == N) return player;
            MoveMark[player][row]++;
            MoveMark[player][col + N]++;
            if (row == col) MoveMark[player][2 * N]++;
            if (row == col && N % 2 == 1 && row == N / 2) MoveMark[player][2 * N + 1]++;
            if (row != col && row + col == N - 1) MoveMark[player][2 * N + 1]++;

            return 0;
        }
    }
}
