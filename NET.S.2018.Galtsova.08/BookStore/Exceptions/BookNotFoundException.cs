using System;
using System.Runtime.Serialization;

namespace BookStore.Exceptions
{
    /// <summary>
    /// Represents an exception when a book not found at the list.
    /// </summary>
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException()
        {
        }

        public BookNotFoundException(string message) : base(message)
        {
        }

        public BookNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BookNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
