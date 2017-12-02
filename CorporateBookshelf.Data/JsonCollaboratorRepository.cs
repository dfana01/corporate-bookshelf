using CorporateBookshelf.Core;
using Newtonsoft.Json;
using System.IO;

namespace CorporateBookshelf.Data
{
    internal class JsonCollaboratorRepository : ICollaboratorRepository
    {
        private readonly JsonDb _db;
        private readonly string _connectionString;

        public JsonCollaboratorRepository(string connectionString)
        {
            _connectionString = connectionString;

            if (File.Exists(connectionString))
            {
                var jsonDb = File.ReadAllText(connectionString);
                _db = JsonConvert.DeserializeObject<JsonDb>(jsonDb);
            }
            else
            {
                _db = new JsonDb();
            }
        }
        
    }
}