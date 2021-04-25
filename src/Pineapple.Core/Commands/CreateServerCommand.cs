using System;
using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class CreateServerCommand : IRequest<Task<Guid>>, ICommand
    {
        /// <summary>
        /// Identyfikator środowiska.
        /// </summary>
        public Guid EnvironmentId { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Adres IP.
        /// </summary>
        public string IpAddress { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Identyfikator systemu operacyjnego.
        /// </summary>
        public Guid OperatingSystemId { get; }

        public CreateServerCommand(Guid environmentId, string name, string symbol, string ipAddress, string description, Guid operatingSystemId)
        {
            EnvironmentId = environmentId;
            Name = name;
            Symbol = symbol;
            IpAddress = ipAddress;
            Description = description;
            OperatingSystemId = operatingSystemId;
        }
    }
}
