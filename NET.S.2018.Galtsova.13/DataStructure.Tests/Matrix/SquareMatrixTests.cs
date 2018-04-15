using System;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        [TestCase(-1)]
        public void Constructor_ArgumentOutOfRangeExceptionTests(int order)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SquareMatrix<int>(order));
        }

        [Test]
        public void Constructor_ArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => new SquareMatrix<int>(null));
        }

        [TestCase(2, 3)]
        public void Constructor_ArgumentExceptionTests(int numOfRows, int numOfColumns)
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(new int[numOfRows, numOfColumns]));
        }

        [TestCase(1, 0, 0, 1)]
        [TestCase(12, 0, 1, 2)]
        public void Indexer_AddNewElementToMatrixTests(int element, int indexI, int indexJ, int order)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(order);
            Handler handler = new Handler();

            matrix.ValueChanged += handler.Message;

            int oldElement = matrix[indexI, indexJ];
            matrix[indexI, indexJ] = element;

            Assert.AreEqual(
                string.Format("The element of the matrix was changed!\nRow index: {0}\nColumn index: {1}\nOld value: {2}\nNew value: {3}",
                indexI, indexJ, oldElement, element), handler.Result);
        }


        [TestCase(1, 1, 0, 1)]
        [TestCase(1, 0, 1, 1)]
        [TestCase(1, 1, 1, 1)]
        [TestCase(12, -1, 1, 2)]
        [TestCase(12, 1, -1, 2)]
        [TestCase(12, -1, -1, 2)]
        public void IndexerSet_ArgumentOutOfRangeExceptionTests(int element, int indexI, int indexJ, int order)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(order);
            Handler handler = new Handler();

            matrix.ValueChanged += handler.Message;

            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[indexI, indexJ] = element);
        }

        [TestCase(1, 1, 0, 1)]
        [TestCase(1, 0, 1, 1)]
        [TestCase(1, 1, 1, 1)]
        [TestCase(12, -1, 1, 2)]
        [TestCase(12, 1, -1, 2)]
        [TestCase(12, -1, -1, 2)]
        public void IndexerGet_ArgumentOutOfRangeExceptionTests(int element, int indexI, int indexJ, int order)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(order);
            Handler handler = new Handler();

            matrix.ValueChanged += handler.Message;

            Assert.Throws<ArgumentOutOfRangeException>(() => { int i = matrix[indexI, indexJ]; });
        }
    }
}
