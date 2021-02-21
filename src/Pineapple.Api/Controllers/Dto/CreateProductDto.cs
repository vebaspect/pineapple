namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Produkt.
    /// </summary>
    public class CreateProductDto
    {
        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }
    }
}
