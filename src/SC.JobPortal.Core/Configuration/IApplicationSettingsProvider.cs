using System;
using System.Collections.Generic;
using System.Text;
using SC.JobPortal.Core.Models;

namespace SC.JobPortal.Core.Configuration
{
    public interface IApplicationSettingsProvider
    {
        T Get<T>(ApplicationSettingKey keys, T defaultValue = default);
    }
}
