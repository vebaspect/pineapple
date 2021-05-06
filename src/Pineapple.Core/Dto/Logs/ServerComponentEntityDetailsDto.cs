using System;

namespace Pineapple.Core.Dto.Logs
{
    /// <summary>
    /// Szczegółowe informacje nt. komponentu zainstalowanego na serwerze.
    /// </summary>
    public class ServerComponentEntityDetailsDto
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Nazwa produktu.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; set; }

        /// <summary>
        /// Nazwa komponentu.
        /// </summary>
        public string ComponentName { get; set; }

        /// <summary>
        /// Identyfikator wersji komponentu.
        /// </summary>
        public Guid ComponentVersionId { get; set; }

        /// <summary>
        /// Numer wersji komponentu.
        /// </summary>
        public string ComponentVersionNumber { get; set; }
    }
}
