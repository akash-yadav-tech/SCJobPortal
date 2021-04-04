using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.JobPortal.Core.FileUpload
{
    public interface IBlobStorageRepository
    {
        Task<bool> UploadFile(IFormFile asset);
        Task<byte[]> DownloadFile(string Filename);
    }
}
