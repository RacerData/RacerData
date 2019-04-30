using System;

namespace RacerData.Data.Aws.Models
{
    public interface IAwsListItem
    {
        string ETag { get; set; }
        string Key { get; set; }
        DateTime LastModified { get; set; }
    }
}