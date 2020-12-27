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
            var result = MicroSoftSubject_Week8.FindKthLargest(new int[] { 7,6,5,4,3,2,1},5);
        }
    }
}
