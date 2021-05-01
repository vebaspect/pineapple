using System;

namespace Pineapple.Core.Exceptions
{
    public class ComponentVersionAlreadyExistsException : Exception
    {
        public ComponentVersionAlreadyExistsException() : base()
        {
        }

        public ComponentVersionAlreadyExistsException(string message) : base(message)
        {
        }

        public ComponentVersionAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
