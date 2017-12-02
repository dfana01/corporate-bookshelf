using CorporateBookshelf.Core;
using CorporateBookShelf.Models;
using System;
using System.IO;
using CorporateBookshelf.Data;

namespace CorporateBookshelf.App
{
    internal class AddBookHandle : IOptionHandle
    {
        bool IOptionHandle.Execute()
        {
            Book book = new Book();
            Console.WriteLine("Ingrese los datos del libro:");
            Console.Write("ISBN: ");
            book.Isbn = Console.ReadLine();
            Console.Write("Titulo: ");
            book.Title = Console.ReadLine();
            Console.Write("Autor: ");
            book.Author = Console.ReadLine();
            try
            {
                IBookRepository repository = RepositoryFactory.CreateBookRepository("json", GetCurrentPath());
                BookRules rules = new BookRules(repository);
                rules.Add(book);
                Console.WriteLine($"El libro ha sido creado, Total libros: {rules.Count()}");
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine();
                Console.Error.WriteLine($"\t{ex.Message}");
                Console.WriteLine();
                Console.WriteLine();
            }
            return true;
        }

        private string GetCurrentPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "db.json");
        }
    }
}