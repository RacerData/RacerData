using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("SetupFiles")]
    class SetupFileModel
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string FullPath { get; set; }
        public int Size { get; set; }
        public byte[] Data { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastWrite { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Moved { get; set; }
    }

    [Table("setupFileIndex3")]
    class SetupFileIndex3Model
    {
        public string Name { get; set; }
        [Key()]
        public string FullPath { get; set; }
        public int Size { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastWrite { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Moved { get; set; }
    }

    class DuplicateSetupFileModel
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public int Size { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastWrite { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
