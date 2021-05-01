using System;

namespace Pineapple.Core.Exceptions
{
    public class ServerAlreadyExistsException : Exception
    {
        public ServerAlreadyExistsException() : base()
        {
        }

        public ServerAlreadyExistsException(string message) : base(message)
        {
        }

        public ServerAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
