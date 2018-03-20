using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Algorithm.NUnitTests
{
    [TestFixture]
    public class NumberAlgorithmTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int InsertNumber_NumberInsertTests(int numberSource, int numberIn, int firstIndex, int lastIndex)
        {
            return NumberAlgorithm.InsertNumber(numberSource, numberIn, firstIndex, lastIndex);
        }

        [TestCase(15, 15, 2, 1)]
        [TestCase(15, 15, -1, 0)]
        public void InsertNumber_ArgumentExceptionTests(int numberSource, int numberIn, int firstIndex, int lastIndex)
        {
            Assert.Throws<ArgumentException>(() => NumberAlgorithm.InsertNumber(numberSource, numberIn, firstIndex, lastIndex));
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(537421, ExpectedResult = 541237)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumber_NextBiggerFindingTests(int number)
        {
            return NumberAlgorithm.FindNextBiggerNumber(number);
        }

        [TestCase(-10)]
        public void FindNextBiggerNumber_ArgumentExceptionTests(int number)
        {
            Assert.Throws<ArgumentException>(() => NumberAlgorithm.FindNextBiggerNumber(number));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new[] { 7, 70, 17 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new[] { 7, 70, 17 })]
        [TestCase(new[] { 20, 20, 20 }, 2, ExpectedResult = new[] { 20, 20, 20 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, 7, ExpectedResult = new int[0])]
        [TestCase(new[] { 10, 20, 30, 100, 181 }, 1, ExpectedResult = new[] { 10, 100, 181 })]
        [TestCase(new[] { 100, 101, 102, 103, 113, 104, 131, 128 }, 3, ExpectedResult = new[] { 103, 113, 131 })]
        [TestCase(new int[0], 3, ExpectedResult = new int[0])]
        [TestCase(new[] { 1 }, 3, ExpectedResult = new int[0])]
        [TestCase(new[] { 1, 11, 111, 1111, 11111 }, 111, ExpectedResult = new[] { 111, 1111, 11111 })]
        [TestCase(new[] { 1, 111, 111, 1111, 11111 }, 111, ExpectedResult = new[] { 111, 111, 1111, 11111 })]
        public int[] FilterDigit_GetNumbersWithSearchNumberTests(int[] numbers, int searchNumber)
        {
            List<int> numbersList = numbers.ToList<int>();
            List<int> resultList = NumberAlgorithm.FilterDigit(numbersList, searchNumber);

            return resultList.ToArray();
        }

        [TestCase(null, 7)]
        public void FilterDigit_ArgumentNullExceptionTests(List<int> numbersList, int searchNumber)
        {
            Assert.Throws<ArgumentNullException>(() => NumberAlgorithm.FilterDigit(numbersList, searchNumber));
        }

        [TestCase(1, 5, 0.0001d, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001d, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001d, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001d, ExpectedResult = 0.45)]
        [TestCase(8d, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001d, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.01, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRoot_RootFindingTests(double number, int rootPower, double eps)
        {
            return Math.Round(NumberAlgorithm.FindNthRoot(number, rootPower, eps), eps.ToString("0.##########").Split(',')[1].Length);
        }

        [TestCase(1, -5, 0.0001)]
        [TestCase(1, 5, -0.0001)]
        public void FindNthRoot_ArgumentExceptionTests(double number, int rootPower, double eps)
        {
            Assert.Throws<ArgumentException>(() => NumberAlgorithm.FindNthRoot(number, rootPower, eps));
        }
    }
}
