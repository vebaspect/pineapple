using System;

namespace Pineapple.Core.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base()
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}