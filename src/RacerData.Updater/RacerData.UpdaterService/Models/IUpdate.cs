using System;

namespace RacerData.UpdaterService.Models
{
    public interface IUpdate
    {
        string Key { get; set; }
        string Url { get; set; }
        Version Version { get; set; }
        bool IsUpgrade { get; }
    }
}