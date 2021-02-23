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
            var res = SpringWeek_2.MaxSatisfied(new int[] { 4,10,10},new int[] {1,1,0 },2);
        }
    }
}
