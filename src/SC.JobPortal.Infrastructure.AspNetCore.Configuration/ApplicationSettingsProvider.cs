using Microsoft.Extensions.Configuration;
using SC.JobPortal.Core.Configuration;
using SC.JobPortal.Core.Models;
using System;

namespace SC.JobPortal.Infrastructure.AspNetCore.Configuration
{
    public class ApplicationSettingsProvider : IApplicationSettingsProvider
    {
        private readonly IConfiguration _configuration;
        public ApplicationSettingsProvider(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public T Get<T>(ApplicationSettingKey keys, T defaultValue = default)
        {
            return _configuration.GetValue(key: keys.ToString(), defaultValue);
        }
    }
}
