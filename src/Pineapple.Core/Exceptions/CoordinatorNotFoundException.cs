using System;

namespace Pineapple.Core.Exceptions
{
    public class CoordinatorNotFoundException : Exception
    {
        public CoordinatorNotFoundException() : base()
        {
        }

        public CoordinatorNotFoundException(string message) : base(message)
        {
        }

        public CoordinatorNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
