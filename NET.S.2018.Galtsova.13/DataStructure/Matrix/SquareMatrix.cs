using System;

namespace DataStructure
{
    /// <summary>
    /// Represents a square matrix.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class SquareMatrix<T>
    {
        #region Private const fields

        private const int DefaultOrder = 4;

        #endregion !Private const fields.

        #region Private fields

        private T[,] _matrix;
        private int _order;

        #endregion !Private fields.

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        public SquareMatrix() : this(DefaultOrder)
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="SquareMatrix{T}"/> with the passed order.
        /// </summary>
        /// <param name="order">The order of matrix.</param>
        public SquareMatrix(int order)
        {
            Order = order;
            _matrix = new T[_order, _order];
        }

        /// <summary>
        /// Initializes an instance of the <see cref="SquareMatrix{T}"/> with the passed matrix.
        /// </summary>
        /// <param name="matrix">The matrix to assign.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="matrix"/> equal to null.
        /// </exception>
        public SquareMatrix(T[,] matrix)
        {
            Matrix = matrix;
            _order = matrix.Length / 2;
        }

        #endregion !Public constructors.

        #region Public event

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MatrixEventArgs<T>> ValueChanged;

        #endregion !Public event.

        #region Public properties

        /// <summary>
        /// The order of matrix.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw when the value less than 0.
        /// </exception>
        public int Order
        {
            get
            {
                return _order;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of rows must be greater than or equal to 0.", nameof(Order));
                }

                _order = value;
            }
        }

        protected T[,] Matrix
        {
            get
            {
                return _matrix;
            }

            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(Matrix));
                }

                if (value.GetUpperBound(0) != value.GetUpperBound(1))
                {
                    throw new ArgumentException("The matrix must be square.", nameof(Matrix));
                }

                _matrix = value;
            }
        }

        #endregion !Private properties.

        /// <summary>
        /// The indexer for the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <param name="indexI">The row number.</param>
        /// <param name="indexJ">The column number.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="indexI"/> or/and <paramref name="indexJ"/> less than 0 or
        /// greater than or equal to the order of matrix.
        /// </exception>
        /// <returns>The element of matrix on passed indexes.</returns>
        public virtual T this[int indexI, int indexJ]
        {
            get
            {
                if ((indexI < 0) || (indexI >= _order))
                {
                    throw new ArgumentOutOfRangeException("Index i of the matrix element must be greater than 0 and less than order.", nameof(indexI));
                }

                if ((indexJ < 0) || (indexJ >= _order))
                {
                    throw new ArgumentOutOfRangeException("Index j of the matrix element must be greater than 0 and less than order.", nameof(indexI));
                }

                return _matrix[indexI, indexJ];
            }

            set
            {
                if ((indexI < 0) || (indexI >= _order))
                {
                    throw new ArgumentOutOfRangeException("Index i of the matrix element must be greater than 0 and less than order.", nameof(indexI));
                }

                if ((indexJ < 0) || (indexJ >= _order))
                {
                    throw new ArgumentOutOfRangeException("Index j of the matrix element must be greater than 0 and less than order.", nameof(indexI));
                }

                MatrixEventArgs<T> eventArgs = new MatrixEventArgs<T>()
                {
                    I = indexI,
                    J = indexJ,
                    OldValue = _matrix[indexI, indexJ],
                    NewValue = value
                };

                _matrix[indexI, indexJ] = value;

                OnChange(eventArgs);
            }
        }

        #region Protected methods

        /// <summary>
        /// Invokes a delegate when the value of the element of the matrix changed.
        /// </summary>
        /// <param name="e">Arguments of event.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <see cref="Matrix{T}.ValueChanged"/> equal to null.
        /// </exception>
        protected virtual void OnChange(MatrixEventArgs<T> e)
        {
            if (ReferenceEquals(ValueChanged, null))
            {
                throw new ArgumentNullException(nameof(ValueChanged));
            }

            ValueChanged(this, e);
        }

        #endregion !Protected methods.
    }
}
