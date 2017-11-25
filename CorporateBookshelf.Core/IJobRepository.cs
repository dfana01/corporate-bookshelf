using CorporateBookshelf.Models;

namespace CorporateBookshelf.Core
{
    public interface IJobRepository
    {
        int Count();
        void Add(Job job);

        void SaveChanges();
    }
}