using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class QueueTests
    {
        #region Constructor tests

        [TestCase(-1)]
        public void Constructor_ArgumentOutOfRangeExceptionTest(int capacity)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Queue<string>(capacity));
        }

        [Test]
        public void Constructor_ArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => new Queue<string>(null));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesCount))]
        public int Count_GetCountOfElementsTests(List<string> list)
        {
            Queue<string> queue = new Queue<string>(list);

            return queue.Count;
        }

        #endregion !Constructor tests.

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesContains))]
        public bool Contains_SearchElementInQueueTests(List<string> list, string element)
        {
            Queue<string> queue = new Queue<string>(list);

            return queue.Contains(element);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesEnqueue))]
        public bool Enqueue_AddElementToQueueTests(string element)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(element);

            return queue.Contains(element);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesDequeue))]
        public string Dequeue_GetAndRemoveElementFromQueueTests(List<string> list, int numOfDequeueElements)
        {
            Queue<string> queue = new Queue<string>(list);

            for (int i = 0; i < numOfDequeueElements - 1; i++)
            {
                queue.Dequeue();
            }

            return queue.Dequeue();
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesDequeueInvalidOperation))]
        public void Dequeue_InvalidOperationExceptionTests(List<string> list, int numOfDequeueElements)
        {
            Queue<string> queue = new Queue<string>(list);

            for (int i = 0; i < numOfDequeueElements - 1; i++)
            {
                queue.Dequeue();
            }

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesPeek))]
        public string Peek_GetElementFromQueueTests(List<string> list, int numOfDequeueElements)
        {
            Queue<string> queue = new Queue<string>(list);

            for (int i = 0; i < numOfDequeueElements - 1; i++)
            {
                queue.Peek();
            }

            return queue.Peek();
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesClear))]
        public int Clear_RemoveAllElementsFromQueueTests(List<string> list)
        {
            Queue<string> queue = new Queue<string>(list);
            queue.Clear();

            return queue.Count;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesGetEnumerator))]
        public string[] GetEnumerator_GetEnumOfElementsTests(List<string> list)
        {
            Queue<string> queue = new Queue<string>(list);
            string[] result = new string[queue.Count];

            int i = 0;
            foreach (string item in queue)
            {
                result[i++] = item;
            }

            return result;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesEnqueueDequeue))]
        public string[] EnqueueDequeue_AddAndRemoveElementsTests(List<string> list, string element, int numOfDequeueElements, int numOfEnqueueElements)
        {
            Queue<string> queue = new Queue<string>(list);
            int i;

            for (i = 0; i < numOfDequeueElements; i++)
            {
                queue.Dequeue();
            }

            for (i = 0; i < numOfEnqueueElements; i++)
            {
                queue.Enqueue(element);
            }

            string[] result = new string[queue.Count];

            i = 0;
            foreach (string item in queue)
            {
                result[i++] = item;
            }

            return result;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesCopyTo))]
        public string[] CopyTo_CopyToArrayTests(List<string> list, int index)
        {
            Queue<string> queue = new Queue<string>(list);

            string[] result = new string[queue.Count - index];

            queue.CopyTo(result, index);

            return result;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesCopyToArgumentException))]
        public void CopyTo_ArgumentExceptionTests(List<string> list, int index, Array array)
        {
            Queue<string> queue = new Queue<string>(list);

            Assert.Throws<ArgumentException>(() => queue.CopyTo(array, index));
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesCopyToArgumentNullException))]
        public void CopyTo_ArgumentNullExceptionTests(List<string> list, int index, Array array)
        {
            Queue<string> queue = new Queue<string>(list);

            Assert.Throws<ArgumentNullException>(() => queue.CopyTo(array, index));
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCasesCount
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }).Returns(3);

                    yield return new TestCaseData(new List<string>()).Returns(0);
                }
            }

            public static IEnumerable TestCasesContains
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, "Masha").Returns(true);

                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, "Vasya").Returns(false);
                }
            }

            public static IEnumerable TestCasesEnqueue
            {
                get
                {
                    yield return new TestCaseData("Masha").Returns(true);
                }
            }

            public static IEnumerable TestCasesDequeue
            {
                get
                {           
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 1).Returns("Petya");

                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 2).Returns("Masha");

                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 3).Returns("Alena");
                }
            }

            public static IEnumerable TestCasesDequeueInvalidOperation
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 4);
                }
            }

            public static IEnumerable TestCasesPeek
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 2).Returns("Petya");

                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 4).Returns("Petya");
                }
            }

            public static IEnumerable TestCasesClear
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }).Returns(0);
                }
            }

            public static IEnumerable TestCasesGetEnumerator
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }).Returns(new[] { "Petya", "Masha", "Alena" });
                }
            }

            public static IEnumerable TestCasesEnqueueDequeue
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, "Vasya", 2, 1).Returns(new[] { "Alena", "Vasya" });

                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, "Vasya", 1, 2).Returns(new[] { "Masha", "Alena", "Vasya", "Vasya" });
                }
            }

            public static IEnumerable TestCasesCopyTo
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 0).Returns(new[] { "Petya", "Masha", "Alena" });

                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 1).Returns(new[] { "Masha", "Alena" });
                }
            }

            public static IEnumerable TestCasesCopyToArgumentException
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, -5, new string[3]);

                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 5, new string[3]);

                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, 0, new string[1]);
                }
            }

            public static IEnumerable TestCasesCopyToArgumentNullException
            {
                get
                {
                    yield return new TestCaseData(new List<string> { "Petya", "Masha", "Alena" }, -5, null);
                }
            }
        }
    }
}
