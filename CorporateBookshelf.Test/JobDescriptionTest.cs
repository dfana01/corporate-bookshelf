using CorporateBookshelf.Core;
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
            JobRules rules = new JobRules();

            //Assert 
            Assert.That(del: () => rules.AddJob(job), expr: Throws.ArgumentException);
        }
    }
}
