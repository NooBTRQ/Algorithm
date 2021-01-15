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
            var data = new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 } , new int[] { 1, 0 } , new int[] { 1, 2 } , new int[] {2,1 } , new int[] { 2,2 }};
            MicroSoftSubject_Week11.RemoveStones(data);
        }


    }
}
