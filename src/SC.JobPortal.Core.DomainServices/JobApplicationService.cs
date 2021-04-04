using SC.JobPortal.Core.Models;
using SC.JobPortal.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SC.JobPortal.Core.FileUpload;
using Microsoft.AspNetCore.Http;

namespace SC.JobPortal.Core.DomainServices
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageRepository _blobStorageRepository;
        public JobApplicationService(IUnitOfWork unitOfWork,IBlobStorageRepository blobStorageRepository)
        {
            _unitOfWork = unitOfWork;
            _blobStorageRepository = blobStorageRepository;
        }
        public async Task<Boolean> CreateJobApplication(JobApplication jobApplication, IFormFile resume)
        {
            var fileUploadResult = await _blobStorageRepository.UploadFile(resume);
            var result = await _unitOfWork.JobApplicationRepository.CreateJobApplication(jobApplication);
            if(fileUploadResult)
            {
                _unitOfWork.Commit();
            }
            return result && fileUploadResult;
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplications()
        {
            return await _unitOfWork.JobApplicationRepository.GetJobApplications();
        }
        public async Task<byte[]> DownloadResume(string fileName)
        {
            return await _blobStorageRepository.DownloadFile(fileName);
        }

    }
}
