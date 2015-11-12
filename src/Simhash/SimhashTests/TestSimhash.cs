using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SimhashLib;

namespace SimhashTests
{
    [TestClass]
    public class TestSimhash
    {
        [TestMethod]
        public void test_value()
        {
            List<string> features = new List<string>() { "aaa", "bbb" };
            var simHash = new Simhash(features);
            Assert.AreEqual(simHash.value, 8637903533912358349);
        }
    }
}
