namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Programista.
    /// </summary>
    public class CreateDeveloperDto
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
