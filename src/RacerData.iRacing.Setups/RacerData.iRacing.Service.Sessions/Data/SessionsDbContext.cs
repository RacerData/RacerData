using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RacerData.iRacing.Service.Sessions.Data.Models;

namespace RacerData.iRacing.Service.Sessions.Data
{
    class SessionsDbContext : DbContext
    {
        public static readonly LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
            });

        public virtual DbSet<TelemetryFileInfoModel> TelemetryFileInfos { get; set; }
        public virtual DbQuery<DuplicateSetupFileModel> DuplicateSetupFiles { get; set; }
        public virtual DbQuery<SessionListViewModel> SessionListViews { get; set; }
        public virtual DbSet<RunModel> Runs { get; set; }
        public virtual DbSet<DriverModel> Drivers { get; set; }
        public virtual DbSet<TrackModel> Tracks { get; set; }
        public virtual DbSet<VehicleModel> Vehicles { get; set; }
        public virtual DbSet<RaceSeasonModel> Seasons { get; set; }
        public virtual DbSet<TelemetryModel> TelemetryData { get; set; }
        public virtual DbSet<LapModel> Laps { get; set; }
        public virtual DbSet<TireReadingsModel> TireReadings { get; set; }
        public virtual DbSet<SetupModel> Setups { get; set; }
        public virtual DbSet<SetupFileModel> SetupFiles { get; set; }
        public virtual DbSet<SetupFileIndex3Model> SetupFilesIndex3 { get; set; }
        public virtual DbSet<SetupPropertyModel> SetupProperties { get; set; }
        public virtual DbSet<VehicleSetupPropertyModel> VehicleSetupProperties { get; set; }
        public virtual DbSet<SetupValueModel> SetupValues { get; set; }
        public virtual DbSet<SetupPropertyPathModel> SetupPropertyPaths { get; set; }
        public virtual DbSet<RunSetupValueModel> RunSetupValues { get; set; }
        public virtual DbSet<SessionTrackStateModel> SessionTrackStates { get; set; }
        public virtual DbSet<SessionTimeModel> SessionTimes { get; set; }

        public SessionsDbContext(DbContextOptions<SessionsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Query<SessionListViewModel>().ToView("SessionListView");

            modelBuilder
              .Query<DuplicateSetupFileModel>().ToView("DuplicateSetupFiles");

            modelBuilder.Entity<RunSetupValueModel>().HasKey(table => new
            {
                table.RunId,
                table.SetupValueId
            });

            modelBuilder.Entity<VehicleSetupPropertyModel>().HasKey(table => new
            {
                table.VehicleId,
                table.PropList
            });

            modelBuilder.Entity<RaceSeasonModel>().HasKey(table => new
            {
                table.Year,
                table.Season,
                table.Week
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }
    }
}
