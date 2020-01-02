using System;
using Microsoft.Azure;

namespace NFWatcherAzureStorageClass
{
    public class TableAccessTools
    {
        public double VersionNumber()
        {
            return (0.9);
        }

        public string GetTableConnString()
        { 
            string TableConnString;
            TableConnString = CloudConfigurationManager.GetSetting("StorageConnection");
            return (TableConnString);
        }
        
    }
}
