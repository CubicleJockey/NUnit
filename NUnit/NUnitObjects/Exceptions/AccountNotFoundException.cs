using System;
using System.Runtime.Serialization;

namespace NUnitObjects.Exceptions
{
    public class AccountNotFoundException : ApplicationException
    {
        public AccountNotFoundException() : base() { }
        public AccountNotFoundException(string message) : base(message) { }
        public AccountNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        public AccountNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
