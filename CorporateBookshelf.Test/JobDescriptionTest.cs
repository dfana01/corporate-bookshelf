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
        [Test]
        public void NameMustHasBetween5and100Characters()
        {
            //Arrange
            Job job = new Job();
            job.Name = "Dev";
            job.Id = 1;

            //Act
            IJobRepository repo = NSubstitute.Substitute.For<IJobRepository>();
            JobRules rules = new JobRules(repo);

            //Assert 
            Assert.That(() => rules.AddJob(job),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid name"));
        }
    }
}
