﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NascarApi.Simulation.Models;

namespace NascarApi.Simulation.Ports
{
    public interface IVehicleRepository
    {
        Task<NascarVehicle> GetAsync(int eventId);
        Task<IEnumerable<NascarVehicle>> GetListAsync();
        Task<NascarVehicle> SaveAsync(NascarVehicle item);
    }
}
