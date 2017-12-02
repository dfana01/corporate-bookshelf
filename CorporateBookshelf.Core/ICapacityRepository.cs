using CorporateBookShelf.Models;

namespace CorporateBookshelf.Core
{
    public interface ICapacityRepository
    {
        bool Exists(Capacity capacity);
    }
}