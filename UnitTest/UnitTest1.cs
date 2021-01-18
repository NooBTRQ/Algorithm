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
            var data = new int[3] { 1, 2, 3 };
            MicroSoftSubject_Week12.SubarraySum(data,3);
        }


    }
}
