using System;

namespace Pineapple.Core.Exceptions
{
    public class ServerComponentAlreadyExistsException : Exception
    {
        public ServerComponentAlreadyExistsException() : base()
        {
        }

        public ServerComponentAlreadyExistsException(string message) : base(message)
        {
        }

        public ServerComponentAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
