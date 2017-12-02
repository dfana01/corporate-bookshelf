using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using CorporateBookShelf.Models;

namespace CorporateBookshelf.Test
{
    [TestFixture()]
    public class CapacityRuleTest
    {
        [Test]
        public void NotEmpty()
        {
            Capacity capacity = new Capacity()
            {
                Id=1,
                Name=""
            };
        }
    }
}
