using CorporateBookshelf.Core;
using CorporateBookshelf.Data;
using CorporateBookshelf.Models;
using System;

namespace CorporateBookshelf.App
{
    internal class AddCollaboratorHandle : IOptionHandle
    {
        public bool Execute()
        {
            ICollaboratorRepository repository = RepositoryFactory.CreateCollaboratorRepository("json", PathUtils.GetCurrentPath(nameof(Collaborator)));
            var rules = new CollaboratorRules(repository);
            Collaborator collaborator = RequestCollaboratorData();
            try
            {
                rules.AddCollaborator(collaborator);
            }
            catch (ArgumentException ex) {
                Console.Error.WriteLine(ex.Message);
            }
            return true;
        }

        private static Collaborator RequestCollaboratorData()
        {
            Console.WriteLine("Ingrese los datos del colaborador: ");
            Console.WriteLine();
            Console.Write("Nombre: ");
            string name = Console.ReadLine();

            return new Collaborator
            {
                Name = name;
            };
        }
    }
}