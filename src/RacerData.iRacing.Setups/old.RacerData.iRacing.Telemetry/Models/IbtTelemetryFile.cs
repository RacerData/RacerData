using System;
using System.Collections.Generic;
using System.Text;

namespace RacerData.iRacing.Telemetry.Models
{
    public class IbtTelemetryFile
    {
        public string FileName { get { return System.IO.Path.GetFileName(FullPath); } }

        public string FullPath { get; set; }

        public ISessionData SessionData { get; set; }

        public IbtTelemetryFile()
        {

        }
    }
}
