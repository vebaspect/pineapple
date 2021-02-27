using System;
using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class CreateOperatorCommand : IRequest<Task<Guid>>, ICommand
    {
        /// <summary>
        /// Imię i nazwisko.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Telefon.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// E-mail.
        /// </summary>
        public string Email { get; }

        public CreateOperatorCommand(string fullName, string login, string phone, string email)
        {
            FullName = fullName;
            Login = login;
            Phone = phone;
            Email = email;
        }
    }
}
