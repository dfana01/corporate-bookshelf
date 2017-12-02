using CorporateBookshelf.Core;
using CorporateBookshelf.Data;
using CorporateBookShelf.Models;
using System;
using System.IO;

namespace CorporateBookshelf.App
{
    internal class AddJobHandle : IOptionHandle
    {
        bool IOptionHandle.Execute()
        {
            IJobRepository repository = RepositoryFactory.CreateJobRepository("json", GetCurrentPath());
            var rules = new JobRules(repository:repository);
            Job job = RequestJobData();
            try
            {
                rules.AddJob(job);
                Console.WriteLine($"El puesto ha sido creado, Total puestos: {rules.Count()}");
            }
            catch (ArgumentException ex){
                Console.Error.WriteLine(ex.Message);
            }
            return true;
        }

        private string GetCurrentPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "db.json");
        }

        private Job RequestJobData()
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