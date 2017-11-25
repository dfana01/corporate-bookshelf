using CorporateBookShelf.Models;

namespace CorporateBookshelf.Core
{
    public interface IBookRepository
    {
        void Add(Book book);

        int Count();

        bool Exists(Book book);

        void SaveChanges();
    }
}