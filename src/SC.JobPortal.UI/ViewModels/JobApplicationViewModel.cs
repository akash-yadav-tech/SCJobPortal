using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SC.JobPortal.UI.Models;

namespace SC.JobPortal.UI.ViewModels
{
    public class JobApplicationViewModel
    {
        public JobApplication JobApplication { get; set; }
        public List<SelectListItem> Jobs { get; set; }
    }
}
