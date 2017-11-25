using CorporateBookshelf.Core;
using CorporateBookShelf.Models;
using System;

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
                BookRules rules = new BookRules(null);
                rules.Add(book);
                Console.WriteLine($"El libro ha sido creado, Total libros: 1");
            }
            catch (ArgumentException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return true;
        }
    }
}