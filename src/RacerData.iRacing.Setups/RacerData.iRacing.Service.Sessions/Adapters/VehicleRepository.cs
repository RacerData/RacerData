using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RacerData.iRacing.Service.Sessions.Data;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;

namespace RacerData.iRacing.Service.Sessions.Adapters
{
    internal class VehicleRepository : IVehicleRepository
    {
        #region fields

        private SessionsDbContext _context = null;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public VehicleRepository(
          SessionsDbContext context,
          IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region public

        public async Task<IList<Vehicle>> GetVehiclesAsync()
        {
            var vehicleModels = await _context.Vehicles.ToListAsync();

            IList<Vehicle> results = _mapper.Map<IList<Vehicle>>(vehicleModels);

            return results;
        }

        public async Task<Vehicle> GetVehicleAsync(long id)
        {
            var vehicleModel = await _context.Vehicles.Where(t => t.Id == id).AsNoTracking().FirstOrDefaultAsync();

            if (vehicleModel == null)
            {
                return null;
            }

            return _mapper.Map<Vehicle>(vehicleModel);
        }

        public async Task<Vehicle> InsertVehicleAsync(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            var vehicleModel = _mapper.Map<VehicleModel>(vehicle);

            _context.Vehicles.Add(vehicleModel);

            await _context.SaveChangesAsync();

            return await GetVehicleAsync(vehicleModel.Id);
        }

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            var vehicleModel = await _context.Vehicles.FindAsync(vehicle.Id);

            if (vehicleModel == null)
            {
                throw new ArgumentException(nameof(vehicle.Id));
            }

            _mapper.Map<Vehicle, VehicleModel>(vehicle, vehicleModel);

            await _context.SaveChangesAsync();

            return await GetVehicleAsync(vehicle.Id);
        }

        public async Task<IList<SetupProperty>> GetVehicleSetupProperties(long vehicleId)
        {
            var vehicleSetupProperties = await _context.VehicleSetupProperties
                .Where(p => p.VehicleId == vehicleId)
                .Select(v => v.PropList)
                .ToListAsync();

            var setupProperties = _context.SetupProperties
                .Include("Path")
                .Where(p => vehicleSetupProperties.Contains(p.Id));

            return _mapper.Map<IList<SetupProperty>>(setupProperties);
        }

        //public async Task<IList<SetupPropertyPath>> GetVehicleSetupPropertyPaths(long vehicleId)
        //{
        //    var vehicleSetupProperties = await _context.VehicleSetupProperties
        //        .Where(p => p.VehicleId == vehicleId)
        //        .Select(v => v.PropList)
        //        .ToListAsync();

        //    var setupPropertyPaths = _context.SetupPropertyPaths
        //        .Where(p=>p.Properties.Any(p=>p.))
        //    //var setupProperties = _context.SetupProperties
        //    //    .Include("Path")
        //    //    .Where(p => vehicleSetupProperties.Contains(p.Id));

        //    return _mapper.Map<IList<SetupProperty>>(setupProperties);
        //}

        #endregion
    }
}
