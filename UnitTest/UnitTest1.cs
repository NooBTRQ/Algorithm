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

            MicroSoftSubject_Week11.SmallestStringWithSwaps("dcab", new List<IList<int>>() { new List<int>{ 0,3}, new List<int>{1,2 } });
        }
    }
}
