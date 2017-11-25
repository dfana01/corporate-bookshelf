using CorporateBookshelf.Core;
using CorporateBookshelf.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateBookshelf.Test
{   
    [TestFixture]
    public class JobDescriptionTest
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
    }
}
