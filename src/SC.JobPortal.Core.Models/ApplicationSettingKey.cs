using System;

namespace SC.JobPortal.Core.Models
{
    public class ApplicationSettingKey
    {
        private readonly string _value;
        public ApplicationSettingKey(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public static readonly ApplicationSettingKey ApplicationConnectionString = new ApplicationSettingKey("DataBase:ApplicationConnectionString");
        public static readonly ApplicationSettingKey BlobStorageConnectionString = new ApplicationSettingKey("BlobStorage:StorageConnection");
        public static readonly ApplicationSettingKey StorageContainer = new ApplicationSettingKey("BlobStorage:Container");
    }
}
