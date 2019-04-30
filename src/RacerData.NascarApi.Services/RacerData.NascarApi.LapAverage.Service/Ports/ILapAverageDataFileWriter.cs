using RacerData.NascarApi.Client.Models.LapAverages;

namespace RacerData.NascarApi.LapAverage.Service.Ports
{
    public interface ILapAverageDataFileWriter
    {
        int? LastElapsedWritten { get; set; }
        void WriteFile(EventVehicleLapAverages data);
        void WriteFile(string rootDirectory, EventVehicleLapAverages data);
    }
}