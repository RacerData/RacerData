using System;
using rNascarApp.UI.Views;

namespace rNascarApp.UI.Models
{
    public class ViewEventArgs : EventArgs
    {
        #region properties

        public View View { get; set; }

        #endregion

        #region ctor

        public ViewEventArgs()
        {

        }

        public ViewEventArgs(View view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        #endregion
    }
}
