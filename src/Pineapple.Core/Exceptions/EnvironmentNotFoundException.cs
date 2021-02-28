using System;

namespace Pineapple.Core.Exceptions
{
    public class EnvironmentNotFoundException : Exception
    {
        public EnvironmentNotFoundException() : base()
        {
        }

        public EnvironmentNotFoundException(string message) : base(message)
        {
        }

        public EnvironmentNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
