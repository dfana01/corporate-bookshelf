using System.IO;
using System.Linq;
using CorporateBookshelf.Core;
using CorporateBookShelf.Models;

namespace CorporateBookshelf.Data
{
    internal class JsonCapacityRepository : ICapacityRepository
    {
        private readonly string _connectionString;
        private readonly JsonDb _db;

        /// <summary>
        /// Creates a new <see cref="JsonCapacityRepository"/>
        /// </summary>
        /// <param name="connectionString"></param>
        public JsonCapacityRepository(string connectionString)
        {
            if (File.Exists(connectionString))
            {
                var jsonDb = File.ReadAllText(connectionString);
                _db = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonDb>(jsonDb);
            }
            else
            {
                _db = new JsonDb();
            }

            _connectionString = connectionString;
        }

        bool ICapacityRepository.Exists(Capacity capacity)
        {
            return _db.Capacities.Any(c =>
                c.Id == capacity.Id || c.Name.ToLowerInvariant() == capacity.Name.ToLowerInvariant());
        }

        int ICapacityRepository.Count()
        {
            return _db.Capacities.Count;
        }

        void ICapacityRepository.Add(Capacity capacity)
        {
            _db.Capacities.Add(capacity);
        }

        void ICapacityRepository.SaveChanges()
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(_db);
            File.WriteAllText(_connectionString, content);
        }
    }
}