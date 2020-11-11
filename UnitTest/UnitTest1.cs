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
            int[][] testData = new int[2][] { new int[] {1,2,3 }, new int[] {4,5,6 } };
            var result = MicroSoftSubject_Week4.MinPathSum(testData);
        }
    }
}
