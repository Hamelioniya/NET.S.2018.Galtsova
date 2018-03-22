using System;
using System.Collections;
using NUnit.Framework;

namespace Algorithm.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCases))]
        public int[][] Sort_SortesArrayTests(int[][] sourceArray, Comparison<int[]> comparator)
        {
            BubbleSort.Sort(sourceArray, comparator);
            return sourceArray;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesException))]
        public void Sort_ArgumentNullExceptionTests(int[][] sourceArray, Comparison<int[]> comparator)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort.Sort(sourceArray, comparator));
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        (Comparison<int[]>)BubbleSort.CompareByRowElementsSumAscending)
                        .Returns(new[] { new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } });

                    yield return new TestCaseData(
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 }, new[] { 16 } },
                        (Comparison<int[]>)BubbleSort.CompareByRowElementsSumDescending)
                        .Returns(new[] { new[] { 16 }, new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } });

                    yield return new TestCaseData(
                        new[] { new[] { 111, -200, 12, 23 }, new[] { int.MinValue }, new[] { 0, 1, 2 } },
                        (Comparison<int[]>)BubbleSort.CompareByMaxRowElementsAscending)
                        .Returns(new[] { new[] { int.MinValue }, new[] { 0, 1, 2 }, new[] { 111, -200, 12, 23 } });

                    yield return new TestCaseData(
                        new[] { new[] { 111, -200, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } },
                        (Comparison<int[]>)BubbleSort.CompareByMaxRowElementsDescending)
                        .Returns(new[] { new[] { 0, int.MaxValue }, new[] { 111, -200, 12, 23 }, new[] { -300 } });

                    yield return new TestCaseData(
                        new[] { new[] { 11, 25, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } },
                        (Comparison<int[]>)BubbleSort.CompareByMinRowElementsAscending)
                        .Returns(new[] { new[] { -300 }, new[] { 0, int.MaxValue }, new[] { 11, 25, 12, 23 } });

                    yield return new TestCaseData(
                        new[] { new[] { 11, 25, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } },
                        (Comparison<int[]>)BubbleSort.CompareByMinRowElementsDescending)
                        .Returns(new[] { new[] { 11, 25, 12, 23 }, new[] { 0, int.MaxValue }, new[] { -300 } });
                }
            }

            public static IEnumerable TestCasesException
            {
                get
                {
                    yield return new TestCaseData(null, (Comparison<int[]>)BubbleSort.CompareByRowElementsSumAscending);

                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 }, new[] { 16 } }, null);

                    yield return new TestCaseData(null, null);
                }
            }
        }
    }
}
