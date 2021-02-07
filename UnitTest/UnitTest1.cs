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

            var result = MicroSoftSubject_Week14.BuildTree(new int[] {3,9,20,15,7 }, new int[] { 9, 3, 15, 20, 7 });
        }


    }
}
