using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SimhashLib;

namespace SimhashTests
{
    [TestClass]
    public class TestSimhashIndexMD5
    {
        private Dictionary<long, Simhash> objs = new Dictionary<long, Simhash>();
        private SimhashIndex index;
        private Dictionary<long, string> testData = new Dictionary<long, string>();
        [TestInitialize]
        public void setUp()
        {
            testData.Add(1, "How are you? I Am fine. blar blar blar blar blar Thanks.");
            testData.Add(2, "How are you i am fine. blar blar blar blar blar than");
            testData.Add(3, "This is simhash test.");
            testData.Add(4, "How are you i am fine. blar blar blar blar blar thank1");

            foreach(var it in testData)
            {
                var simHash = new Simhash(hashingType:Simhash.HashingType.MD5);
                simHash.GenerateSimhash(it.Value);
                objs.Add(it.Key, simHash);
                
            }
            index = new SimhashIndex(objs: objs, k: 10);
           
        }
        [TestMethod]
        public void test_offset_creation_with_ten()
        {
            var dict = new Dictionary<long, Simhash>();
            var simHashIndex = new SimhashIndex(dict, k: 10);
            var offsets = simHashIndex.make_offsets();
            Assert.AreEqual(0, offsets[0]);
            Assert.AreEqual(10, offsets[2]);
            Assert.IsTrue(offsets.Count == 11);
        }
        [TestMethod]
        public void test_offset_creation_with_two()
        {
            var dict = new Dictionary<long, Simhash>();
            var simHashIndex = new SimhashIndex(dict, k: 2);
            var offsets = simHashIndex.make_offsets();
            Assert.AreEqual(0, offsets[0]);
            Assert.AreEqual(42, offsets[2]);
            Assert.IsTrue(offsets.Count == 3);
        }

        [TestMethod]
        public void test_get_keys()
        {
            Dictionary<long, string> testdata = new Dictionary<long, string>();
            testdata.Add(1, "How are you? I Am fine. blar blar blar blar blar Thanks.");

            Dictionary<long, Simhash> simHashObjs = new Dictionary<long, Simhash>();
            foreach (var it in testdata)
            {
                var simHash = new Simhash(hashingType:Simhash.HashingType.MD5);
                simHash.GenerateSimhash(it.Value);
                simHashObjs.Add(it.Key, simHash);
            }
            var simHashIndex = new SimhashIndex(objs: simHashObjs, k: 10);
            var listOfKeys = simHashIndex.get_the_keys(simHashObjs[1]);
            Assert.IsTrue(listOfKeys.Count == 11);
            Assert.AreEqual("26,0", listOfKeys[0]);
            Assert.AreEqual("3,1", listOfKeys[1]);
            Assert.AreEqual("7,2", listOfKeys[2]);
            Assert.AreEqual("12,3", listOfKeys[3]);
            Assert.AreEqual("17,4", listOfKeys[4]);
            Assert.AreEqual("0,5", listOfKeys[5]);
            Assert.AreEqual("13,6", listOfKeys[6]);
            Assert.AreEqual("30,7", listOfKeys[7]);
            Assert.AreEqual("1,8", listOfKeys[8]);
            Assert.AreEqual("14,9", listOfKeys[9]);
            Assert.AreEqual("7496,10", listOfKeys[10]);

        }

        [TestMethod]
        public void test_get_near_dup_hash()
        {
            var s1 = new Simhash(hashingType: Simhash.HashingType.MD5);
            s1.GenerateSimhash("How are you i am fine.ablar ablar xyz blar blar blar blar blar blar blar thank");
            var dups = index.get_near_dups(s1);
            Assert.AreEqual(3, dups.Count);

            var s2 = new Simhash(hashingType: Simhash.HashingType.MD5);
            s2.GenerateSimhash(testData[1]);
            index.delete(1, s2);
            dups = index.get_near_dups(s1);
            Assert.AreEqual(2, dups.Count);

            var s3 = new Simhash(hashingType: Simhash.HashingType.MD5);
            s3.GenerateSimhash(testData[1]);
            index.delete(1, s3);
            dups = index.get_near_dups(s1);
            Assert.AreEqual(2, dups.Count);

            var s4 = new Simhash(hashingType: Simhash.HashingType.MD5);
            s4.GenerateSimhash(testData[1]);
            index.add(1, s4);
            dups = index.get_near_dups(s1);
            Assert.AreEqual(3, dups.Count);

            var s5 = new Simhash(hashingType: Simhash.HashingType.MD5);
            s5.GenerateSimhash(testData[1]);
            index.add(1, s5);
            dups = index.get_near_dups(s1);
            Assert.AreEqual(3, dups.Count);
        }
    }
}
