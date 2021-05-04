using System;

namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Oprogramowanie zainstalowane na serwerze.
    /// </summary>
    public class ServerSoftwareApplication
    {
        /// <summary>
        /// Identyfikator.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Identyfikator serwera.
        /// </summary>
        public Guid ServerId { get; }

        /// <summary>
        /// Serwer.
        /// </summary>
        public Server Server { get; }

        /// <summary>
        /// Identyfikator oprogramowania.
        /// </summary>
        public Guid SoftwareApplicationId { get; }

        /// <summary>
        /// Oprogramowanie.
        /// </summary>
        public SoftwareApplication SoftwareApplication { get; }

        public ServerSoftwareApplication(Guid serverId, Guid softwareApplicationId)
        {
            Id = Guid.NewGuid();
            ServerId = serverId;
            SoftwareApplicationId = softwareApplicationId;
        }
    }
}
