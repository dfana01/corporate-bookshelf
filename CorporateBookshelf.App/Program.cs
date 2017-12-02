using System;

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
            Console.WriteLine("=========================================");
            Console.WriteLine("Corporate Book Shelf");
            Console.WriteLine();
            Console.WriteLine("Opciones:");
            Console.WriteLine("\t 1: Agregar Puesto");
            Console.WriteLine("\t 2: Agregar Libro");
            Console.WriteLine("\t 3: Agregar Colaborador");
            Console.WriteLine("\t 0: Salir");
            Console.WriteLine("=========================================");
            Console.WriteLine();
            Console.Write("Favor ingrese una opcion: ");

            return Console.ReadLine();
        }

        private static bool DoOption(string option)
        {
            IOptionHandle handle = OptionHandleFactory.Create(option);
            return handle.Execute();            
        }
    }
}
