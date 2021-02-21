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

            var res = SpringWeek_1.LongestSubarray(new int[] { 4, 2, 2, 2, 4, 4, 2, 2 },0);
        }
    }
}
