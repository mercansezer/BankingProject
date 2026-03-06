using System;

namespace HarshaBank.Exceptions
{
    /// <summary>
    /// Represents errors that occur during transaction operations.
    /// </summary>
    public class TransactionException : Exception
    {
        public TransactionException(string message) : base(message) { }

        public TransactionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
