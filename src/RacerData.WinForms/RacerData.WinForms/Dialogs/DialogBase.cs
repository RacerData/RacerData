using System;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Dialogs
{
    public partial class DialogBase : Form
    {
        #region properties

        public ButtonTypes DialogType
        {
            get
            {
                return dialogButtons1.ButtonTypes;
            }
            set
            {
                dialogButtons1.ButtonTypes = value;
            }
        }

        #endregion

        #region ctor

        public DialogBase()
        {
            InitializeComponent();

            dialogButtons1.DialogResultClicked += DialogResultClicked;

            dialogButtons1.FormStateChanging += DialogButtons1_FormStateChanging;
            dialogButtons1.FormStateChanged += DialogButtons1_FormStateChanged;

            dialogButtons1.RaiseFormStateEvents = dialogButtons1.ButtonTypes == ButtonTypes.EditForm;
        }

        #endregion

        #region protected

        protected virtual void DialogResultClicked(object sender, Events.DialogResultEventArgs e)
        {
            Console.WriteLine($"DialogResult: {e.Result}");

            this.DialogResult = e.Result;
        }

        #endregion

        #region private

        private void DialogButtons1_FormStateChanging(object sender, Events.FormStateChangingEventArgs e)
        {
            Console.WriteLine($"FormState Changing: {e.CurrentState} -> {e.NewState}");
        }

        private void DialogButtons1_FormStateChanged(object sender, Events.FormStateChangedEventArgs e)
        {
            Console.WriteLine($"FormState Changed: {e.State}");
        }

        #endregion
    }
}
