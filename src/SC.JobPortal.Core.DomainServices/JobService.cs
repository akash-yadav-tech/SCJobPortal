using SC.JobPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SC.JobPortal.Core.Repository;

namespace SC.JobPortal.Core.DomainServices
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await _unitOfWork.JobRepository.GetJobs();
        }
    }
}
