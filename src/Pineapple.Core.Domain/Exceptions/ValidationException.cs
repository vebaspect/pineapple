using System;

namespace Pineapple.Core.Domain.Exceptions
{
    public abstract class ValidationException : Exception
    {
        protected ValidationException() : base()
        {
        }

        protected ValidationException(string message) : base(message)
        {
        }

        protected ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
