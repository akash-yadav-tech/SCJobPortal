using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SC.JobPortal.Core.Models;

namespace SC.JobPortal.Core
{
    public interface IJobApplicationService
    {
        Task<IEnumerable<JobApplication>> GetJobApplications();

        Task<Boolean> CreateJobApplication(JobApplication jobApplication,IFormFile resume);
        Task<byte[]> DownloadResume(string fileName);

    }
}
