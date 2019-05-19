using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace RacerData.Data.TestApp.Logging
{
    public class Logger
    {
        public static void Setup()
        {
            try
            {
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

                // console
                PatternLayout consolePatternLayout = new PatternLayout();
                consolePatternLayout.ConversionPattern = "%date %-5level %logger - %message%newline";
                consolePatternLayout.ActivateOptions();

                ColoredConsoleAppender coloredConsoleAppender = new ColoredConsoleAppender();
                coloredConsoleAppender.Layout = consolePatternLayout;

                coloredConsoleAppender.AddMapping(new ColoredConsoleAppender.LevelColors()
                {
                    Level = Level.Info,
                    ForeColor = ColoredConsoleAppender.Colors.Blue,
                    BackColor = ColoredConsoleAppender.Colors.White
                });

                coloredConsoleAppender.AddMapping(new ColoredConsoleAppender.LevelColors()
                {
                    Level = Level.Error,
                    ForeColor = ColoredConsoleAppender.Colors.Red,
                    BackColor = ColoredConsoleAppender.Colors.Yellow
                });

                coloredConsoleAppender.AddMapping(new ColoredConsoleAppender.LevelColors()
                {
                    Level = Level.Warn,
                    ForeColor = ColoredConsoleAppender.Colors.Red,
                    BackColor = ColoredConsoleAppender.Colors.White
                });

                coloredConsoleAppender.ActivateOptions();
                hierarchy.Root.AddAppender(coloredConsoleAppender);

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

                hierarchy.Root.Level = Level.Info;
                hierarchy.Configured = true;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"EXCEPTION IN Logger.Setup: {ex.Message}\r\n{ex.ToString()}");
                throw;
            }
        }

        public static string GetLogFilePath()
        {
            return $"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}\\logs\\errorLog.json";
        }
    }
}