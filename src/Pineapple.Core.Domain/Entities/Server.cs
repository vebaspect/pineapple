using System;
using System.Collections.Generic;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Serwer.
    /// </summary>
    public class Server : Entity
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
        /// Wersje.
        /// </summary>
        public List<Version> Versions { get; set; }

        /// <summary>
        /// Oprogramowanie.
        /// </summary>
        public List<SoftwareApplication> SoftwareApplications { get; set; }
    }
}
