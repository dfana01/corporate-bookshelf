using CorporateBookshelf.Models;
using System.Collections.Generic;

namespace CorporateBookshelf.Data
{
    internal class JsonDb
    {
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}