using System;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Dialogs
{
    public partial class DialogBase : Form
    {
        #region properties
        
        private ApplicationAppearance _appearance;
        public virtual ApplicationAppearance Appearance
        {
            get
            {
                return _appearance;
            }
            set
            {
                _appearance = value;
                ApplyTheme(_appearance);
            }
        }
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

        protected virtual void ApplyTheme(ApplicationAppearance appearance)
        {
            if (appearance != null)
            {
                this.BackColor = appearance.DialogAppearance.BackColor;
                this.ForeColor = appearance.DialogAppearance.ForeColor;
                this.Font = appearance.DialogAppearance.Font;

                foreach (Button button in Controls.OfType<Button>())
                {
                    button.BackColor = appearance.DialogAppearance.ButtonAppearance.BackColor;
                    button.ForeColor = appearance.DialogAppearance.ButtonAppearance.ForeColor;
                    button.Font = appearance.DialogAppearance.ButtonAppearance.Font;
                    button.FlatStyle = appearance.DialogAppearance.ButtonAppearance.FlatStyle; ;
                    button.FlatAppearance.BorderColor = appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderColor;
                    button.FlatAppearance.BorderSize = appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderSize;
                    button.FlatAppearance.MouseDownBackColor = appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseDownBackColor;
                    button.FlatAppearance.MouseOverBackColor = appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseOverBackColor;
                }

                dialogButtons1.Appearance = appearance;
            }
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
            ApplyTheme(Appearance);
        }

        #endregion
    }
}
