using SC.JobPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.JobPortal.Core.Repository
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetCandidates();
    }
}
