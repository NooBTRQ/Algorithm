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
            var dic = new List<string>() { "hot", "dot", "dog", "lot", "log", "app" };
            var result = MicroSoftSubject_Week4.LadderLength("hit", "cog", dic);
        }
    }
}
