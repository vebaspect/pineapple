namespace Pineapple.Core.Domain
{
    /// <summary>
    /// Dostępne rodzaje wersji komponentów.
    /// </summary>
    public static class AvailableComponentVersionKinds
    {
        /// <summary>
        /// Wersja przedpremierowa.
        /// </summary>
        public const string PreRelease = "PreRelease";

        /// <summary>
        /// Wersja.
        /// </summary>
        public const string Release = "Release";

        /// <summary>
        /// Poprawka.
        /// </summary>
        public const string Patch = "Patch";
    }
}
