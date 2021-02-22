using System;
using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class CreateCoordinatorCommand : IRequest<Task<Guid>>, ICommand
    {
        /// <summary>
        /// Identyfikator wdrożenia.
        /// </summary>
        public Guid ImplementationId { get; }

        /// <summary>
        /// Imię i nazwisko.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Telefon.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// E-mail.
        /// </summary>
        public string Email { get; }

        public CreateCoordinatorCommand(Guid implementationId, string fullName, string phone, string email)
        {
            ImplementationId = implementationId;
            FullName = fullName;
            Phone = phone;
            Email = email;
        }
    }
}
