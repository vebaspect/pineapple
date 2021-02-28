using System;

namespace Pineapple.Core.Exceptions
{
    public class ServerNotFoundException : Exception
    {
        public ServerNotFoundException() : base()
        {
        }

        public ServerNotFoundException(string message) : base(message)
        {
        }

        public ServerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
