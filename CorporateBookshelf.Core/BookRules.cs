using System;
using CorporateBookShelf.Models;

namespace CorporateBookshelf.Core
{
    public class BookRules
    {
        private readonly IBookRepository _repo;

        public BookRules(IBookRepository repo)
        {
            _repo = repo;
        }

        public Book Add(Book book)
        {
            if (book.Isbn?.Contains("--") || book.Isbn.StartsWith("-") || book.Isbn.EndsWith("-"))
            {
                throw new ArgumentException("Invalid ISBN");
            }

            book.Isbn = book.Isbn.Replace("-", string.Empty);

            if (book.Isbn.Length != 10 && book.Isbn.Length != 13)
            {
                throw new ArgumentException("Invalid ISBN");
            }

            return book;
        }
    }
}