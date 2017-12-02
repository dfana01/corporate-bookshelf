using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using CorporateBookShelf.Models;
using CorporateBookshelf.Core;
using NSubstitute;

namespace CorporateBookshelf.Test
{
    [TestFixture()]
    public class CapacityRuleTest
    {
        /*
             1 - Nombre no duplicado
             2 - Agregar una capacidad con un puesto que exista 
             3 - Agregar una capacidad con un puesto que no exista
             4 - Agregar con nombres validos 
             5 - Agregar con nombres invalidados
         */

        [TestCase("",Description = "Name should not be empty")]
        public void NotEmpty(string name)
        {
            Capacity capacity = new Capacity()
            {
                Id=1,
                Name=name
            };

            ICapacityRepository repo = NSubstitute.Substitute.For<ICapacityRepository>();
            IJobRepository jobRepo = NSubstitute.Substitute.For<IJobRepository>();
            CapacityRules rules = new CapacityRules(repo,jobRepo);

            Assert.That(() => rules.Add(capacity),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid Name"));
        }

        [TestCase("testName","testName", Description = "Name ")]
        public void NotDuplicateName(string name1, string name2)
        {
            Capacity capacity = new Capacity()
            {
                Id = 1,
                Name = name1
            };

            ICapacityRepository repo = NSubstitute.Substitute.For<ICapacityRepository>();
            IJobRepository jobRepo = NSubstitute.Substitute.For<IJobRepository>();
            repo.Exists(Arg.Any<Capacity>()).Returns(true);
            jobRepo.Exists(Arg.Any<Job>()).Returns(true);
            CapacityRules rules = new CapacityRules(repo,jobRepo);

            Assert.That(() => rules.Add(capacity),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Duplicate Name"));
        }

        [TestCase(1, Description = "Adding job")]
        public void CreateACapacityWithExistingJobPass(int jobId)
        {
            Capacity capacity = new Capacity()
            {
                Id = 1, 
                Name = "TestName",
                Job = new Job() { Id= jobId , Name = "Tester"}
            };

            ICapacityRepository capacityRepo = NSubstitute.Substitute.For<ICapacityRepository>();
            IJobRepository jobRepo = NSubstitute.Substitute.For<IJobRepository>();
            jobRepo.Exists(Arg.Any<Job>()).Returns(true);
            
            CapacityRules rules = new CapacityRules(capacityRepo,jobRepo);
            
            rules.Add(capacity);
            Assert.Pass();
        }

        [TestCase(1, Description = "Adding job")]
        public void CreateACapacityNotExistingJobError(int jobId)
        {
            Capacity capacity = new Capacity()
            {
                Id = 1,
                Name = "TestName",
                Job = new Job() { Id = jobId, Name = "Tester" }
            };

            ICapacityRepository capacityRepo = NSubstitute.Substitute.For<ICapacityRepository>();
            IJobRepository jobRepo = NSubstitute.Substitute.For<IJobRepository>();
            jobRepo.Exists(Arg.Any<Job>()).Returns(false);

            CapacityRules rules = new CapacityRules(capacityRepo, jobRepo);

            Assert.That(() => rules.Add(capacity),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("The job do not exist"));
        }
    }
}
