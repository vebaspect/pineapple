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

        public ServerDto(Guid id, DateTime modifiedDate, string name, string symbol, string description, Guid operatingSystemId, string operatingSystemName)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            Name = name;
            Symbol = symbol;
            Description = description;
            OperatingSystemId = operatingSystemId;
            OperatingSystemName = operatingSystemName;
        }
    }
}
