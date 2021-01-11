using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week9
    {
        /// <summary>
        /// 443. 压缩字符串
        /// 给定一组字符，使用原地算法将其压缩。
        /// 压缩后的长度必须始终小于或等于原数组长度。
        /// 数组的每个元素应该是长度为1 的字符（不是 int 整数类型）。
        /// 在完成原地修改输入数组后，返回数组的新长度。
        /// 进阶：
        ///   你能否仅使用O(1) 空间解决问题？
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static int Compress(char[] chars)
        {
            int write = 0;
            int currentChar = 0;
            for (int read = 0; read < chars.Length; read++) {

                if (read + 1 == chars.Length || chars[read + 1] != chars[read]) {

                    chars[write++] = chars[currentChar];
                    if (read > currentChar) {

                        foreach (char c in (read - currentChar + 1).ToString().ToCharArray()) {

                            chars[write++] = c;
                        }
                    }
                    currentChar = read + 1;
                }
            }

            return write;
        }

        /// <summary>
        /// 402. 移掉K位数字
        /// 给定一个以字符串表示的非负整数 num，移除这个数中的 k 位数字，使得剩下的数字最小。
        /// 注意:
        ///   num 的长度小于 10002 且 ≥ k。
        ///   num 不会包含任何前导零。      
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string RemoveKdigits(string num, int k)
        {
            if (num == null || num.Length == 0 || k == 0) return num;
            if (num.Length == k) return "0";

            var numList = new List<char>();

            for (int i = 0; i < num.Length; i++) {

                if (numList.Count > 0 && num[i] < num[i - 1] && k > 0) {

                    while (numList.Count > 0 && numList[numList.Count - 1] > num[i] && k > 0) {

                        numList.RemoveAt(numList.Count - 1);
                        k--;
                    }
                }
                numList.Add(num[i]);
            }

            if (k > 0) {

                numList.RemoveRange(numList.Count - k, k);
            }
            var result = new StringBuilder();

            for (int i = 0; i < numList.Count; i++) {

                if (numList[i] == '0' && result.Length == 0) {

                    continue;
                }

                result.Append(numList[i]);
            }
            if (result.ToString() == "") return "0";
            return result.ToString();
        }

        /// <summary>
        /// 117. 填充每个节点的下一个右侧节点指针 II
        /// 给定一个二叉树
        /// 填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。
        /// 初始状态下，所有 next 指针都被设置为 NULL。
        /// 进阶：
        ///   你只能使用常量级额外空间。
        ///   使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static Node Connect(Node root)
        {
            if (root == null) return root;
            //从根节点开始
            var leftNode = root;
            while (leftNode != null)
            {

                var head = leftNode;
                //下一层最左的节点
                Node nextLeft = null;
                Node lastNode = null;
                while (head != null) {
                    if (head.left != null)
                    {

                        if (nextLeft == null) nextLeft = head.left;
                        if(lastNode != null) lastNode.next = head.left;
                        lastNode = head.left;
                    }
                    if (head.right != null) {

                        if (nextLeft == null) nextLeft = head.right;
                        if (lastNode != null) lastNode.next = head.right;
                        lastNode = head.right;
                    }
                    head = head.next;
                }
                leftNode = nextLeft;
            }

            return root;
        }
    }

    /// <summary>
    /// 173. 二叉搜索树迭代器
    /// 实现一个二叉搜索树迭代器。你将使用二叉搜索树的根节点初始化迭代器。
    /// 调用 next() 将返回二叉搜索树中的下一个最小的数。
    /// 提示：
    ///   next() 和 hasNext() 操作的时间复杂度是 O(1)，并使用 O(h) 内存，其中 h 是树的高度。
    ///   你可以假设 next() 调用总是有效的，也就是说，当调用 next() 时，BST 中至少存在一个下一个最小的数。
    /// </summary>
    public class BSTIterator
    {

        private Stack<TreeNode> stack;

        public BSTIterator(TreeNode root)
        {
            stack = new Stack<TreeNode>();

            LeftmostInorder(root);
        }

        private void LeftmostInorder(TreeNode root) {

            while (root != null) {

                stack.Push(root);
                root = root.left;
            }
        }

        public int Next()
        {
            TreeNode topmostNode = stack.Pop();

            if (topmostNode.right != null) {

                LeftmostInorder(topmostNode.right);
            }

            return topmostNode.val;
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }
    }
}
