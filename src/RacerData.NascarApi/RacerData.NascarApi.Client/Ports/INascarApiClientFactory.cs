using System.Collections.Generic;

namespace RacerData.NascarApi.Client.Ports
{
    public interface INascarApiClientFactory
    {
        INascarApiClient GetMockNascarApiClient(IList<string> files);
        INascarApiClient GetMockNascarApiClient(string rootDirectory);
        INascarApiClient GetNascarApiClient();
    }
}