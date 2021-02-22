namespace Pineapple.Api.Controllers.Dto
{
    /// <summary>
    /// Koordynator.
    /// </summary>
    public class CreateCoordinatorDto
    {
        /// <summary>
        /// Imię i nazwisko.
        /// </summary>
        public string FullName { get; set; }

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
