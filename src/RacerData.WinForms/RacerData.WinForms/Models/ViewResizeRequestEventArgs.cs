using System;
using System.Drawing;

namespace RacerData.WinForms.Models
{
    public class BeginViewResizeRequestEventArgs : ViewResizeRequestEventArgs
    {
        #region ctor

        public BeginViewResizeRequestEventArgs()
            : base()
        {
        }
        public BeginViewResizeRequestEventArgs(Point point, ResizeDirection resizeDirection)
            : base(point, resizeDirection)
        {
        }

        #endregion
    }
    public class EndViewResizeRequestEventArgs : ViewResizeRequestEventArgs
    {
        #region fields

        public bool Cancelled { get; set; }

        #endregion

        #region ctor

        public EndViewResizeRequestEventArgs()
            : base()
        {
        }
        public EndViewResizeRequestEventArgs(Point point, ResizeDirection resizeDirection)
            : base(point, resizeDirection)
        {
        }
        public EndViewResizeRequestEventArgs(bool cancelled)
            : base(cancelled)
        {
        }
        #endregion
    }
    public class ViewResizeRequestEventArgs : EventArgs
    {
        #region properties

        public Point Location { get; set; }
        public ResizeDirection ResizeDirection { get; set; }

        #endregion

        #region ctor

        public ViewResizeRequestEventArgs()
        {

        }
        public ViewResizeRequestEventArgs(bool cancelled)
        {

        }
        public ViewResizeRequestEventArgs(Point point, ResizeDirection resizeDirection)
        {
            Location = point;
            ResizeDirection = resizeDirection;
        }

        #endregion
    }
}
