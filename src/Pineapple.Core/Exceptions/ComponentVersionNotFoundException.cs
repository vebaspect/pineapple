using System;

namespace Pineapple.Core.Exceptions
{
    public class ComponentVersionNotFoundException : Exception
    {
        public ComponentVersionNotFoundException() : base()
        {
        }

        public ComponentVersionNotFoundException(string message) : base(message)
        {
        }

        public ComponentVersionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
