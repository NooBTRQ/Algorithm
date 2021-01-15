using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week11
    {
        /// <summary>
        /// 1202. 交换字符串中的元素
        /// 给你一个字符串 s，以及该字符串中的一些「索引对」数组 pairs，其中 pairs[i] = [a, b] 表示字符串中的两个索引（编号从 0 开始）。
        /// 你可以 任意多次交换 在 pairs 中任意一对索引处的字符。
        /// 返回在经过若干次交换后，s 可以变成的按字典序最小的字符串。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public static string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            if (pairs.Count == 0)
            {
                return s;
            }
       
            //构建并查集
            UnionFind uf = new UnionFind(s.Length);
            foreach (var pair in pairs) {

                uf.Union(pair[0], pair[1]);
            }

            //构建映射关系
            var charArr = s.ToCharArray();
            Dictionary<int, List<char>> map = new Dictionary<int, List<char>>();
            for (int i = 0; i < charArr.Length; i++) {

                var root = uf.Find(i);
                if (map.ContainsKey(root))
                {

                    map[root].Add(charArr[i]);                   
                }
                else {

                    map[root] = new List<char>() { charArr[i] };
                }
            }
            foreach(var kv in map) { 
            
                kv.Value.Sort((x, y) => x < y ? 1 : -1);
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < charArr.Length; i++) {

                int root = uf.Find(i);
                char c = map[root][map[root].Count - 1];
                map[root].RemoveAt(map[root].Count - 1);
                result.Append(c);
            }

            return result.ToString();
        }

        /// <summary>
        /// 684. 冗余连接
        /// 在本问题中, 树指的是一个连通且无环的无向图。
        /// 输入一个图，该图由一个有着N个节点(节点值不重复1, 2, ..., N) 的树及一条附加的边构成。
        /// 附加的边的两个顶点包含在1到N中间，这条附加的边不属于树中已存在的边。
        /// 结果图是一个以边组成的二维数组。每一个边的元素是一对[u, v] ，满足 u<v，表示连接顶点u 和v的无向图的边。
        /// 返回一条可以删去的边，使得结果图是一个有着N个节点的树。如果有多个答案，则返回二维数组中最后出现的边。
        /// 答案边[u, v] 应满足相同的格式 u<v。
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static int[] FindRedundantConnection(int[][] edges)
        {
            var uf = new UnionFind(edges.Length + 1);
            foreach (var edge in edges) {

                if (uf.Find(edge[0]) == uf.Find(edge[1])) {

                    return edge;
                }
                uf.Union(edge[0], edge[1]);
            }
            return null;
        }

        /// <summary>
        /// 1239. 串联字符串的最大长度
        /// 给定一个字符串数组 arr，字符串 s 是将 arr 某一子序列字符串连接所得的字符串，
        /// 如果 s 中的每一个字符都只出现过一次，那么它就是一个可行解。
        /// 请返回所有可行解 s 中最长长度。
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int MaxLength(IList<string> arr)
        {
            if (arr == null || arr.Count == 0) return 0;
            if (arr.Count == 1) return arr[0].Length;

            return MaxLengthDFS(arr, 0, 0);
        }

        /// <summary>
        /// 1018. 可被 5 整除的二进制前缀
        /// 给定由若干 0 和 1 组成的数组 A。我们定义 N_i：从 A[0] 到 A[i] 的第 i 个子数组被解释为一个二进制数（从最高有效位到最低有效位）。
        /// 返回布尔值列表 answer，只有当 N_i 可以被 5 整除时，答案 answer[i] 为 true，否则为 false。
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static IList<bool> PrefixesDivBy5(int[] A)
        {
            var result = new List<bool>();
            var mod = 0;
            for (int i = 0; i < A.Length; i++) {

                mod = (mod*2) + A[i];
                mod = mod % 5;
                if (mod == 0)
                {

                    result.Add(true);
                }
                else {

                    result.Add(false);
                }
            }

            return result;
        }

        /// <summary>
        /// 74. 搜索二维矩阵
        /// 编写一个高效的算法来判断 m x n 矩阵中，是否存在一个目标值。该矩阵具有如下特性：
        /// 每行中的整数从左到右按升序排列。
        /// 每行的第一个整数大于前一行的最后一个整数。
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0) return false;
            if (matrix[matrix.Length - 1][matrix[0].Length - 1] < target) return false;
            if (matrix[0][0] > target) return false;
            //int row = 0;
            //for (int i = 0; i < matrix.Length; i++) {
            //    row = i;
            //    if (i + 1 < matrix.Length && matrix[i + 1][0] > target) {
            //        break;
            //    }
            //}
            //bool result = false;
            //for (int j = 0; j < matrix[0].Length; j++) {

            //    if (matrix[row][j] == target) {

            //        result = true;
            //    }
            //}

            //return result;

            // 二分法

            int m = matrix.Length;
            int n = matrix[0].Length;
            int left = 0;
            int right = m * n - 1;

            while (left <= right) {

                int mid = (left + right) >> 1;

                if (matrix[mid / n][mid % n] == target) return true;

                else if (matrix[mid / n][mid % n] < target) left = mid + 1;
                else right = mid - 1;
            }

            return false;
        }

        /// <summary>
        /// 947. 移除最多的同行或同列石头
        /// n 块石头放置在二维平面中的一些整数坐标点上。每个坐标点上最多只能有一块石头。
        /// 如果一块石头的 同行或者同列 上有其他石头存在，那么就可以移除这块石头。
        /// 给你一个长度为 n 的数组 stones ，其中 stones[i] = [xi, yi] 表示第 i 块石头的位置，返回 可以移除的石子 的最大数量。
        /// </summary>
        public static int RemoveStones(int[][] stones)
        {
            if (stones == null || stones.Length <= 1) return 0;

            UnionFind2 uf = new UnionFind2();
            foreach (var point in stones) {

                uf.Union(point[0] + 10001, point[1]);
            }

            return stones.Length - uf.Count;
        }

        private static int MaxLengthDFS(IList<string> arr,int start,int bitMask) {

            if (start == arr.Count) return 0;

            int result = 0;
            for (int i = start; i < arr.Count; i++) {

                int bit = GetBitMask(arr[i]);
                if (bit == 0 || (bit & bitMask) != 0) continue;

                result = Math.Max(result, MaxLengthDFS(arr, i + 1,bit | bitMask) + arr[i].Length);
            }

            return result;
        }

        private static int GetBitMask(string s) {

            int bit = 0;
            int bitMask = 0;
            foreach (var c in s)
            {

                bit = 1 << (c - 'a');
                if ((bit & bitMask) != 0)
                {

                    bitMask = 0;
                    break;
                }
                bitMask |= bit;
            }

            return bitMask;
        }

        /// <summary>
        /// 并查集
        /// </summary>
        private class UnionFind
        {

            private int[] parent;
            private int[] rank;
            public UnionFind(int n)
            {

                parent = new int[n];
                rank = new int[n];
                for (int i = 0; i < n; i++)
                {

                    parent[i] = i;
                    rank[i] = 1;
                }
            }

            public void Union(int x, int y)
            {

                int rootX = Find(x);
                int rootY = Find(y);

                if (rootX == rootY) return;

                if (rank[rootX] == rank[rootY])
                {

                    parent[rootX] = rootY;
                    rank[rootY]++;
                }
                else if (rank[rootX] < rank[rootY])
                {

                    parent[rootX] = rootY;
                }
                else
                {

                    parent[rootY] = rootX;
                }
            }

            public int Find(int x)
            {
                if (parent[x] != x)
                {

                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }
        }

        private class UnionFind2 {

            Dictionary<int, int> parent = new Dictionary<int, int>();
            private int _count = 0;
            public int Count { get { return _count; } }
            public void Union(int x,int y) {

                var rootX = Find(x);
                var rootY = Find(y);
                if (rootX == rootY) return;

                parent[rootX] = y;
                _count--;
            }

            public int Find(int x) {

                if (!parent.ContainsKey(x)) {

                    parent[x] = x;
                    _count++;
                }

                if (x != parent[x]) {

                    parent[x] = Find(parent[x]);
                }

                return parent[x];
            }

        }
    }
}
