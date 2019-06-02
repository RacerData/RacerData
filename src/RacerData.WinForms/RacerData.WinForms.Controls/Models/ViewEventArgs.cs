using System;
using RacerData.WinForms.Views;

namespace RacerData.WinForms.Models
{
    public class ViewEventArgs : EventArgs
    {
        #region properties

        public ViewBase View { get; set; }

        #endregion

        #region ctor

        public ViewEventArgs()
        {

        }

        public ViewEventArgs(ViewBase view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        #endregion
    }
}
