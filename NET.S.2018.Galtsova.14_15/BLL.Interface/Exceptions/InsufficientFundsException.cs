using System;
using System.Runtime.Serialization;

namespace BLL.Interface.Exceptions
{
    /// <summary>
    /// Represents an insufficient funds exception.
    /// </summary>
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException()
        {
        }

        public InsufficientFundsException(string message) : base(message)
        {
        }

        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InsufficientFundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
