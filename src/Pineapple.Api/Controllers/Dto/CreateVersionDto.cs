namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Wersja.
    /// </summary>
    public class CreateVersionDto
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
        /// Wydanie przedpremierowe.
        /// </summary>
        public string PreRelease { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }
    }
}
