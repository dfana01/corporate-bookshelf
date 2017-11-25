using CorporateBookshelf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateBookshelf.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string option;
            do
            {
                option = ShowMenu();
            } while (DoOption(option));
        }

        private static string ShowMenu()
        {
            Console.WriteLine("Corporate Book Shelf");
            Console.WriteLine();
            Console.WriteLine("Opciones:");
            Console.WriteLine("\t 1: Agregar Puesto");
            Console.WriteLine("\t 0: Salir");
            Console.WriteLine();
            Console.Write("Favor ingrese una opcion: ");

            return Console.ReadLine();
        }

        private static bool DoOption(string option)
        {
            IOptionHandle handle = OptionHanldeFactory.Create(option);
            return handle.Execute();            
        }
    }
}
