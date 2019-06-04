using System;
using RacerData.WinForms.Controls;

namespace RacerData.WinForms.Models
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
