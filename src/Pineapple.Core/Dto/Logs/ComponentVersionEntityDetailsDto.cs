namespace Pineapple.Core.Dto.Logs
{
    /// <summary>
    /// Szczegółowe informacje nt. wersji komponentu.
    /// </summary>
    public class ComponentVersionEntityDetailsDto
    {
        /// <summary>
        /// Flaga określająca, czy wersja komponentu jest oznaczona jako "Ważna".
        /// </summary>
        public bool IsImportant { get; set; }
    }
}
