using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public static class MicroSoftSubject_Week14
    {
        /// <summary>
        /// 114. 二叉树展开为链表
        /// 给你二叉树的根结点 root ，请你将它展开为一个单链表：
        /// 展开后的单链表应该同样使用 TreeNode ，其中 right 子指针指向链表中下一个结点，而左子指针始终为 null 。
        /// 展开后的单链表应该与二叉树 先序遍历 顺序相同。
        /// </summary>
        /// <param name="root"></param>
        public static void Flatten(TreeNode root)
        {
            if (root == null) return ;
            var currentNode = root;
            while (currentNode != null) {

                if (currentNode.left != null) {

                    var preNode = currentNode.left;
                    while (preNode.right != null) {

                        preNode = preNode.right;
                    }

                    preNode.right = currentNode.right;
                    currentNode.right = currentNode.left;
                    currentNode.left = null;
                    
                }

                currentNode = currentNode.right;
            }
        }

        /// <summary>
        /// 328. 奇偶链表
        /// 给定一个单链表，把所有的奇数节点和偶数节点分别排在一起。请注意，这里的奇数节点和偶数节点指的是节点编号的奇偶性，而不是节点的值的奇偶性。
        /// 请尝试使用原地算法完成。你的算法的空间复杂度应为 O(1)，时间复杂度应为 O(nodes)，nodes 为节点总数。
        /// 说明:
        ///   应当保持奇数节点和偶数节点的相对顺序。
        ///   链表的第一个节点视为奇数节点，第二个节点视为偶数节点，以此类推。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            var current = head.next.next;
            ListNode oddHead = head;
            ListNode evenHead = head.next;
            head.next.next = null;
            head.next = null;
            var tempOdd = oddHead;
            var tempEven = evenHead;
            while (current != null) {

                if (current.next == null) {

                    tempOdd.next = current;
                    tempOdd = tempOdd.next;
                    break;
                }
                tempOdd.next = current;
                tempEven.next = current.next;
                var next = current.next.next;
                current.next.next = null;
                current.next = null;
                tempOdd = tempOdd.next;
                tempEven = tempEven.next;
                current = next;
            }

            tempOdd.next = evenHead;
            return oddHead;
        }
    }
}
