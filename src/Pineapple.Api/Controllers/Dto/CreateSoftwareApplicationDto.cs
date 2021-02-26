namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Oprogramowanie.
    /// </summary>
    public class CreateSoftwareApplicationDto
    {
        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }
    }
}
