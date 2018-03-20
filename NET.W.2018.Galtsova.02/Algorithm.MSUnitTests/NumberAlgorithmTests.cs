using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.MSUnitTests
{
    [TestClass]
    public class NumberAlgorithmTests
    {
        [TestMethod]
        public void InsertNumber_NumberInsert15and15From0To0Test()
        {
            int numberSource = 15, numberIn = 15;
            int firstIndex = 0, lastIndex = 0;
            int expected = 15;

            int result = NumberAlgorithm.InsertNumber(numberSource, numberIn, firstIndex, lastIndex);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertNumber_NumberInsert8and15From0To0Test()
        {
            int numberSource = 8, numberIn = 15;
            int firstIndex = 0, lastIndex = 0;
            int expected = 9;

            int result = NumberAlgorithm.InsertNumber(numberSource, numberIn, firstIndex, lastIndex);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertNumber_NumberInsert8and15From3To8Test()
        {
            int numberSource = 8, numberIn = 15;
            int firstIndex = 3, lastIndex = 8;
            int expected = 120;

            int result = NumberAlgorithm.InsertNumber(numberSource, numberIn, firstIndex, lastIndex);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_ArgumentExceptionFirstIndexGreaterThanLastTest()
        {
            int numberSource = 15, numberIn = 15;
            int firstIndex = 2, lastIndex = 1;

            NumberAlgorithm.InsertNumber(numberSource, numberIn, firstIndex, lastIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_ArgumentExceptionIndexLessThan0Test()
        {
            int numberSource = 15, numberIn = 15;
            int firstIndex = -1, lastIndex = 0;

            NumberAlgorithm.InsertNumber(numberSource, numberIn, firstIndex, lastIndex);
        }
    }
}
