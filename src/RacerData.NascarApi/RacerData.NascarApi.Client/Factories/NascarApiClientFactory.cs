using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Mocks;
using RacerData.NascarApi.Client.Ports;
using RacerData.NascarApi.Factories;
using RacerData.NascarApi.Ports;

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

        public INascarApiClient GetMockNascarApiClient(string rootDirectory)
        {
            return new NascarApiClientMock(
                rootDirectory,
                _services.GetRequiredService<IResultFactory<INascarApiClient>>());

        }

        public INascarApiClient GetMockNascarApiClient(IList<string> files)
        {
            return new NascarApiClientMock(
                files,
                _services.GetRequiredService<IResultFactory<INascarApiClient>>());
        }
    }
}
