using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Zainstalowane oprogramowanie.
    /// </summary>
    public class InstalledSoftwareApplicationDto : IDto
    {
        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; }

        /// <summary>
        /// Nazwa oprogramowania.
        /// </summary>
        public string SoftwareApplicationName { get; }

        public InstalledSoftwareApplicationDto(Guid softwareApplicationId, string softwareApplicationName)
        {
            SoftwareApplicationId = softwareApplicationId;
            SoftwareApplicationName = softwareApplicationName;
        }
    }
}
