using System;
using System.Collections.Generic;
using System.Text;

namespace SC.JobPortal.Core.Repository
{
    public interface IUnitOfWork
    {
        IJobRepository JobRepository { get; }
        IJobApplicationRepository JobApplicationRepository { get; }
        ICandidateRepository CandidateRepository { get; }
        int Commit();
    }
}
