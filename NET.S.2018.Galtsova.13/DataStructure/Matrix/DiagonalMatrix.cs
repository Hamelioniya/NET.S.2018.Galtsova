using System;

namespace DataStructure
{
    /// <summary>
    /// Represents a diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Public constructors        

        /// <summary>
        /// Initializes an instance of the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        public DiagonalMatrix() : base()
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="DiagonalMatrix{T}"/> with the passed order.
        /// </summary>
        /// <param name="order">The order of matrix.</param>
        public DiagonalMatrix(int order) : base(order)
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="DiagonalMatrix{T}"/> with passed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to assign.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="matrix"/> is not diagonal.
        /// </exception>
        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            if (this.IsDiagonal())
            {
                throw new ArgumentException("The passed matrix must be diagonal.", nameof(matrix));
            }
        }

        #endregion !Public constructors.

        /// <summary>
        /// The indexer for the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <param name="indexI">The row number.</param>
        /// <param name="indexJ">The column number.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="indexI"/> and <paramref name="indexJ"/> unequal
        /// and value is non-default.
        /// </exception>
        /// <returns>The element of matrix on passed indexes.</returns>
        public override T this[int indexI, int indexJ]
        {
            get
            {
                return base[indexI, indexJ];
            }

            set
            {
                if (indexI != indexJ && !((dynamic)value == default(T)))
                {
                    throw new ArgumentOutOfRangeException("A non-default element can only be placed on the main diagonal.");
                }

                base[indexI, indexJ] = value;
            }
        }

        /// <summary>
        /// Checks is matrix diagonal.
        /// </summary>
        /// <returns>true if matrix is diagonal, false otherwise.</returns>
        private bool IsDiagonal()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (i != j && ((dynamic)Matrix[i, j] == default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
