namespace Pineapple.Core.Domain.Entities
{
    /// <summary>
    /// Użytkownik.
    /// </summary>
    public abstract class User : Entity
    {
        /// <summary>
        /// Typ.
        /// </summary>
        public string Type { get; set; }

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
