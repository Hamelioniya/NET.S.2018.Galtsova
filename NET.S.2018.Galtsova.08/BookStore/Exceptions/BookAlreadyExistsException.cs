using System;
using System.Runtime.Serialization;

namespace BookStore.Exceptions
{
    /// <summary>
    /// Represents an exception when a book already exists at the list.
    /// </summary>
    public class BookAlreadyExistsException : Exception
    {
        public BookAlreadyExistsException()
        {
        }

        public BookAlreadyExistsException(string message) : base(message)
        {
        }

        public BookAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BookAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
