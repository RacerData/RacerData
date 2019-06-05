using System;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Dialogs
{
    public partial class DialogBase : Form
    {
        #region properties

        public ApplicationAppearance Appearance { get; set; }
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

        public DialogBase(ApplicationAppearance appearance)
            : this()
        {
            Appearance = appearance;

            dialogButtons1.Appearance = appearance;
        }

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

        private void DialogBase_Load(object sender, EventArgs e)
        {
            if (Appearance != null)
            {
                this.BackColor = Appearance.DialogAppearance.BackColor;
                this.ForeColor = Appearance.DialogAppearance.ForeColor;
                this.Font = Appearance.DialogAppearance.Font;

                foreach (Button button in Controls.OfType<Button>())
                {
                    button.BackColor = Appearance.DialogAppearance.ButtonAppearance.BackColor;
                    button.ForeColor = Appearance.DialogAppearance.ButtonAppearance.ForeColor;
                    button.Font = Appearance.DialogAppearance.ButtonAppearance.Font;
                    button.FlatStyle = Appearance.DialogAppearance.ButtonAppearance.FlatStyle; ;
                    button.FlatAppearance.BorderColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderColor;
                    button.FlatAppearance.BorderSize = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderSize;
                    button.FlatAppearance.MouseDownBackColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseDownBackColor;
                    button.FlatAppearance.MouseOverBackColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseOverBackColor;
                }

                dialogButtons1.Appearance = Appearance;
            }
        }

        #endregion
    }
}
