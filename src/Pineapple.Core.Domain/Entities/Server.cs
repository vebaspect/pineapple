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
        /// Adres IP.
        /// </summary>
        public string IpAddress { get; }

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
        /// Zainstalowane komponenty.
        /// </summary>
        public List<ServerComponent> InstalledComponents { get; }

        /// <summary>
        /// Zainstalowane oprogramowanie.
        /// </summary>
        public List<ServerSoftwareApplication> InstalledSoftwareApplications { get; }

        /// <summary>
        /// Logi dotyczące serwera.
        /// </summary>
        public List<ServerLog> EntityLogs { get; }

        private Server(Guid id, string name, string symbol, string ipAddress, string description, Guid environmentId, Guid operatingSystemId)
            : base(id)
        {
            Name = name;
            Symbol = symbol;
            IpAddress = ipAddress;
            Description = description;
            EnvironmentId = environmentId;
            OperatingSystemId = operatingSystemId;
        }

        /// <summary>
        /// Stwórz serwer.
        /// </summary>
        public static Server Create(Guid id, string name, string symbol, string ipAddress, string description, Guid environmentId, Guid operatingSystemId)
        {
            return new Server(id, name, symbol, ipAddress, description, environmentId, operatingSystemId);
        }

        /// <summary>
        /// Zainstaluj komponent.
        /// </summary>
        public void InstallComponent(ServerComponent component)
        {
            InstalledComponents?.Add(component);
        }

        /// <summary>
        /// Odinstaluj komponent.
        /// </summary>
        public void UninstallComponent(ServerComponent component)
        {
            InstalledComponents?.Remove(component);
        }

        /// <summary>
        /// Zainstaluj oprogramowanie.
        /// </summary>
        public void InstallSoftwareApplication(ServerSoftwareApplication softwareApplication)
        {
            InstalledSoftwareApplications?.Add(softwareApplication);
        }

        /// <summary>
        /// Odinstaluj oprogramowanie.
        /// </summary>
        public void UninstallSoftwareApplication(ServerSoftwareApplication softwareApplication)
        {
            InstalledSoftwareApplications?.Remove(softwareApplication);
        }
    }
}
