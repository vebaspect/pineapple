using System;

namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Serwer.
    /// </summary>
    public class CreateServerDto
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

        /// <summary>
        /// Identyfikator systemu operacyjnego.
        /// </summary>
        public Guid OperatingSystemId { get; set; }

        /// <summary>
        /// Adres IP.
        /// </summary>
        public string IpAddress { get; set; }
    }
}
