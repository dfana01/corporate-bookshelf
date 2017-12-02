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
        /// Create a <see cref="JsonJobRepository"/>
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

        /// <summary>
        /// Creates a <see cref="JsonCollaboratorRepository"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static ICollaboratorRepository CreateCollaboratorRepository(string type, string connectionString)
        {
            if (type == "json")
            {
                return new JsonCollaboratorRepository(connectionString);
            }

            throw new NotSupportedException($"Repository Type not supported: {type}");
        }
    }
}