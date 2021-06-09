using System;
using System.Collections.Generic;

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
        /// Data utworzenia.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Data modyfikacji.
        /// </summary>
        public DateTime ModificationDate { get; }

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
        /// Adres IP.
        /// </summary>
        public string IpAddress { get; }

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
        /// Zainstalowane komponenty.
        /// </summary>
        public List<InstalledComponentDto> InstalledComponents { get; }

        /// <summary>
        /// Zainstalowane oprogramowanie.
        /// </summary>
        public List<InstalledSoftwareApplicationDto> InstalledSoftwareApplications { get; }

        /// <summary>
        /// Flaga określająca, czy dostępne są nowsze wersje zainstalowanych komponentów.
        /// </summary>
        public bool IsUpdateAvailable { get; }

        public ServerDto(Guid id, DateTime creationDate, DateTime modificationDate, bool isDeleted, string name, string symbol, string ipAddress, string description, Guid operatingSystemId, string operatingSystemName, List<InstalledComponentDto> installedComponents, List<InstalledSoftwareApplicationDto> installedSoftwareApplications, bool isUpdateAvailable)
        {
            Id = id;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            IsDeleted = isDeleted;
            Name = name;
            Symbol = symbol;
            IpAddress = ipAddress;
            Description = description;
            OperatingSystemId = operatingSystemId;
            OperatingSystemName = operatingSystemName;
            InstalledComponents = installedComponents;
            InstalledSoftwareApplications = installedSoftwareApplications;
            IsUpdateAvailable = isUpdateAvailable;
        }
    }
}
