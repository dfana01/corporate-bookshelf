using CorporateBookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateBookshelf.Core
{
    public class JobRules
    {
        private readonly IJobRepository _repository;

        public JobRules(IJobRepository repository)
        {
            _repository = repository;
        }

        public void AddJob(Job job)
        {
            //throw new ArgumentException("Invalid xyz");
            _repository.Add(job);
        }

        public object Count()
        {
            return _repository.Count();
        }
    }
}
