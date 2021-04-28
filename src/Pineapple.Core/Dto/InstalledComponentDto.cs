using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Zainstalowany komponent.
    /// </summary>
    public class InstalledComponentDto : IDto
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Nazwa produktu.
        /// </summary>
        public string ProductName { get; }

        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        /// <summary>
        /// Nazwa komponentu.
        /// </summary>
        public string ComponentName { get; }

        /// <summary>
        /// Identyfikator wersji komponentu.
        /// </summary>
        public Guid ComponentVersionId { get; }

        /// <summary>
        /// Numer wersji komponentu.
        /// </summary>
        public string ComponentVersionNumber { get; }

        public InstalledComponentDto(Guid productId, string productName, Guid componentId, string componentName, Guid componentVersionId, string componentVersionNumber)
        {
            ProductId = productId;
            ProductName = productName;
            ComponentId = componentId;
            ComponentName = componentName;
            ComponentVersionId = componentVersionId;
            ComponentVersionNumber = componentVersionNumber;
        }
    }
}
