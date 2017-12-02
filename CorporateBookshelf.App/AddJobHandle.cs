using CorporateBookshelf.Core;
using CorporateBookshelf.Data;
using CorporateBookShelf.Models;
using System;

namespace CorporateBookshelf.App
{
    internal class AddJobHandle : IOptionHandle
    {
        bool IOptionHandle.Execute()
        {
            IJobRepository repository = RepositoryFactory.CreateJobRepository("json", PathUtils.GetCurrentPath(nameof(Job)));
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