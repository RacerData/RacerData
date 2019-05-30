using rNascarApp.UI.Views;

namespace rNascarApp.UI.Models
{
    public class ViewAddedEventArgs : ViewEventArgs
    {
        #region ctor

        public ViewAddedEventArgs()
            : base()
        {

        }

        public ViewAddedEventArgs(View view)
            : base(view)
        {
        }

        #endregion
    }
}
