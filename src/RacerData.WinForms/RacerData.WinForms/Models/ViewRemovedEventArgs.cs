using RacerData.WinForms.Controls;

namespace RacerData.WinForms.Models
{
    public class ViewRemovedEventArgs : ViewEventArgs
    {
        #region ctor

        public ViewRemovedEventArgs()
            : base()
        {

        }

        public ViewRemovedEventArgs(View view)
            : base(view)
        {
        }

        #endregion
    }
}
