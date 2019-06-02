using System;

namespace RacerData.WinForms.Models
{
    public class RemoveViewRequestEventArgs : EventArgs
    {
        #region properties

        public int Index { get; set; }

        #endregion

        #region ctor

        public RemoveViewRequestEventArgs()
        {

        }

        public RemoveViewRequestEventArgs(int index)
        {
            Index = index;
        }

        #endregion
    }
}
