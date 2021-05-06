using System;

namespace Pineapple.Core.Dto.Logs
{
    /// <summary>
    /// Szczegółowe informacje nt. oprogramowania zainstalowanego na serwerze.
    /// </summary>
    public class ServerSoftwareApplicationEntityDetailsDto
    {
        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; set; }

        /// <summary>
        /// Nazwa oprogramowania.
        /// </summary>
        public string SoftwareApplicationName { get; set; }
    }
}
