using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RacerData.rNascarApp.Settings
{
    public class AppSettings : SettingsBase
    {
        #region constants

        private const string AppSettingsFileName = "appSettings.json";

        #endregion

        #region properties

        public IList<ViewState> ViewStates { get; set; } = new List<ViewState>();
        public int GridRowCount { get; set; } = 4;
        public int GridColumnCount { get; set; } = 4;
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

            var loaded = settings.Load<AppSettings>();

            return loaded;
        }

        #endregion
    }
}
