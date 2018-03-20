using System;
using Algorithm;
using NUnit.Framework;

namespace EuclidAlgorithm.NUnitTests
{
    [TestFixture]
    public class GCDAlgorithmTests
    {
        [TestCase(18, 30, ExpectedResult = 6)]
        [TestCase(7920, 594, ExpectedResult = 198)]
        [TestCase(10, -10, ExpectedResult = 10)]
        [TestCase(0, 432, ExpectedResult = 432)]
        [TestCase(432, 0, ExpectedResult = 432)]
        [TestCase(0, -0, ExpectedResult = 0)]
        [TestCase(-0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(78, 294, 570, ExpectedResult = 6)]
        [TestCase(-585, 81, -189, ExpectedResult = 9)]
        [TestCase(32, 294, 570, 37, 20, 124, 74, 12, 15, ExpectedResult = 1)]
        [TestCase(-5, -10, 100, 15, -45, 30, 90, ExpectedResult = 5)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, ExpectedResult = 0)]
        public int GetEuclidGCD_GetNumbersArrayGCGTests(params int[] numbersArray)
        {
            return GCDAlgorithm.GetEuclidGCD(numbersArray);
        }

        [TestCase]
        [TestCase(1)]
        public void GetEuclidGCD_ArgumentExceptionTests(params int[] numbersArray)
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithm.GetEuclidGCD(numbersArray));
        }

        [Test]
        public void GetEuclidGCD_ArgumentNullExceptionTests()
        {
            Assert.Throws<ArgumentNullException>(() => GCDAlgorithm.GetEuclidGCD(null));
        }

        [TestCase(10, -10, ExpectedResult = 10)]
        [TestCase(0, 432, ExpectedResult = 432)]
        [TestCase(432, 0, ExpectedResult = 432)]
        [TestCase(0, -0, ExpectedResult = 0)]
        [TestCase(-0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(78, 294, 570, ExpectedResult = 6)]
        [TestCase(-585, 81, -189, ExpectedResult = 9)]
        [TestCase(32, 294, 570, 37, 20, 124, 74, 12, 15, ExpectedResult = 1)]
        [TestCase(-5, -10, 100, 15, -45, 30, 90, ExpectedResult = 5)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, ExpectedResult = 0)]
        public int GetShteinGCD_GetNumbersArrayGCGTests(params int[] numbersArray)
        {
            return GCDAlgorithm.GetSteinGCD(numbersArray);
        }

        [TestCase]
        [TestCase(1)]
        public void GetShteinGCD_ArgumentExceptionTests(params int[] numbersArray)
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithm.GetSteinGCD(numbersArray));
        }

        [Test]
        public void GetShteinGCD_ArgumentNullExceptionTests()
        {
            Assert.Throws<ArgumentNullException>(() => GCDAlgorithm.GetSteinGCD(null));
        }
    }
}
