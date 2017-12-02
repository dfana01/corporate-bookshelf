using CorporateBookshelf.Core;
using CorporateBookshelf.Models;
using System.IO;
using CorporateBookShelf.Models;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace CorporateBookshelf.Data
{
    internal class JsonJobRepository : IJobRepository
    {
        private readonly JsonDb _db;
        private readonly string _connectionString;

        /// <summary>
        /// Initialized JSON Repository, if the file not exists then create the necessary file
        /// </summary>
        /// <param name="connectionString"></param>
        public JsonJobRepository(string connectionString)
        {
            if (File.Exists(connectionString))
            {
                var jsonDb = File.ReadAllText(connectionString);
                _db = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonDb>(jsonDb);
            } else
            {
                _db = new JsonDb();
            }

            _connectionString = connectionString;
        }

        void IJobRepository.Add(Job job)
        {
            _db.Jobs.Add(job); 
            (this as IJobRepository).SaveChanges();
        }

        int IJobRepository.Count()
        {
            return _db.Jobs.Count;
        }

        bool IJobRepository.Exists(Job job)
        {
            return _db.Jobs.Any(x => AreEquals(job, x));
        }

        private static bool AreEquals(Job job, Job x)
        {
            return x.Id == job.Id || x.Name.ToUpperInvariant() == job.Name.ToUpperInvariant();
        }

        void IJobRepository.SaveChanges()
        {
            var content = JsonConvert.SerializeObject(_db);
            File.WriteAllText(_connectionString, content);
        }
    }
}