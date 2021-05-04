using System;

namespace Pineapple.Core.Exceptions
{
    public class ServerSoftwareApplicationAlreadyExistsException : Exception
    {
        public ServerSoftwareApplicationAlreadyExistsException() : base()
        {
        }

        public ServerSoftwareApplicationAlreadyExistsException(string message) : base(message)
        {
        }

        public ServerSoftwareApplicationAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
