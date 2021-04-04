using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SC.JobPortal.Core.Models;

namespace SC.JobPortal.Core.Repository
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetJobs();
    }
}
