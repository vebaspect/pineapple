using System;

namespace Pineapple.Core.Exceptions
{
    public class EnvironmentAlreadyExistsException : Exception
    {
        public EnvironmentAlreadyExistsException() : base()
        {
        }

        public EnvironmentAlreadyExistsException(string message) : base(message)
        {
        }

        public EnvironmentAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
