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
        public void test_slide()
        {
            var simHash = new Simhash();
            List<string> pieces = simHash.slide("aaabbb", width: 4);
            //aaab, aabb, abbb
            Assert.AreEqual(3, pieces.Count);
        }

        [TestMethod]
        public void test_clean()
        {
            var simHash = new Simhash();
            string cleaned = simHash.scrub("aaa bbb test test testing. happy time =-).");
            //aaab, aabb, abbb
            Assert.AreEqual("aaabbbtesttesttestinghappytime", cleaned);
        }

        [TestMethod]
        public void test_tokenize_width_default()
        {
            var simHash = new Simhash();
            List<string> pieces = simHash.tokenize("aaabbb");
            //aaab, aabb, abbb
            Assert.AreEqual(3, pieces.Count);
        }
        [TestMethod]
        public void test_tokenize_width_three()
        {
            var simHash = new Simhash();
            List<string> pieces = simHash.tokenize("This is a test for really cool content. yeah! =)", width:3);
            //thi, his, isi, sis, isa .. etc....
            Assert.AreEqual(33, pieces.Count);
        }

        [TestMethod]
        public void test_value_by_string()
        {
            var simHash = new Simhash("aaa bbb test test testing. happy time =-).");
            ulong expected = 5683413558821905382;
            Assert.AreEqual(expected, simHash.value);
        }

        //Exact tests from https://github.com/liangsun/simhash
        [TestMethod]
        public void test_value()
        {
            List<string> features = new List<string>() { "aaa", "bbb" };
            var simHash = new Simhash(features);
            ulong expected = 8637903533912358349;
            Assert.AreEqual(expected, simHash.value);
        }
        [TestMethod]
        public void test_distance()
        {
            var sh = new Simhash("How are you? I AM fine. Thanks. And you?");
            var sh2 = new Simhash("How old are you? :-) i am fine. Thanks. And you?");
            int distA = sh.distance(sh2);
            Assert.IsTrue(distA > 0);
            //Assert.AreEqual(8,distA);

            var sh3 = new Simhash(sh2);
            int distB = sh2.distance(sh3);
            Assert.AreEqual(0,distB);

            Assert.AreNotEqual(0, new Simhash("1").distance(sh3));
        }
        [TestMethod]
        public void test_chinese()
        {
            var sh = new Simhash("你好　世界！　　呼噜。");
            var sh2 = new Simhash("你好，世界　呼噜");
            Assert.AreEqual(sh.distance(sh2), 0);

            var sh4 = new Simhash("How are you? I Am fine. ablar ablar xyz blar blar blar blar blar blar blar Thanks.");
            var sh5 = new Simhash("How are you i am fine.ablar ablar xyz blar blar blar blar blar blar blar than");
            var sh6 = new Simhash("How are you i am fine.ablar ablar xyz blar blar blar blar blar blar blar thank");

            Assert.IsTrue(sh4.distance(sh6) < 3);
            Assert.IsTrue(sh5.distance(sh6) < 3);
        }

        [TestMethod]
        public void test_short()
        {
            List<Simhash> shs = new List<Simhash>();
            List<string> ss = new List<string>() { "aa", "aaa", "aaaa", "aaaab", "aaaaabb", "aaaaabbb" };
            foreach (string s in ss)
            {
                var simHash = new Simhash(s);
                shs.Add(simHash);
            }

            foreach (Simhash sh1 in shs)
            {
                foreach (Simhash sh2 in shs)
                {
                    if (sh1 != sh2)
                    {
                        Assert.AreNotEqual(sh1, sh2);
                    }
                }
            }
        }
    }
}
