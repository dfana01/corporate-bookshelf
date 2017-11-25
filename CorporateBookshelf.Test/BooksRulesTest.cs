using CorporateBookshelf.Core;
using CorporateBookShelf.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateBookshelf.Test
{
    [TestFixture]
    class BooksRulesTest
    {
        const string MAX_VALID_TITLE = "ddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfd";
        const string MAX_INVALID_TITLE = "dddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfd";
        private const string MAX_VALID_AUTHOR = "dddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddfdfdfddD";

        [TestCase("1", Description = "Only accept 10 or 13 characters")]
        [TestCase("12-2", Description = "Only accept 10 or 13 characters")]
        [TestCase("", Description = "Only accept a valid isbn")]
        [TestCase("123456789", Description = "Only accept a valid isbn")]
        [TestCase("1--234567890123", Description = "Only accept a valid isbn")]
        [TestCase("-1234567890123", Description = "Only accept a valid isbn")]
        [TestCase("1234567890123-", Description = "Only accept a valid isbn")]
        [TestCase(null, Description = "Only accept a valid isbn")]
        public void InvalidISBN(string isbn)
        {
            //Arrange
            Book book = new Book();
            book.Id = 1;
            book.Title = "";
            book.Isbn = isbn;
            book.Author = "Gabriel Garcia Marquez";

            //Act
            IBookRepository repo = NSubstitute.Substitute.For<IBookRepository>();
            BookRules rules = new BookRules(repo);

            //Assert 
            Assert.That(() => rules.Add(book),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid ISBN"));
        }

        [TestCase("1234567890123", Description = "Only accept a valid isbn")]
        [TestCase("1234567890", Description = "Only accept a valid isbn")]
        [TestCase("0123456789", Description = "Only accept a valid isbn")]
        [TestCase("123-45678-90123", Description = "Only accept a valid isbn")]
        public void ValidISBN(string isbn)
        {
            //Arrange
            Book book = new Book();
            book.Id = 1;
            book.Title = "Don Quijote de la mancha";
            book.Isbn = isbn;
            book.Author = "Gabriel Garcia Marquez";

            //Act
            IBookRepository repo = NSubstitute.Substitute.For<IBookRepository>();
            BookRules rules = new BookRules(repo);

            //Assert 
            rules.Add(book);
            Assert.Pass();
        }

        [TestCase("1", Description = "Title should be between 5 and 1000")]
        [TestCase(MAX_INVALID_TITLE, Description = "Title should be between 5 and 1000")]
        [TestCase("    e", Description = "The title is valid")]
        [TestCase("e", Description = "The title is valid")]
        [TestCase(" ", Description = "The title is valid")]
        [TestCase("001", Description = "The title is valid")]
        [TestCase(null, Description = "The title is valid")]
        public void InvalidTitle(string title)
        {
            //Arrange
            Book book = new Book();
            book.Id = 1;
            book.Isbn = "1234567890123";
            book.Title = title;
            book.Author = "Gabriel Garcia Marquez";

            //Act
            IBookRepository repo = NSubstitute.Substitute.For<IBookRepository>();
            BookRules rules = new BookRules(repo);

            //Assert 
            Assert.That(() => rules.Add(book),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid Title"));
        }

        [TestCase("abcde", Description = "The title is valid" )]
        [TestCase(MAX_VALID_TITLE, Description = "The title is valid")]
        [TestCase(MAX_VALID_TITLE + " ", Description = "The title is valid")]
        [TestCase(" " + MAX_VALID_TITLE + " ", Description = "The title is valid")]       
        public void ValidTitle(string title)
        {
            //Arrange
            Book book = new Book();
            book.Id = 1;
            book.Isbn = "1234567890123";
            book.Title = title;
            book.Author = "Gabriel Garcia Marquez";
            //Act
            IBookRepository repo = NSubstitute.Substitute.For<IBookRepository>();
            BookRules rules = new BookRules(repo);

            //Assert 
            rules.Add(book);
            Assert.Pass();
        }

        [TestCase("1", Description = "Author should be between 10 and 200")]
        [TestCase(MAX_INVALID_TITLE, Description = "Author should be between 10 and 200")]
        [TestCase("    e", Description = "Author should be between 10 and 200")]
        [TestCase("e", Description = "Author should be between 10 and 200")]
        [TestCase(" ", Description = "Author should be between 10 and 200")]
        [TestCase("001", Description = "Author should be between 10 and 200")]
        [TestCase(null, Description = "Author should be between 10 and 200")]
        public void InvalidAuthor(string author)
        {
            //Arrange
            Book book = new Book();
            book.Id = 1;
            book.Isbn = "1234567890123";
            book.Title = "Don quijote de la mancha";
            book.Author = author;

            //Act
            IBookRepository repo = NSubstitute.Substitute.For<IBookRepository>();
            BookRules rules = new BookRules(repo);

            //Assert 
            Assert.That(() => rules.Add(book),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid Author"));
        }

        [TestCase("abcdeabcde", Description = "The title is valid")]
        [TestCase(MAX_VALID_AUTHOR, Description = "The title is valid")]
        [TestCase(MAX_VALID_AUTHOR + " ", Description = "The title is valid")]
        [TestCase(" " + MAX_VALID_AUTHOR + " ", Description = "The title is valid")]
        public void ValidAuthor(string author)
        {
            //Arrange
            Book book = new Book();
            book.Id = 1;
            book.Isbn = "1234567890123";
            book.Title = "Don quijote de la mancha";
            book.Author = author;
            //Act
            IBookRepository repo = NSubstitute.Substitute.For<IBookRepository>();
            BookRules rules = new BookRules(repo);

            //Assert 
            rules.Add(book);
            Assert.Pass();
        }

        [Test(Description="Title cannot be duplicated")]
        public void DuplicatedTitle()
        {

        }
    }
}
