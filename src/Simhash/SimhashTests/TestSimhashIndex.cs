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
                index = new SimhashIndex(objs, 10);
            }

        }
        [TestMethod]
        public void test_get_near_dup()
        {

        }
    }
}
