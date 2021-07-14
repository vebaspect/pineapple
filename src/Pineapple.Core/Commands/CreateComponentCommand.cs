using System;
using System.Threading.Tasks;
using MediatR;

namespace Pineapple.Core.Commands
{
    public class CreateComponentCommand : IRequest<Task<Guid>>, ICommand
    {
        /// <summary>
        /// Identyfikator produktu.
        /// </summary>
        public Guid ProductId { get; }

        /// <summary>
        /// Nazwa.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Repozytorium kodu źródłowego (adres URL).
        /// </summary>
        public string SourceCodeRepositoryUrl { get; }

        /// <summary>
        /// Repozytorium paczek (ścieżka).
        /// </summary>
        public string PackagesRepositoryPath { get; }

        /// <summary>
        /// Repozytorium licencji (ścieżka).
        /// </summary>
        public string LicensesRepositoryPath { get; }

        /// <summary>
        /// Opis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Identyfikator typu komponentu.
        /// </summary>
        public Guid ComponentTypeId { get; }

        public CreateComponentCommand(Guid productId, string name, string sourceCodeRepositoryUrl, string packagesRepositoryPath, string licensesRepositoryPath, string description, Guid componentTypeId)
        {
            ProductId = productId;
            Name = name;
            SourceCodeRepositoryUrl = sourceCodeRepositoryUrl;
            PackagesRepositoryPath = packagesRepositoryPath;
            LicensesRepositoryPath = licensesRepositoryPath;
            Description = description;
            ComponentTypeId = componentTypeId;
        }
    }
}
