using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SC.JobPortal.UI.Models
{
    public class JobApplication
    {
        [Display(Name = "Job")]
        public Job Job { get; set; }
        public Candidate Candidate { get; set; }
        public IFormFile ResumeFile { get; set; }
        public string Resume { get; set; }
    }
}
