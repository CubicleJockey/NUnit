using System;
using System.Runtime.Serialization;

namespace NUnitObjects.Exceptions
{
    public class InsufficientFundsException : ApplicationException
    {
        public InsufficientFundsException() : base() { }
        public InsufficientFundsException(string message) : base(message) { }
        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException) { }
        public InsufficientFundsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
