using Microsoft.AspNetCore.Http;
using SC.JobPortal.Core.Configuration;
using SC.JobPortal.Core.FileUpload;
using System;
using System.Threading.Tasks;

using SC.JobPortal.Core.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace SC.JobPortal.Infrastructure.Azure.BlobStorage
{
    public class BlobStorageRepository : IBlobStorageRepository
    {
        private readonly IApplicationSettingsProvider _applicationSettingsProvider;

        public BlobStorageRepository(IApplicationSettingsProvider applicationSettingsProvider)
        {
            _applicationSettingsProvider = applicationSettingsProvider;
        }
        public async Task<bool> UploadFile(IFormFile asset)
        {
            try
            {
                if (CloudStorageAccount.TryParse(_applicationSettingsProvider.Get<string>(ApplicationSettingKey.BlobStorageConnectionString), out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(_applicationSettingsProvider.Get<string>(ApplicationSettingKey.StorageContainer));
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(asset.FileName);
                    await blockBlob.UploadFromStreamAsync(asset.OpenReadStream());

                    return true;
                }
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }
            return false;

        }
        public async Task<byte[]> DownloadFile(string Filename)
        {
            try
            {
                if (CloudStorageAccount.TryParse(_applicationSettingsProvider.Get<string>(ApplicationSettingKey.BlobStorageConnectionString), out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer container = blobClient.GetContainerReference(_applicationSettingsProvider.Get<string>(ApplicationSettingKey.StorageContainer));
                    var blockBlob = container.GetBlockBlobReference(Filename);
                    using (var ms = new MemoryStream())
                    {
                        if (await blockBlob.ExistsAsync())
                        {
                            await blockBlob.DownloadToStreamAsync(ms);
                        }
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                //log exception
                throw new Exception("Error in Downloading File.");
            }
            throw new Exception("Error in Downloading File.");
        }
    }
}
