using System;

namespace Pineapple.Core.Exceptions
{
    public class SoftwareApplicationAlreadyExistsException : Exception
    {
        public SoftwareApplicationAlreadyExistsException() : base()
        {
        }

        public SoftwareApplicationAlreadyExistsException(string message) : base(message)
        {
        }

        public SoftwareApplicationAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
