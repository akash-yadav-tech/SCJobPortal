using AutoMapper;
using SoftModel = SC.JobPortal.Core.Models;
using HardModel = SC.JobPortal.Infrastructure.EntityFrameworkCore.Models;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository
{
    public class DomainToRepositoryMappingProfile : Profile
    {
        public DomainToRepositoryMappingProfile()
        {
            CreateMap<SoftModel.Candidate, HardModel.Candidate>().ReverseMap();
            CreateMap<SoftModel.Job, HardModel.Job>().ReverseMap();
            CreateMap<SoftModel.JobApplication, HardModel.JobApplication>()
                .ForMember(dest => dest.CandidateId,opt => opt.MapFrom(src => src.Candidate.Id))
                .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.Job.Id))
                .ReverseMap();
        }
    }
}
