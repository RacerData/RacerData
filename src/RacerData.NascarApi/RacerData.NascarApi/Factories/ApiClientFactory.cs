using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using RacerData.NascarApi.Client.Mocks;
using RacerData.NascarApi.Ports;

namespace RacerData.NascarApi.Factories
{
    class ApiClientFactory : IApiClientFactory
    {
        private readonly IServiceProvider _services;

        public ApiClientFactory(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public IApiClient GetNascarApiClient()
        {
            return _services.GetRequiredService<IApiClient>();
        }

        public IApiClient GetMockNascarApiClient(string rootDirectory)
        {
            return new ApiClientMock() { RootDirectory = rootDirectory };
        }

        public IApiClient GetMockNascarApiClient(IList<string> files)
        {
            return new ApiClientMock() { Files = files };
        }
    }
}
