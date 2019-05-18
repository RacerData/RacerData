using System;
using System.Collections.Generic;

namespace RacerData.rNascarApp.Services
{
    public class ViewStateIdsChangedEventArgs : EventArgs
    {
        public IList<Guid> ViewStateIds { get; set; }
    }
}
