using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week4
    {
        /// <summary>
        /// 253. Meeting Rooms II
        /// Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), 
        /// find the minimum number of conference rooms required.
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) {

                return 0;
            }
            intervals = intervals.OrderBy(e => e[0]).ToArray();
            var heap = new MinHeap();
            heap.Add(intervals[0][1]);
            
            for (int i = 1; i < intervals.Count(); i++) {
                if (heap.HeapPeak() <= intervals[i][0]) heap.Poll();
                heap.Add(intervals[i][1]);
            }
            return heap.Count;
        }

        /// <summary>
        /// 22. Generate Parentheses
        /// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        /// Input: n = 3
        /// Output: ["((()))","(()())","(())()","()(())","()()()"]
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<string> GenerateParenthesis(int n)
        {
            if (n == 0) return new List<string>() {};

            var result = new List<string>();
            DFSGenerateParenthesis("", n, n, result);
            return result;
        }

        /// <summary>
        /// 56. Merge Intervals
        /// Given a collection of intervals, merge all overlapping intervals.
        /// Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
        /// Output: [[1,6],[8,10],[15,18]]
        /// Explanation: Since intervals[1, 3] and[2, 6] overlaps, merge them into[1, 6].
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 1) return intervals;
            intervals = intervals.OrderBy(e => e[0]).ToArray();
            var result = new List<int[]>();
            result.Add(intervals[0]);
            for (int i = 1; i < intervals.Count(); i++)
            {
                if (intervals[i][0] <= result.Last()[1]) {

                    int newEnd = Math.Max(intervals[i][1], result.Last()[1]);
                    result.Last()[1] = newEnd;
                    continue;
                }
                result.Add(intervals[i]);
            }

            return result.ToArray();
        }

        public static void DFSGenerateParenthesis(string tmpStr,int left,int right,List<string> res) {

            if (left == 0 && right == 0) { 

                res.Add(tmpStr);
            }

            if (left >right) {

                return;
            }

            if (left > 0) {

                DFSGenerateParenthesis(tmpStr + "(", left - 1, right, res);
            }

            if (right > 0) {

                DFSGenerateParenthesis(tmpStr + ")", left, right - 1, res);
            }
        }
    }

    public class MinHeap {

        private List<int> ItemList;
        public int Count { get { return ItemList.Count-1; } }

        public MinHeap() {

            ItemList = new List<int>() { default};
        }

        public int HeapPeak() {

            if(ItemList.Count>1) return ItemList[1];
            throw new IndexOutOfRangeException();
        }
        public void Poll() {

            ItemList.RemoveAt(1);
            ItemList.Insert(1, ItemList.Last());
            ItemList.RemoveAt(ItemList.Count - 1);
            //堆化
            int currentIndex = 1;
            while (currentIndex <= (ItemList.Count-1) / 2) {

                int nextLeft = currentIndex * 2;
                if (nextLeft + 1 <= ItemList.Count - 1 && ItemList[nextLeft] > ItemList[nextLeft + 1]) {

                    nextLeft++;
                }
                if (ItemList[currentIndex] > ItemList[nextLeft]) {

                    int currentValue = ItemList[currentIndex];
                    ItemList[currentIndex] = ItemList[nextLeft];
                    ItemList[nextLeft] = currentValue;
                    currentIndex = nextLeft;
                    continue;
                }
                break;
            }
        }

        public void Add(int item) {

            ItemList.Add(item);
            //堆化
            int currentIndex = ItemList.Count-1;
            while (currentIndex > 1) {

                int next = currentIndex / 2;
                if (ItemList[currentIndex] >= ItemList[next]) break;
                int currentValue = ItemList[currentIndex];
                ItemList[currentIndex] = ItemList[next];
                ItemList[next] = currentValue;
                currentIndex = next;
            }
        }
    }
}
