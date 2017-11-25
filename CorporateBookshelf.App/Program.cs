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
            ShowMenu();
            string option = Console.ReadLine();

            HandleOption(option);

            Console.ReadLine();
        }

        private static void HandleOption(string option)
        {
            while (option != "0")
            {
                DoOption(option);

                ShowMenu();
                return;
            }            
        }
        private static void ShowMenu()
        {
            Console.WriteLine("Corporate B  ook Shelf");
            Console.WriteLine();
            Console.WriteLine("Opciones:");
            Console.WriteLine("\t 1: Agregar Puesto");
            Console.WriteLine("\t 0: Salir");
            Console.WriteLine();
            Console.Write("Favor ingrese una opcion: ");
        }

        private static void DoOption(string option)
        {
            if (option == "1")
            {
                var rules = new JobRules();
                Job job = RequestJobData();
                rules.AddJob(job);
                Console.WriteLine($"El puesto ha sido creado, Total puestos: {rules.Count()}");
                return;
            }
            else 
            {
                Console.WriteLine("Opcion invalida!");
                return;
            }
        }

        private static Job RequestJobData()
        {
            Console.Write("Ingrese los datos del puesto: ");
            Console.WriteLine();
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            string name = Console.ReadLine();

            return new Job
            {
                Id = id,
                Name = name
            };
        }
    }
}
