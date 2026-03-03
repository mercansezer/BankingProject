using System;

namespace HarshaBank.Exceptions
{

    /// <summary>
    /// Exception class that represents error raised in Customer class
    /// </summary>
    public class CustomerException : Exception
    {
        /// <summary>
        /// Constructor that initializes exception message
        /// </summary>
        /// <param name="message">exception message</param>
        public CustomerException(string message) : base(message) { }


        /// <summary>
        /// Constructor that initializes exception message and inner exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">inner exception</param>
        public CustomerException(string message, Exception innerException) : base(message, innerException) { }

    }
}
