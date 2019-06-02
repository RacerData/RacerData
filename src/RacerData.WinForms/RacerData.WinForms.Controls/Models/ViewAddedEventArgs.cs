using RacerData.WinForms.Views;

namespace RacerData.WinForms.Models
{
    public class ViewAddedEventArgs : ViewEventArgs
    {
        #region ctor

        public ViewAddedEventArgs()
            : base()
        {

        }

        public ViewAddedEventArgs(ViewBase view)
            : base(view)
        {
        }

        #endregion
    }
}
