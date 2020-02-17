using System;
using System.IO;

namespace RacerData.iRacing.Telemetry
{
    public class iRacingTelemetryOptions
    {
        #region constants
        public const string FieldDisplaysFileName = "DefaultDisplayInfo.json";
        public const string FieldDefinitionsFileName = "FieldDefinitions.json";
        public const string TelemetryFunctionsFileName = "Functions.json";
        public const string UserDefinedFunctionsFileName = "UserDefinedFunctions.json";
        public const string LogFileName = "TelemetryViewer.Log";
        #endregion

        #region properties
        public bool IsDebug { get; set; } = true;

        public string TelemetryDirectory
        {
            get
            {
                return Path.Combine(RootDirectory, @"iRacing\Telemetry");
            }
        }
        public string AppDirectory
        {
            get
            {
                return ApplicationDirectory;
            }
        }
        public string FunctionsDirectory
        {
            get
            {
                return Path.Combine(ApplicationDirectory, @"Functions\"); ;
            }
        }
        public string ProjectsDirectory
        {
            get
            {
                return Path.Combine(ApplicationDirectory, @"Projects\");
            }
        }
        public string TracksDirectory
        {
            get
            {
                return Path.Combine(ApplicationDirectory, @"Tracks\");
            }
        }
        public string DisplaysDirectory
        {
            get
            {
                return Path.Combine(ApplicationDirectory, @"Displays\");
            }
        }
        public string LogDirectory
        {
            get
            {
                return Path.Combine(ApplicationDirectory, @"Logs\");
            }
        }

        public string LogFile
        {
            get
            {
                return Path.Combine(LogDirectory, LogFileName);
            }
        }
        public string FieldDisplaysFile
        {
            get
            {
                return Path.Combine(ApplicationDirectory, FieldDisplaysFileName);
            }
        }
        public string FieldDefinitionsFile
        {
            get
            {
                return Path.Combine(ApplicationDirectory, FieldDefinitionsFileName);
            }
        }
        public string TelemetryFunctionsFile
        {
            get
            {
                return Path.Combine(ApplicationDirectory, TelemetryFunctionsFileName);
            }
        }
        public string UserDefinedFunctionsFile
        {
            get
            {
                return Path.Combine(ApplicationDirectory, UserDefinedFunctionsFileName);
            }
        }
        #endregion

        #region ctor
        public iRacingTelemetryOptions()
        {
            CreateIfNotExists(AppDirectory);
            CreateIfNotExists(FunctionsDirectory);
            CreateIfNotExists(ProjectsDirectory);
            CreateIfNotExists(TracksDirectory);
            CreateIfNotExists(DisplaysDirectory);
        }
        #endregion

        #region protected virtual
        protected static void CreateIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        protected static string RootDirectory
        {
            get
            {
                return Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), @"Documents\");
            }
        }
        protected static string ApplicationDirectory
        {
            get
            {
                return Path.Combine(RootDirectory, @"Telemetry\iRacingTelemetry\"); ;
            }
        }
        #endregion
    }
}
