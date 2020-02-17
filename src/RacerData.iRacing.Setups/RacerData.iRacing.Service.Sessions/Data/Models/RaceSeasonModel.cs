using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RacerData.iRacing.Service.Sessions.Data.Models
{
    [Table("RaceSeasons")]
    class RaceSeasonModel
    {
        [Key()]
        public int Year { get; set; }
        [Key()]
        public int Season { get; set; }
        [Key()]
        public int Week { get; set; }
        [Required()]
        public DateTime StartDate { get; set; }
        [Required()]
        public DateTime EndDate { get; set; }
    }
}
