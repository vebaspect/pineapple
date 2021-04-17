using System;
using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class CreateComponentVersionCommand : IRequest<Task<Guid>>, ICommand
    {
        /// <summary>
        /// Identyfikator komponentu.
        /// </summary>
        public Guid ComponentId { get; }

        /// <summary>
        /// Major.
        /// </summary>
        public int Major { get; }

        /// <summary>
        /// Minor.
        /// </summary>
        public int Minor { get; }

        /// <summary>
        /// Patch.
        /// </summary>
        public int Patch { get; }

        /// <summary>
        /// Przyrostek.
        /// </summary>
        public string Suffix { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        public CreateComponentVersionCommand(Guid componentId, int major, int minor, int patch, string suffix, string description)
        {
            ComponentId = componentId;
            Major = major;
            Minor = minor;
            Patch = patch;
            Suffix = suffix;
            Description = description;
        }
    }
}
