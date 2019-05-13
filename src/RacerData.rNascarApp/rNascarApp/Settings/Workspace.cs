using System;
using System.Collections.Generic;
using System.Linq;

namespace RacerData.rNascarApp.Settings
{
    public class Workspace
    {
        #region consts

        public const string DefaultWorkspaceName = "Default";

        #endregion

        #region properties

        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
        public IList<Guid> ViewStates { get; set; }
        private int _rows = 8;
        public int GridRowCount
        {
            get
            {
                if (_rows == 0)
                    _rows = 8;

                return _rows;
            }
            set
            {
                _rows = value;
            }
        }
        private int _columns = 8;
        public int GridColumnCount
        {
            get
            {
                if (_columns == 0)
                    _columns = 8;

                return _columns;
            }
            set
            {
                _columns = value;
            }
        }
        public bool IsDefaultPracticeWorkspace { get; set; }
        public bool IsDefaultQualifyingWorkspace { get; set; }
        public bool IsDefaultRaceWorkspace { get; set; }

        #endregion

        #region ctor

        public Workspace()
        {
            ViewStates = new List<Guid>();
        }

        #endregion

        #region public

        public Workspace Copy(string newName)
        {
            return new Workspace()
            {
                Name = newName,
                ViewStates = ViewStates.ToList(),
                GridColumnCount = GridColumnCount,
                GridRowCount = GridRowCount
            };
        }

        #endregion
    }
}
