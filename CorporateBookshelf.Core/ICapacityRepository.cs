using CorporateBookShelf.Models;

namespace CorporateBookshelf.Core
{
    /// <summary>
    /// Responsible of manage data access for the <see cref="Capacity"/>
    /// </summary>
    public interface ICapacityRepository
    {
        /// <summary>
        /// Validates if the current capacity exists in the store
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        bool Exists(Capacity capacity);
        /// <summary>
        /// Returns how many capacities are saved in the store
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// Persists a new capacity in the store
        /// </summary>
        /// <param name="capacity"></param>
        void Add(Capacity capacity);
        /// <summary>
        /// Commits the changes to the store
        /// </summary>
        void SaveChanges();
    }
}