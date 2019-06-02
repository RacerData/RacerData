using RacerData.WinForms.Views;

namespace RacerData.WinForms.Models
{
    public class ViewRemovedEventArgs : ViewEventArgs
    {
        #region ctor

        public ViewRemovedEventArgs()
            : base()
        {

        }

        public ViewRemovedEventArgs(ViewBase view)
            : base(view)
        {
        }

        #endregion
    }
}
