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
        /// 并查集
        /// </summary>
        private class UnionFind
        {

            private int[] parent;
            private int[] rank;
            public UnionFind(int n) {

                parent = new int[n];
                rank = new int[n];
                for (int i = 0; i < n; i++) {

                    parent[i] = i;
                    rank[i] = 1;
                }
            }

            public void Union(int x, int y) {

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
                else {

                    parent[rootY] = rootX;
                }
            }

            public int Find(int x) {
                if (parent[x] != x) {

                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }
        }
    }
}
