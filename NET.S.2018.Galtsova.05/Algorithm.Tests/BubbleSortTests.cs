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
    public class BubbleSortTests
    {
        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesSortByMaxElemAscending))]
        public int[][] SortByMaxElementAscending_SortArray(int[][] sourceArray)
        {
            BubbleSort.SortByMaxElementAscending(sourceArray);
            return sourceArray;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesSortByMaxElemDescending))]
        public int[][] SortByMaxElementDescending_SortArray(int[][] sourceArray)
        {
            BubbleSort.SortByMaxElementDescending(sourceArray);
            return sourceArray;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesSortByMinElemAscending))]
        public int[][] SortByMinElementAscending_SortArray(int[][] sourceArray)
        {
            BubbleSort.SortByMinElementAscending(sourceArray);
            return sourceArray;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesSortByMinElemDescending))]
        public int[][] SortByMinElementDescending_SortArray(int[][] sourceArray)
        {
            BubbleSort.SortByMinElementDescending(sourceArray);
            return sourceArray;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesSortByMaxRowElemSumAscending))]
        public int[][] SortByMaxRowElementsSumAscending_SortArray(int[][] sourceArray)
        {
            BubbleSort.SortByMaxRowElementsSumAscending(sourceArray);
            return sourceArray;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesSortByMaxRowElemSumDescending))]
        public int[][] SortByMaxRowElementsSumDescending_SortArray(int[][] sourceArray)
        {
            BubbleSort.SortByMaxRowElementsSumDescending(sourceArray);
            return sourceArray;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesException))]
        public void SortByMaxElementAscending_ArgumentNullException(int[][] sourceArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortByMaxElementAscending(sourceArray));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesException))]
        public void SortByMaxElementDescending_ArgumentNullException(int[][] sourceArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortByMaxElementDescending(sourceArray));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesException))]
        public void SortByMinElementAscending_ArgumentNullException(int[][] sourceArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortByMinElementAscending(sourceArray));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesException))]
        public void SortByMinElementDescending_ArgumentNullException(int[][] sourceArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortByMinElementDescending(sourceArray));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesException))]
        public void SortByMaxRowElementsSumAscending_ArgumentNullException(int[][] sourceArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortByMaxRowElementsSumAscending(sourceArray));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesException))]
        public void SortByMaxRowElementsSumDescending_ArgumentNullException(int[][] sourceArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortByMaxRowElementsSumDescending(sourceArray));
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCasesSortByMaxElemAscending
            {
                get
                {
                    yield return new TestCaseData(
                        (Array)new[] { new[] { 111, -200, 12, 23 }, new[] { int.MinValue }, new[] { 0, 1, 2 } })
                        .Returns(new[] { new[] { int.MinValue }, new[] { 0, 1, 2 }, new[] { 111, -200, 12, 23 } });
                }
            }

            public static IEnumerable TestCasesSortByMaxElemDescending
            {
                get
                {
                    yield return new TestCaseData(
                        (Array)new[] { new[] { 111, -200, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } })
                        .Returns(new[] { new[] { 0, int.MaxValue }, new[] { 111, -200, 12, 23 }, new[] { -300 } });
                }
            }

            public static IEnumerable TestCasesSortByMinElemAscending
            {
                get
                {
                    yield return new TestCaseData(
                        (Array)new[] { new[] { 11, 25, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } })
                        .Returns(new[] { new[] { -300 }, new[] { 0, int.MaxValue }, new[] { 11, 25, 12, 23 } });
                }
            }

            public static IEnumerable TestCasesSortByMinElemDescending
            {
                get
                {
                    yield return new TestCaseData(
                        (Array)new[] { new[] { 11, 25, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } })
                        .Returns(new[] { new[] { 11, 25, 12, 23 }, new[] { 0, int.MaxValue }, new[] { -300 } });
                }
            }

            public static IEnumerable TestCasesSortByMaxRowElemSumAscending
            {
                get
                {
                    yield return new TestCaseData(
                       (Array)new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } })
                       .Returns(new[] { new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } });
                }
            }

            public static IEnumerable TestCasesSortByMaxRowElemSumDescending
            {
                get
                {
                    yield return new TestCaseData(
                        (Array)new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 }, new[] { 16 } })
                        .Returns(new[] { new[] { 16 }, new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } });
                }
            }

            public static IEnumerable TestCasesException
            {
                get
                {
                    yield return new TestCaseData(null);
                }
            }
        }
    }
}
