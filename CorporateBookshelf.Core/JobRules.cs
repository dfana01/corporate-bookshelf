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
            int size = (job.Name?.Trim().Length).GetValueOrDefault();

            if (_repository.Exists(job))
            {
                throw new ArgumentException("Job already exist");
            }

            if (size < 5 || size > 100)
            {
                throw new ArgumentException("Invalid name");
            }

            if (job.Id < 1 || job.Id > 1000000)
            {
                throw new ArgumentException("Invalid id");
            }

            _repository.Add(job);
        }

        public object Count()
        {
            return _repository.Count();
        }
    }
}
