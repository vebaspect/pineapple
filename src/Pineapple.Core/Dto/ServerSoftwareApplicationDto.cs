using System;

namespace Pineapple.Core.Dto
{
    /// <summary>
    /// Oprogramowanie zainstalowane na serwerze.
    /// </summary>
    public class ServerSoftwareApplicationDto : IDto
    {
        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; }

        public ServerSoftwareApplicationDto(Guid softwareApplicationId)
        {
            SoftwareApplicationId = softwareApplicationId;
        }
    }
}
