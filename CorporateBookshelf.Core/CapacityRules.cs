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
            if (capacity.Name.Length < 5 || capacity.Name.Length > 100)
            {
                throw new ArgumentException("Invalid Name");
            }

            if (! _jobRepo.Exists(capacity.Job))
            {
                throw  new ArgumentException("The job do not exist");
            }
            if (_repo.Exists(capacity))
            {
                throw new ArgumentException("Duplicate Name");
            }   
            
        }

        
    }
}