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
            Validate(book);

            if (_repo.Exists(book))
            {
                throw new ArgumentException("Duplicated Book");
            }

            _repo.Add(book);

            return book;
        }

        public int Count() => _repo.Count();

        private static void Validate(Book book)
        {
            ValidateIsbn(book);

            ValidateTitle(book);

            ValdiateAuthor(book);
        }
        private static void ValidateTitle(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                throw new ArgumentException("Invalid Title");
            }

            book.Title = book.Title.Trim();
            if (book.Title.Length < 5 || book.Title.Length > 1000)
            {
                throw new ArgumentException("Invalid Title");
            }
        }

        private static void ValidateIsbn(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Isbn) || book.Isbn.Contains("--")
                || book.Isbn.StartsWith("-") || book.Isbn.EndsWith("-"))
            {
                throw new ArgumentException("Invalid ISBN");
            }

            book.Isbn = book.Isbn.Replace("-", string.Empty);

            if (book.Isbn.Length != 10 && book.Isbn.Length != 13)
            {
                throw new ArgumentException("Invalid ISBN");
            }
        }

        private static void ValdiateAuthor(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Author))
            {
                throw new ArgumentException("Invalid Author");
            }

            book.Author = book.Author.Trim();

            if (book.Author.Length < 10 || book.Author.Length > 200)
            {
                throw new ArgumentException("Invalid Author");
            }
        }
    }
}