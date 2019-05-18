using System;
using System.Collections.Generic;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Services
{
    public class ViewStatesChangedEventArgs : EventArgs
    {
        public IList<ViewState> ViewStates { get; set; }
    }
}
