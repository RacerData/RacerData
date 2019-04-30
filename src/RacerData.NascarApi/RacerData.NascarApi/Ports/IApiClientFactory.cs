using System.Collections.Generic;
using RacerData.NascarApi.Ports;

namespace RacerData.NascarApi.Factories
{
    public interface IApiClientFactory
    {
        IApiClient GetMockNascarApiClient(IList<string> files);
        IApiClient GetMockNascarApiClient(string rootDirectory);
        IApiClient GetNascarApiClient();
    }
}