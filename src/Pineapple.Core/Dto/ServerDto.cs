using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Serwer.
    /// </summary>
    public class ServerDto : IDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModifiedDate { get; }

        /// <summary>
        /// Flaga określająca, czy serwer został usunięty.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Identyfikator systemu operacyjnego.
        /// </summary>
        public Guid OperatingSystemId { get; }

        /// <summary>
        /// Nazwa systemu operacyjnego.
        /// </summary>
        public string OperatingSystemName { get; }

        /// <summary>
        /// Adres IP.
        /// </summary>
        public string IPAddress { get; }

        public ServerDto(Guid id, DateTime modifiedDate, bool isDeleted, string name, string symbol, string description, Guid operatingSystemId, string operatingSystemName, string ipAddress)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            IsDeleted = isDeleted;
            Name = name;
            Symbol = symbol;
            Description = description;
            OperatingSystemId = operatingSystemId;
            OperatingSystemName = operatingSystemName;
            IPAddress = ipAddress;
        }
    }
}
