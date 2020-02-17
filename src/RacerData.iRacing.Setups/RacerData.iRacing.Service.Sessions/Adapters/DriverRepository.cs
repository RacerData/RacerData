using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RacerData.iRacing.Service.Sessions.Data;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;

namespace RacerData.iRacing.Service.Sessions.Adapters
{
    internal class DriverRepository : IDriverRepository
    {
        #region fields

        private SessionsDbContext _context = null;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public DriverRepository(
          SessionsDbContext context,
          IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region public

        public async Task<IList<Driver>> GetDriversAsync()
        {
            var driverModels = await _context.Drivers.ToListAsync();

            IList<Driver> results = _mapper.Map<IList<Driver>>(driverModels);

            return results;
        }

        public async Task<Driver> GetDriverAsync(long id)
        {
            var driverModel = await _context.Drivers.FindAsync(id);

            if (driverModel == null)
            {
                return null;
            }

            return _mapper.Map<Driver>(driverModel);
        }

        public async Task<Driver> InsertDriverAsync(Driver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(nameof(driver));
            }

            var driverModel = _mapper.Map<DriverModel>(driver);

            _context.Drivers.Add(driverModel);

            await _context.SaveChangesAsync();

            return await GetDriverAsync(driverModel.Id);
        }

        public async Task<Driver> UpdateDriverAsync(Driver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(nameof(driver));
            }

            var driverModel = await _context.Drivers.FindAsync(driver.Id);

            if (driverModel == null)
            {
                throw new ArgumentException(nameof(driver.Id));
            }

            _mapper.Map<Driver, DriverModel>(driver, driverModel);

            await _context.SaveChangesAsync();

            return await GetDriverAsync(driver.Id);
        }

        #endregion
    }
}
