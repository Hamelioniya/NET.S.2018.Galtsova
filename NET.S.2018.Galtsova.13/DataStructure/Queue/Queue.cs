using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    /// <summary>
    /// Represents a custom queue.
    /// </summary>
    /// <typeparam name="T">Type of elements of the queue.</typeparam>
    public class Queue<T> : ICollection, IEnumerable<T>
    {
        #region Private const fields

        private const int DefaultCapacity = 4;

        #endregion !Private const fields.

        #region Private fields

        private T[] _arrayOfElements;
        private int _size;
        private int _head;
        private int _tail;
        private object _syncRoot;

        #endregion !Private fields.

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="Queue{T}"/>.
        /// </summary>
        public Queue() : this(DefaultCapacity)
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="Queue{T}"/> with the passed capacity.
        /// </summary>
        /// <param name="capacity">The capacity of the new queue.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="capacity"/> less than 0.
        /// </exception>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Capacity of the queue must be greater than or equal to 0.", nameof(capacity));
            }

            _arrayOfElements = new T[capacity];
            _head = 0;
            _tail = 0;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="Queue{T}"/> with the passed collection.
        /// </summary>
        /// <param name="collection">The collection to copy.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="collection"/> equal to null.
        /// </exception>
        public Queue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException(nameof(collection));
            }

            _arrayOfElements = new T[DefaultCapacity];
            _size = 0;
            _head = 0;
            _tail = 0;

            foreach (var item in collection)
            {
                this.Enqueue(item);
            }
        }

        #endregion !Public constructors.

        #region ICollection implementation

        /// <summary>
        /// A number of elements contained in the queue.
        /// </summary>
        public int Count
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// A value indicating whether access to the queue is synchronized.
        /// </summary>
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// An object that can be used to synchronize access to the queue.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <see cref="Queue{T}._syncRoot"/> equal to null.
        /// </exception>
        public object SyncRoot
        {
            get
            {
                if (ReferenceEquals(_syncRoot, null))
                {
                    System.Threading.Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);
                }

                return _syncRoot;
            }
        }

        /// <summary>
        /// Determines whether an element is in the queue.
        /// </summary>
        /// <param name="element">The element to search for.</param>
        /// <returns>true if the queue contains the passed element, false otherwise.</returns>
        public bool Contains(T element)
        {
            T[] array = this.ToArray();

            for (int i = 0; i < _size; i++)
            {
                if (array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copies the queue elements to an existing one-dimensional <paramref name="array"/>,
        /// starting at the specified array <paramref name="index"/>.
        /// </summary>
        /// <param name="array">An array from which elements copies.</param>
        /// <param name="index">An index from which elements copies.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="array"/> equal to null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="array"/> rank unequal to 1, number of copied elements greater
        /// than the queue size, type of <paramref name="array"/> unequal to type of the queue,
        /// <paramref name="index"/> less than 0 or greater than the queue size - <paramref name="index"/>.
        /// </exception>
        public void CopyTo(Array array, int index)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("Rank of the array must be equal to 1.", nameof(array));
            }

            if ((index < 0) || (index >= _size))
            {
                throw new ArgumentException("Index must be greater than 0 and less than the queue size.", nameof(index));
            }

            if (_size - index > array.Length)
            {
                throw new ArgumentException("Length of the array must be greater than or equal to the size of the queue - index.", nameof(array));
            }

            if (_head >= _tail)
            {
                Array.Copy(_arrayOfElements, _head + index, array, 0, _size - _head - index);
                Array.Copy(_arrayOfElements, 0, array, _size - _head - index, _head);
            }
            else
            {
                Array.Copy(_arrayOfElements, _head + index, array, 0, _size - index);
            }
        }

        #endregion !ICollection implementation.

        #region Public methods

        /// <summary>
        /// Adds the element to the queue.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void Enqueue(T element)
        {
            if (_size == _arrayOfElements.Length)
            {
                T[] newArray = new T[_arrayOfElements.Length + 1];
                Array.Copy(_arrayOfElements, _head, newArray, 0, _arrayOfElements.Length - _head);
                Array.Copy(_arrayOfElements, 0, newArray, _arrayOfElements.Length - _head, _tail);

                _arrayOfElements = newArray;
                _head = 0;
                _tail = _arrayOfElements.Length - 1;
            }
            else
            {
                if (_tail == _arrayOfElements.Length)
                {
                    _tail = 0;
                }
            }

            _arrayOfElements[_tail] = element;
            _tail++;
            _size++;
        }

        /// <summary>
        /// Removes and returns the element at the beginning of the queue.
        /// and increment position.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the size of the queue equal to 0.
        /// </exception>
        /// <returns>The element at the beginning of the queue.</returns>
        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T result = _arrayOfElements[_head];
            _arrayOfElements[_head] = default(T);
            _head++;
            _size--;

            return result;
        }

        /// <summary>
        /// Returns the element at the beginning of the queue without removing it.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the size of the queue equal to 0.
        /// </exception>
        /// <returns>The element at the beginning of the queue.</returns>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _arrayOfElements[_head];
        }

        /// <summary>
        /// Removes all elements of the queue.
        /// </summary>
        public void Clear()
        {
            Array.Clear(_arrayOfElements, 0, _arrayOfElements.Length);
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        /// <summary>
        /// Sets the capacity to the actual number of elements in the <see cref="Queue<T>"/>.
        /// </summary>
        public void TrimExcess()
        {
            _arrayOfElements = this.ToArray();
            _head = 0;
            _tail = _size;
        }

        /// <summary>
        /// Copies the queue elements to an existing one-dimensional <paramref name="array"/>,
        /// starting at the specified array <paramref name="index"/>.
        /// </summary>
        /// <param name="array">An array from which elements copies.</param>
        /// <param name="index">An index from which elements copies.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="array"/> equal to null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="array"/> rank unequal to 1, number of copied elements greater
        /// than the queue size, type of <paramref name="array"/> unequal to type of the queue,
        /// <paramref name="index"/> less than 0 or greater than the queue size - <paramref name="index"/>.
        /// </exception>
        public void CopyTo(T[] array, int index)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("Rank of the array must be equal to 1.", nameof(array));
            }

            if ((index < 0) || (index >= _size))
            {
                throw new ArgumentException("Index must be greater than 0 and less than the queue size.", nameof(index));
            }

            if (_size - index > array.Length)
            {
                throw new ArgumentException("Length of the array must be greater than or equal to the size of the queue - index.", nameof(array));
            }

            if (_head >= _tail)
            {
                Array.Copy(_arrayOfElements, _head + index, array, 0, _size - _head - index);
                Array.Copy(_arrayOfElements, 0, array, _size - _head - index, _head);
            }
            else
            {
                Array.Copy(_arrayOfElements, _head + index, array, 0, _size - index);
            }
        }

        /// <summary>
        /// Copies the queue elements to the new array.
        /// </summary>
        /// <returns>The new array with queue elements.</returns>
        public T[] ToArray()
        {
            T[] newArray = new T[_size];

            if (_head > _tail)
            {
                Array.Copy(_arrayOfElements, _head, newArray, 0, _arrayOfElements.Length - _head);
                Array.Copy(_arrayOfElements, 0, newArray, _arrayOfElements.Length - _head, _tail);
            }
            else
            {
                Array.Copy(_arrayOfElements, _head, newArray, 0, _size);
            }

            return newArray;
        }

        #endregion !Public methods.

        #region IEnumerable implementation

        /// <summary>
        /// Gets the enumerator for the queue.
        /// </summary>
        /// <returns>The enumerator for the queue.</returns>
        public IEnumerator GetEnumerator()
        {
            return new QueueEnumerator<T>(this);
        }

        /// <summary>
        /// Gets the enumerator for the queue.
        /// </summary>
        /// <returns>The enumerator for the queue.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new QueueEnumerator<T>(this);
        }

        #endregion !IEnumerable implementation.

        #region Internal methods

        /// <summary>
        /// Gets the element of the queue by the index.
        /// </summary>
        /// <param name="index">The index of element in the queue.</param>
        /// <returns>The element of the queue on the passed index.</returns>
        internal T GetElement(int index)
        {
            if (_size - _tail - index > 0)
            {
                return _arrayOfElements[_head + index];
            }
            else
            {
                return _arrayOfElements[Math.Abs(_size - _tail - index)];
            }
        }

        #endregion !Internal methods.
    }
}
