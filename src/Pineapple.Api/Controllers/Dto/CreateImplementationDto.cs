using System;

namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Wdrożenie.
    /// </summary>
    public class CreateImplementationDto
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
        /// Identyfikator menedżera.
        /// </summary>
        public Guid ManagerId { get; set; }
    }
}
