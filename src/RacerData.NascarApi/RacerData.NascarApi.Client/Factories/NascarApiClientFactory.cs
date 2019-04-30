using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Adapters;
using RacerData.NascarApi.Client.Mocks;
using RacerData.NascarApi.Client.Ports;
using RacerData.NascarApi.Factories;
using RacerData.NascarApi.Ports;

namespace RacerData.NascarApi.Client.Factories
{
    class NascarApiClientFactory
    {
        private readonly ServiceProvider _services;

        public NascarApiClientFactory(ServiceProvider services)
        {
            _services = _services ?? throw new ArgumentNullException(nameof(services));
        }

        public IApiClient GetNascarApiClient()
        {
            return _services.GetRequiredService<IApiClient>();
        }

        public INascarApiClient GetMockNascarApiClient(string rootDirectory)
        {
            return new NascarApiClientMock(
                rootDirectory,
                _services.GetRequiredService<IApiClientFactory>(),
                _services.GetRequiredService<IResultFactory<INascarApiClient>>(),
                _services.GetRequiredService<IMapper>());

        }

        public INascarApiClient GetMockNascarApiClient(IList<string> files)
        {
            return new NascarApiClientMock(
                files,
                _services.GetRequiredService<IApiClientFactory>(),
                _services.GetRequiredService<IResultFactory<INascarApiClient>>(),
                _services.GetRequiredService<IMapper>());
        }
    }
}
