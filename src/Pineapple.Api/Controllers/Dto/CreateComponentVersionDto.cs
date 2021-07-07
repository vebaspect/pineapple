namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Wersja komponentu.
    /// </summary>
    public class CreateComponentVersionDto
    {
        /// <summary>
        /// Data wydania.
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Major.
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// Minor.
        /// </summary>
        public int Minor { get; set; }

        /// <summary>
        /// Patch.
        /// </summary>
        public int Patch { get; set; }

        /// <summary>
        /// Przyrostek.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// Zgłoszenie w systemie ITS (adres URL).
        /// </summary>
        public string IssueTrackingSystemTicketUrl { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Flaga określająca, czy wersja komponentu jest oznaczona jako "Ważna".
        /// </summary>
        public bool IsImportant { get; set; }
    }
}
