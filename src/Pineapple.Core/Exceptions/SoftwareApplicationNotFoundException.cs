using System;

namespace Pineapple.Core.Exceptions
{
    public class SoftwareApplicationNotFoundException : Exception
    {
        public SoftwareApplicationNotFoundException() : base()
        {
        }

        public SoftwareApplicationNotFoundException(string message) : base(message)
        {
        }

        public SoftwareApplicationNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
