using System;
using System.Collections.Generic;
using RacerData.Data.Ports;

namespace RacerData.Data.Aws.Models
{
    public interface IAwsItem : IKeyedItem<string>
    {
        /// <summary>
        /// Unique key for the item
        /// </summary>
        new string Key { get; set; }

        /// <summary>
        /// Json serialized item
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Httpcontent type
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// Size of the content
        /// </summary>
        int ContentLength { get; set; }

        /// <summary>
        /// Item ETag
        /// </summary>
        string ETag { get; set; }

        /// <summary>
        /// Last modified timestamp
        /// </summary>
        DateTime LastModified { get; set; }

        /// <summary>
        /// Metadata tags for the item
        /// </summary>
        IDictionary<string, string> Metadata { get; set; }
    }
}
