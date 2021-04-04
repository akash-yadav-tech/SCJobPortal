using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SC.JobPortal.UI.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Candidates name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        [Display(Name = "Candidates Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Candidates Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Candidates Place Of Birth")]
        public string PlaceOfBirth { get; set; }
    }
}
