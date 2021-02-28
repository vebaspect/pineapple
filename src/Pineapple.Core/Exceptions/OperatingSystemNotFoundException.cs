using System;

namespace Pineapple.Core.Exceptions
{
    public class OperatingSystemNotFoundException : Exception
    {
        public OperatingSystemNotFoundException() : base()
        {
        }

        public OperatingSystemNotFoundException(string message) : base(message)
        {
        }

        public OperatingSystemNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
