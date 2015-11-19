using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimhashLib;
using System.Collections.Generic;

namespace SimhashTests
{
    [TestClass]
    public class TestShingling
    {

        [TestMethod]
        public void test_slide()
        {
            var shingling = new Shingling();
            List<string> pieces = shingling.slide("aaabbb", width: 4);
            //aaab, aabb, abbb
            Assert.AreEqual(3, pieces.Count);
        }

        [TestMethod]
        public void test_tokenize_width_default()
        {
            var shingling = new Shingling();
            List<string> pieces = shingling.tokenize("aaabbb");
            //aaab, aabb, abbb
            Assert.AreEqual(3, pieces.Count);
        }
        [TestMethod]
        public void test_tokenize_width_three()
        {
            var shingling = new Shingling();
            List<string> pieces = shingling.tokenize("This is a test for really cool content. yeah! =)", width: 3);
            //thi, his, isi, sis, isa .. etc....
            Assert.AreEqual(33, pieces.Count);
        }
        [TestMethod]
        public void test_clean()
        {
            var shingling = new Shingling();
            string cleaned = shingling.scrub("aaa bbb test test testing. happy time =-).");
            //aaab, aabb, abbb
            Assert.AreEqual("aaabbbtesttesttestinghappytime", cleaned);
        }
    }
}
