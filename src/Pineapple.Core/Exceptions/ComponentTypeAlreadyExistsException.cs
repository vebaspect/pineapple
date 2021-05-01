using System;

namespace Pineapple.Core.Exceptions
{
    public class ComponentTypeAlreadyExistsException : Exception
    {
        public ComponentTypeAlreadyExistsException() : base()
        {
        }

        public ComponentTypeAlreadyExistsException(string message) : base(message)
        {
        }

        public ComponentTypeAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
