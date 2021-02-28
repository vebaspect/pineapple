using System;

namespace Pineapple.Core.Exceptions
{
    public class ComponentNotFoundException : Exception
    {
        public ComponentNotFoundException() : base()
        {
        }

        public ComponentNotFoundException(string message) : base(message)
        {
        }

        public ComponentNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
