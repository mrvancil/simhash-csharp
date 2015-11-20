using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimhashLib;

namespace SimhashTests
{
    [TestClass]
    public class TestConverters
    {

        [TestMethod]
        public void test_ulongtolongbacktoulong_strings()
        {
            ulong theUlong = 18446744073709551615;
            string stheUlong = Converters.convert_ulong_to_bin(theUlong);
            long cLong = Convert.ToInt64(stheUlong, 2);
            //save to mongo or other db using long (as ulong aren't!)

            //retrieve from db and then get back to ulong
            string sLong = Convert.ToString(cLong, 2);
            ulong fromDb = Convert.ToUInt64(sLong, 2);
            string thedbUlong = Converters.convert_ulong_to_bin(fromDb);

            Assert.AreEqual(stheUlong, thedbUlong);
        }

        [TestMethod]
        public void test_ulongtolongbacktoulong_native()
        {
            ulong theUlong = 18446744073709551615;
            long cLong = Converters.ConvertUlongToLong(theUlong);
            //save to mongo or other db using long (as ulong aren't!)

            //retrieve from db and then get back to ulong
            string sLong = Convert.ToString(cLong, 2);
            ulong fromDb = Convert.ToUInt64(sLong, 2);
           
            Assert.AreEqual(theUlong, fromDb);
        }

        [TestMethod]
        public void test_ulongtobinary()
        {
            ulong theUlong = 8637903533912358349;
            string stheUlong = Converters.ConvertulongToString(theUlong);
            string expSimHash = "111011111011111111111110111111110011110111011111111110111001101";
            Assert.AreEqual(expSimHash, stheUlong);
        }
    }
}
