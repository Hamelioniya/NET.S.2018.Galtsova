using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithm.Tests
{
    [TestFixture]
    public class BubbleSortInterfaceTests
    {
        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesDelegate))]
        public int[][] Sort_SortesArrayUsingDelegateTests(int[][] sourceArray, Comparison<int[]> comparator)
        {
            BubbleSortInterface.Sort(sourceArray, comparator);
            return sourceArray;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesInterface))]
        public int[][] Sort_SortesArrayUsingInterfaceTests(int[][] sourceArray, IComparer<int[]> comparator)
        {
            BubbleSortInterface.Sort(sourceArray, comparator);
            return sourceArray;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesException))]
        public void Sort_ArgumentNullExceptionTests(int[][] sourceArray, IComparer<int[]> comparator)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortInterface.Sort(sourceArray, comparator));
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCasesDelegate
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        (Comparison<int[]>)Comparator.CompareByRowElementsSumAscending)
                        .Returns(new[] { new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } });

                    yield return new TestCaseData(
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 }, new[] { 16 } },
                        (Comparison<int[]>)Comparator.CompareByRowElementsSumDescending)
                        .Returns(new[] { new[] { 16 }, new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } });

                    yield return new TestCaseData(
                        new[] { new[] { 111, -200, 12, 23 }, new[] { int.MinValue }, new[] { 0, 1, 2 } },
                        (Comparison<int[]>)Comparator.CompareByMaxRowElementsAscending)
                        .Returns(new[] { new[] { int.MinValue }, new[] { 0, 1, 2 }, new[] { 111, -200, 12, 23 } });

                    yield return new TestCaseData(
                        new[] { new[] { 111, -200, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } },
                        (Comparison<int[]>)Comparator.CompareByMaxRowElementsDescending)
                        .Returns(new[] { new[] { 0, int.MaxValue }, new[] { 111, -200, 12, 23 }, new[] { -300 } });

                    yield return new TestCaseData(
                        new[] { new[] { 11, 25, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } },
                        (Comparison<int[]>)Comparator.CompareByMinRowElementsAscending)
                        .Returns(new[] { new[] { -300 }, new[] { 0, int.MaxValue }, new[] { 11, 25, 12, 23 } });

                    yield return new TestCaseData(
                        new[] { new[] { 11, 25, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } },
                        (Comparison<int[]>)Comparator.CompareByMinRowElementsDescending)
                        .Returns(new[] { new[] { 11, 25, 12, 23 }, new[] { 0, int.MaxValue }, new[] { -300 } });
                }
            }

            public static IEnumerable TestCasesInterface
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        new ComparatorByMaxSumAscending())
                        .Returns(new[] { new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } });

                    yield return new TestCaseData(
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 }, new[] { 16 } },
                        new ComparatorByMaxSumDescending())
                        .Returns(new[] { new[] { 16 }, new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } });

                    yield return new TestCaseData(
                        new[] { new[] { 111, -200, 12, 23 }, new[] { int.MinValue }, new[] { 0, 1, 2 } },
                        new ComparatorByMaxElemAscending())
                        .Returns(new[] { new[] { int.MinValue }, new[] { 0, 1, 2 }, new[] { 111, -200, 12, 23 } });

                    yield return new TestCaseData(
                        new[] { new[] { 111, -200, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } },
                        new ComparatorByMaxElemDescending())
                        .Returns(new[] { new[] { 0, int.MaxValue }, new[] { 111, -200, 12, 23 }, new[] { -300 } });

                    yield return new TestCaseData(
                        new[] { new[] { 11, 25, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } },
                        new ComparatorByMinElemAscending())
                        .Returns(new[] { new[] { -300 }, new[] { 0, int.MaxValue }, new[] { 11, 25, 12, 23 } });

                    yield return new TestCaseData(
                        new[] { new[] { 11, 25, 12, 23 }, new[] { -300 }, new[] { 0, int.MaxValue } },
                        new ComparatorByMinElemDescending())
                        .Returns(new[] { new[] { 11, 25, 12, 23 }, new[] { 0, int.MaxValue }, new[] { -300 } });
                }
            }

            public static IEnumerable TestCasesException
            {
                get
                {
                    yield return new TestCaseData(null, new ComparatorByMinElemAscending());

                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 }, new[] { 16 } }, null);

                    yield return new TestCaseData(null, null);
                }
            }
        }
    }
}
