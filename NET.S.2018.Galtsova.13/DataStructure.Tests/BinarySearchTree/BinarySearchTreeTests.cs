using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region Int32 tests

        [TestCase(new[] { 1, 2, 3, 4 }, 5, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 11, 12, 3, 1, 13, 12 }, 5, ExpectedResult = new[] { 11, 3, 1, 5, 12, 13, 12 })]
        public int[] AddInt_AddElementDefaultComparerTests(int[] array, int element)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
            tree.Add(element);

            return tree.PreOrderTraversal().ToArray();
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 5, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 11, 12, 3, 1, 13, 12 }, 5, ExpectedResult = new[] { 11, 3, 1, 5, 12, 13, 12 })]
        public int[] AddInt_AddElementCustomComparerTests(int[] array, int element)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array, new ComparatorInt().Compare);
            tree.Add(element);

            return tree.PreOrderTraversal().ToArray();
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 5, ExpectedResult = false)]
        [TestCase(new[] { 11, 3, 8, 4, 6 }, 11, ExpectedResult = true)]
        public bool ContainsInt_SearchElementDefaultComparerTests(int[] array, int element)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);

            return tree.Contains(element);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 5, ExpectedResult = false)]
        [TestCase(new[] { 11, 3, 8, 4, 6 }, 11, ExpectedResult = true)]
        public bool ContainsInt_SearchElementCustomComparerTests(int[] array, int element)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array, new ComparatorInt().Compare);

            return tree.Contains(element);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, ExpectedResult = new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 11, 12, 3, 1, 13, 12, 5 }, 3, ExpectedResult = new[] { 11, 5, 1, 12, 13, 12 })]
        public int[] RemoveInt_RemoveElementDefaultComparerTests(int[] array, int element)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
            tree.Remove(element);

            return tree.PreOrderTraversal().ToArray();
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, ExpectedResult = new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 11, 12, 3, 1, 13, 12, 5 }, 3, ExpectedResult = new[] { 11, 5, 1, 12, 13, 12 })]
        public int[] RemoveInt_RemoveElementCustomComparerTests(int[] array, int element)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array, new ComparatorInt().Compare);
            tree.Remove(element);

            return tree.PreOrderTraversal().ToArray();
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 11, 12, 3, 1, 13, 12, 5 }, ExpectedResult = new[] { 11, 3, 1, 5, 12, 13, 12 })]
        public int[] PreorderTraversalzintTests(int[] array)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);

            return tree.PreOrderTraversal().ToArray();
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, ExpectedResult = new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 11, 12, 3, 1, 13, 12, 5 }, ExpectedResult = new[] { 1, 5, 3, 12, 13, 12, 11 })]
        public int[] PostorderTraversalIntTests(int[] array)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);

            return tree.PostOrderTraversal().ToArray();
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, ExpectedResult = new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 11, 12, 3, 1, 13, 12, 5 }, ExpectedResult = new[] { 1, 3, 5, 11, 12, 12, 13 })]
        public int[] InorderTraversalIntTests(int[] array)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);

            return tree.InOrderTraversal().ToArray();
        }

        #endregion !Int32 tests.

        #region String tests

        [TestCase(new[] { "A", "B", "C", "D" }, "E", ExpectedResult = new[] { "A", "B", "C", "D", "E" })]
        [TestCase(new[] { "H", "I", "C", "A", "K", "I" }, "E", ExpectedResult = new[] { "H", "C", "A", "E", "I", "K", "I" })]
        public string[] AddString_AddElementDefaultComparerTests(string[] array, string element)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(array);
            tree.Add(element);

            return tree.PreOrderTraversal().ToArray();
        }

        [TestCase(new[] { "A", "B", "C", "D" }, "E", ExpectedResult = new[] { "A", "B", "C", "D", "E" })]
        [TestCase(new[] { "H", "I", "C", "A", "K", "I" }, "E", ExpectedResult = new[] { "H", "C", "A", "E", "I", "K", "I" })]
        public string[] AddString_AddElementCustomComparerTests(string[] array, string element)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(array, new ComparatorString().Compare);
            tree.Add(element);

            return tree.PreOrderTraversal().ToArray();
        }

        [TestCase(new[] { "A", "B", "C", "D" }, "E", ExpectedResult = false)]
        [TestCase(new[] { "H", "I", "C", "A", "K", "I" }, "A", ExpectedResult = true)]
        public bool ContainsString_SearchElementDefaultComparerTests(string[] array, string element)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(array);

            return tree.Contains(element);
        }

        [TestCase(new[] { "A", "B", "C", "D" }, "E", ExpectedResult = false)]
        [TestCase(new[] { "H", "I", "C", "A", "K", "I" }, "A", ExpectedResult = true)]
        public bool ContainsString_SearchElementCustomComparerTests(string[] array, string element)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(array, new ComparatorString().Compare);

            return tree.Contains(element);
        }

        [TestCase(new[] { "A", "B", "C", "D" }, "D", ExpectedResult = new[] { "A", "B", "C" })]
        [TestCase(new[] { "H", "I", "C", "A", "K", "I", "E" }, "C", ExpectedResult = new[] { "H", "E", "A", "I", "K", "I" })]
        public string[] RemoveString_RemoveElementDefaultComparerTests(string[] array, string element)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(array);
            tree.Remove(element);

            return tree.PreOrderTraversal().ToArray();
        }

        [TestCase(new[] { "A", "B", "C", "D" }, "D", ExpectedResult = new[] { "A", "B", "C" })]
        [TestCase(new[] { "H", "I", "C", "A", "K", "I", "E" }, "C", ExpectedResult = new[] { "H", "E", "A", "I", "K", "I" })]
        public string[] RemoveString_RemoveElementCustomComparerTests(string[] array, string element)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(array, new ComparatorString().Compare);
            tree.Remove(element);

            return tree.PreOrderTraversal().ToArray();
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasePreString))]
        public string[] PreorderTraversalStringTests(List<string> collection)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(collection);

            return tree.PreOrderTraversal().ToArray();
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasePostString))]
        public string[] PostorderTraversalTests(List<string> collection)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(collection);

            return tree.PostOrderTraversal().ToArray();
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseInString))]
        public string[] InorderTraversal_DefaultComparerTests(List<string> collection)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(collection);

            return tree.InOrderTraversal().ToArray();
        }

        #endregion !String tests.

        #region Book tests

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseAddBook))]
        public void AddBook_AddElementDefaultComparerTests(Book[] array, Book element, Book[] resultArray)
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(array);
            tree.Add(element);
            Book[] result = tree.PreOrderTraversal().ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.IsTrue(resultArray[i].Name == result[i].Name && result[i].Author == result[i].Author);
            }
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseAddBook))]
        public void AddBook_AddElementCustomComparerTests(Book[] array, Book element, Book[] resultArray)
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(array, new ComparatorBook().Compare);
            tree.Add(element);
            Book[] result = tree.PreOrderTraversal().ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.IsTrue(resultArray[i].Name == result[i].Name && result[i].Author == result[i].Author);
            }
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseContainsBook))]
        public bool ContainsBook_SearchElementDefaultComparerTests(Book[] array, Book element)
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(array);

            return tree.Contains(element);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseContainsBook))]
        public bool ContainsBook_SearchElementCustomComparerTests(Book[] array, Book element)
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(array, new ComparatorBook().Compare);

            return tree.Contains(element);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseRemoveBook))]
        public void RemoveBook_RemoveElementDefaultComparerTests(Book[] array, Book element, Book[] resultArray)
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(array);
            tree.Remove(element);
            Book[] result = tree.PreOrderTraversal().ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.IsTrue(resultArray[i].Name == result[i].Name && result[i].Author == result[i].Author);
            }
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseRemoveBook))]
        public void RemoveBook_RemoveElementCustomComparerTests(Book[] array, Book element, Book[] resultArray)
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(array, new ComparatorBook().Compare);
            tree.Remove(element);
            Book[] result = tree.PreOrderTraversal().ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.IsTrue(resultArray[i].Name == result[i].Name && result[i].Author == result[i].Author);
            }
        }

        #endregion !Book tests.

        #region Point tests

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseAddPoint))]
        public void AddPoint_AddElementCustomComparerTests(Point[] array, Point element, Point[] resultArray)
        {
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(array, new ComparatorPoint().Compare);
            tree.Add(element);
            Point[] result = tree.PreOrderTraversal().ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(resultArray[i], result[i]);
            }
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseContainsPoint))]
        public bool ContainsPoint_SearchElementCustomComparerTests(Point[] array, Point element)
        {
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(array, new ComparatorPoint().Compare);

            return tree.Contains(element);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseRemovePoint))]
        public void RemovePoint_RemoveElementCustomComparerTests(Point[] array, Point element, Point[] resultArray)
        {
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(array, new ComparatorPoint().Compare);
            tree.Remove(element);
            Point[] result = tree.PreOrderTraversal().ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(resultArray[i], result[i]);
            }
        }

        #endregion !Point tests.

        private class TestCasesClass
        {
            public static IEnumerable TestCasePreString
            {
                get
                {
                    yield return new TestCaseData(
                        new List<string> { "A", "B", "C", "D", "E" })
                        .Returns(new[] { "A", "B", "C", "D", "E" });

                    yield return new TestCaseData(
                        new List<string>() { "H", "I", "C", "A", "K", "I", "E" })
                        .Returns(new[] { "H", "C", "A", "E", "I", "K", "I" });
                }
            }

            public static IEnumerable TestCasePostString
            {
                get
                {
                    yield return new TestCaseData(
                        new List<string> { "A", "B", "C", "D", "E" })
                        .Returns(new[] { "E", "D", "C", "B", "A" });

                    yield return new TestCaseData(
                        new List<string>() { "H", "I", "C", "A", "K", "I", "E" })
                        .Returns(new[] { "A", "E", "C", "I", "K", "I", "H" });
                }
            }

            public static IEnumerable TestCaseInString
            {
                get
                {
                    yield return new TestCaseData(
                        new List<string> { "A", "B", "C", "D", "E" })
                        .Returns(new[] { "A", "B", "C", "D", "E" });

                    yield return new TestCaseData(
                        new List<string>() { "H", "I", "C", "A", "K", "I", "E" })
                        .Returns(new[] { "A", "C", "E", "H", "I", "I", "K" });
                }
            }

            public static IEnumerable TestCaseAddBook
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { new Book("A", "A"), new Book("B", "B"), new Book("C", "C") },
                        new Book("D", "D"),
                        new[] { new Book("A", "A"), new Book("B", "B"), new Book("C", "C"), new Book("D", "D") });

                    yield return new TestCaseData(
                        new[] { new Book("H", "H"), new Book("I", "I"), new Book("C", "C"), new Book("A", "A"), new Book("K", "K") }, 
                        new Book("E", "E"),
                        new[] { new Book("H", "H"), new Book("C", "C"), new Book("A", "A"), new Book("E", "E"), new Book("I", "I"), new Book("K", "K") });
                }
            }

            public static IEnumerable TestCaseContainsBook
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { new Book("A", "A"), new Book("B", "B"), new Book("C", "C") }, new Book("D", "D"))
                        .Returns(false);

                    yield return new TestCaseData(
                        new[] { new Book("H", "H"), new Book("I", "I"), new Book("C", "C"), new Book("A", "A"), new Book("K", "K") },
                        new Book("A", "A"))
                        .Returns(true);
                }
            }

            public static IEnumerable TestCaseRemoveBook
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { new Book("A", "A"), new Book("B", "B"), new Book("C", "C") },
                        new Book("C", "C"),
                        new[] { new Book("A", "A"), new Book("B", "B") });

                    yield return new TestCaseData(
                        new[] { new Book("H", "H"), new Book("I", "I"), new Book("C", "C"), new Book("A", "A"), new Book("K", "K"), new Book("E", "E") },
                        new Book("C", "C"),
                        new[] { new Book("H", "H"), new Book("E", "E"), new Book("A", "A"), new Book("I", "I"), new Book("K", "K") });
                }
            }

            public static IEnumerable TestCaseAddPoint
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { new Point(1, 1), new Point(2, 2), new Point(3, 3) },
                        new Point(4, 4),
                        new[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(4, 4) });
                }
            }

            public static IEnumerable TestCaseContainsPoint
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { new Point(1, 1), new Point(2, 2), new Point(3, 3) }, new Point(4, 4))
                        .Returns(false);
                }
            }

            public static IEnumerable TestCaseRemovePoint
            {
                get
                {
                    yield return new TestCaseData(
                        new[] { new Point(1, 1), new Point(2, 2), new Point(3, 3) },
                        new Point(3, 3),
                        new[] { new Point(1, 1), new Point(2, 2) });
                }
            }
        }
    }
}
