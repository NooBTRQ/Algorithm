using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class ArrayStudy
    {
        /*
         给定一个排序数组，你需要在 原地 删除重复出现的元素，使得每个元素只出现一次，返回移除后数组的新长度。
         不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。
         */
        public static int RemoveDuplicates(int[] nums)
        {
            List<int> result = new List<int>();
            int a = 0;
            for (int i = 0; i < nums.Length; i++){
                if (i == 0) {
                    result.Add(nums[0]);
                    continue;
                }
                if (nums[i] != nums[i - 1]) {
                    result.Add(nums[i]);
                }
            }
            nums = result.ToArray();
            return result.Count;
        }
    }
}
