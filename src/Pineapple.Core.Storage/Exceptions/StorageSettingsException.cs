using System;

namespace Pineapple.Core.Storage.Exceptions
{
    public class StorageSettingsException : Exception
    {
        public StorageSettingsException() : base()
        {
        }

        public StorageSettingsException(string message) : base(message)
        {
        }

        public StorageSettingsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
