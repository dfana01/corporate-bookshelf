using CorporateBookshelf.Models;
using System;

namespace CorporateBookshelf.Core
{
    /// <summary>
    /// Apply business rules for job.
    /// </summary>
    public class JobRules
    {
        private readonly IJobRepository _repository;

        /// <summary>
        /// Initialized the job rules 
        /// </summary>
        /// <param name="repository"></param>
        public JobRules(IJobRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Insert new job and check validations.
        /// </summary>
        /// <param name="job"></param>
        public void AddJob(Job job)
        {
            Validate(job);

            _repository.Add(job);
        }

        private void Validate(Job job)
        {
            ValidateIfNotDuplicate(job);
            ValidateName(job);
            ValidateId(job);
        }

        private static void ValidateId(Job job)
        {
            if (job.Id < 1 || job.Id > 1000000)
            {
                throw new ArgumentException("Invalid id");
            }
        }

        private static void ValidateName(Job job)
        {
            int size = (job.Name?.Trim().Length).GetValueOrDefault();
            if (size < 5 || size > 100)
            {
                throw new ArgumentException("Invalid name");
            }
        }

        private void ValidateIfNotDuplicate(Job job)
        {
            if (_repository.Exists(job))
            {
                throw new ArgumentException("Job already exist");
            }
        }



        /// <summary>
        /// return quantity of jobs.
        /// </summary>
        /// <returns></returns>
        public object Count()
        {
            return _repository.Count();
        }
    }
}
