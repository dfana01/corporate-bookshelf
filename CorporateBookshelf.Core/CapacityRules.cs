using System;
using CorporateBookShelf.Models;

namespace CorporateBookshelf.Core
{
    public class CapacityRules
    {
        private readonly ICapacityRepository _repo;
        private readonly IJobRepository _jobRepo;

        public CapacityRules(ICapacityRepository repo, IJobRepository jobRepo)
        {
            _repo = repo;
            _jobRepo = jobRepo;
        }

        public void Add(Capacity capacity)
        {
            int nameLength = capacity.Name.Trim().Length;
            if (nameLength < 5 || nameLength > 100)
            {
                throw new ArgumentException("Invalid Name");
            }

            if (! _jobRepo.Exists(capacity.Job))
            {
                throw  new ArgumentException("The job do not exist");
            }
            if (_repo.Exists(capacity))
            {
                throw new ArgumentException("Duplicated capacity");
            }

            _repo.Add(capacity);
            _repo.SaveChanges();
        }

        public int Count()
        {
            return _repo.Count();
        }
    }
}