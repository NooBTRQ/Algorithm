using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace Algorithm
{
    public static class MicroSoftSubject_Week3
    {
        /// <summary>
        /// 98. 验证二叉搜索树
        /// 给定一个二叉树，判断其是否是一个有效的二叉搜索树。
        ///假设一个二叉搜索树具有如下特征：
        ///节点的左子树只包含小于当前节点的数。
        ///节点的右子树只包含大于当前节点的数。
        ///所有左子树和右子树自身必须也是二叉搜索树。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsValidBST(TreeNode root)
        {
            return IsValidBSTHelper(root, null, null);

        }

        public static bool IsValidBSTHelper(TreeNode root, int? minInt, int? maxInt) {

            if (root == null) return true;
            if (minInt != null && minInt >= root.val) return false;
            if (maxInt != null && maxInt <= root.val) return false;

            return IsValidBSTHelper(root.left, minInt, root.val) && IsValidBSTHelper(root.right, root.val, maxInt);
        }

        /// <summary>
        /// 15.三数之和
        /// 给你一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？请你找出所有满足条件且不重复的三元组。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums == null || nums.Length < 3) return result;
            nums = nums.OrderBy(e =>e).ToArray();
            int len = nums.Length;
            for (int i = 0; i < len; i++) {
                if (nums[i] > 0) break;
                if (i>0 && nums[i] == nums[i - 1]) continue;
                int target = -nums[i];
                int RIndex = len - 1;
                for (int LIndex = i + 1; LIndex < len; LIndex++) {

                    if (LIndex > i+1&& nums[LIndex] == nums[LIndex - 1]) continue;
                    
                    while (RIndex>LIndex && nums[LIndex] + nums[RIndex] > target) {

                        RIndex--;
                    }
                    if (RIndex == LIndex) break;
                    if (nums[LIndex] + nums[RIndex] == target)
                    {

                        result.Add(new List<int>() { nums[i], nums[LIndex], nums[RIndex] });
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 240. 搜索二维矩阵 II
        /// 编写一个高效的算法来搜索 m x n 矩阵 matrix 中的一个目标值 target。该矩阵具有以下特性：
        /// 每行的元素从左到右升序排列。
        /// 每列的元素从上到下升序排列。
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix.Length == 0 || matrix[0, 0] > target) return false;
            int row = 0;int column = matrix.GetLength(1)-1;
            while (row < matrix.GetLength(0) && column >=0) {
                if (matrix[row, column] == target) return true;
                if (matrix[row, column] < target)
                {
                    row++;
                }
                else {

                    column--;
                }
            }
            return false;
        }

        /// <summary>
        /// 236. 二叉树的最近公共祖先
        /// 给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。
        /// 百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，
        /// 满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。”
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            IsContainsPQ(root, p, q);
            return result;
        }
        public static TreeNode result;
        public static bool IsContainsPQ(TreeNode node, TreeNode p, TreeNode q) {

            if (node == null) return false;
            bool lson = IsContainsPQ(node.left, p, q);
            bool rson = IsContainsPQ(node.right, p, q);

            if ((lson && rson) || ((node.val == p.val || node.val == q.val) && (lson || rson))) {

                result = node;
            }

            return lson || rson || node.val == p.val || node.val == q.val;
        }

        /// <summary>
        /// 48. Rotate Image
        /// You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
        /// You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.DO NOT allocate another 2D matrix and do the rotation.
        /// </summary>
        /// <param name="matrix"></param>
        public static void Rotate(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) {

                return ;
            }
            int rowCount = matrix.Length;
            for (int i = 0; i < rowCount / 2;i++) {

                int[] temp = matrix[i];
                matrix[i] = matrix[rowCount - i - 1];
                matrix[rowCount - i - 1] = temp;

            }
            for (int i = 0; i < rowCount; i++) {

                for (int j = 0; j <= i; j++) {

                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        private static Dictionary<int, int> nodeMap = new Dictionary<int, int>();
        /// <summary>
        /// 105. Construct Binary Tree from Preorder and Inorder Traversal
        /// Given preorder and inorder traversal of a tree, construct the binary tree.
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null || preorder.Length != inorder.Length) {

                return null;
            }
            nodeMap.Clear();
            for (int i = 0; i < inorder.Length; i++) {

                nodeMap.Add(inorder[i], i);
            }
            return FindRootNode(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
        }

        private static TreeNode FindRootNode(int[] preorder,int[] inorder,int preLeft,int preRight,int inLeft,int inRight) {

            if (preLeft> preRight)
            {              
                return null;
            }

            var rootVal = preorder[preLeft]; 
            var rootNode = new TreeNode(rootVal);
            var rootIndex = nodeMap[rootVal];
            rootNode.left = FindRootNode(preorder,inorder,preLeft+1,preLeft+rootIndex-inLeft,inLeft,rootIndex-1);
            rootNode.right = FindRootNode(preorder, inorder, preLeft + rootIndex - inLeft + 1, preRight, rootIndex + 1, inRight);
            return rootNode;
        }
    }
}

