using System;
using System.Collections.Generic;
using System.Text;

namespace SC.JobPortal.Core.Models
{
    public class JobApplication
    {
        public Job Job { get; set; }
        public Candidate Candidate { get; set; }

        public string Resume { get; set; }
    }
}
