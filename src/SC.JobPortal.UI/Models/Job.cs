using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SC.JobPortal.UI.Models
{
    public class Job
    {
        [Required]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
