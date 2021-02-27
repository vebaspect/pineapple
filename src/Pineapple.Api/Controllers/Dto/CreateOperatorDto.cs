namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Wdrożeniowiec.
    /// </summary>
    public class CreateOperatorDto
    {
        /// <summary>
        /// Imię i nazwisko.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Telefon.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// E-mail.
        /// </summary>
        public string Email { get; set; }
    }
}
