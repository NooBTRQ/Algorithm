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
            var result = MicroSoftSubject_Week13.CanFinish(2,new int[][] { new int[] { 0,1},new int[] { 1,0} });
        }


    }
}
