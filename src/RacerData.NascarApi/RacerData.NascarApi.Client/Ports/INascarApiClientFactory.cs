using Microsoft.Extensions.Configuration;

namespace RacerData.NascarApi.Client.Ports
{
    public interface INascarApiClientFactory
    {
        INascarApiClient GetMockNascarApiClient(IConfiguration configuration);
        INascarApiClient GetNascarApiClient();
    }
}