using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RacerData.iRacing.Service.Sessions.Data;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Service.Sessions.Mapping;
using RacerData.iRacing.Sessions.Models;
using RacerData.iRacing.Sessions.Ports;

namespace RacerData.iRacing.Service.Sessions.Adapters
{
    internal class RunRepository : IRunRepository
    {
        #region fields

        bool verbose = false;
        int _newPaths = 0;
        int _newProperties = 0;
        int _newValues = 0;
        private SessionsDbContext _context = null;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public RunRepository(
          SessionsDbContext context,
          IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region public

        public IQueryable<Lap> GetLaps(long runId)
        {
            var models = _context.Laps.Where(l => l.RunId == runId);

            return _mapper.ProjectTo<Lap>(models);
        }

        public IQueryable<TireSheet> GetTireSheetQuery(long runId)
        {
            var models = _context.TireReadings.Where(l => l.RunId == runId);

            var mapped = _mapper.ProjectTo<TireSheet>(models);

            return mapped;
        }

        public TireSheet GetTireSheet(long runId)
        {
            var models = _context.TireReadings.Where(l => l.RunId == runId);

            var mapped = TireSheetMapper.ToTireSheet(runId, models.ToList());

            return mapped;
        }

        public IQueryable<SetupValue> GetSetupValuesQuery(long runId)
        {
            var models = _context.RunSetupValues
                .Include(runSetup => runSetup.SetupValue)
                    .ThenInclude(setupValue => setupValue.Property)
                        .ThenInclude(property => property.Path)
                .Where(runSetup => runSetup.RunId == runId);

            return _mapper.ProjectTo<SetupValue>(models);
        }
        public IList<SetupValue> GetSetupValues(long runId)
        {
            var models = _context.RunSetupValues
                .Include(runSetup => runSetup.SetupValue)
                    .ThenInclude(setupValue => setupValue.Property)
                        .ThenInclude(property => property.Path)
                .Where(runSetup => runSetup.RunId == runId);

            return _mapper.Map<IList<SetupValue>>(models);
        }

        public Run GetRun(string fileName)
        {
            var existingTelemetryModel = _context.TelemetryData
                   .Where(p => p.FileName == fileName)
                   .SingleOrDefault();

            if (existingTelemetryModel == null)
            {
                return null;
            }

            var existingRunModel = _context.Runs
                .Where(p => p.TelemetryId == existingTelemetryModel.Id)
                .Include(p => p.Laps)
                .Include(p => p.TireReadings)
                .SingleOrDefault();

            if (existingRunModel == null)
            {
                return null;
            }

            return _mapper.Map<Run>(existingRunModel);
        }

        public async Task<Run> InsertRunAsync(Run run)
        {
            if (run == null)
            {
                throw new ArgumentNullException(nameof(run));
            }

            var model = _mapper.Map<RunModel>(run);

            if (model.Season == 0)
            {
                model = UpdateSeason(model);
            }

            IList<RunSetupValueModel> runSetupValues = await UpdateRunSetupAsync(model);

            _context.Runs.Add(model);

            await _context.SaveChangesAsync();

            await _context.RunSetupValues.LoadAsync();

            foreach (RunSetupValueModel runSetupValue in runSetupValues)
            {
                try
                {
                    runSetupValue.Run = model;
                    runSetupValue.RunId = model.Id;

                    var existing = _context.RunSetupValues.FirstOrDefault(rsv => rsv.RunId == runSetupValue.RunId &&
                        rsv.SetupValueId == runSetupValue.SetupValueId);

                    if (existing == null)
                    {
                        existing = _context.RunSetupValues.Local.FirstOrDefault(rsv => rsv.RunId == runSetupValue.RunId &&
                          rsv.SetupValueId == runSetupValue.SetupValueId);

                        if (existing == null)
                        {
                            _context.RunSetupValues.Add(runSetupValue);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<Run>(model);
        }

        #endregion

        #region protected

        protected virtual RunModel UpdateSeason(RunModel run)
        {
            var raceSeason = _context.Seasons.FirstOrDefault(s => run.RunTime > s.StartDate && run.RunTime <= s.EndDate);

            run.Year = raceSeason.Year;
            run.Season = raceSeason.Season;
            run.Week = raceSeason.Week;

            return run;
        }

        protected virtual async Task<IList<RunSetupValueModel>> UpdateRunSetupAsync(RunModel runModel)
        {
            IList<RunSetupValueModel> updatedRunSetupValues = new List<RunSetupValueModel>();

            var runSetupValueModels = runModel.SetupValues.ToList();

            runModel.SetupValues.Clear();

            foreach (RunSetupValueModel runSetupValue in runSetupValueModels)
            {
                string propertyPath = runSetupValue.SetupValue.Property.Path.Path;

                var pathModel = _context.SetupPropertyPaths.FirstOrDefault(p => p.Path == propertyPath);

                if (pathModel == null)
                {
                    pathModel = new SetupPropertyPathModel()
                    {
                        Path = runSetupValue.SetupValue.Property.Path.Path
                    };

                    _context.SetupPropertyPaths.Add(pathModel);
                }
                else
                {
                    runSetupValue.SetupValue.Property.Path = pathModel;
                    runSetupValue.SetupValue.Property.SetupPropertyPathId = pathModel.Id;
                }

                await _context.SaveChangesAsync();

                var propertyModel = _context.SetupProperties.FirstOrDefault(p =>
                    p.Name == runSetupValue.SetupValue.Property.Name &&
                    p.Path.Path == runSetupValue.SetupValue.Property.Path.Path);

                if (propertyModel == null)
                {
                    propertyModel = new SetupPropertyModel()
                    {
                        Path = pathModel,
                        DataType = runSetupValue.SetupValue.Property.DataType,
                        Units = runSetupValue.SetupValue.Property.Units,
                        Name = runSetupValue.SetupValue.Property.Name,
                        Version = runSetupValue.SetupValue.Property.Version
                    };

                    _context.SetupProperties.Add(propertyModel);

                    await _context.SaveChangesAsync();
                }

                var valueModel = _context.SetupValues.FirstOrDefault(v =>
                    v.Property.Name == runSetupValue.SetupValue.Property.Name &&
                    v.Property.Path.Path == runSetupValue.SetupValue.Property.Path.Path &&
                    v.Value == runSetupValue.SetupValue.Value);

                if (valueModel == null)
                {
                    valueModel = new SetupValueModel()
                    {
                        Property = propertyModel,
                        RawValue = runSetupValue.SetupValue.RawValue,
                        Value = runSetupValue.SetupValue.Value
                    };

                    _context.SetupValues.Add(valueModel);

                    await _context.SaveChangesAsync();
                }

                VehicleSetupPropertyModel vehicleSetupProperty = _context.VehicleSetupProperties
                    .FirstOrDefault(p => p.VehicleId == runModel.VehicleId &&
                    p.PropList == propertyModel.Id);

                if (vehicleSetupProperty == null)
                {
                    vehicleSetupProperty = _context.VehicleSetupProperties.Local
                    .FirstOrDefault(p => p.VehicleId == runModel.VehicleId &&
                    p.PropList == propertyModel.Id);

                    if (vehicleSetupProperty == null)
                    {
                        vehicleSetupProperty = new VehicleSetupPropertyModel()
                        {
                            VehicleId = runModel.VehicleId.Value,
                            PropList = propertyModel.Id
                        };

                        _context.VehicleSetupProperties.Add(vehicleSetupProperty);

                        await _context.SaveChangesAsync();
                    }
                }

                RunSetupValueModel runSetupValueModel = new RunSetupValueModel()
                {
                    Run = runModel,
                    RunId = runModel.Id,
                    SetupValue = valueModel,
                    SetupValueId = valueModel.Id
                };

                updatedRunSetupValues.Add(runSetupValueModel);
            }

            return updatedRunSetupValues;
        }

        //protected virtual void UpdateRunGraph(RunModel runModel)
        //{
        //    var existingRunModel = _context.Runs
        //        .Where(p => p.Id == runModel.Id)
        //        .Include(p => p.Laps)
        //        .Include(p => p.TireReadings)
        //        .SingleOrDefault();

        //    if (existingRunModel != null)
        //    {
        //        // Update parent
        //        _context.Entry(existingRunModel).CurrentValues.SetValues(runModel);

        //        // Delete laps
        //        foreach (var existingLap in existingRunModel.Laps.ToList())
        //        {
        //            if (!runModel.Laps.Any(c => c.Id == existingLap.Id))
        //                _context.Laps.Remove(existingLap);
        //        }
        //        // Update and Insert laps
        //        foreach (var lapModel in runModel.Laps)
        //        {
        //            var existingLap = existingRunModel.Laps
        //                .Where(c => c.Id == lapModel.Id)
        //                .SingleOrDefault();

        //            if (existingLap != null)
        //                // Update lap
        //                _context.Entry(existingLap).CurrentValues.SetValues(lapModel);
        //            else
        //            {
        //                var newLapModel = _mapper.Map<LapModel>(runModel);
        //                existingRunModel.Laps.Add(newLapModel);
        //            }
        //        }

        //        // Delete tireReadings
        //        foreach (var existingTireReadngs in existingRunModel.TireReadings.ToList())
        //        {
        //            if (!runModel.TireReadings.Any(c => c.Id == existingTireReadngs.Id))
        //                _context.TireReadings.Remove(existingTireReadngs);
        //        }
        //        // Update and Insert tireReadings
        //        foreach (var tireReadingModel in runModel.TireReadings)
        //        {
        //            var existingTireReadings = existingRunModel.TireReadings
        //                .Where(c => c.Id == tireReadingModel.Id)
        //                .SingleOrDefault();

        //            if (existingTireReadings != null)
        //                // Update tireReadong
        //                _context.Entry(existingTireReadings).CurrentValues.SetValues(tireReadingModel);
        //            else
        //            {
        //                var newTireReadngsModel = _mapper.Map<TireReadingsModel>(runModel);
        //                existingRunModel.TireReadings.Add(newTireReadngsModel);
        //            }
        //        }
        //    }

        //    runModel = UpdateSetupValuesGraph(runModel);
        //}

        //protected virtual RunModel UpdateSetupValuesGraph(RunModel runModel)
        //{
        //    IList<RunSetupValueModel> runSetupValues = new List<RunSetupValueModel>();
        //    _newPaths = 0;
        //    _newProperties = 0;
        //    _newValues = 0;

        //    if (verbose) Console.WriteLine($"#########################################################");
        //    if (verbose) Console.WriteLine($"################# Updating setup values #################");
        //    if (verbose) Console.WriteLine($"#########################################################");

        //    // make sure there are vehicle setup properties for each setup value.
        //    foreach (RunSetupValueModel runSetupValue in runModel.SetupValues.ToList())
        //    {
        //        var modelName = "RunSetupValue";
        //        var debugName = $"RunID:{runSetupValue.RunId}.SetupValueID:{runSetupValue.SetupValueId}";

        //        RunSetupValueModel runSetupValueModel = null;

        //        if (runSetupValue.RunId > 0 && runSetupValue.SetupValueId > 0)
        //        {
        //            if (verbose) Console.WriteLine($"\t->FINDING [{modelName}] using {debugName}...");

        //            // FIND searches local and db.
        //            runSetupValueModel = _context.RunSetupValues.Find(new long[] { runSetupValue.RunId, runSetupValue.SetupValueId });

        //            if (runSetupValueModel == null)
        //            {
        //                if (verbose) Console.WriteLine($"\t[{modelName}] {debugName} NOT FOUND in context or LOCAL context.");
        //            }
        //        }
        //        else
        //        {
        //            if (verbose) Console.WriteLine($"\tNEW [{modelName}] {debugName}, not searching context.");
        //        }

        //        if (runSetupValueModel == null)
        //        {
        //            if (verbose) Console.WriteLine($"\t\tCalling GetSetupValueModel to get the value model");
        //            if (verbose) Console.WriteLine("\t\t------------------>");
        //            SetupValueModel updatedSetupValueModel = GetSetupValueModel(runSetupValue.SetupValue);
        //            if (verbose) Console.WriteLine("\t\t<------------------");

        //            if (verbose) Console.WriteLine($"\tCreating new [{modelName}] {debugName}...");

        //            runSetupValueModel = new RunSetupValueModel()
        //            {
        //                Run = runModel,
        //                SetupValue = updatedSetupValueModel
        //            };

        //            if (verbose) Console.WriteLine($"\tNew [{modelName}] {debugName} added to context. <<<<<<<<<<<<<");
        //        }
        //        else
        //        {
        //            if (verbose) Console.WriteLine($"\t*** [{modelName}] {debugName} ***FOUND*** in context.");
        //        }

        //        runSetupValues.Add(runSetupValueModel);

        //    } // end foreach runSetupValue

        //    runModel.SetupValues = runSetupValues;

        //    if (verbose) Console.WriteLine();
        //    if (verbose) Console.WriteLine($"++++++++ New Paths:{_newPaths}\tNew Properties:{_newProperties}\tNew Values:{_newValues} ++++++++");
        //    if (verbose) Console.WriteLine();

        //    return runModel;
        //}

        //protected virtual SetupPropertyPathModel GetSetupPropertyPathModel(SetupValueModel setupValueModel)
        //{
        //    var modelName = "SetupValue";
        //    var debugName = $"{setupValueModel.Property.Path.Path}";

        //    if (verbose) Console.WriteLine($"\t\tSearching for [{modelName}] {debugName} in context...");

        //    SetupPropertyPathModel pathModel = _context.SetupPropertyPaths.
        //        FirstOrDefault(p =>
        //                  p.Path == setupValueModel.Property.Path.Path);

        //    if (pathModel == null)
        //    {
        //        if (verbose) Console.WriteLine($"\t\t[{modelName}] {debugName} NOT in context. Searching local context...");

        //        pathModel = _context.SetupPropertyPaths.Local.
        //            FirstOrDefault(p =>
        //                p.Path == setupValueModel.Property.Path.Path);

        //        if (pathModel == null)
        //        {
        //            if (verbose) Console.WriteLine($"\t\t[{modelName}] {debugName} NOT in LOCAL context.");

        //            if (verbose) Console.WriteLine($"\t\tCreating new [{modelName}] {debugName}...");

        //            pathModel = new SetupPropertyPathModel()
        //            {
        //                Path = setupValueModel.Property.Path.Path
        //            };
        //            _newPaths += 1;
        //            _context.SetupPropertyPaths.Add(pathModel);

        //            if (verbose) Console.WriteLine($"\t\tNew [{modelName}] {debugName} added to context. <<<<<<<<<<<<<");
        //        }
        //        else
        //        {
        //            if (verbose) Console.WriteLine($"\t\t*** [{modelName}] {debugName} ***FOUND*** in LOCAL context.");
        //        }
        //    }
        //    else
        //    {
        //        if (verbose) Console.WriteLine($"\t\t*** [{modelName}] {debugName} ***FOUND*** in context.");
        //    }

        //    return pathModel;
        //}

        //protected virtual SetupPropertyModel GetSetupPropertyModel(SetupValueModel setupValueModel)
        //{
        //    var modelName = "SetupProperty";
        //    var debugName = $"{setupValueModel.Property.Path.Path}.{setupValueModel.Property.Name}";

        //    SetupPropertyModel propertyModel = null;

        //    if (setupValueModel.SetupPropertyId > 0)
        //    {
        //        if (verbose) Console.WriteLine($"\t\t->FINDING [{modelName}] {debugName} using SetupPropertyId {setupValueModel.SetupPropertyId}...");

        //        // FIND searches local and db.
        //        propertyModel = _context.SetupProperties.Find(setupValueModel.SetupPropertyId);
        //    }
        //    else
        //    {
        //        if (verbose) Console.WriteLine($"\t\tSearching for [{modelName}] {debugName} in context...");

        //        propertyModel = _context.SetupProperties
        //             .FirstOrDefault(p =>
        //                 p.Path.Path == setupValueModel.Property.Path.Path &&
        //                 p.Name == setupValueModel.Property.Name);
        //    }

        //    if (propertyModel == null)
        //    {
        //        if (verbose) Console.WriteLine($"\t\t[{modelName}] {debugName} NOT in context. Searching local context...");

        //        propertyModel = _context.SetupProperties.Local
        //             .FirstOrDefault(p =>
        //                 p.Path?.Path == setupValueModel.Property.Path.Path &&
        //                 p.Name == setupValueModel.Property.Name);

        //        if (propertyModel == null)
        //        {
        //            if (verbose) Console.WriteLine($"\t\t[{modelName}] {debugName} NOT in LOCAL context.");

        //            if (verbose) Console.WriteLine($"\t\t\tCalling GetSetupPropertyPathModel to get the path model");
        //            if (verbose) Console.WriteLine("\t\t\t------------------>");
        //            SetupPropertyPathModel pathModel = GetSetupPropertyPathModel(setupValueModel);
        //            if (verbose) Console.WriteLine("\t\t\t<------------------");

        //            if (verbose) Console.WriteLine($"\t\tCreating new [{modelName}] {debugName}...");

        //            propertyModel = new SetupPropertyModel()
        //            {
        //                Name = setupValueModel.Property.Name,
        //                DataType = setupValueModel.Property.DataType,
        //                SetupPropertyPathId = setupValueModel.Property.SetupPropertyPathId,
        //                Units = setupValueModel.Property.Units,
        //                Version = setupValueModel.Property.Version,
        //                Path = pathModel
        //            };
        //            _newProperties += 1;
        //            _context.SetupProperties.Add(propertyModel);

        //            if (verbose) Console.WriteLine($"\t\tNew [{modelName}] {debugName} added to context. <<<<<<<<<<<<<");
        //        }
        //        else
        //        {
        //            if (verbose) Console.WriteLine($"\t\t*** [{modelName}] {debugName} ***FOUND*** in LOCAL context.");
        //        }
        //    }
        //    else
        //    {
        //        if (verbose) Console.WriteLine($"\t\t*** [{modelName}] {debugName} ***FOUND*** in context.");
        //    }

        //    return propertyModel;
        //}

        //protected virtual SetupValueModel GetSetupValueModel(SetupValueModel setupValueModel)
        //{
        //    var modelName = "SetupValue";
        //    var debugName = $"{setupValueModel.Property.Path.Path}.{setupValueModel.Property.Name}.{setupValueModel.Value}";

        //    SetupValueModel valueModel = null;

        //    if (setupValueModel.Id > 0)
        //    {
        //        if (verbose) Console.WriteLine($"\t\t->FINDING [{modelName}] {debugName} using Id {setupValueModel.Id}...");

        //        // FIND searches local and db.
        //        valueModel = _context.SetupValues.Find(setupValueModel.Id);
        //    }
        //    else
        //    {
        //        if (verbose) Console.WriteLine($"\t\tSearching for [{modelName}] {debugName} in context...");

        //        valueModel = _context.SetupValues
        //             .FirstOrDefault(p =>
        //                 p.Property.Path.Path == setupValueModel.Property.Path.Path &&
        //                 p.Property.Name == setupValueModel.Property.Name &&
        //                 p.Value == setupValueModel.Value);
        //    }

        //    if (valueModel == null)
        //    {
        //        if (verbose) Console.WriteLine($"\t\t[{modelName}] {debugName} NOT in context. Searching local context...");

        //        valueModel = _context.SetupValues.Local
        //           .Where(p => p.Property != null && p.Property?.Path != null)
        //           .FirstOrDefault(p =>
        //               p.Property.Path.Path == setupValueModel.Property.Path.Path &&
        //               p.Property.Name == setupValueModel.Property.Name &&
        //               p.Value == setupValueModel.Value);

        //        if (valueModel == null)
        //        {
        //            if (verbose) Console.WriteLine($"\t\t[{modelName}] {debugName} NOT in LOCAL context.");

        //            if (verbose) Console.WriteLine($"\t\t\tCalling GetSetupPropertyModel to get the property model");
        //            if (verbose) Console.WriteLine("\t\t\t------------------>");
        //            SetupPropertyModel propertyModel = GetSetupPropertyModel(setupValueModel);
        //            if (verbose) Console.WriteLine("\t\t\t<------------------");

        //            if (verbose) Console.WriteLine($"\t\tCreating new [{modelName}] {debugName}...");

        //            valueModel = new SetupValueModel()
        //            {
        //                Property = propertyModel,
        //                RawValue = setupValueModel.RawValue,
        //                Value = (float)Math.Round(setupValueModel.Value, 3)
        //            };
        //            _newValues += 1;
        //            _context.SetupValues.Add(valueModel);

        //            if (verbose) Console.WriteLine($"\t\tNew [{modelName}] {debugName} added to context. <<<<<<<<<<<<<");
        //        }
        //        else
        //        {
        //            if (verbose) Console.WriteLine($"\t\t*** [{modelName}] {debugName} ***FOUND*** in LOCAL context.");
        //        }
        //    }
        //    else
        //    {
        //        if (verbose) Console.WriteLine($"\t\t*** [{modelName}] {debugName} ***FOUND*** in context.");
        //    }

        //    if (valueModel.Property == null)
        //    {
        //        SetupPropertyModel propertyModel = GetSetupPropertyModel(setupValueModel);
        //        valueModel.Property = propertyModel;
        //    }

        //    return valueModel;
        //}

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ((IDisposable)_context).Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
