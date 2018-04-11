using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithm.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesInt))]
        public int Search_FindIntegerElementInIntegerArrayTests(int[] array, int element, IComparer<int> comparator)
        {
            return BinarySearch<int>.Search(array, element, comparator);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesString))]
        public int Search_FindStringElementInStringArrayTests(string[] array, string element, IComparer<string> comparator)
        {
            return BinarySearch<string>.Search(array, element, comparator);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesArgumentNullException))]
        public void Search_ArgumentNullExceptionTests(string[] array, string element, IComparer<string> comparator)
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearch<string>.Search(array, element, comparator));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesArgumentException))]
        public void Search_ArgumentExceptionTests(int[] array, int element, IComparer<int> comparator)
        {
            Assert.Throws<ArgumentException>(() => BinarySearch<int>.Search(array, element, comparator));
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCasesInt
            {
                get
                {
                    yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }, 3, new ComparatorInt()).Returns(2);

                    yield return new TestCaseData(new[] { 1, 12, 23, 45, 54, 74 }, 47, new ComparatorInt()).Returns(-1);

                    yield return new TestCaseData(new[] { 1, 12, 23, 45, 54 }, -3, new ComparatorInt()).Returns(-1);

                    yield return new TestCaseData(new[] { 1, 12, 23, 45, 54 }, 78, new ComparatorInt()).Returns(-1);
                }
            }

            public static IEnumerable TestCasesString
            {
                get
                {
                    yield return new TestCaseData(new[] { "A", "B", "C", "D", "E" }, "C", new ComparatorString()).Returns(2);

                    yield return new TestCaseData(new[] { "A", "B", "C", "D", "E" }, string.Empty, new ComparatorString()).Returns(-1);
                }
            }

            public static IEnumerable TestCasesArgumentNullException
            {
                get
                {
                    yield return new TestCaseData(null, string.Empty, new ComparatorString());
                }
            }

            public static IEnumerable TestCasesArgumentException
            {
                get
                {
                    yield return new TestCaseData(new int[0], 0, new ComparatorInt());

                    yield return new TestCaseData(new[] { 11, 15, 20, 45, 78, 9 }, 15, new ComparatorInt());
                }
            }
        }
    }
}
