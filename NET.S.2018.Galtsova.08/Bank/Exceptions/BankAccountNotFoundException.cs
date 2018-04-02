using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Exceptions
{
    public class BankAccountNotFoundException : Exception
    {
        public BankAccountNotFoundException()
        {
        }

        public BankAccountNotFoundException(string message) : base(message)
        {
        }

        public BankAccountNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BankAccountNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
