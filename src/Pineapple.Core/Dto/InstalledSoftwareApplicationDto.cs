using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Zainstalowane oprogramowanie.
    /// </summary>
    public class InstalledSoftwareApplicationDto : IDto
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; }

        /// <summary>
        /// Nazwa oprogramowania.
        /// </summary>
        public string SoftwareApplicationName { get; }

        public InstalledSoftwareApplicationDto(Guid id, Guid softwareApplicationId, string softwareApplicationName)
        {
            Id = id;
            SoftwareApplicationId = softwareApplicationId;
            SoftwareApplicationName = softwareApplicationName;
        }
    }
}
