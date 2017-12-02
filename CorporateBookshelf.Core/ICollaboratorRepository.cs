using CorporateBookshelf.Models;

namespace CorporateBookshelf.Core
{
    public interface ICollaboratorRepository
    {
        int Count();
        void Add(Collaborator collaborator);
        void SaveChanges();
        bool Exists(int id);
    }
}