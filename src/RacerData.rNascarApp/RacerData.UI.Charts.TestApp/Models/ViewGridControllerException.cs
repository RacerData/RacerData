using System;
using rNascarApp.UI.Views;

namespace rNascarApp.UI.Models
{
    public class ViewGridControllerException : Exception
    {
        #region properties

        public View View { get; set; }

        #endregion

        #region ctor

        public ViewGridControllerException()
            : base()
        {

        }
        public ViewGridControllerException(string message)
           : base(message)
        {

        }
        public ViewGridControllerException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
        public ViewGridControllerException(string message, Exception innerException, View view)
            : base(message, innerException)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        #endregion
    }
}
