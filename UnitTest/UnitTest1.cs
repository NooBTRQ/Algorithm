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
            int[] data = new int[5] {5,2,1,6,3};
            MicroSoftSubject_Week4.QuickSort(ref data);
        }
    }
}
