using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimhashLib;

namespace SimhashTests
{
    [TestClass]
    public class TestHashing
    {
        [TestMethod]
        public void LearnAboutGetHashCode1()
        {

            string aaa = "aaa";
            int hash = aaa.GetHashCode();
            string hashString = hash.ToString();
            //ulong hashValue = Convert.ToUInt64(hash,2);
            Assert.AreEqual("-625742108", hashString);
        }
        [TestMethod]
        public void LearnAboutGetHashCode2()
        {

            string aaa = "aaa";
            int hash = aaa.GetHashCode();
            Assert.AreEqual(-625742108, hash);
        }
        [TestMethod]
        public void LearnAboutGetHashCode3()
        {
            string eval = "aaa";
            var simHash = new Simhash();
            ulong fromDb = simHash.hashfunccustom(eval);
            Assert.AreEqual(14828866757492062143, fromDb);
        }
    }
}
