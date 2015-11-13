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
        public static string ConvertToBinary(ulong value)
        {
            if (value == 0) return "0";
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            while (value != 0)
            {
                b.Insert(0, ((value & 1) == 1) ? '1' : '0');
                value >>= 1;
            }
            return b.ToString();
        }

        [TestMethod]
        public void test_ulongtolongbacktoulong()
        {
            ulong theUlong = 18446744073709551615;
            string stheUlong = ConvertToBinary(theUlong);
            long cLong = Convert.ToInt64(stheUlong, 2);
            //save to mongo or other db using long (as ulong aren't!)
            //retrieve from db and then get back to ulong
            string sLong = Convert.ToString(cLong, 2);
            ulong fromDb = Convert.ToUInt64(sLong,2);
            string thedbUlong = ConvertToBinary(fromDb);
            
            Assert.AreEqual(stheUlong, thedbUlong);
        }
        public void test_ulongtobinary()
        {
            //ulong theUlong = 8637903533912358349;
            ulong theUlong = 18446744073709551615;
            string stheUlong = ConvertToBinary(theUlong);
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
        public void test_value()
        {
            List<string> features = new List<string>() { "aaa", "bbb" };
            var simHash = new Simhash(features);
            ulong expected = 8637903533912358349;
            Assert.AreEqual(expected,simHash.value );
        }

    }
}
