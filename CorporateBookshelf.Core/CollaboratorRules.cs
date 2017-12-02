using CorporateBookshelf.Models;

namespace CorporateBookshelf.Core
{
    public sealed class CollaboratorRules
    {
        private readonly ICollaboratorRepository _repository;

        public CollaboratorRules(ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public int Count()
        {
            return 0;
        }

        public void AddCollaborator(Collaborator collaborator)
        {

        }

        public void SaveChanges()
        {

        }

        public bool Exists()
        {
            return false;
        }
    }
}
