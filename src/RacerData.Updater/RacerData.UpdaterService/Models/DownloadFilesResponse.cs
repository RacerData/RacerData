using System.Collections.Generic;

namespace RacerData.UpdaterService.Models
{
    public class DownloadFilesResponse
    {
        public string TempDirectory { get; set; }
        public IList<string> Files { get; set; }

        public DownloadFilesResponse()
        {
            Files = new List<string>();
        }
    }
}
