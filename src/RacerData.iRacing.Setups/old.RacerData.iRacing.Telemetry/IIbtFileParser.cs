using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RacerData.iRacing.Telemetry.Models;

namespace RacerData.iRacing.Telemetry
{
    public interface IIbtFileParser
    {
        Task<IbtTelemetryFile> ParseTelemetryFileAsync(string fullPath, IbtParseOptions options);
    }
}
