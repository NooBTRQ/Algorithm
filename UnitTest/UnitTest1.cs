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
            var data = new char[] { 't', 'h', 'e'};
            MicroSoftSubject_Week12.ReverseWords(data);
        }


    }
}
