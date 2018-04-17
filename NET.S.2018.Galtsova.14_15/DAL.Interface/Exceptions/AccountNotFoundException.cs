using System;
using System.Runtime.Serialization;

namespace DAL.Interface.Exceptions
{
    /// <summary>
    /// Represents a bank account not found exception.
    /// </summary>
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException()
        {
        }

        public AccountNotFoundException(string message) : base(message)
        {
        }

        public AccountNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AccountNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
