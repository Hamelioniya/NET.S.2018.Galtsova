using System.Collections;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class MatrixExtensionTests
    {
        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseSquareSquare))]
        public void Add_SquareAddToSquareMatrixTests(SquareMatrix<int> firstMatrix, SquareMatrix<int> secondMatrix, SquareMatrix<int> expectedMatrix)
        {
            SquareMatrix<int> result = firstMatrix.Add(secondMatrix);

            for (int i = 0; i < result.Order; i++)
            {
                for (int j = 0; j < result.Order; j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], result[i, j]);
                }
            }
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseSymmetricalSymmetrical))]
        public void Add_SymmetricalAddToSymmetricalMatrixTests(SymmetricalMatrix<int> firstMatrix, SymmetricalMatrix<int> secondMatrix, SymmetricalMatrix<int> expectedMatrix)
        {
            SymmetricalMatrix<int> result = firstMatrix.Add(secondMatrix);

            for (int i = 0; i < result.Order; i++)
            {
                for (int j = 0; j < result.Order; j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], result[i, j]);
                }
            }
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseDiagonalDiagonal))]
        public void Add_DiagonalAddToDiagonalMatrixTests(DiagonalMatrix<int> firstMatrix, DiagonalMatrix<int> secondMatrix, DiagonalMatrix<int> expectedMatrix)
        {
            DiagonalMatrix<int> result = firstMatrix.Add(secondMatrix);

            for (int i = 0; i < result.Order; i++)
            {
                for (int j = 0; j < result.Order; j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], result[i, j]);
                }
            }
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseSquareSymmetrical))]
        public void Add_SquareAddToSymmetricalMatrixTests(SquareMatrix<int> firstMatrix, SymmetricalMatrix<int> secondMatrix, SymmetricalMatrix<int> expectedMatrix)
        {
            SymmetricalMatrix<int> result = firstMatrix.Add(secondMatrix);

            for (int i = 0; i < result.Order; i++)
            {
                for (int j = 0; j < result.Order; j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], result[i, j]);
                }
            }
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCaseSquareDiagonal))]
        public void Add_SquareAddToDiagonalMatrixTests(SquareMatrix<int> firstMatrix, DiagonalMatrix<int> secondMatrix, SquareMatrix<int> expectedMatrix)
        {
            SquareMatrix<int> result = firstMatrix.Add(secondMatrix);

            for (int i = 0; i < result.Order; i++)
            {
                for (int j = 0; j < result.Order; j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], result[i, j]);
                }
            }
        }

        private class TestCasesClass
        {
            public static IEnumerable TestCaseSquareSquare
            {
                get
                {
                    yield return new TestCaseData(
                        new SquareMatrix<int>(new int[,] { { 1, 2 }, { 2, 3 } }),
                        new SquareMatrix<int>(new int[,] { { 2, 2 }, { 3, 3 } }),
                        new SquareMatrix<int>(new int[,] { { 3, 4 }, { 5, 6 } }));
                }
            }

            public static IEnumerable TestCaseSymmetricalSymmetrical
            {
                get
                {
                    yield return new TestCaseData(
                        new SymmetricalMatrix<int>(new int[,] { { 1, 2 }, { 2, 3 } }),
                        new SymmetricalMatrix<int>(new int[,] { { 2, 3 }, { 3, 3 } }),
                        new SymmetricalMatrix<int>(new int[,] { { 3, 5 }, { 5, 6 } }));
                }
            }

            public static IEnumerable TestCaseDiagonalDiagonal
            {
                get
                {
                    yield return new TestCaseData(
                        new DiagonalMatrix<int>(new int[,] { { 1, 0 }, { 0, 3 } }),
                        new DiagonalMatrix<int>(new int[,] { { 2, 0 }, { 0, 3 } }),
                        new DiagonalMatrix<int>(new int[,] { { 3, 0 }, { 0, 6 } }));
                }
            }

            public static IEnumerable TestCaseSquareSymmetrical
            {
                get
                {
                    yield return new TestCaseData(
                        new SquareMatrix<int>(new int[,] { { 1, 2 }, { 4, 3 } }),
                        new SymmetricalMatrix<int>(new int[,] { { 2, 3 }, { 3, 3 } }),
                        new SymmetricalMatrix<int>(new int[,] { { 3, 7 }, { 7, 6 } }));
                }
            }

            public static IEnumerable TestCaseSquareDiagonal
            {
                get
                {
                    yield return new TestCaseData(
                        new SquareMatrix<int>(new int[,] { { 1, 2 }, { 4, 3 } }),
                        new DiagonalMatrix<int>(new int[,] { { 2, 0 }, { 0, 3 } }),
                        new SquareMatrix<int>(new int[,] { { 3, 2 }, { 4, 6 } }));
                }
            }
        }
    }
}
