using System.Collections.Generic;

namespace RacerData.Common.Models
{
    public class DirectoryConfiguration
    {
        public string myDocumentsFolder { get; set; }
        public List<DirectoryMapItem> map { get; set; }
    }
}
