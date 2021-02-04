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

            var result = MicroSoftSubject_Week14.FindMaxAverage(new int[] { 1, 12, -5, -6, 50, 3 },4);
        }


    }
}
