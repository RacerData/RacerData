using System;
using System.Collections.Generic;

namespace RacerData.UpdaterService.Models
{
    public class UpdateFilesResponse
    {
        public Version Version { get; set; }
        public IList<UpdateFile> UpdateFiles { get; set; }

        public UpdateFilesResponse()
        {
            UpdateFiles = new List<UpdateFile>();
        }
    }
}
