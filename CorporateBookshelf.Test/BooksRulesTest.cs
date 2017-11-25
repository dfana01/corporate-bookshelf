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
            book.Name = "";
            book.Isbn = isbn;

            //Act
            IBookRepository repo = NSubstitute.Substitute.For<IBookRepository>();
            BookRules rules = new BookRules(repo);

            //Assert 
            Assert.That(() => rules.Add(book),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid ISBN"));
        }

        [TestCase("1234567890123", Description = "Only accept a valid isbn")]
        [TestCase("1234567890", Description = "Only accept a valid isbn")]
        [TestCase("123-45678-90123", Description = "Only accept a valid isbn")]
        
        public void ValidISBN(string isbn)
        {
            //Arrange
            Book book = new Book();
            book.Id = 1;
            book.Name = "";
            book.Isbn = isbn;

            //Act
            IBookRepository repo = NSubstitute.Substitute.For<IBookRepository>();
            BookRules rules = new BookRules(repo);

            //Assert 
            rules.Add(book);
            Assert.Pass();
        }

    }
}
