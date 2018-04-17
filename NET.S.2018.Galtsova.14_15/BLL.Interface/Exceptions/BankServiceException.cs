using System;
using System.Runtime.Serialization;

namespace BLL.Interface.Exceptions
{
    /// <summary>
    /// Represents a bank service exception.
    /// </summary>
    public class BankServiceException : Exception
    {
        public BankServiceException()
        {
        }

        public BankServiceException(string message) : base(message)
        {
        }

        public BankServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BankServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
