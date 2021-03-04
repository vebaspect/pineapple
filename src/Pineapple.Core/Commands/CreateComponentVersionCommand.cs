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
        /// Wydanie przedpremierowe.
        /// </summary>
        public string PreRelease { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        public CreateComponentVersionCommand(Guid componentId, int major, int minor, int patch, string preRelease, string description)
        {
            ComponentId = componentId;
            Major = major;
            Minor = minor;
            Patch = patch;
            PreRelease = preRelease;
            Description = description;
        }
    }
}
