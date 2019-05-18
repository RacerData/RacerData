using System;

namespace RacerData.UpdaterService.Models
{
    public class Upgrade : IUpdate
    {
        public string Key { get; set; }
        public Version Version { get; set; }
        public string Url { get; set; }
        public bool IsUpgrade => true;
    }
}
