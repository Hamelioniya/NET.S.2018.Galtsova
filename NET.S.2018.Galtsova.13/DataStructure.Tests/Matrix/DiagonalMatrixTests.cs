using System;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    class DiagonalMatrixTests
    {
        [TestCase(2)]
        public void Constructor_ArgumentExceptionIsDiagonalTests(int order)
        {
            int[,] matrix = new int[order, order];

            int k = 0;
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    matrix[i, j] = k++;
                }
            }

            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(matrix));
        }

        [TestCase(1, 0, 0, 1)]
        [TestCase(12, 1, 1, 2)]
        [TestCase(0, 0, 1, 2)]
        public void Indexer_AddNewElementToMatrixTests(int element, int indexI, int indexJ, int order)
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(order);
            Handler handler = new Handler();

            matrix.ValueChanged += handler.Message;

            int oldElement = matrix[indexI, indexJ];
            matrix[indexI, indexJ] = element;

            Assert.AreEqual(
                string.Format("The element of the matrix was changed!\nRow index: {0}\nColumn index: {1}\nOld value: {2}\nNew value: {3}",
                indexI, indexJ, oldElement, element), handler.Result);
            Assert.AreEqual(matrix[indexI, indexJ], matrix[indexJ, indexI]);
        }

        [TestCase(12, 0, 1, 2)]
        public void Indexer_ArgumentOutOfRangeTests(int element, int indexI, int indexJ, int order)
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(order);

            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[indexI, indexJ] = element);
        } 
    }
}
