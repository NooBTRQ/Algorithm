using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week8
    {
        /// <summary>
        /// 141. 环形链表
        ///  给定一个链表，判断链表中是否有环。
        /// 如果链表中有某个节点，可以通过连续跟踪 next 指针再次到达，则链表中存在环。 
        /// 为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 
        /// 如果 pos 是 -1，则在该链表中没有环。注意：pos 不作为参数进行传递，仅仅是为了标识链表的实际情况。
        /// 如果链表中存在环，则返回 true 。 否则，返回 false 。
        /// 进阶：
        ///   你能用 O(1)（即，常量）内存解决此问题吗？
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null) return false;

            ListNode slow = head;
            ListNode fast = head;
            do
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            while (slow != fast);

            return true;
        }

        /// <summary>
        /// 142. 环形链表 II
        /// 给定一个链表，返回链表开始入环的第一个节点。 如果链表无环，则返回 null。
        /// 为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 
        /// 如果 pos 是 -1，则在该链表中没有环。注意，pos 仅仅是用于标识环的情况，并不会作为参数传递到函数中。
        /// 说明：不允许修改给定的链表。
        /// 进阶：
        ///   你是否可以使用 O(1) 空间解决此题？
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null) return null;
            if (head.next.next == head) return head;
            ListNode slow = head;
            ListNode fast = head;
            do
            {
                if (fast == null || fast.next == null)
                {
                    return null;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            while (slow != fast);

            slow = head;

            do
            {

                slow = slow.next;
                fast = fast.next;
            } while (slow != fast);

            return slow;
        }

        /// <summary>
        /// 215. 数组中的第K个最大元素
        /// 在未排序的数组中找到第 k 个最大的元素。请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthLargest(int[] nums, int k)
        {
            //构建小顶堆
            int?[] heap = new int?[k + 1];

            for (int i = 0; i < nums.Length; i++) {
                if (i <= k - 1)
                {

                    heap[i + 1] = nums[i];
                    int index = i + 1;
                    while (index > 1) {

                        if (heap[index] < heap[index / 2]) {

                            int temp = heap[index].Value;
                            heap[index] = heap[index / 2];
                            heap[index / 2] = temp;
                            index = index / 2;
                            continue;
                        }

                        break;
                    }
                }
                else if (nums[i] > heap[1]) {
                    
                    heap[1] = nums[i];
                    //堆化
                    int index = 1;
                    while (true)
                    {
                        int swapIndex = index;
                        if (index * 2 <= k && heap[swapIndex] > heap[index * 2]) swapIndex = index * 2;
                        if (index * 2 + 1 <= k && heap[swapIndex] > heap[index * 2 + 1]) swapIndex = index * 2 + 1;
                        if (index == swapIndex) break;

                        int temp = heap[index].Value;
                        heap[index] = heap[swapIndex];
                        heap[swapIndex] = temp;
                        index = swapIndex;
                    }
                }               
            }

            return heap[1].Value;
        }

        /// <summary>
        /// 189. 旋转数组
        /// 给定一个数组，将数组中的元素向右移动 k 个位置，其中 k 是非负数。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public static void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;

            Array.Reverse(nums);
            Array.Reverse(nums, 0, k - 1);
            Array.Reverse(nums, k, nums.Length - k);
        }
    }
}
