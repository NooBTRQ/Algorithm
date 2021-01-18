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
            var node1 = new MicroSoftSubject_Week11.Node(1);
            var node2 = new MicroSoftSubject_Week11.Node(2);
            var node3 = new MicroSoftSubject_Week11.Node(3);
            var node4 = new MicroSoftSubject_Week11.Node(4);
            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);

            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);

            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);

            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

            var result = MicroSoftSubject_Week11.CloneGraph(node1);
        }


    }
}
