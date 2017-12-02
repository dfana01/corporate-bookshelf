using CorporateBookshelf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateBookShelf.Models;
using System.IO;
using Newtonsoft.Json;

namespace CorporateBookshelf.Data
{
    public class JsonBookRepository : IBookRepository
    {
        private readonly string _connectionString;
        private readonly JsonDb _db;

        public JsonBookRepository(string connectionString)
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

        public void Add(Book book)
        {
            _db.Books.Add(book);
            SaveChanges();
        }

        public int Count() => _db.Books.Count;

        public bool Exists(Book book)
        {
            Func<Book, bool> AreEquals = b =>
                string.Equals(b.Isbn.ToLowerInvariant(), book.Isbn.ToLowerInvariant(), StringComparison.InvariantCulture)
                || string.Equals(b.Title.ToLowerInvariant(), book.Title.ToLowerInvariant(), StringComparison.InvariantCulture);

            return _db.Books.Any(AreEquals);
        }

        public void SaveChanges()
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(_db);
            File.WriteAllText(_connectionString, content);
        }
    }
}
