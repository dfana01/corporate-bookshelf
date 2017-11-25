using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateBookshelf.Core
{
    public class JobRules
    {

        public Job AddJob(Job job)
        {
            return job;
        }

        public object Count()
        {
            return 1;
        }
    }
}
