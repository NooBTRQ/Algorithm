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
            if (nums.Length == 0) return 0;
            int index = 0;
            for (int i = 1; i < nums.Length; i++) {

                if (nums[i] != nums[index]) {

                    nums[index + 1] = nums[i];
                    index++;
                }
            }

            return index + 1;
        }
    }
}
