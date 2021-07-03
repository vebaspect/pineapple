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
        /// Data wydania.
        /// </summary>
        public DateTime ReleaseDate { get; }

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

        /// <summary>
        /// Flaga określająca, czy wersja komponentu jest oznaczona jako "Ważna".
        /// </summary>
        public bool IsImportant { get; }

        public CreateComponentVersionCommand(Guid componentId, DateTime releaseDate, int major, int minor, int patch, string suffix, string description, bool isImportant)
        {
            ComponentId = componentId;
            ReleaseDate = releaseDate;
            Major = major;
            Minor = minor;
            Patch = patch;
            Suffix = suffix;
            Description = description;
            IsImportant = isImportant;
        }
    }
}
