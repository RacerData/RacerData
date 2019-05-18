using System;
using System.IO;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json;

namespace RacerData.rNascarApp.Settings
{
    public abstract class SettingsBase
    {
        #region properties

        protected ILog Log { get; set; }

        protected abstract string SettingsFileName { get; }

        protected string SettingsDirectory
        {
            get
            {
                return $"{Path.GetDirectoryName(Application.ExecutablePath)}\\settings\\";
            }
        }

        #endregion

        #region ctor

        public SettingsBase()
        {
            Log = LogManager.GetLogger("Settings");
        }

        #endregion

        #region public

        public bool Save()
        {
            try
            {
                var filePath = GetSettingsFilePath();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    NullValueHandling = NullValueHandling.Include
                };

                var content = JsonConvert.SerializeObject(
                        this,
                        Formatting.Indented,
                        settings);

                File.WriteAllText(filePath, content);

                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error saving settings file", ex);
            }

            return false;
        }

        public string GetSettingsFilePath()
        {
            try
            {
                if (!Directory.Exists(SettingsDirectory))
                    Directory.CreateDirectory(SettingsDirectory);

                return Path.Combine(SettingsDirectory, SettingsFileName);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error getting settings file path", ex);
            }

            return @".\";
        }

        #endregion

        #region protected
        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            Log?.Error(message, ex);

            MessageBox.Show(ex.Message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected T Load<T>() where T : SettingsBase, new()
        {
            try
            {
                var filePath = GetSettingsFilePath();

                if (!File.Exists(filePath))
                {
                    var defaultSettings = new T();

                    defaultSettings.Save();

                    return defaultSettings;
                }

                var settingsContent = File.ReadAllText(filePath);

                return JsonConvert.DeserializeObject<T>(settingsContent);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error loading settings file", ex);
            }

            return default(T);
        }

        protected virtual T GetDefaultSettings<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
