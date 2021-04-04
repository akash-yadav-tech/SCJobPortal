using SC.JobPortal.Core.Models;
using SC.JobPortal.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        public Task<IEnumerable<Candidate>> GetCandidates()
        {
            throw new NotImplementedException();
        }
    }
}
