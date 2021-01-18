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
            foreach (var kv in map) {

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

                mod = (mod * 2) + A[i];
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

        /// <summary>
        /// 803. 打砖块
        /// 有一个 m x n 的二元网格，其中 1 表示砖块，0 表示空白。砖块 稳定（不会掉落）的前提是：
        ///   一块砖直接连接到网格的顶部，或者
        ///   至少有一块相邻（4 个方向之一）砖块 稳定 不会掉落时
        /// 给你一个数组 hits ，这是需要依次消除砖块的位置。每当消除 hits[i] = (rowi, coli) 位置上的砖块时，对应位置的砖块（若存在）会消失，然后其他的砖块可能因为这一消除操作而掉落。一旦砖块掉落，它会立即从网格中消失（即，它不会落在其他稳定的砖块上）。
        /// 返回一个数组 result ，其中 result[i] 表示第 i 次消除操作对应掉落的砖块数目。
        /// 注意，消除可能指向是没有砖块的空白位置，如果发生这种情况，则没有砖块掉落。
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="hits"></param>
        /// <returns></returns>
        public static int[] HitBricks(int[][] grid, int[][] hits)
        {
            int h = grid.Length, w = grid[0].Length;

            UnionFind3 uf = new UnionFind3(h * w + 1);
            int[][] status = new int[h][];
            for (int i = 0; i < h; i++)
            {
                status[i] = new int[grid[0].Length];
                for (int j = 0; j < w; j++)
                {
                    status[i][j] = grid[i][j];
                }
            }
            for (int i = 0; i < hits.Length; i++)
            {
                status[hits[i][0]][hits[i][1]] = 0;
            }
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (status[i][j] == 1)
                    {
                        if (i == 0)
                        {
                            uf.Merge(h * w, i * w + j);
                        }
                        if (i > 0 && status[i - 1][j] == 1)
                        {
                            uf.Merge(i * w + j, (i - 1) * w + j);
                        }
                        if (j > 0 && status[i][j - 1] == 1)
                        {
                            uf.Merge(i * w + j, i * w + j - 1);
                        }
                    }
                }
            }
            int[][] directions = { new int[]{ 0, 1 }, new int[]{ 1, 0 }, new int[]{ 0, -1 }, new int[]{ -1, 0 } };
            int[] ret = new int[hits.Length];
            for (int i = hits.Length - 1; i >= 0; i--)
            {
                int r = hits[i][0], c = hits[i][1];
                if (grid[r][c] == 0)
                {
                    continue;
                }
                int prev = uf.Size(h * w);

                if (r == 0)
                {
                    uf.Merge(c, h * w);
                }
                foreach (int[] direction in directions)
                {
                    int dr = direction[0], dc = direction[1];
                    int nr = r + dr, nc = c + dc;

                    if (nr >= 0 && nr < h && nc >= 0 && nc < w)
                    {
                        if (status[nr][nc] == 1)
                        {
                            uf.Merge(r * w + c, nr * w + nc);
                        }
                    }
                }
                int size = uf.Size(h * w);
                ret[i] = Math.Max(0, size - prev - 1);
                status[r][c] = 1;
            }
            return ret;
        }

        /// <summary>
        /// 143. 重排链表
        /// 给定一个单链表 L：L0→L1→…→Ln-1→Ln ，
        /// 将其重新排列后变为： L0→Ln→L1→Ln-1→L2→Ln-2→…
        /// 你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
        /// </summary>
        /// <param name="head"></param>
        public static void ReorderList(ListNode head)
        {
            if (head == null || head.next == null) return;

            var nodeStack = new Stack<ListNode>();
            var current = head;
            while (current != null) {

                nodeStack.Push(current);
                current = current.next;
            }
            current = head;
            while (current != null) {
                var nextNode = current.next;
                current.next = nodeStack.Pop();
                if (nextNode == current.next) { 
                    current.next.next = null;
                    break;
                }
                if (current.next == current) {

                    current.next = null;
                    break;
                }
                current.next.next = nextNode;
                current = nextNode;
            }

            //1 -> 2 -> 3 ->4 -> 5
            //1 -> 2 -> 3 ->4

        }

        /// <summary>
        /// 78. 子集
        /// 给你一个整数数组 nums ，返回该数组所有可能的子集（幂集）。解集不能包含重复的子集。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return result;

            int n = nums.Length;
            for (int mask = 0; mask < (1 << n); mask++) {
                var t = new List<int>();
                for (int i = 0; i < n; i++) {

                    if ((mask & (1 << i)) != 0) {

                        t.Add(nums[i]);
                    }
                }

                result.Add(t);
            }

            return result;
        }

        /// <summary>
        /// 133. 克隆图
        /// 给你无向 连通 图中一个节点的引用，请你返回该图的 深拷贝（克隆）。
        /// 图中的每个节点都包含它的值 val（int） 和其邻居的列表
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Node CloneGraph(Node node)
        {
            if (node == null) return null;

            var newHead = new Node(node.val);
            newHead.neighbors = node.neighbors;
            var nodeQueue = new Queue<Node>();
            var nodeDic = new Dictionary<int, Node>();
            nodeQueue.Enqueue(newHead);
            nodeDic[node.val] = newHead;
            while (nodeQueue.Count > 0) {

                int count = nodeQueue.Count;
                for (int i = 0; i < count; i++) {
                    var currentNode = nodeQueue.Dequeue();
                    if (currentNode.neighbors == null) continue;
                    var newNeighbors = new List<Node>();
                    for (int j = 0; j < currentNode.neighbors.Count; j++) {
                        
                        if (nodeDic.ContainsKey(currentNode.neighbors[j].val))
                        {

                            newNeighbors.Add(nodeDic[currentNode.neighbors[j].val]);
                        }
                        else {

                            var newNeighbor = new Node(currentNode.neighbors[j].val);
                            newNeighbor.neighbors = currentNode.neighbors[j].neighbors;
                            newNeighbors.Add(newNeighbor);
                            nodeQueue.Enqueue(newNeighbor);
                            nodeDic[newNeighbor.val] = newNeighbor;
                        }
                        
                    }
                    currentNode.neighbors = newNeighbors;
                }
            }
            return newHead;
        }

        /// <summary>
        /// 1232. 缀点成线
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public static bool CheckStraightLine(int[][] coordinates)
        {
            int deltaX = coordinates[0][0], deltaY = coordinates[0][1];
            int n = coordinates.Length;
            for (int i = 0; i < n; ++i)
            {
                coordinates[i][0] -= deltaX;
                coordinates[i][1] -= deltaY;
            }
            int A = coordinates[1][1], B = -coordinates[1][0];
            for (int i = 2; i < n; ++i)
            {
                int x = coordinates[i][0], y = coordinates[i][1];
                if (A * x + B * y != 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 71. 简化路径
        /// 以 Unix 风格给出一个文件的绝对路径，你需要简化它。或者换句话说，将其转换为规范路径。
        /// 在 Unix 风格的文件系统中，一个点（.）表示当前目录本身；此外，两个点 （..） 表示将目录切换到上一级（指向父目录）；
        /// 两者都可以是复杂相对路径的组成部分。更多信息请参阅：Linux / Unix中的绝对路径 vs 相对路径
        /// 请注意，返回的规范路径必须始终以斜杠 / 开头，并且两个目录名之间必须只有一个斜杠 /。
        /// 最后一个目录名（如果存在）不能以 / 结尾。此外，规范路径必须是表示绝对路径的最短字符串。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string SimplifyPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return "";
            if (!path.Contains("/")) return path + "/";
            var pathArr = path.Split('/');
            var pathList = new List<string>();
            foreach (var str in pathArr) {

                if (str == ".") continue;
                else if (str == "..")
                {

                    if (pathList.Count > 0) pathList.RemoveAt(pathList.Count - 1);
                }
                else if (string.IsNullOrEmpty(str)) continue;
                else pathList.Add(str);
            }

            return "/" + string.Join("/", pathList);
        }

        private static int MaxLengthDFS(IList<string> arr, int start, int bitMask) {

            if (start == arr.Count) return 0;

            int result = 0;
            for (int i = start; i < arr.Count; i++) {

                int bit = GetBitMask(arr[i]);
                if (bit == 0 || (bit & bitMask) != 0) continue;

                result = Math.Max(result, MaxLengthDFS(arr, i + 1, bit | bitMask) + arr[i].Length);
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
            public void Union(int x, int y) {

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

        private class UnionFind3 {

            int[] f;
            int[] sz;

            public UnionFind3(int n)
            {
                f = new int[n];
                sz = new int[n];
                for (int i = 0; i < n; i++)
                {
                    f[i] = i;
                    sz[i] = 1;
                }
            }

            public int Find(int x)
            {
                if (f[x] == x)
                {
                    return x;
                }
                int newf = Find(f[x]);
                f[x] = newf;
                return f[x];
            }

            public void Merge(int x, int y)
            {
                int fx = Find(x), fy = Find(y);
                if (fx == fy)
                {
                    return;
                }
                f[fx] = fy;
                sz[fy] += sz[fx];
            }

            public int Size(int x)
            {
                return sz[Find(x)];
            }
        }

        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
    }
}
