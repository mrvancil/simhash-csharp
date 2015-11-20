using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimhashLib;

namespace SimhashTests
{
    [TestClass]
    public class TestHashing
    {
        [TestMethod]
        public void test_gethashcode_asstring()
        {

            string aaa = "aaa";
            int hash = aaa.GetHashCode();
            string hashString = hash.ToString();
            //ulong hashValue = Convert.ToUInt64(hash,2);
            Assert.AreEqual("-625742108", hashString);
        }
        [TestMethod]
        public void test_gethashcode_asint()
        {

            string aaa = "aaa";
            int hash = aaa.GetHashCode();
            Assert.AreEqual(-625742108, hash);
        }
        [TestMethod]
        public void test_gethashcode_specialhashing_to64bit()
        {
            string eval = "aaa";
            var simHash = new Simhash();
            ulong fromDb = simHash.hashfuncjenkins(eval);
            Assert.AreEqual(18323053351575752945, fromDb);
        }
    }
}
