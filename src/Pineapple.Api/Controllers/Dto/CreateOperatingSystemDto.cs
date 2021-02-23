namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// System operacyjny.
    /// </summary>
    public class CreateOperatingSystemDto
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
