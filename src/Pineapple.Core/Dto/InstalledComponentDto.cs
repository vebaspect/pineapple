using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Zainstalowany komponent.
    /// </summary>
    public class InstalledComponentDto : IDto
    {
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

        public InstalledComponentDto(Guid componentId, string componentName, Guid componentVersionId, string componentVersionNumber)
        {
            ComponentId = componentId;
            ComponentName = componentName;
            ComponentVersionId = componentVersionId;
            ComponentVersionNumber = componentVersionNumber;
        }
    }
}
