using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Models
{
    public class JobApplication
    {
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public string Resume { get; set; }

    }
}
