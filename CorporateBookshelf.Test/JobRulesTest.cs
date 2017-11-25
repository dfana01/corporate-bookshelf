using CorporateBookshelf.Core;
using CorporateBookshelf.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace CorporateBookshelf.Test
{   
    [TestFixture]
    public class JobRulesTest
    {


        [TestCase("Dev",Description = "Name is too short")]
        [TestCase(null, Description = "Name is null")]
        [TestCase("", Description = "Name is empty")]
        [TestCase("     e", Description = "Name is too short (with whitespace)")]
        [TestCase("e     ", Description = "Name is too short (with whitespace)")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaa", Description = "Name is too long")]
        public void InvalidName(string name)
        {
            //Arrange
            Job job = new Job();
            job.Id = 1;
            job.Name = name;
            
            //Act
            IJobRepository repo = NSubstitute.Substitute.For<IJobRepository>();
            JobRules rules = new JobRules(repo);

            //Assert 
            Assert.That(() => rules.AddJob(job),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid name"));
        }

        [TestCase("Dante", Description = "Nombre valido")]
        [TestCase("e     e", Description = "Name is valid with space between character")]
        public void ValidName(string name)
        {
            //Arrange
            Job job = new Job { Name = name, Id = 1 };

            //Act
            IJobRepository repo = NSubstitute.Substitute.For<IJobRepository>();
            JobRules rules = new JobRules(repo);

            //Assert 
            rules.AddJob(job);
            Assert.Pass();
        }

        [TestCase(-1, Description = "Id is invalid cause is negative(-1)")]
        [TestCase(0, Description = "Id is invalid cause is zero")]
        [TestCase(-2, Description = "Is is invalid cause is negative(-2)")]
        [TestCase(1000001, Description = "Is is invalid cause greater than 1MM")]
        public void InvalidId(int id)
        {
            //Arrange
            Job job = new Job { Name = "TestId", Id = id };

            //Act
            IJobRepository repo = NSubstitute.Substitute.For<IJobRepository>();
            JobRules rules = new JobRules(repo);

            //Assert 
            Assert.That(() => rules.AddJob(job),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid id"));
        }

        [TestCase(1, Description = "Id is valid (1)")]
        [TestCase(10, Description = "Id is valid (10)")]
        [TestCase(121, Description = "Id is valid (121)")]
        [TestCase(999999, Description = "Id is valid (999999)")]
        [TestCase(1_000_000, Description = "Id is valid (1_000_000)")]
        public void ValidId(int id)
        {
            //Arrange
            Job job = new Job { Name = "TestId", Id = id };

            //Act
            IJobRepository repo = NSubstitute.Substitute.For<IJobRepository>();
            JobRules rules = new JobRules(repo);

            //Assert 
            rules.AddJob(job);
            Assert.Pass();
        }

        [TestCase(1, Description = "Adding to time the same id")]
        [TestCase(5, Description = "Adding to time the same id")]
        public void ValidUniqueId(int id)
        {
            //Arrange
            Job job1 = new Job { Name = "TestID1", Id = id };
            Job job2 = new Job { Name = "TestID2", Id = id };

            //Act
            IJobRepository repo = NSubstitute.Substitute.For<IJobRepository>();
            repo.Exists(Arg.Any<Job>()).Returns(true);
            JobRules rules = new JobRules(repo);

            //Assert
            Assert.That(() => { rules.AddJob(job1); rules.AddJob(job2); },
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Job already exist"));

        }

        [TestCase("TestUniqueName  ", "  TestUniqueName", Description = "Adding to time the same name")]
        [TestCase("TestUniqueName", "TestUniqueName", Description = "Adding to time the same name")]
        public void ValidUniqueName(String name1, String name2)
        {
            //Arrange
            Job job1 = new Job { Name = name1, Id = 1 };
            Job job2 = new Job { Name = name2, Id = 2 };

            //Act
            IJobRepository repo = NSubstitute.Substitute.For<IJobRepository>();
            repo.Exists(Arg.Any<Job>()).Returns(true);
            JobRules rules = new JobRules(repo);

            //Assert
            Assert.That(() => { rules.AddJob(job1); rules.AddJob(job2); },
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Job already exist"));

        }


    }
}
