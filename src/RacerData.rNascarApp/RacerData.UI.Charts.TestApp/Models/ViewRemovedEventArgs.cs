using rNascarApp.UI.Views;

namespace rNascarApp.UI.Models
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
