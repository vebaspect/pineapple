namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Wersja komponentu.
    /// </summary>
    public class CreateComponentVersionDto
    {
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
        /// Opis.
        /// </summary>
        public string Description { get; set; }
    }
}
