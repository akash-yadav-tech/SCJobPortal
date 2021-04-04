using SC.JobPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.JobPortal.Core
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetJobs();
    }
}
