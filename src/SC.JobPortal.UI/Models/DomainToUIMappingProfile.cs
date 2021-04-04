using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIModel = SC.JobPortal.UI.Models;
using SoftModel = SC.JobPortal.Core.Models;

namespace SC.JobPortal.UI.Models
{
    public class DomainToUIMappingProfile : Profile
    {
        public DomainToUIMappingProfile()
        {
            CreateMap<SoftModel.Candidate, UIModel.Candidate>().ReverseMap();
            CreateMap<SoftModel.Job, UIModel.Job>().ReverseMap();
            CreateMap<SoftModel.JobApplication, UIModel.JobApplication>().ReverseMap();
        }
    }
}
