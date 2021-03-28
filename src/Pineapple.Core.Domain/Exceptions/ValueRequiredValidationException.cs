using System;

namespace Pineapple.Core.Domain.Exceptions
{
    public class ValueRequiredValidationException : ValidationException
    {
        public ValueRequiredValidationException() : base()
        {
        }

        public ValueRequiredValidationException(string message) : base(message)
        {
        }

        public ValueRequiredValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
