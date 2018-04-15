using System;

namespace DataStructure
{
    /// <summary>
    /// Provides extension for the matrices classes.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Adds the <see cref="SquareMatrix{T}"/> and the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of matrices elements.</typeparam>
        /// <param name="firstMatrix">The first matrix to add.</param>
        /// <param name="secondMatrix">The second matrix to add.</param>
        /// <returns>The matrix of added matrices elements.</returns>
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            return new SquareMatrix<T>(AddMatrix<T>(firstMatrix, secondMatrix));
        }

        /// <summary>
        /// Adds the <see cref="SymmetricalMatrix{T}"/> and the <see cref="SymmetricalMatrix{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of matrices elements.</typeparam>
        /// <param name="firstMatrix">The first matrix to add.</param>
        /// <param name="secondMatrix">The second matrix to add.</param>
        /// <returns>The matrix of added matrices elements.</returns>
        public static SymmetricalMatrix<T> Add<T>(this SymmetricalMatrix<T> firstMatrix, SymmetricalMatrix<T> secondMatrix)
        {
            return new SymmetricalMatrix<T>(AddMatrix<T>(firstMatrix, secondMatrix));
        }

        /// <summary>
        /// Adds the <see cref="DiagonalMatrix{T}"/> and the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of matrices elements.</typeparam>
        /// <param name="firstMatrix">The first matrix to add.</param>
        /// <param name="secondMatrix">The second matrix to add.</param>
        /// <returns>The matrix of added matrices elements.</returns>
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            CheckMatrix<T>(firstMatrix, secondMatrix);

            T[,] resultArray = new T[firstMatrix.Order, secondMatrix.Order];

            for (int i = 0; i < firstMatrix.Order; i++)
            {
                resultArray[i, i] = (dynamic)firstMatrix[i, i] + (dynamic)secondMatrix[i, i];
            }

            return new DiagonalMatrix<T>(resultArray);
        }

        /// <summary>
        /// Adds the <see cref="SquareMatrix{T}"/> and the <see cref="SymmetricalMatrix{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of matrices elements.</typeparam>
        /// <param name="firstMatrix">The first matrix to add.</param>
        /// <param name="secondMatrix">The second matrix to add.</param>
        /// <returns>The matrix of added matrices elements.</returns>
        public static SymmetricalMatrix<T> Add<T>(this SquareMatrix<T> firstMatrix, SymmetricalMatrix<T> secondMatrix)
        {
            CheckMatrix<T>(firstMatrix, secondMatrix);

            T[,] resultArray = new T[firstMatrix.Order, secondMatrix.Order];

            for (int i = 0; i < firstMatrix.Order; i++)
            {
                for (int j = 0; j < secondMatrix.Order; j++)
                {
                    resultArray[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                    resultArray[j, i] = resultArray[i, j];
                }
            }

            return new SymmetricalMatrix<T>(resultArray);
        }

        /// <summary>
        /// Adds the <see cref="SymmetricalMatrix{T}"/> and the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of matrices elements.</typeparam>
        /// <param name="firstMatrix">The first matrix to add.</param>
        /// <param name="secondMatrix">The second matrix to add.</param>
        /// <returns>The matrix of added matrices elements.</returns>
        public static SymmetricalMatrix<T> Add<T>(this SymmetricalMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix) => Add(secondMatrix, firstMatrix);

        /// <summary>
        /// Adds the <see cref="SquareMatrix{T}"/> and the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of matrices elements.</typeparam>
        /// <param name="firstMatrix">The first matrix to add.</param>
        /// <param name="secondMatrix">The second matrix to add.</param>
        /// <returns>The matrix of added matrices elements.</returns>
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            return new SquareMatrix<T>(AddMatrix<T>(firstMatrix, secondMatrix));
        }

        /// <summary>
        /// Adds the <see cref="DiagonalMatrix{T}"/> and the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of matrices elements.</typeparam>
        /// <param name="firstMatrix">The first matrix to add.</param>
        /// <param name="secondMatrix">The second matrix to add.</param>
        /// <returns>The matrix of added matrices elements.</returns>
        public static SquareMatrix<T> Add<T>(this DiagonalMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix) => Add(secondMatrix, firstMatrix);

        #region Private methods

        private static T[,] AddMatrix<T>(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            CheckMatrix<T>(firstMatrix, secondMatrix);

            T[,] resultArray = new T[firstMatrix.Order, secondMatrix.Order];

            for (int i = 0; i < firstMatrix.Order; i++)
            {
                for (int j = 0; j < secondMatrix.Order; j++)
                {
                    resultArray[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                }
            }

            return resultArray;
        }

        private static void CheckMatrix<T>(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            if (ReferenceEquals(firstMatrix, null))
            {
                throw new ArgumentNullException(nameof(firstMatrix));
            }

            if (ReferenceEquals(secondMatrix, null))
            {
                throw new ArgumentNullException(nameof(secondMatrix));
            }

            if (firstMatrix.Order != secondMatrix.Order)
            {
                throw new ArgumentException("Matrices must be of the same order.");
            }
        }

        #endregion !Private methods.
    }
}
