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
        public void test_ulongtolongbacktoulong()
        {
            ulong theUlong = 18446744073709551615;
            string stheUlong = Simhash.convert_ulong_to_bin(theUlong);
            long cLong = Convert.ToInt64(stheUlong, 2);
            //save to mongo or other db using long (as ulong aren't!)
            //retrieve from db and then get back to ulong
            string sLong = Convert.ToString(cLong, 2);
            ulong fromDb = Convert.ToUInt64(sLong, 2);
            string thedbUlong = Simhash.convert_ulong_to_bin(fromDb);

            Assert.AreEqual(stheUlong, thedbUlong);
        }

        [TestMethod]
        public void test_ulongtobinary()
        {
            ulong theUlong = 8637903533912358349;
            string stheUlong = Simhash.convert_ulong_to_bin(theUlong);
            string expSimHash = "111011111011111111111110111111110011110111011111111110111001101";
            Assert.AreEqual(expSimHash, stheUlong);
        }

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
        public void test_value_by_string()
        {
            var simHash = new Simhash("aaa bbb");
            ulong expected = 8637903533912358349;
            Assert.AreEqual(expected, simHash.value);
        }

        [TestMethod]
        public void test_value_by_collection()
        {
            List<string> features = new List<string>() { "aaa", "bbb" };
            var simHash = new Simhash(features);
            ulong expected = 8637903533912358349;
            Assert.AreEqual(expected, simHash.value);
        }
        //[TestMethod]
        //public void test_distance()
        //{
        //    var sh = new Simhash("How are you? I AM fine. Thanks. And you?");
        //    var sh2 = new Simhash("How old are you? :-) i am fine. Thanks. And you?");

        //}
    }
}
