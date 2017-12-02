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
            var capacity = new Capacity();
            Console.WriteLine("Ingrese los datos de la capacidad:");
            Console.Write("ID: ");
            string id = Console.ReadLine();
            capacity.Id = int.Parse(id);
            Console.Write("Nombre: ");
            capacity.Name = Console.ReadLine();

            Console.Write("Job ID: ");
            int jobId = int.Parse(Console.ReadLine());

            capacity.Job = new Job {Id = jobId};
            try
            {
                ICapacityRepository capacityRepository = RepositoryFactory.CreateCapacityRepository("json", GetCurrentPath());
                IJobRepository jobRepository = RepositoryFactory.CreateJobRepository("json", GetCurrentPath());
                var rules = new CapacityRules(capacityRepository, jobRepository);
                rules.Add(capacity);

                Console.WriteLine($"La capacidad ha sido creada correctamente. Total: {rules.Count()}");
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
