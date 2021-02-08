using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{

    public static class SpringWeek_1
    {
        /// <summary>
        /// 978. 最长湍流子数组
        /// 当 A 的子数组 A[i], A[i+1], ..., A[j] 满足下列条件时，我们称其为湍流子数组：
        ///   若 i <= k<j，当 k 为奇数时， A[k]> A[k + 1]，且当 k 为偶数时，A[k] < A[k + 1]；
        ///   或 若 i <= k<j，当 k 为偶数时，A[k]> A[k + 1] ，且当 k 为奇数时， A[k] < A[k + 1]。
        /// 也就是说，如果比较符号在子数组中的每个相邻元素对之间翻转，则该子数组是湍流子数组。
        /// 返回 A 的最大湍流子数组的长度。
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int MaxTurbulenceSize(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            if (arr.Length == 1) return 1;
            int result = 0;
            int left = 0;
            int right = 1;
            while (right < arr.Length) {
                if (arr[right] != arr[right - 1]) result = Math.Max(result, 2);
                if (arr[right] == arr[right - 1]) 
                { 
                    result = Math.Max(result, 1);
                    left++;
                    right++;
                    continue;
                }
                if (right - 2 >= 0 && arr[right] > arr[right - 1] && arr[right - 1] < arr[right - 2]) right++;
                else if (right - 2 >= 0 && arr[right] < arr[right - 1] && arr[right - 1] > arr[right - 2]) right++;
                else{
                    left = right - 1;
                    right++;
                    continue;
                }
                result = Math.Max(result, right - left);
            }

            return result;
        }

        /// <summary>
        /// 剑指 Offer 10- I. 斐波那契数列
        /// 写一个函数，输入 n ，求斐波那契（Fibonacci）数列的第 n 项（即 F(N)）。斐波那契数列的定义如下：
        /// F(0) = 0,   F(1) = 1
        /// F(N) = F(N - 1) + F(N - 2), 其中 N > 1.
        /// 斐波那契数列由 0 和 1 开始，之后的斐波那契数就是由之前的两数相加而得出。
        /// 答案需要取模 1e9+7（1000000007），如计算初始结果为：1000000008，请返回 1。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int n_2 = 0;
            int n_1 = 1;           
            int result = 0;
            while (n > 1) {

                result = (n_1 + n_2)% 1000000007;
                n_2 = n_1;
                n_1 = result;
                n--;
            }

            return result;
        }

        /// <summary>
        /// 剑指 Offer 10- II. 青蛙跳台阶问题
        /// 一只青蛙一次可以跳上1级台阶，也可以跳上2级台阶。求该青蛙跳上一个 n 级的台阶总共有多少种跳法。
        /// 答案需要取模 1e9+7（1000000007），如计算初始结果为：1000000008，请返回 1。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NumWays(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            if (n == 2) return 2;
            int a = 1;
            int b = 2;
            for (int i = 3; i <= n; i++) {

                int sum = (a + b) % 1000000007;
                a = b;
                b = sum;
            }

            return b;
        }
    }
}
