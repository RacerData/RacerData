using System;
using System.Windows.Forms;

namespace RacerData.WinForms.Events
{
    public class DialogResultEventArgs : EventArgs
    {
        public virtual DialogResult Result { get; protected set; }

        public DialogResultEventArgs(DialogResult result)
        {
            Result = result;
        }
    }
}
