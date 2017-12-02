using CorporateBookshelf.Core;
using Newtonsoft.Json;
using System.IO;
using CorporateBookshelf.Models;

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

        public void Add(Collaborator collaborator) => throw new System.NotImplementedException();
        public int Count() => throw new System.NotImplementedException();
        public bool Exists(int id) => throw new System.NotImplementedException();
        public void SaveChanges() => throw new System.NotImplementedException();
    }
}