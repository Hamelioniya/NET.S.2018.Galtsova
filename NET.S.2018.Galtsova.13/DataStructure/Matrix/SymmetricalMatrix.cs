using System;

namespace DataStructure
{
    /// <summary>
    /// Represents a symmetrical matrix.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="SymmetricalMatrix{T}"/>.
        /// </summary>
        public SymmetricalMatrix() : base()
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="SymmetricalMatrix{T}"/> with the passed order.
        /// </summary>
        /// <param name="order">The order of matrix.</param>
        public SymmetricalMatrix(int order) : base(order)
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="SymmetricalMatrix{T}"/> with the passed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to assign.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="matrix"/> is not symmetrical.
        /// </exception>
        public SymmetricalMatrix(T[,] matrix) : base(matrix)
        {
            if (!this.IsSymmetry())
            {
                throw new ArgumentException("The passed matrix must be symmetric.", nameof(matrix));
            }
        }

        #endregion !Public constructors.

        /// <summary>
        /// The indexer for the <see cref="SymmetricalMatrix{T}"/>.
        /// </summary>
        /// <param name="indexI">The row number.</param>
        /// <param name="indexJ">The column number.</param>
        /// <returns>The element of matrix on passed indexes.</returns>
        public override T this[int indexI, int indexJ]
        {
            get
            {
                return base[indexI, indexJ];
            }

            set
            {
                base[indexI, indexJ] = value;
                this.Matrix[indexJ, indexI] = value;
            }
        }

        /// <summary>
        /// Checks is matrix symmetrical.
        /// </summary>
        /// <returns>true if matrix is symmetrical, false otherwise.</returns>
        private bool IsSymmetry()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (!((dynamic)Matrix[i, j] == (dynamic)Matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
