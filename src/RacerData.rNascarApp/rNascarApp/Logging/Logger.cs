using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace RacerData.rNascarApp.Logging
{
    public class Logger
    {
        public static void Setup()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            // event log
            PatternLayout eventLogPatternLayout = new PatternLayout();
            eventLogPatternLayout.ConversionPattern = "%date %-5level %logger - %message%newline";
            eventLogPatternLayout.ActivateOptions();

            EventLogAppender eventLogAppender = new EventLogAppender();
            eventLogAppender.Layout = eventLogPatternLayout;
            hierarchy.Root.AddAppender(eventLogAppender);

            // console
            PatternLayout consolePatternLayout = new PatternLayout();
            consolePatternLayout.ConversionPattern = "%date %-5level %logger - %message%newline";
            consolePatternLayout.ActivateOptions();

            ConsoleAppender consoleAppender = new ConsoleAppender();
            consoleAppender.Layout = consolePatternLayout;
            hierarchy.Root.AddAppender(consoleAppender);

            // file
            PatternLayout rollingFilePatternLayout = new PatternLayout();
            rollingFilePatternLayout.ConversionPattern = "%date %-5level %logger - %message%newline";
            rollingFilePatternLayout.ActivateOptions();

            RollingFileAppender rollingFileAppender = new RollingFileAppender();            
            rollingFileAppender.AppendToFile = true;
            rollingFileAppender.File = GetLogFilePath();
            rollingFileAppender.MaxSizeRollBackups = 5;
            rollingFileAppender.MaximumFileSize = "1GB";
            rollingFileAppender.RollingStyle = RollingFileAppender.RollingMode.Size;
            rollingFileAppender.StaticLogFileName = true;
            rollingFileAppender.ImmediateFlush = true;
            rollingFileAppender.Layout = rollingFilePatternLayout;
            rollingFileAppender.ActivateOptions();

            hierarchy.Root.AddAppender(rollingFileAppender);


            hierarchy.Root.Level = Level.Error;
            hierarchy.Configured = true;
        }

        public static string GetLogFilePath()
        {
            return $"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}\\logs\\errorLog.json";
        }
    }
}