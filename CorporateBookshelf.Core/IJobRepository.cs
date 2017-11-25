using CorporateBookshelf.Models;

namespace CorporateBookshelf.Core
{
    /// <summary>
    /// Responsible of manage data access.
    /// </summary>
    public interface IJobRepository
    {
        /// <summary>
        /// return total numbers of jobs. 
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// add new element in source.
        /// </summary>
        /// <param name="job"></param>
        void Add(Job job);

        /// <summary>
        /// Save change in source.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Validate that the given job is present. 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        bool Exists(Job job);
    }
}