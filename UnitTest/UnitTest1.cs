using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var head = new ListNode(1);
            var node1 = new ListNode(2);
            head.next = node1;
            var node2 = new ListNode(3);
            node1.next = node2;
            var node3 = new ListNode(4);
            node2.next = node3;
            var node4 = new ListNode(5);
            node3.next = node4;
            MicroSoftSubject_Week11.ReorderList(head);
        }


    }
}
