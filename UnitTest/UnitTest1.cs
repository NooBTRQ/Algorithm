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
            TreeNode node1 = new TreeNode(10);
            TreeNode node2 = new TreeNode(12);
            TreeNode node3 = new TreeNode(6);
            node1.left = node2;
            node1.right = node3;
            TreeNode node4 = new TreeNode(8);
            TreeNode node5 = new TreeNode(3);
            node2.left = node4;
            node2.right = node5;
            TreeNode node6 = new TreeNode(11);
            node4.left = node6;

            TreeNode node7 = new TreeNode(10);
            TreeNode node8 = new TreeNode(12);
            TreeNode node9 = new TreeNode(6);
            node7.left = node8;
            node7.right = node9;
            TreeNode node10 = new TreeNode(8);
            node8.left = node10;
            var res = SpringWeek_2.IsSubStructure(node1,node7);
        }
    }
}
