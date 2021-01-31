using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week13
    {
        /// <summary>
        /// 347. 前 K 个高频元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] TopKFrequent(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) return null;

            var frequentDic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {

                if (frequentDic.ContainsKey(nums[i]))
                {

                    frequentDic[nums[i]]++;
                }
                else
                {

                    frequentDic[nums[i]] = 1;
                }
            }

            var minHeap = new int?[k + 1];
            int count = 1;
            foreach (var kv in frequentDic)
            {
                if (count <= k) {

                    minHeap[count] = kv.Key;

                    var index = count;
                    while (index > 1) {

                        if (frequentDic[minHeap[index].Value] <frequentDic[minHeap[index / 2].Value]) {

                            int temp = minHeap[index].Value;
                            minHeap[index] = minHeap[index / 2];
                            minHeap[index / 2] = temp;
                            index = index / 2;
                            continue;
                        }
                        break;
                    }
                    count++;
                }else if(kv.Value > frequentDic[minHeap[1].Value]){

                    minHeap[1] = kv.Key;
                    int index = 1;
                    while (true) {

                        int swapIndex = index;
                        if (index * 2 <= k && frequentDic[minHeap[swapIndex].Value] > frequentDic[minHeap[swapIndex * 2].Value]) swapIndex = index * 2;
                        if (index * 2 + 1 <= k && frequentDic[minHeap[swapIndex].Value] > frequentDic[minHeap[index * 2 + 1].Value]) swapIndex = index * 2 + 1;

                        if (index == swapIndex) break;

                        int temp = minHeap[swapIndex].Value;
                        minHeap[swapIndex] = minHeap[index].Value;
                        minHeap[index] = temp;
                        index = swapIndex;
                    }

                    count++;
                }
            }

            var result = new int[k];
            for (int i = 0; i < result.Length; i++) {

                result[i] = minHeap[i + 1].Value;
            }

            return result;
        }

        /// <summary>
        /// 207. 课程表
        /// 你这个学期必须选修 numCourse 门课程，记为 0 到 numCourse-1 。
        /// 在选修某些课程之前需要一些先修课程。 例如，想要学习课程 0 ，你需要先完成课程 1 ，我们用一个匹配来表示他们：[0,1]
        /// 给定课程总量以及它们的先决条件，请你判断是否可能完成所有课程的学习？
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public static bool CanFinish(int numCourses, int[][] prerequisites) {

            if (prerequisites == null || prerequisites.Length <= 1) return true;

            var inDegree = new int[numCourses];
            var edgeArr = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++) {

                edgeArr[i] = new List<int>();
            }
            for (int i = 0; i < prerequisites.Length; i++) {

                inDegree[prerequisites[i][1]]++;
                edgeArr[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            var courseQueue = new Queue<int>();
            var canFinish = new List<int>();
            for (int i = 0; i < numCourses; i++) {

                if (inDegree[i] == 0) { 
                    courseQueue.Enqueue(i);
                    canFinish.Add(i);
                }               
            }

            while (courseQueue.Count > 0) {

                int course = courseQueue.Dequeue();
                foreach (int c in edgeArr[course]) {

                    inDegree[c]--;
                    if (inDegree[c] == 0) {
                        canFinish.Add(c);
                        courseQueue.Enqueue(c);
                    }
                }
            }

            return numCourses == canFinish.Count;
        }

        /// <summary>
        /// 210. 课程表 II
        /// 现在你总共有 n 门课需要选，记为 0 到 n-1。
        /// 在选修某些课程之前需要一些先修课程。 例如，想要学习课程 0 ，你需要先完成课程 1 ，我们用一个匹配来表示他们: [0,1]
        /// 给定课程总量以及它们的先决条件，返回你为了学完所有课程所安排的学习顺序。
        /// 可能会有多个正确的顺序，你只要返回一种就可以了。如果不可能完成所有课程，返回一个空数组。
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var result = new List<int>();

            var inDegree = new int[numCourses];
            var courseEdge = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++) {

                courseEdge[i] = new List<int>();
            }
            for (int i = 0; i < prerequisites.Length; i++) {

                inDegree[prerequisites[i][0]]++;
                courseEdge[prerequisites[i][1]].Add(prerequisites[i][0]);
            }

            var courseQueue = new Queue<int>();
            for (int i = 0; i < numCourses; i++) {

                if (inDegree[i] == 0) {

                    courseQueue.Enqueue(i);
                }                
            }

            while (courseQueue.Count > 0) {

                var course = courseQueue.Dequeue();
                result.Add(course);
                foreach(var c in courseEdge[course]) {

                    inDegree[c]--;
                    if (inDegree[c] == 0) {

                        courseQueue.Enqueue(c);
                    }
                }
            }

            return result.Count == numCourses? result.ToArray():new int[] { };
        }

        /// <summary>
        /// 39. 组合总和
        /// 给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
        /// candidates 中的数字可以无限制重复被选取。
        /// 说明：
        ///   所有数字（包括 target）都是正整数。
        ///   解集不能包含重复的组合。 
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();

            CombinationSumDFS(candidates, target, 0, new List<int>(), result);
            return result;
        }

        /// <summary>
        /// 419. 甲板上的战舰
        /// 给定一个二维的甲板， 请计算其中有多少艘战舰。 战舰用 'X'表示，空位用 '.'表示。 你需要遵守以下规则：
        ///   给你一个有效的甲板，仅由战舰或者空位组成。
        ///   战舰只能水平或者垂直放置。换句话说,战舰只能由 1xN(1 行, N 列)组成，或者 Nx1(N 行, 1 列)组成，其中N可以是任意大小。
        ///   两艘战舰之间至少有一个水平或垂直的空位分隔 - 即没有相邻的战舰。
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static int CountBattleships(char[][] board)
        {
            if (board == null || board.Length == 0) return 0;
            var result = 0;
            //寻找舰头
            for (int i = 0; i < board.Length; i++) {

                for (int j = 0; j < board[0].Length; j++) {

                    if (board[i][j] == 'X' && (i == 0 || board[i - 1][j] == '.') && (j == 0 || board[i][j - 1] == '.')) {

                        result++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 722. 删除注释
        /// 给一个 C++ 程序，删除程序中的注释。这个程序source是一个数组，其中source[i]表示第i行源码。 这表示每行源码由\n分隔。
        /// 在 C++ 中有两种注释风格，行内注释和块注释。
        /// 字符串// 表示行注释，表示//和其右侧的其余字符应该被忽略。
        /// 字符串/* 表示一个块注释，它表示直到*/的下一个（非重叠）出现的所有字符都应该被忽略。
        /// （阅读顺序为从左到右）非重叠是指，字符串/*/并没有结束块注释，因为注释的结尾与开头相重叠。
        /// 第一个有效注释优先于其他注释：如果字符串//出现在块注释中会被忽略。 
        /// 同样，如果字符串/*出现在行或块注释中也会被忽略。
        /// 如果一行在删除注释之后变为空字符串，那么不要输出该行。即，答案列表中的每个字符串都是非空的。
        /// 样例中没有控制字符，单引号或双引号字符。比如，source = "string s = "/* Not a comment. */";" 不会出现在测试样例里。
        /// （此外，没有其他内容（如定义或宏）会干扰注释。）
        /// 我们保证每一个块注释最终都会被闭合， 所以在行或块注释之外的/*总是开始新的注释。
        /// 最后，隐式换行符可以通过块注释删除。 有关详细信息，请参阅下面的示例。
        /// 从源代码中删除注释后，需要以相同的格式返回源代码。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IList<string> RemoveComments(string[] source)
        {
            bool inBlock = false;
            StringBuilder newLine = new StringBuilder();
            var result = new List<string>();
            foreach (var str in source) {

                if (!inBlock) newLine = new StringBuilder();
                int i = 0;
                while (i<str.Length) {

                    if (!inBlock && i+1 < str.Length && str[i] == '/' && str[i + 1] == '/')
                    {
                        break;
                    }
                    else if (!inBlock && i + 1 < str.Length && str[i] == '/' && str[i + 1] == '*')
                    {

                        i++;
                        inBlock = true;
                    }
                    else if (inBlock && i+1<str.Length && str[i] == '*' && str[i + 1] == '/')
                    {

                        i++;
                        inBlock = false;
                    }
                    else if(!inBlock) {

                        newLine.Append(str[i]);
                    }
                    i++;
                }

                if (!inBlock && newLine.Length > 0) {

                    result.Add(newLine.ToString());
                }
                
            }

            return result;
        }

        private static void CombinationSumDFS(int[] candidates, int target, int idx, List<int> combine, List<IList<int>> result) {

            if (idx == candidates.Length) return;
            if (target == 0) {

                result.Add(new List<int>(combine));
                return;
            }

            CombinationSumDFS(candidates, target, idx + 1, combine, result);

            if (target >= candidates[idx]) {

                combine.Add(candidates[idx]);
                CombinationSumDFS(candidates, target - candidates[idx], idx, combine, result);
                combine.Remove(candidates[idx]);
            }
        }
    }

    /// <summary>
    /// 384. 打乱数组
    /// 给你一个整数数组 nums ，设计算法来打乱一个没有重复元素的数组。
    /// 实现 Solution class:
    ///   Solution(int[] nums) 使用整数数组 nums 初始化对象
    ///   int[] reset() 重设数组到它的初始状态并返回
    ///   int[] shuffle() 返回数组随机打乱后的结果
    /// </summary>
    public class Solution
    {
        private int[] OriginalArr;
        private int[] ShuffleArr;
        Random random;
        public Solution(int[] nums)
        {
            OriginalArr = (int [])nums.Clone();
            ShuffleArr = (int[])nums.Clone();
            random = new Random();
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            ShuffleArr = (int[])OriginalArr.Clone();
            return ShuffleArr;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            for (int i = 0; i < ShuffleArr.Length; i++) {

                var swapIndex = random.Next(i,ShuffleArr.Length);
                var temp = ShuffleArr[i];
                ShuffleArr[i] = ShuffleArr[swapIndex];
                ShuffleArr[swapIndex] = temp;
            }

            return ShuffleArr;
        }
    }

    /// <summary>
    /// 380. 常数时间插入、删除和获取随机元素
    /// 设计一个支持在平均 时间复杂度 O(1) 下，执行以下操作的数据结构。
    /// insert(val)：当元素 val 不存在时，向集合中插入该项。
    /// remove(val)：元素 val 存在时，从集合中移除该项。
    /// getRandom：随机返回现有集合中的一项。每个元素应该有相同的概率被返回。
    /// </summary>
    public class RandomizedSet
    {
        private List<int> itemList;
        private Dictionary<int, int> itemMap;
        private Random random;
        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            itemList = new List<int>();
            itemMap = new Dictionary<int, int>();
            random = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (!itemMap.ContainsKey(val)) {

                itemList.Add(val);
                itemMap.Add(val, itemList.Count - 1);
                return true;
            }
            return false;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (itemMap.ContainsKey(val)) {

                int valIndex = itemMap[val];

                itemList[valIndex] = itemList[itemList.Count - 1];
                itemMap[itemList[valIndex]] = valIndex;
                itemList.RemoveAt(itemList.Count - 1);
                itemMap.Remove(val);
                return true;
            }

            return false;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            var randomNum = random.Next(itemList.Count);
            return itemList[randomNum];
        }
    }
}
