using System;

namespace Pineapple.Core.Exceptions
{
    public class OperatingSystemAlreadyExistsException : Exception
    {
        public OperatingSystemAlreadyExistsException() : base()
        {
        }

        public OperatingSystemAlreadyExistsException(string message) : base(message)
        {
        }

        public OperatingSystemAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
