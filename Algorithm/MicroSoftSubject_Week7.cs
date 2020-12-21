using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week7
    {
        /// <summary>
        /// 165. 比较版本号
        /// 给你两个版本号 version1 和 version2 ，请你比较它们。
        /// 版本号由一个或多个修订号组成，各修订号由一个 '.' 连接。
        /// 每个修订号由 多位数字 组成，可能包含 前导零 。每个版本号至少包含一个字符。
        /// 修订号从左到右编号，下标从 0 开始，最左边的修订号下标为 0 ，下一个修订号下标为 1 ，以此类推。
        /// 例如，2.5.33 和 0.1 都是有效的版本号。
        /// 比较版本号时，请按从左到右的顺序依次比较它们的修订号。
        /// 比较修订号时，只需比较 忽略任何前导零后的整数值 。
        /// 也就是说，修订号 1 和修订号 001 相等 。如果版本号没有指定某个下标处的修订号，则该修订号视为 0 。
        /// 例如，版本 1.0 小于版本 1.1 ，因为它们下标为 0 的修订号相同，而下标为 1 的修订号分别为 0 和 1 ，0 < 1 。
        /// 返回规则如下：
        ///   如果 version1 > version2 返回 1，
        ///   如果 version1 < version2 返回 -1，
        ///   除此之外返回 0。
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public static int CompareVersion(string version1, string version2)
        {
            int i = 0, j = 0;
            while (i < version1.Length || j < version2.Length)
            {
                int x = i, y = j;
                while (x < version1.Length && version1[x] != '.') x++;
                while (y < version2.Length && version2[y] != '.') y++;
                int a = (i == x) ? 0 : int.Parse(version1.Substring(i, x - i));
                int b = (j == y) ? 0 : int.Parse(version2.Substring(j, y - j));
                if (a > b) return 1;
                else if (a < b) return -1;
                i = x + 1; j = y + 1;
            }
            return 0;
        }

        /// <summary>
        /// 94.二叉树中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> InorderTraversal(TreeNode root)
        {
            if(root == null) return new List<int>();

            var result = new List<int>();
           
            InorderDFS(root, result);

            return result;
        }

        /// <summary>
        /// 11. 盛最多水的容器
        /// 给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。
        /// 在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0) 。
        /// 找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。
        /// 说明：你不能倾斜容器。
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int capacity = 0;
            while (left < right) {

                capacity = Math.Max(capacity,Math.Min(height[left],height[right]) * (right - left));
                if (height[left] > height[right])
                {

                    right--;
                }
                else {

                    left++;
                }
            }

            return capacity;
        }

        /// <summary>
        /// 153. 寻找旋转排序数组中的最小值
        /// 假设按照升序排序的数组在预先未知的某个点上进行了旋转。例如，数组 [0,1,2,4,5,6,7] 可能变为 [4,5,6,7,0,1,2] 。
        /// 请找出其中最小的元素。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMin(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            int l = 0;
            int r = nums.Length - 1;
            
            while (l < r) {

                int mid = (l + r) >> 1;
                if (nums[mid] > nums[r])
                {

                    l = mid + 1;
                }
                else {

                    r = mid;
                }
            }

            return nums[l];
        }

        /// <summary>
        /// 277. 搜寻名人
        /// 假设你是一个专业的狗仔，参加了一个 n 人派对，其中每个人被从 0 到 n - 1 标号。
        /// 在这个派对人群当中可能存在一位 “名人”。所谓 “名人” 的定义是：其他所有 n - 1 个人都认识他/她，而他/她并不认识其他任何人。
        /// 现在你想要确认这个 “名人” 是谁，或者确定这里没有 “名人”。
        /// 而你唯一能做的就是问诸如 “A 你好呀，请问你认不认识 B呀？” 的问题，以确定 A 是否认识 B。
        /// 你需要在（渐近意义上）尽可能少的问题内来确定这位 “名人” 是谁（或者确定这里没有 “名人”）。
        /// 在本题中，你可以使用辅助函数 bool knows(a, b) 获取到 A 是否认识 B。请你来实现一个函数 int findCelebrity(n)。
        /// 派对最多只会有一个 “名人” 参加。若 “名人” 存在，请返回他/她的编号；若 “名人” 不存在，请返回 -1。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FindCelebrity(int n)
        {
            //int[] inDegree = new int[n];
            //int[] outDegree = new int[n];
            //int result = -1;
            //for (int i = 0; i < n; i++) {

            //    for (int j = i + 1; j < n; j++) {


            //        if (Knows(i, j))
            //        {

            //            inDegree[j]++;
            //            outDegree[i]++;
            //        }
            //        if (Knows(j, i))
            //        {
            //            inDegree[i]++;
            //            outDegree[j]++;
            //        }
            //    }
            //}

            //for (int i = 0; i < n; i++) {

            //    if (inDegree[i] == n - 1 && outDegree[i] == 0) return i;
            //}

            //return result;

            int result = 0;
            for (int i = 1; i < n; i++) {

                if (Knows(result, i)) {

                    result = i;
                }
            }

            for (int i = 0; i < n; i++) {

                if (i == result) continue;
                if (Knows(result, i) || !Knows(i, result)) return -1;
            }

            return result;
        }


        /// <summary>
        /// 31. 下一个排列
        /// 实现获取 下一个排列 的函数，算法需要将给定数字序列重新排列成字典序中下一个更大的排列。
        /// 如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。
        /// 必须 原地 修改，只允许使用额外常数空间。
        /// </summary>
        /// <param name="nums"></param>
        public static void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (j >= 0 && nums[i] >= nums[j])
                {
                    j--;
                }
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
            Array.Reverse(nums,i + 1,nums.Length - 1 - i);
        }

        /// <summary>
        /// 43. 字符串相乘
        /// 给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";
            if (num1 == "1") return num2;
            if (num2 == "1") return num1;
            int[] res = new int[num1.Length + num2.Length];
            for (int i = num1.Length - 1; i >= 0; i--) {

                for (int j = num2.Length - 1; j >= 0; j--) {

                    int tempRes = (num1[i] - '0') * (num2[j] - '0');
                    tempRes += res[i + j + 1];
                    res[i + j + 1] = tempRes % 10;
                    res[i + j] += tempRes / 10;
                }
            }

            int start = 0;
            for (; start < res.Length; start ++) {

                if (res[start] != 0) break;
            }
            string resStr = "";
            for (; start < res.Length; start++) {

                resStr += res[start].ToString();
            }

            return resStr;
        }

        /// <summary>
        /// 36. 有效的数独
        /// 判断一个 9x9 的数独是否有效。只需要根据以下规则，验证已经填入的数字是否有效即可。
        /// 数字 1-9 在每一行只能出现一次。
        /// 数字 1-9 在每一列只能出现一次。
        /// 数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。
        /// 数独部分空格内已填入了数字，空白格用 '.' 表示。
        /// 说明:
        /// 一个有效的数独（部分已被填充）不一定是可解的。
        /// 只需要根据以上规则，验证已经填入的数字是否有效即可。
        /// 给定数独序列只包含数字 1-9 和字符 '.' 。
        /// 给定数独永远是 9x9 形式的。
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool IsValidSudoku(char[][] board)
        {
            HashSet<char>[] colnumSet = new HashSet<char>[9];
            HashSet<char>[] rowSet = new HashSet<char>[9];
            HashSet<char>[] boxSet = new HashSet<char>[9];

            for (int i = 0; i < 9; i++) {

                colnumSet[i] = new HashSet<char>();
                rowSet[i] = new HashSet<char>();
                boxSet[i] = new HashSet<char>();
            }

            for (int i = 0; i < 9; i++) {

                for (int j = 0; j < 9; j++) {

                    if (board[i][j] != '.') {

                        if (colnumSet[j].Contains(board[i][j])) {

                            return false;
                        }
                        else {

                            colnumSet[j].Add(board[i][j]);
                        }
                        if (rowSet[i].Contains(board[i][j]))
                        {

                            return false;
                        }
                        else { 
                        
                            rowSet[i].Add(board[i][j]);
                        }
                        if (boxSet[(i / 3) * 3 + j / 3].Contains(board[i][j]))
                        {

                            return false;
                        }
                        else {

                            boxSet[(i / 3) * 3 + j / 3].Add(board[i][j]);
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 12. 整数转罗马数字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntToRoman(int num)
        {
            // 把阿拉伯数字与罗马数字可能出现的所有情况和对应关系，放在两个数组中，并且按照阿拉伯数字的大小降序排列
            int[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            String[] romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder stringBuilder = new StringBuilder();
            int index = 0;
            while (index < 13)
            {
                // 特别注意：这里是等号
                while (num >= nums[index])
                {
                    stringBuilder.Append(romans[index]);
                    num -= nums[index];
                }
                index++;
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 287. 寻找重复数
        /// 给定一个包含 n + 1 个整数的数组 nums，其数字都在 1 到 n 之间（包括 1 和 n），可知至少存在一个重复的整数。
        /// 假设只有一个重复的整数，找出这个重复的数。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindDuplicate(int[] nums)
        {
            // ------二分法
            //int left = 1;
            //int right = nums.Length - 1;
            //int ans = -1;
            //// 1,2,3,4,5,6,9,8,9,9
            //while (left <= right) {
            //    int cnt = 0;
            //    int mid = (left + right) >> 1;
            //    for (int i = 0; i < nums.Length; ++i) {

            //        if (nums[i] <= mid) {

            //            cnt++;
            //        }
            //    }

            //    if (cnt <= mid)
            //    {

            //        left = mid + 1;
            //    }
            //    else {

            //        right = mid - 1;
            //        ans = mid;
            //    }
            //}

            //return ans;

            // -----快慢指针
            int slow = 0, fast = 0;
            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            } while (slow != fast);
            slow = 0;
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }
            return slow;
        }

        private static bool Knows(int a, int b) {

            if (a == 0 && b == 0) return true;
            if (a == 0 && b == 1) return true;
            if (a == 0 && b == 2) return false;
            if (a == 1 && b == 0) return false;
            if (a == 1 && b == 1) return true;
            if (a == 1 && b == 2) return false;
            if (a == 2 && b == 0) return true;
            if (a == 2 && b == 1) return true;
            if (a == 2 && b == 2) return true;
            return true;
        }

        private static void InorderDFS(TreeNode node,List<int> result) {

            if (node == null) {

                return;
            }
            if (node.left != null) InorderDFS(node.left, result);
            result.Add(node.val);
            if (node.right != null) InorderDFS(node.right, result);
        }
    }
}
