using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using CorporateBookShelf.Models;
using CorporateBookshelf.Core;

namespace CorporateBookshelf.Test
{
    [TestFixture()]
    public class CapacityRuleTest
    {
        [TestCase("",Description = "Name should not be empty")]
        public void NotEmpty(string name)
        {
            Capacity capacity = new Capacity()
            {
                Id=1,
                Name=name
            };

            CapacityRules rules = new CapacityRules();

            Assert.That(() => rules.Add(capacity),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid Name"));
        }

        [TestCase("testName","testName", Description = "Name ")]
        public void NotDuplicateName()
        {
            Capacity capacity = new Capacity()
            {
                Id = 1,
                Name = ""
            };

            CapacityRules rules = new CapacityRules();

            Assert.That(() => rules.Add(capacity),
                Throws.TypeOf<ArgumentException>().With.Message.Contains("Invalid Name"));
        }

    }
}
