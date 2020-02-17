using System;

namespace RacerData.iRacing.Sessions.Models
{
    public class SetupFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public int Size { get; set; }
        public byte[] Data { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastWrite { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Moved { get; set; }
    }

    public class DuplicateSetupFile
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public int Size { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastWrite { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
