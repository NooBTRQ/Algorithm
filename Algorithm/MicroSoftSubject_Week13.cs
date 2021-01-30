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
}
