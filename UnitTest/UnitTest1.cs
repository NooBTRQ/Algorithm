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
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            node1.next = node2;
            var node3 = new ListNode(3);
            node2.next = node3;
            var node4 = new ListNode(4);
            node3.next = node4;
            var node5 = new ListNode(5);
            node4.next = node5;
            var node6 = new ListNode(6);
            node5.next = node6;
            var node7 = new ListNode(7);
            //node6.next = node7;
            var result = MicroSoftSubject_Week14.OddEvenList(node1);
        }


    }
}
