using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SimhashLib;

namespace SimhashTests
{
    [TestClass]
    public class TestSimhashIndex
    {
        private Dictionary<long, Simhash> objs = new Dictionary<long, Simhash>();
        private SimhashIndex index;

        [TestInitialize]
        public void setUp()
        {
            Dictionary<long, string> data = new Dictionary<long, string>();
            data.Add(1, "How are you? I Am fine. blar blar blar blar blar Thanks.");
            data.Add(2, "How are you i am fine. blar blar blar blar blar than");
            data.Add(3, "This is simhash test.");
            data.Add(4, "How are you i am fine. blar blar blar blar blar thank1");

            foreach(var it in data)
            {
                objs.Add(it.Key, new Simhash(it.Value));
                index = new SimhashIndex(objs:objs,k:10);
            }

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

        [Ignore]
        [TestMethod]
        public void test_get_near_dup()
        {
            var s1 = new Simhash("How are you i am fine.ablar ablar xyz blar blar blar blar blar blar blar thank");
            var dups = index.get_near_dups(s1);
            Assert.AreEqual(dups.Count, 3);
        }
    }
}
