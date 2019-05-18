using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Settings
{
    public class AppSettings : SettingsBase
    {
        #region constants

        private const string AppSettingsFileName = "appSettings.json";

        #endregion

        #region properties

        public IList<ViewState> ViewStates { get; set; } = new List<ViewState>();
        public Size Size { get; set; }
        public Point Location { get; set; }
        public FormWindowState WindowState { get; set; }
        public FormStartPosition StartPosition { get; set; }
        protected override string SettingsFileName => AppSettingsFileName;

        #endregion

        #region public

        public static AppSettings Load()
        {
            var settings = new AppSettings();

            try
            {
                var loaded = settings.Load<AppSettings>();

                return loaded;
            }
            catch (Exception ex)
            {
                settings.ExceptionHandler("Error loading AppSettings", ex);

                settings = settings.GetDefaultSettings<AppSettings>();
            }

            return settings;
        }

        public void ProcessChangeSet(ChangeSet<ViewState> changes)
        {
            foreach (ViewState deleted in changes.Deleted)
            {
                var existing = ViewStates.SingleOrDefault(v => v.Id == deleted.Id);

                if (existing != null)
                    ViewStates.Remove(existing);
            }

            foreach (ViewState added in changes.Added)
            {
                ViewStates.Add(added);
            }

            foreach (ViewState updated in changes.Edited)
            {
                var existing = ViewStates.SingleOrDefault(v => v.Id == updated.Id);

                if (existing != null)
                    ViewStates.Remove(existing);

                ViewStates.Add(updated);
            }
        }

        #endregion

        #region protected

        protected override T GetDefaultSettings<T>()
        {
            var defaultSettings = new AppSettings()
            {
                Size = new Size(500, 500),
                Location = new Point(0, 0),
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterScreen,
            } as T;

            return defaultSettings;
        }

        #endregion
    }
}
