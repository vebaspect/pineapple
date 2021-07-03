namespace Pineapple.Core.Dto.Logs
{
    /// <summary>
    /// Szczegółowe informacje nt. encji.
    /// </summary>
    public class EntityDetailsDto
    {
        /// <summary>
        /// Szczegółowe informacje nt. wersji komponentu.
        /// </summary>
        public ComponentVersionEntityDetailsDto ComponentVersion { get; set; }

        /// <summary>
        /// Szczegółowe informacje nt. komponentu zainstalowanego na serwerze.
        /// </summary>
        public ServerComponentEntityDetailsDto ServerComponent { get; set; }

        /// <summary>
        /// Szczegółowe informacje nt. oprogramowania zainstalowanego na serwerze.
        /// </summary>
        public ServerSoftwareApplicationEntityDetailsDto ServerSoftwareApplication { get; set; }
    }
}
