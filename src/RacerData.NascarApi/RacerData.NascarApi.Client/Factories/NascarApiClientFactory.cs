using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Mocks;
using RacerData.NascarApi.Client.Ports;

namespace RacerData.NascarApi.Client.Factories
{
    class NascarApiClientFactory : INascarApiClientFactory
    {
        private readonly IServiceProvider _services;

        public NascarApiClientFactory(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public INascarApiClient GetNascarApiClient()
        {
            return _services.GetRequiredService<INascarApiClient>();
        }

        public INascarApiClient GetMockNascarApiClient(IConfiguration configurationy)
        {
            return new NascarApiClientMock(
                configurationy,
                _services.GetRequiredService<IResultFactory<INascarApiClient>>());
        }
    }
}
