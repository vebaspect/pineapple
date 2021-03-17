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
        /// Identyfikator środowiska.
        /// </summary>
        public Guid EnvironmentId { get; }

        /// <summary>
        /// Środowisko.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Identyfikator systemu operacyjnego.
        /// </summary>
        public Guid OperatingSystemId { get; }

        /// <summary>
        /// System operacyjny.
        /// </summary>
        public OperatingSystem OperatingSystem { get; }

        /// <summary>
        /// Adres IP.
        /// </summary>
        public string IpAddress { get; }

        /// <summary>
        /// Wersje komponentów.
        /// </summary>
        public List<ComponentVersion> ComponentVersions { get; }

        /// <summary>
        /// Oprogramowanie.
        /// </summary>
        public List<SoftwareApplication> SoftwareApplications { get; }

        /// <summary>
        /// Logi dotyczące serwera.
        /// </summary>
        public List<ServerLog> EntityLogs { get; }

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
            IpAddress = ipAddress;
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
