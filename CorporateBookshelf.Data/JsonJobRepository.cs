using CorporateBookshelf.Core;
using System.IO;
using CorporateBookshelf.Models;

namespace CorporateBookshelf.Data
{
    public class JsonJobRepository : IJobRepository
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

        public void Add(Job job)
        {
            _db.Jobs.Add(job);
            SaveChanges();
        }

        public int Count()
        {
            return _db.Jobs.Count;
        }

        public void SaveChanges()
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(_db);
            File.WriteAllText(_connectionString, content);
        }
    }
}