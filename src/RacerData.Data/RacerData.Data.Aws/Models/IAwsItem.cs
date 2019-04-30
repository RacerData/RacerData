using System.Collections.Generic;

namespace RacerData.Data.Aws.Models
{
    public interface IAwsItem
    {
        /// <summary>
        /// Unique key for the item
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Json serialized item
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Httpcontent type
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// Metadata tags for the item
        /// </summary>
        IDictionary<string, string> Metadata { get; set; }
    }
}
