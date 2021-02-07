using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week14
    {
        /// <summary>
        /// 114. 二叉树展开为链表
        /// 给你二叉树的根结点 root ，请你将它展开为一个单链表：
        /// 展开后的单链表应该同样使用 TreeNode ，其中 right 子指针指向链表中下一个结点，而左子指针始终为 null 。
        /// 展开后的单链表应该与二叉树 先序遍历 顺序相同。
        /// </summary>
        /// <param name="root"></param>
        public static void Flatten(TreeNode root)
        {
            if (root == null) return ;
            var currentNode = root;
            while (currentNode != null) {

                if (currentNode.left != null) {

                    var preNode = currentNode.left;
                    while (preNode.right != null) {

                        preNode = preNode.right;
                    }

                    preNode.right = currentNode.right;
                    currentNode.right = currentNode.left;
                    currentNode.left = null;
                    
                }

                currentNode = currentNode.right;
            }
        }

        /// <summary>
        /// 328. 奇偶链表
        /// 给定一个单链表，把所有的奇数节点和偶数节点分别排在一起。请注意，这里的奇数节点和偶数节点指的是节点编号的奇偶性，而不是节点的值的奇偶性。
        /// 请尝试使用原地算法完成。你的算法的空间复杂度应为 O(1)，时间复杂度应为 O(nodes)，nodes 为节点总数。
        /// 说明:
        ///   应当保持奇数节点和偶数节点的相对顺序。
        ///   链表的第一个节点视为奇数节点，第二个节点视为偶数节点，以此类推。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            var current = head.next.next;
            ListNode oddHead = head;
            ListNode evenHead = head.next;
            head.next.next = null;
            head.next = null;
            var tempOdd = oddHead;
            var tempEven = evenHead;
            while (current != null) {

                if (current.next == null) {

                    tempOdd.next = current;
                    tempOdd = tempOdd.next;
                    break;
                }
                tempOdd.next = current;
                tempEven.next = current.next;
                var next = current.next.next;
                current.next.next = null;
                current.next = null;
                tempOdd = tempOdd.next;
                tempEven = tempEven.next;
                current = next;
            }

            tempOdd.next = evenHead;
            return oddHead;
        }

        /// <summary>
        /// 剑指 Offer 03. 数组中重复的数字
        /// 找出数组中重复的数字。
        /// 在一个长度为 n 的数组 nums 里的所有数字都在 0～n-1 的范围内。数组中某些数字是重复的，但不知道有几个数字重复了，也不知道每个数字重复了几次。请找出数组中任意一个重复的数字。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindRepeatNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var numSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++) {

                if (numSet.Contains(nums[i])) return nums[i];
                numSet.Add(nums[i]);
            }

            return 0;
        }

        /// <summary>
        /// 剑指 Offer 04. 二维数组中的查找
        /// 在一个 n * m 的二维数组中，每一行都按照从左到右递增的顺序排序，每一列都按照从上到下递增的顺序排序。
        /// 请完成一个高效的函数，输入这样的一个二维数组和一个整数，判断数组中是否含有该整数。
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool FindNumberIn2DArray(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0 || matrix[0][0] > target) return false;
            int row = 0;
            int column = matrix[0].Length - 1;
            while (row < matrix.Length && column >= 0) {

                if (matrix[row][column] == target) return true;
                else if (matrix[row][column] < target) row++;
                else column--;
            }
            return false;
        }

        /// <summary>
        /// 643. 子数组最大平均数 I
        /// 给定 n 个整数，找出平均数最大且长度为 k 的连续子数组，并输出该最大平均数。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double FindMaxAverage(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || nums.Length < k || k <= 0) return 0;

            int tempSum = 0;           
            double ans = 0;
            for (int i = 0; i < k; i++) {

                tempSum += nums[i];
            }
            ans = tempSum * 1.0 / k;

            int left = 1;
            int right = k;
            while (right < nums.Length) {

                tempSum = tempSum + nums[right] - nums[left - 1];
                ans = Math.Max(ans, tempSum * 1.0 / k);
                left++;
                right++;
            }

            return ans;
        }

        /// <summary>
        /// 剑指 Offer 05. 替换空格
        /// 请实现一个函数，把字符串 s 中的每个空格替换成"%20"。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReplaceSpace(string s)
        {
            if (s == null || s.Length == 0) return "";
            var str = new StringBuilder();
            for (int i = 0; i < s.Length; i++) {

                if (s[i] == ' ')
                {

                    str.Append("%20");
                }
                else {

                    str.Append(s[i]);
                }
            }

            return str.ToString();
        }

        /// <summary>
        /// 剑指 Offer 06. 从尾到头打印链表
        /// 输入一个链表的头节点，从尾到头反过来返回每个节点的值（用数组返回）。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static int[] ReversePrint(ListNode head)
        {
            if (head == null) return new int[0];
            var nodeStack = new Stack<ListNode>();
            while (head != null) {

                nodeStack.Push(head);
                head = head.next;
            }
            var result = new int[nodeStack.Count];
            int index = 0;
            while (nodeStack.Count > 0) {
                var node = nodeStack.Pop();
                result[index] = node.val;
                index++;
            }

            return result;
        }

        /// <summary>
        /// 1208. 尽可能使字符串相等
        /// </summary>给你两个长度相同的字符串，s 和 t。
        /// 将 s 中的第 i 个字符变到 t 中的第 i 个字符需要 |s[i] - t[i]| 的开销（开销可能为 0），也就是两个字符的 ASCII 码值的差的绝对值。
        /// 用于变更字符串的最大预算是 maxCost。在转化字符串时，总开销应当小于等于该预算，这也意味着字符串的转化可能是不完全的。
        /// 如果你可以将 s 的子字符串转化为它在 t 中对应的子字符串，则返回可以转化的最大长度。
        /// 如果 s 中没有子字符串可以转化成 t 中对应的子字符串，则返回 0。
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="maxCost"></param>
        /// <returns></returns>
        public static int EqualSubstring(string s, string t, int maxCost)
        {
            if (s == null || s.Length == 0) return 0;
            int[] costArr = new int[26];
            for (int i = 0; i < s.Length; i++){

                costArr[Math.Abs(s[i] - t[i])]++;
            }

            int result = 0;
            int index = 1;
            result += costArr[0];
            while (maxCost >= 0 && index<26) {

                if (maxCost >= index * costArr[index])
                {

                    result += costArr[index];
                    maxCost -= costArr[index] * index;
                    index++;
                }
                else {

                    result += maxCost / index;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 1423. 可获得的最大点数
        /// 几张卡牌 排成一行，每张卡牌都有一个对应的点数。点数由整数数组 cardPoints 给出。
        /// 每次行动，你可以从行的开头或者末尾拿一张卡牌，最终你必须正好拿 k 张卡牌。
        /// 你的点数就是你拿到手中的所有卡牌的点数之和。
        /// 给你一个整数数组 cardPoints 和整数 k，请你返回可以获得的最大点数。
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int MaxScore(int[] cardPoints, int k)
        {
            if (cardPoints == null || cardPoints.Length == 0 || k == 0) return 0;
            int n = cardPoints.Length;
            // 滑动窗口大小为 n-k
            int windowSize = n - k;
            // 选前 n-k 个作为初始值
            int sum = 0;
            for (int i = 0; i < windowSize; ++i)
            {
                sum += cardPoints[i];
            }
            int totalSum = 0;
            for (int i = 0; i < cardPoints.Length; i++) {

                totalSum += cardPoints[i];
            }
            int minSum = sum;
            for (int i = windowSize; i < n; ++i)
            {
                // 滑动窗口每向右移动一格，增加从右侧进入窗口的元素值，并减少从左侧离开窗口的元素值
                sum += cardPoints[i] - cardPoints[i - windowSize];
                minSum = Math.Min(minSum, sum);
            }
            return totalSum - minSum;
        }

        /// <summary>
        /// 剑指 Offer 07. 重建二叉树
        /// 输入某二叉树的前序遍历和中序遍历的结果，请重建该二叉树。假设输入的前序遍历和中序遍历的结果中都不含重复的数字。
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0) return null;
            var root = BuildTreeHelper(preorder, inorder, 0, inorder.Length - 1, 0, preorder.Length - 1);
            return root;
        }

        private static TreeNode BuildTreeHelper(int[] preorder, int[] inorder, int inLeft, int inRight,int preLeft,int preRight)
        {
            if (preLeft > preRight) return null;
            int mid = preorder[preLeft];
            int midIndex = 0;
            TreeNode rootNode = new TreeNode(mid);
            for (int i = inLeft; i <= inRight; i++)
            {

                if (inorder[i] == mid)
                {
                    midIndex = i;
                    break;
                }
            }
            int leftNodeLen = midIndex - inLeft;
            rootNode.left = BuildTreeHelper(preorder, inorder, inLeft, midIndex - 1, preLeft + 1, preLeft + leftNodeLen);
            rootNode.right = BuildTreeHelper(preorder, inorder, midIndex + 1, inRight, preLeft + leftNodeLen + 1, preRight);
            return rootNode;
        }

        public static int SumOfUnique(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var numSet = new HashSet<int>();
            var dupSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++) {

                if (numSet.Contains(nums[i]))
                {

                    dupSet.Add(nums[i]);
                    numSet.Remove(nums[i]);
                }
                else if (!numSet.Contains(nums[i]) && !dupSet.Contains(nums[i])) {

                    numSet.Add(nums[i]);
                }
            }

            int result = 0;
            for (int i = 0; i < nums.Length; i++) {

                if (!dupSet.Contains(nums[i])) {

                    result += nums[i];
                }
            }

            return result;
        }

        public static int MaxAbsoluteSum(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var result = 0;
            for (int len = 1; len <= nums.Length; len++) {
                int tempSum = 0;
                for (int i = 0; i < len; i++) {

                    tempSum += nums[i];
                }
                result = Math.Max(Math.Abs(tempSum), result);
                for (int left = 1; left <= nums.Length - len; left++) {

                    tempSum -= nums[left - 1];
                    tempSum += nums[left + len - 1];
                    result = Math.Max(Math.Abs(tempSum),result);
                }
            }
            return result;
        }

        /// <summary>
        /// 665. 非递减数列
        /// 给你一个长度为 n 的整数数组，请你判断在 最多 改变 1 个元素的情况下，该数组能否变成一个非递减数列。
        /// 我们是这样定义一个非递减数列的： 对于数组中所有的 i(0 <= i <= n-2)，总满足 nums[i] <= nums[i + 1]。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CheckPossibility(int[] nums)
        {
            int n = nums.Length, cnt = 0;
            for (int i = 0; i < n - 1; ++i)
            {
                int x = nums[i], y = nums[i + 1];
                if (x > y)
                {
                    cnt++;
                    if (cnt > 1)
                    {
                        return false;
                    }
                    if (i > 0 && y < nums[i - 1])
                    {
                        nums[i + 1] = x;
                    }
                }
            }
            return true;
        }


    }

    /// <summary>
    /// 剑指 Offer 09. 用两个栈实现队列
    /// 用两个栈实现一个队列。队列的声明如下，请实现它的两个函数 appendTail 和 deleteHead ，分别完成在队列尾部插入整数和在队列头部删除整数的功能。(若队列中没有元素，deleteHead 操作返回 -1 )
    /// </summary>
    public class CQueue
    {
        private Stack<int> stackInput;
        private Stack<int> stackOutput;
        public CQueue()
        {
            stackInput = new Stack<int>();
            stackOutput = new Stack<int>();
        }

        public void AppendTail(int value)
        {
            stackInput.Push(value);
        }

        public int DeleteHead()
        {
            if (stackOutput.Count == 0) {

                while (stackInput.Count > 0) {

                    var v = stackInput.Pop();
                    stackOutput.Push(v);
                }
            }

            if (stackOutput.Count > 0) return stackOutput.Pop();
            return -1;
        }
    }
}
