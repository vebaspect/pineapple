namespace Pineapple.Core.Domain
{
    /// <summary>
    /// Dostępne rodzaje wersji komponentów.
    /// </summary>
    public static class AvailableComponentVersionKinds
    {
        /// <summary>
        /// Wydanie przedpremierowe.
        /// </summary>
        public const string PreRelease = "PreRelease";

        /// <summary>
        /// Wydanie.
        /// </summary>
        public const string Release = "Release";

        /// <summary>
        /// Łatka.
        /// </summary>
        public const string Patch = "Patch";
    }
}
