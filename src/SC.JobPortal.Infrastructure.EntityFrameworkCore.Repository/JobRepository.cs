using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SC.JobPortal.Core.Models;
using SC.JobPortal.Core.Repository;
using SoftModel = SC.JobPortal.Core.Models;
using HardModel = SC.JobPortal.Infrastructure.EntityFrameworkCore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public JobRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Job>> GetJobs()
        {
            var jobsHardModel = await _dbContext.Jobs.ToListAsync();
            return _mapper.Map<IEnumerable<SoftModel.Job>>(jobsHardModel);
        }
    }
}
