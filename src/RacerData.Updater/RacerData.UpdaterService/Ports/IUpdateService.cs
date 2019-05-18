using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.UpdaterService.Models;

namespace RacerData.UpdaterService.Ports
{
    public interface IUpdateService
    {
        Task<IResult<UpdateResponse>> GetUpdatesAsync(string key, Version version);
        Task<IResult<UpdateFilesResponse>> GetUpdateFilesAsync(string key);
        Task<IResult<DownloadFilesResponse>> DownloadUpdateFiles(IList<string> fileUrls);
    }
}
