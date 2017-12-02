using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateBookshelf.Core;
using CorporateBookshelf.Data;
using CorporateBookShelf.Models;

namespace CorporateBookshelf.App
{
    public class AddCapacityHandle : IOptionHandle
    {
        bool IOptionHandle.Execute()
        {
            var book = new Capacity();
            Console.WriteLine("Ingrese los datos de la capacidad:");
            Console.Write("ID: ");
           
            try
            {
               ///
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
