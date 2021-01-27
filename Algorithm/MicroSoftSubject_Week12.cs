using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week12
    {
        /// <summary>
        /// 721. 账户合并
        /// 给定一个列表 accounts，每个元素 accounts[i] 是一个字符串列表，其中第一个元素 accounts[i][0] 是 名称 (name)，其余元素是 emails 表示该账户的邮箱地址。
        /// 现在，我们想合并这些账户。如果两个账户都有一些共同的邮箱地址，则两个账户必定属于同一个人。
        /// 请注意，即使两个账户具有相同的名称，它们也可能属于不同的人，因为人们可能具有相同的名称。
        /// 一个人最初可以拥有任意数量的账户，但其所有账户都具有相同的名称。
        /// 合并账户后，按以下格式返回账户：每个账户的第一个元素是名称，其余元素是按字符 ASCII 顺序排列的邮箱地址。
        /// 账户本身可以以任意顺序返回。
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            return null;
        }

        /// <summary>
        /// 实现 pow(x, n) ，即计算 x 的 n 次幂函数。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            if (n == 1) return x;
            if (n == -1) return 1 / x;
            var half = MyPow(x, n / 2);
            var rest = MyPow(x, n % 2);
            return  half * half * rest;
        }

        /// <summary>
        /// 560. 和为K的子数组
        /// 给定一个整数数组和一个整数 k，你需要找到该数组中和为 k 的连续的子数组的个数。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int SubarraySum(int[] nums, int k)
        {
            // 暴力
            if (nums == null || nums.Length == 0) return 0;

            // 前缀和优化
            var perSumDic = new Dictionary<int, int>() { { 0, 1 } };
            int result = 0;
            int perSum = 0;
            for (int i = 0; i < nums.Length; i++) {

                perSum += nums[i];
                int tempPerSum = perSum - k;
                if (perSumDic.ContainsKey(tempPerSum)) {

                    result += perSumDic[tempPerSum];
                }
                if (perSumDic.ContainsKey(perSum)) perSumDic[perSum]++;
                else perSumDic[perSum] = 1;
            }
            return result;

            // 暴力
            //int result = 0;
            //int[] sumArr = new int[nums.Length];
            //for (int len = 1; len <= nums.Length; len++) {

            //    for (int i = 0; qi + len <= nums.Length; i++) {
            //        sumArr[i] += nums[i + len - 1];
            //        if (sumArr[i] == k) result++;
            //    }
            //}
            //return result;
        }

        /// <summary>
        /// 61. 旋转链表
        /// 给定一个链表，旋转链表，将链表每个节点向右移动 k 个位置，其中 k 是非负数。
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0) return head;
            var tail = head;
            int count = 1;
            while (tail.next != null) {
                tail = tail.next;
                count++;
            }
            tail.next = head;

            k = k % count;
            k = count - k;
            if (k == 0) return head;

            while (k > 1) {

                head = head.next;
                k--;
            }
            var newHead = head.next;
            head.next = null;

            return newHead;
        }

        /// <summary>
        /// 186. 翻转字符串里的单词 II
        /// 给定一个字符串，逐个翻转字符串中的每个单词。
        /// 注意：
        ///   单词的定义是不包含空格的一系列字符
        ///   输入字符串中不会包含前置或尾随的空格
        ///   单词与单词之间永远是以单个空格隔开的
        /// 进阶：使用 O(1) 额外空间复杂度的原地解法。
        /// </summary>
        /// <param name="s"></param>
        public static void ReverseWords(char[] s)
        {
            if (s == null || s.Length == 0) return;

            for (int i = 0; i < s.Length / 2; i++) {

                char temp = s[i];
                s[i] = s[s.Length - i - 1];
                s[s.Length - 1 - i] = temp;
            }

            int head = 0;
            int tail = 0;
            while (tail < s.Length) {

                while (tail < s.Length && s[tail] != ' ') {

                    tail++;
                }

                for (int i = head; i < (tail + head) / 2; i++) {
                    char tempChar = s[i];
                    s[i] = s[tail - 1 - (i - head)];
                    s[tail - 1 - (i - head)] = tempChar;
                }

                head = ++tail;
            }
        }

        /// <summary>
        /// 59. 螺旋矩阵 II
        /// 给定一个正整数 n，生成一个包含 1 到 n2 所有元素，且元素按顺时针顺序螺旋排列的正方形矩阵。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[][] GenerateMatrix(int n)
        {
            if (n == 0) return null;
            if (n == 1) return new int[1][] { new int[]{ 1 } };
            var result = new int[n][];
            for (int i = 0; i < n; i++) {

                result[i] = new int[n];
            }
            int l = 0;
            int r = n - 1;
            int t = 0;
            int b = n - 1;
            int num = 1;
            while (num <= n * n) {

                for (int i = l; i <= r; i++) { 
                    result[t][i] = num;
                    num++;
                }
                t++;

                for (int i = t; i <= b; i++) {

                    result[i][r] = num;
                    num++;
                } 
                r--;

                for (int i = r; i >= l; i--) {

                    result[b][i] = num;
                    num++;
                }
                
                b--;

                for (int i = b; i >= t; i--) {

                    result[i][l] = num;
                    num++;
                }
                
                l++;
                
            }

            return result;
        }

        /// <summary>
        /// 227. 基本计算器 II
        /// 实现一个基本的计算器来计算一个简单的字符串表达式的值。
        // 字符串表达式仅包含非负整数，+， - ，*，/ 四种运算符和空格  。 整数除法仅保留整数部分。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int Calculate(string s)
        {
            var numStack = new Stack<int>();
            int d = 0;
            char sign = '+';
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] >= '0')
                {//加减乘除和空格ASCII码都小于'0'
                    d = d * 10 - '0' + s[i];//进位(先减法)
                }
                if ((s[i] < '0' && s[i] != ' ') || i == s.Length - 1)
                {
                    if (sign == '+')
                    {
                        numStack.Push(d);
                    }
                    else if (sign == '-')
                    {
                        numStack.Push(-d);
                    }
                    else if (sign == '*' || sign == '/')
                    {
                        int tmp = sign == '*' ? numStack.Peek() * d : numStack.Peek() / d;
                        numStack.Pop();
                        numStack.Push(tmp);
                    }
                    sign = s[i]; //保存当前符号
                    d = 0;
                }
            }

            int res = 0;
            while (numStack.Count > 0) {
                var num = numStack.Pop();
                res += num;
            }

            return res;
        }

        /// <summary>
        /// 93. 复原IP地址
        /// 给定一个只包含数字的字符串，复原它并返回所有可能的 IP 地址格式。
        /// 有效的 IP 地址 正好由四个整数（每个整数位于 0 到 255 之间组成，且不能含有前导 0），整数之间用 '.' 分隔。
        /// 例如："0.1.2.201" 和 "192.168.1.1" 是 有效的 IP 地址，但是 "0.011.255.245"、"192.168.1.312" 和 "192.168@1.1" 是 无效的 IP 地址。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IList<string> RestoreIpAddresses(string s)
        {
            var result = new List<string>();
            if (s == null || s.Length < 4) return result;

            RestoreIpAddressesDFS(s, 1,"",result);

            return result;
        }

        private static void RestoreIpAddressesDFS(string s,int index,string ip,List<string> result) {

            if (index == 4) {

                if (s.Length < 4 && int.Parse(s) <= 255 && (s.Length == 1 || (s.Length>1 && s[0] != '0'))) {

                    ip += ("." + s);
                    result.Add(ip.Substring(1));
                }
                return;
            }

            if (s.Length > 1) {

                RestoreIpAddressesDFS(s.Substring(1), index + 1,ip + "." + s.Substring(0,1),result) ;
            }
            if (s.Length > 2 && s[0] != '0') {
                RestoreIpAddressesDFS(s.Substring(2), index + 1, ip + "." + s.Substring(0, 2), result);

            }
            if (s.Length > 3 && s[0] != '0' && int.Parse(s.Substring(0,3)) <= 255) {

                RestoreIpAddressesDFS(s.Substring(3), index + 1, ip + "." + s.Substring(0, 3), result);
            }
            
        }

        /// <summary>
        /// 179. 最大数
        /// 给定一组非负整数 nums，重新排列它们每个数字的顺序（每个数字不可拆分）使之组成一个最大的整数。
        // 注意：输出结果可能非常大，所以你需要返回一个字符串而不是整数。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static string LargestNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0) return "";

            List<string> numStrList = new List<string>();

            for (int i = 0; i < nums.Length; i++) {

                numStrList.Add(nums[i].ToString());
            }

            numStrList.Sort((x,y) => {

                var order1 = x + y;
                var order2 = y + x;
                return order2.CompareTo(order1);
            });

            if (numStrList[0] == "0") return "0";

            var result = new StringBuilder();
            foreach (var numStr in numStrList) {
                result.Append(numStr);
            }

            return result.ToString();
        }

        /// <summary>
        /// 148. 排序链表
        /// 给你链表的头结点 head ，请将其按 升序 排列并返回 排序后的链表 。
        /// 进阶：
        ///    你可以在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序吗？
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            int length = 0;
            var node = head;
            while (node != null) {

                length++;
                node = node.next;
            }

            var dummyHead = new ListNode(0);
            dummyHead.next = head;
            // dummy-> 1 -> 2-> 3-> 4->5->6->7
            for (int subLength = 1; subLength < length; subLength <<= 1) {
                var current = dummyHead.next;
                var preNode = dummyHead;
                while (current != null) {

                    ListNode head1 = current;                  
                    ListNode tail1 = current;
                    for (int i = 1; i < subLength && tail1.next != null; i++) {
                        tail1 = tail1.next;
                    }

                    ListNode head2 = null;
                    ListNode tail2 = null;
                    if (tail1.next != null)
                    {

                        head2 = tail1.next;
                        tail2 = tail1.next;
                        tail1.next = null;
                        for (int i = 1; i < subLength && tail2.next != null; i++)
                        {

                            tail2 = tail2.next;
                        }
                        current = tail2.next;
                        tail2.next = null;
                    }
                    else {

                        current = null;
                    }
                                      
                    ListNode mergedList = MergeList(head1, head2);
                    preNode.next = mergedList;
                    while (preNode.next != null) {

                        preNode = preNode.next;
                    }
                    preNode.next = current;
                }
            }
            return dummyHead.next;
        }

        /// <summary>
        /// 285. 二叉搜索树中的顺序后继
        /// 给你一个二叉搜索树和其中的某一个结点，请你找出该结点在树中顺序后继的节点。
        /// 结点 p 的后继是值比 p.val 大的结点中键值最小的结点。
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            if (p.right != null)
            {
                p = p.right;
                while (p.left != null) p = p.left;
                return p;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            int inorder = int.MinValue;

            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (inorder == p.val) return root;
                inorder = root.val;
                root = root.right;
            }

            return null;
        }

        /// <summary>
        /// 5645. 找到最高海拔
        /// </summary>
        /// <param name="gain"></param>
        /// <returns></returns>
        public static int LargestAltitude(int[] gain)
        {
            if (gain == null || gain.Length == 0) return 0;
            var maxAltitude = 0;
            var currentAltitude = 0;
            for (int i = 0; i < gain.Length; i++) {

                currentAltitude += gain[i];
                maxAltitude = Math.Max(maxAltitude, currentAltitude);
            }
            return maxAltitude;
        }

        /// <summary>
        /// 5646. 需要教语言的最少人数
        /// 在一个由 m 个用户组成的社交网络里，我们获取到一些用户之间的好友关系。两个用户之间可以相互沟通的条件是他们都掌握同一门语言。
        /// 给你一个整数 n ，数组 languages 和数组 friendships ，它们的含义如下：
        /// 总共有 n 种语言，编号从 1 到 n 。
        /// languages[i] 是第 i 位用户掌握的语言集合。
        /// friendships[i] = [u​​​​​​i​​​, v​​​​​​i] 表示 u​​​​​​​​​​​i​​​​​ 和 vi 为好友关系。
        /// 你可以选择 一门 语言并教会一些用户，使得所有好友之间都可以相互沟通。请返回你 最少 需要教会多少名用户。
        /// 请注意，好友关系没有传递性，也就是说如果 x 和 y 是好友，且 y 和 z 是好友， x 和 z 不一定是好友。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="languages"></param>
        /// <param name="friendships"></param>
        /// <returns></returns>
        public static int MinimumTeachings(int n, int[][] languages, int[][] friendships)
        {
            //    a  b  c  d
            // 1  x  
            // 2     x
            // 3  x
            var peopleLang = new bool[n][];
            for (int i = 0; i < n; i++) {

                peopleLang[i] = new bool[languages.Length];
            }
            for (int i = 0; i < languages.Length; i++) {

                for (int j = 0; j < languages[i].Length; j++) {

                    peopleLang[j][i] = true;
                }
            }

            return 0;
        }

        /// <summary>
        /// 5647. 解码异或后的排列
        /// 给你一个整数数组 perm ，它是前 n 个正整数的排列，且 n 是个 奇数 。
        /// 它被加密成另一个长度为 n - 1 的整数数组 encoded ，满足 encoded[i] = perm[i] XOR perm[i + 1] 。比方说，如果 perm = [1, 3, 2] ，那么 encoded = [2, 1] 。
        /// 给你 encoded 数组，请你返回原始数组 perm 。题目保证答案存在且唯一。
        /// </summary>
        /// <param name="encoded"></param>
        /// <returns></returns>
        public static int[] Decode(int[] encoded)
        {
            if (encoded == null || encoded.Length == 0) return null;

            int allXor = 1;
            int tempXor = 0;
            for (int i = 2; i <= encoded.Length+1; i++) {

                allXor ^= i;
            }

            for (int i = 1; i < encoded.Length; i = i + 2) {

                tempXor ^= encoded[i];
            }

            int first = tempXor ^ allXor;

            var result = new int[encoded.Length+1];
            result[0] = first;
            for (int i = 1; i < result.Length; i++) {

                result[i] = encoded[i - 1] ^ result[i - 1];
            }

            return result;
        }

        /// <summary>
        /// 5661. 替换隐藏数字得到的最晚时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string MaximumTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time)) return time;

            if (time[0] == '?' && time[1] != '?' && time[1] <= '3')
            {

                time = "2" + time.Substring(1);
            }
            else if (time[0] == '?' && time[1] != '?' && time[1] > '3')
            {

                time = "1" + time.Substring(1);
            }
            else if (time[0] == '?' && time[1] == '?') {

                time = "23" + time.Substring(2);
            }

            if (time[1] == '?' && time[0] == '1')
            {

                time = "19" + time.Substring(2);
            }
            else if (time[1] == '?' && time[0] == '2')
            {

                time = "23" + time.Substring(2);
            }
            else if (time[1] == '?' && time[0] == '0') { 
            
                time = "09" + time.Substring(2);
            }

            if (time[3] == '?') {

                time = time.Substring(0, 3) + "5" + time.Substring(4);
            }
            if (time[4] == '?') {

                time = time.Substring(0, 4) + "9";
            }

            return time;
        }

        /// <summary>
        /// 5662. 满足三条件之一需改变的最少字符数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int MinCharacters(string a, string b)
        {
            var mapA = new int[26];
            var mapB = new int[26];

            for (int i = 0; i < a.Length; i++) {

                mapA[a[i] - 'a']++;
            }

            for (int i = 0; i < b.Length; i++)
            {

                mapB[b[i] - 'a']++;
            }

            int maxA = 0;
            int maxB = 0;
            int minA = -1;
            int minB = -1;
            int maxSameCharCount = 0;
            for (int i = 0; i < 26; i++) {

                if (mapA[i] > 0) {

                    maxA = i;
                }

                if (mapB[i] > 0)
                {

                    maxB = i;
                }
                if (mapA[i] > 0 && minA == -1) {

                    minA = i;
                }
                if (mapB[i] > 0 && minB == -1)
                {

                    minB = i;
                }

                if (mapA[i] > 0 && mapB[i] > 0) {
                    maxSameCharCount = Math.Max(maxSameCharCount, mapA[i] + mapB[i]);
                }
            }

            var changeBGreaterA = 0;
            var changeAGreaterB = 0;
            var changeBLessA = 0;
            var changeALessB = 0;
            var changeABEqual = a.Length+b.Length-maxSameCharCount;

            for (int i = 0; i < 26; i++) {

                if (i <= maxA) {

                    changeBGreaterA += mapB[i];
                }

                if (i <= maxB) {

                    changeAGreaterB += mapA[i];
                }

                if (i >= minA) {

                    changeBLessA += mapB[i];
                }

                if (i >= minB)
                {

                    changeALessB += mapA[i];
                }
            }

            var minChange1 = Math.Min(changeALessB, changeBLessA);
            var minChange2 = Math.Min(changeAGreaterB, changeBGreaterA);
            return Math.Min(changeABEqual, Math.Min(minChange1, minChange2));

        }

        private static ListNode MergeList(ListNode head1,ListNode head2) {

            if (head1 == null) return head2;
            if (head2 == null) return head1;

            var currentNode1 = head1;
            var currentNode2 = head2;
            var dummyHead = new ListNode(0);
            var currentNode = dummyHead;
            while (currentNode1 != null || currentNode2 != null) {

                if (currentNode1 == null)
                {
                    currentNode.next = currentNode2;
                    return dummyHead.next;
                }
                if (currentNode2 == null) {

                    currentNode.next = currentNode1;
                    return dummyHead.next;
                } 

                if (currentNode1.val <= currentNode2.val)
                {
                    currentNode.next = currentNode1;
                    currentNode = currentNode.next;
                    currentNode1 = currentNode1.next;
                }
                else {

                    currentNode.next = currentNode2;
                    currentNode = currentNode.next;
                    currentNode2 = currentNode2.next;
                }
            }

            return dummyHead.next;
        }
    }
}
