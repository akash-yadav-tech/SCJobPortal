using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SC.JobPortal.UI.Models;
using SC.JobPortal.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SC.JobPortal.Core;
using SoftModel = SC.JobPortal.Core.Models;
using UIModel = SC.JobPortal.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;


namespace SC.JobPortal.UI.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper _mapper;
        public JobApplicationController(IJobService jobService, IJobApplicationService jobApplicationService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _jobService = jobService;
            _jobApplicationService = jobApplicationService;
            _mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {

            var jobs = await _jobService.GetJobs();

            var jobApplicationViewModel = new JobApplicationViewModel()
            {
                Jobs = jobs.Select(x => new SelectListItem()
                {
                    Text = x.Description,
                    Value = x.Id.ToString()
                }).ToList()
            };
            return View(jobApplicationViewModel);
        }

        public async Task<IActionResult> Create(JobApplication jobApplication)
        {
            var jobApplicationSoftModel = _mapper.Map<SoftModel.JobApplication>(jobApplication);
            var result = await _jobApplicationService.CreateJobApplication(jobApplicationSoftModel,jobApplication.ResumeFile);
            if (result)
            {
                return RedirectToAction("ApplicationList");
            }
            throw new Exception("Error Occured While Creating Job Application");
        }

        public async Task<IActionResult> ApplicationList()
        {
            var jobApplicationsSoftModels = await _jobApplicationService.GetJobApplications();

            return View("ApplicationList", _mapper.Map<IEnumerable<UIModel.JobApplication>>(jobApplicationsSoftModels));
        }

        public async Task<IActionResult> DownloadResume(string fileName)
        {
            var result = await _jobApplicationService.DownloadResume(fileName);
            return File(result,fileName);
        }
    }
}
