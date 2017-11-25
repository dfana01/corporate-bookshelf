using CorporateBookshelf.Core;
using System;

namespace CorporateBookshelf.Data
{
    public class RepositoryFactory
    {
        public static IJobRepository CreateJobRepository(string type, string connectionString)
        {
            if (type == "json")
            {
                return new JsonJobRepository(connectionString);
            }

            throw new NotSupportedException($"Repository Type not suported: {type}");
        }
    }
}