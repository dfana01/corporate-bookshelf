using CorporateBookshelf.Core;
using System.IO;
using CorporateBookshelf.Models;
using System.Linq;

namespace CorporateBookshelf.Data
{

    internal class JsonJobRepository : IJobRepository
    {
        private readonly JsonDb _db;
        private readonly string _connectionString;

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
            return _db.Jobs.Any(x => 
                                    x.Id == job.Id || 
                                    x.Name.ToUpperInvariant() == job.Name.ToUpperInvariant());
        }

        void IJobRepository.SaveChanges()
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(_db);
            File.WriteAllText(_connectionString, content);
        }
    }
}