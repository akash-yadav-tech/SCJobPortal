using Lamar;
using SC.JobPortal.Core.Configuration;
using SC.JobPortal.Infrastructure.AspNetCore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository;
using AutoMapper;
using SC.JobPortal.UI.Models;

namespace SC.JobPortal.UI
{
    public class ApplicationServicesRegistry : ServiceRegistry
    {
        public ApplicationServicesRegistry()
        {
            RegisterDependencies();
            RegisterAutoMapper();
        }
        private void RegisterDependencies()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.Assembly("SC.JobPortal.Core");
                scan.Assembly("SC.JobPortal.Core.DomainServices");
                scan.Assembly("SC.JobPortal.Core.Models");
                scan.Assembly("SC.JobPortal.Infrastructure.AspNetCore.Configuration");
               // scan.Assembly("SC.JobPortal.Infrastructure.Azure.BlobStorage");
                scan.Assembly("SC.JobPortal.Infrastructure.EntityFrameworkCore.Models");
                scan.Assembly("SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository");
            });
            For<ApplicationDbContext>().Use<ApplicationDbContext>().Scoped();
            ForSingletonOf<IApplicationSettingsProvider>().Use<ApplicationSettingsProvider>();
        }

        private void RegisterAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToRepositoryMappingProfile>();
                cfg.AddProfile<DomainToUIMappingProfile>();
            });

            IMapper _mapper = config.CreateMapper();

            For<IMapper>().Use(_mapper);
        }
    }
}
