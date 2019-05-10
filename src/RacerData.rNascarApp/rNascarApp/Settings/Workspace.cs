using System;
using System.Collections.Generic;

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

        #endregion

        #region ctor

        public Workspace()
        {
            ViewStates = new List<Guid>();
        }

        #endregion
    }
}
