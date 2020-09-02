using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var listNode1 = new ListNode(9);
            //listNode1.next = new ListNode(4);
            //listNode1.next.next = new ListNode(3);
            var listNode2 = new ListNode(1);
            listNode2.next = new ListNode(9);
            listNode2.next.next = new ListNode(9);
            listNode2.next.next.next = new ListNode(9);
            listNode2.next.next.next.next = new ListNode(9);
            listNode2.next.next.next.next.next = new ListNode(9);
            listNode2.next.next.next.next.next.next = new ListNode(9);
            listNode2.next.next.next.next.next.next.next = new ListNode(9);
            listNode2.next.next.next.next.next.next.next.next = new ListNode(9);
            listNode2.next.next.next.next.next.next.next.next.next = new ListNode(9);
            MicroSoftSubject.AddTwoNumbers(listNode1,listNode2);
        }
    }
}
