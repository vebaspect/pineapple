using System;

namespace Pineapple.Core.Exceptions
{
    public class ServerSoftwareApplicationNotFoundException : Exception
    {
        public ServerSoftwareApplicationNotFoundException() : base()
        {
        }

        public ServerSoftwareApplicationNotFoundException(string message) : base(message)
        {
        }

        public ServerSoftwareApplicationNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
