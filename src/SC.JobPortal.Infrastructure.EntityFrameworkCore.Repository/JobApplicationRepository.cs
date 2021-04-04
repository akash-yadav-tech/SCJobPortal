using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SoftModel = SC.JobPortal.Core.Models;
using HardModel = SC.JobPortal.Infrastructure.EntityFrameworkCore.Models;
using SC.JobPortal.Core.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public JobApplicationRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            this._mapper = mapper;
            this._dbContext = dbContext;

        }
        public async Task<Boolean> CreateJobApplication(SoftModel.JobApplication jobApplication)
        {
            var jobApplicationHardModel = _mapper.Map<HardModel.JobApplication>(jobApplication);
            jobApplicationHardModel.Job = null;
            var result = await _dbContext.JobApplications.AddAsync(jobApplicationHardModel);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<SoftModel.JobApplication>> GetJobApplications()
        {
            var jobApplicationsHardModel = await _dbContext.JobApplications.Include(x=>x.Candidate).Include(x=>x.Job).ToListAsync();
            return _mapper.Map<IEnumerable<SoftModel.JobApplication>>(jobApplicationsHardModel);
        }
    }
}
