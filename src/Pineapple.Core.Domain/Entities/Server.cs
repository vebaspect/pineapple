using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Serwer.
    /// </summary>
    public sealed class Server : Entity
    {
        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identyfikator środowiska.
        /// </summary>
        public Guid EnvironmentId { get; set; }

        /// <summary>
        /// Środowisko.
        /// </summary>
        public Environment Environment { get; set; }

        /// <summary>
        /// Identyfikator systemu operacyjnego.
        /// </summary>
        public Guid OperatingSystemId { get; set; }

        /// <summary>
        /// System operacyjny.
        /// </summary>
        public OperatingSystem OperatingSystem { get; set; }

        /// <summary>
        /// Adres IP.
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Wersje komponentów.
        /// </summary>
        public List<ComponentVersion> ComponentVersions { get; set; }

        /// <summary>
        /// Oprogramowanie.
        /// </summary>
        public List<SoftwareApplication> SoftwareApplications { get; set; }

        private Server(Guid id, string name, string symbol, string description, Guid environmentId, Guid operatingSystemId, string ipAddress)
        {
            Id = id;
            ModifiedDate = DateTime.Now;
            IsDeleted = false;
            Name = name;
            Symbol = symbol;
            Description = description;
            EnvironmentId = environmentId;
            OperatingSystemId = operatingSystemId;
            IPAddress = ipAddress;
        }

        /// <summary>
        /// Stwórz serwer.
        /// </summary>
        public static Server Create(Guid id, string name, string symbol, string description, Guid environmentId, Guid operatingSystemId, string ipAddress)
        {
            return new Server(id, name, symbol, description, environmentId, operatingSystemId, ipAddress);
        }
    }
}
