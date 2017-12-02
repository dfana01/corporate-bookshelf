using CorporateBookShelf.Models;
using System.Collections.Generic;

namespace CorporateBookshelf.Data
{
    internal class JsonDb
    {
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
        public ICollection<Book> Books { get; internal set; } = new List<Book>();
        public ICollection<Capacity> Capacities { get; set; } = new List<Capacity>();
    }
}