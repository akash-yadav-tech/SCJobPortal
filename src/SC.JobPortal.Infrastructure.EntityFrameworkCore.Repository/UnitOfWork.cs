using System;
using System.Collections.Generic;
using System.Text;
using SC.JobPortal.Core.Repository;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IJobRepository JobRepository { get; }

        public IJobApplicationRepository JobApplicationRepository { get; }

        public ICandidateRepository CandidateRepository { get; }

        public UnitOfWork(ApplicationDbContext context, 
                            IJobRepository jobRepository, 
                            IJobApplicationRepository jobApplicationRepository,
                            ICandidateRepository candidateRepository)
        {
            this._context = context;
            this.JobRepository = jobRepository;
            this.CandidateRepository = candidateRepository;
            this.JobApplicationRepository = jobApplicationRepository;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
