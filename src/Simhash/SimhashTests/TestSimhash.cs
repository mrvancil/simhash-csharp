using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SimhashLib;
using System.Numerics;

namespace SimhashTests
{
    [TestClass]
    public class TestSimhash
    {
        [TestMethod]
        public void test_hashtostringvalue()
        {
            var simHash = new Simhash();
            string val = simHash.hashfunc_hashtostring("aaa");
            Assert.AreEqual(val, "47bce5c74f589f4867dbd57e9ca9f808");
        }
        [TestMethod]
        public void test_hashstringtobigint()
        {
            var simHash = new Simhash();
            BigInteger actualBiggie = simHash.hashfunc_hashstringtobignasty("47bce5c74f589f4867dbd57e9ca9f808");
            string expectedBiggie = "95355999972893604581396806948474189832";
            Assert.AreEqual(expectedBiggie, actualBiggie.ToString());
        }

        [TestMethod]
        public void test_value()
        {
            List<string> features = new List<string>() { "aaa", "bbb" };
            var simHash = new Simhash(features);
            ulong expected = 8637903533912358349;
            Assert.AreEqual(expected,simHash.value );
        }

    }
}
