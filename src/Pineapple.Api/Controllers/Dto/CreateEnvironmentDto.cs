namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Środowisko.
    /// </summary>
    public class CreateEnvironmentDto
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
