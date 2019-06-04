using RacerData.WinForms.Controls;

namespace RacerData.WinForms.Models
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
