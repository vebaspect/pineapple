using System;

namespace Pineapple.Core.Exceptions
{
    public class ImplementationNotFoundException : Exception
    {
        public ImplementationNotFoundException() : base()
        {
        }

        public ImplementationNotFoundException(string message) : base(message)
        {
        }

        public ImplementationNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
