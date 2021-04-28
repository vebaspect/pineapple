using System;

namespace Pineapple.Core.Exceptions
{
    public class ServerComponentNotFoundException : Exception
    {
        public ServerComponentNotFoundException() : base()
        {
        }

        public ServerComponentNotFoundException(string message) : base(message)
        {
        }

        public ServerComponentNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
