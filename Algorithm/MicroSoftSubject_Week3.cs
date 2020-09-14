using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// 三数之和
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
    }
}

