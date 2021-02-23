using System;

namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Komponent.
    /// </summary>
    public class CreateComponentDto
    {
        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; set; }
    }
}
