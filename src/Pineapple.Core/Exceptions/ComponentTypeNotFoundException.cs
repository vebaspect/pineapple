using System;

namespace Pineapple.Core.Exceptions
{
    public class ComponentTypeNotFoundException : Exception
    {
        public ComponentTypeNotFoundException() : base()
        {
        }

        public ComponentTypeNotFoundException(string message) : base(message)
        {
        }

        public ComponentTypeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
