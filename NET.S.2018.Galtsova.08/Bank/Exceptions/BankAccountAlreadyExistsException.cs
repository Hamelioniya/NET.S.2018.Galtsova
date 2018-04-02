using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Exceptions
{
    public class BankAccountAlreadyExistsException : Exception
    {
        public BankAccountAlreadyExistsException()
        {
        }

        public BankAccountAlreadyExistsException(string message) : base(message)
        {
        }

        public BankAccountAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BankAccountAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
