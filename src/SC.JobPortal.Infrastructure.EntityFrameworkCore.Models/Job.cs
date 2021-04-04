using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
