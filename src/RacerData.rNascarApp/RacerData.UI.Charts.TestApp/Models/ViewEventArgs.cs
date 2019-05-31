using System;
using rNascarApp.UI.Views;

namespace rNascarApp.UI.Models
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
