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
    }
}
