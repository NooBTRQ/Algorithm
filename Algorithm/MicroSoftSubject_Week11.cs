﻿using System;
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

            // 第 1 步：将任意交换的结点对输入并查集
            int len = s.Length;
            UnionFind unionFind = new UnionFind(len);
            foreach (List<int> pair in pairs)
            {
                int index1 = pair[0];
                int index2 = pair[1];
                unionFind.union(index1, index2);
            }

            // 第 2 步：构建映射关系
            char[] charArray = s.ToCharArray();
            // key：连通分量的代表元，value：同一个连通分量的字符集合（保存在一个优先队列中）
            Dictionary<int, List<char>> hashMap = new Dictionary<int, List<char>>(len);
            for (int i = 0; i < len; i++)
            {
                int root = unionFind.find(i);
                if (hashMap.ContainsKey(root))
                {
                    hashMap[root].Add(charArray[i]);
                    hashMap[root].Sort((x,y) => x < y ? 1 : -1);
                }
                else
                {
                    List<char> minHeap = new List<char>();
                    minHeap.Add(charArray[i]);
                    hashMap.Add(root, minHeap);
                }

            }

            // 第 3 步：重组字符串
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                int root = unionFind.find(i);
                stringBuilder.Append(hashMap[root][0]);
            }
            return stringBuilder.ToString();
        }

        private class UnionFind
        {

            private int[] parent;
            /**
             * 以 i 为根结点的子树的高度（引入了路径压缩以后该定义并不准确）
             */
            private int[] rank;

            public UnionFind(int n)
            {
                this.parent = new int[n];
                this.rank = new int[n];
                for (int i = 0; i < n; i++)
                {
                    this.parent[i] = i;
                    this.rank[i] = 1;
                }
            }

            public void union(int x, int y)
            {
                int rootX = find(x);
                int rootY = find(y);
                if (rootX == rootY)
                {
                    return;
                }

                if (rank[rootX] == rank[rootY])
                {
                    parent[rootX] = rootY;
                    // 此时以 rootY 为根结点的树的高度仅加了 1
                    rank[rootY]++;
                }
                else if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                    // 此时以 rootY 为根结点的树的高度不变
                }
                else
                {
                    // 同理，此时以 rootX 为根结点的树的高度不变
                    parent[rootY] = rootX;
                }
            }

            public int find(int x)
            {
                if (x != parent[x])
                {
                    parent[x] = find(parent[x]);
                }
                return parent[x];
            }
        }
    }
}
