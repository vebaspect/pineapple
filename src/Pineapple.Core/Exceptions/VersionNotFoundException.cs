using System;

namespace Pineapple.Core.Exceptions
{
    public class VersionNotFoundException : Exception
    {
        public VersionNotFoundException() : base()
        {
        }

        public VersionNotFoundException(string message) : base(message)
        {
        }

        public VersionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
