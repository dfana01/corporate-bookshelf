using CorporateBookshelf.Core;
using System;

namespace CorporateBookshelf.Data
{
    /// <summary>
    /// Responsible to create data source management implementation
    /// </summary>
    public class RepositoryFactory
    {
        /// <summary>
        /// Create a <see cref="IJobRepository"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IJobRepository CreateJobRepository(string type, string connectionString)
        {
            if (type == "json")
            {
                return new JsonJobRepository(connectionString);
            }

            throw new NotSupportedException($"Repository Type not supported: {type}");
        }
    }
}