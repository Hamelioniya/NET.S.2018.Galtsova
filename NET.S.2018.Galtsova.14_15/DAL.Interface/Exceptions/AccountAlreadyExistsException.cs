using System;
using System.Runtime.Serialization;

namespace DAL.Interface.Exceptions
{
    /// <summary>
    /// Represents a bank account already exists exception.
    /// </summary>
    public class AccountAlreadyExistsException : Exception
    {
        public AccountAlreadyExistsException()
        {
        }

        public AccountAlreadyExistsException(string message) : base(message)
        {
        }

        public AccountAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AccountAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
