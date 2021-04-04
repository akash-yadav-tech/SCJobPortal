using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        public string PlaceOfBirth { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
