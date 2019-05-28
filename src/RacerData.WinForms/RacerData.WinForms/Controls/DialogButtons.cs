using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Events;
using RacerData.WinForms.Factories;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public partial class DialogButtons : UserControl
    {
        #region consts

        private const int DefaultButtonPadding = 8;
        private const int DefaultButtonWidth = 75;

        #endregion

        #region events

        public delegate void HasSelectionHandler(object sender, ref bool hasSelection);
        public event HasSelectionHandler HasSelectionQuery;
        protected virtual bool OnHasSelectionQuery()
        {
            var handler = HasSelectionQuery;
            var hasSelection = false;
            handler?.Invoke(this, ref hasSelection);

            return hasSelection;
        }

        public delegate void HasChangesHandler(object sender, ref bool hasChanges);
        public event HasChangesHandler HasChangesQuery;
        protected virtual bool OnHasChangesQuery()
        {
            var handler = HasChangesQuery;
            var hasChanges = false;
            handler?.Invoke(this, ref hasChanges);

            return hasChanges;
        }

        public event EventHandler<DialogResultEventArgs> DialogResultClicked;
        protected virtual void OnDialogResultClicked(DialogResult result)
        {
            var handler = DialogResultClicked;
            handler?.Invoke(this, new DialogResultEventArgs(result));
        }

        public event EventHandler<FormStateChangingEventArgs> FormStateChanging;
        protected virtual bool OnFormStateChanging(FormStates currentState, FormStates newState)
        {
            var handler = FormStateChanging;

            var e = new FormStateChangingEventArgs(currentState, newState);

            bool cancelled = false;

            foreach (EventHandler<FormStateChangingEventArgs> subHandler in handler?.GetInvocationList())
            {
                subHandler?.Invoke(this, e);
                if (e.Cancel)
                {
                    cancelled = true;
                    break;
                }
            }

            return cancelled;
        }

        public event EventHandler<FormStateChangedEventArgs> FormStateChanged;
        protected virtual void OnFormStateChanged(FormStates state)
        {
            if (!RaiseFormStateEvents)
                return;

            var handler = FormStateChanged;
            handler?.Invoke(this, new FormStateChangedEventArgs(state));
        }

        #endregion

        #region fields

        private ButtonSet _buttonSet = new ButtonSet();

        #endregion

        #region properties

        public ButtonTypes ButtonTypes { get; set; } = ButtonTypes.Blank;

        private FormStates _state;
        public FormStates FormState
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state == value)
                    return;

                bool cancel = OnFormStateChanging(_state, value);

                if (!cancel)
                {
                    _state = value;
                    OnFormStateChanged(_state);
                }
            }
        }

        public bool RaiseFormStateEvents { get; set; } = true;

        #endregion

        #region ctor

        public DialogButtons()
        {
            InitializeComponent();

            Dock = DockStyle.Bottom;

            FormStateChanged += Dialog_FormStateChanged;
        }

        #endregion

        #region public

        #endregion

        #region protected

        protected virtual void CreateButtons()
        {
            var buttonHeight = this.Height - this.Padding.Top - this.Padding.Bottom;

            var _factory = new ButtonSetFactory(DefaultButtonWidth, buttonHeight);

            _buttonSet = _factory.BuildButtonSet(ButtonTypes);

            AddLeftButtons(_buttonSet.LeftButtons);

            AddRightButtons(_buttonSet.RightButtons);

            SetButtonPositions();
        }

        protected virtual void SetButtonPositions()
        {
            PositionLeftButtons(_buttonSet.LeftButtons);

            PositionRightButtons(_buttonSet.RightButtons);
        }

        #endregion

        #region private

        private void DialogButtons_Load(object sender, EventArgs e)
        {
            CreateButtons();
        }

        private void AddLeftButtons(IOrderedEnumerable<ButtonInfo> buttons)
        {
            foreach (ButtonInfo buttonPosition in buttons)
            {
                Controls.Add(buttonPosition.Button);
            }
        }

        private void AddRightButtons(IOrderedEnumerable<ButtonInfo> buttons)
        {
            foreach (ButtonInfo buttonPosition in buttons)
            {
                Controls.Add(buttonPosition.Button);
            }
        }

        private void PositionLeftButtons(IOrderedEnumerable<ButtonInfo> buttons)
        {
            int x = this.Padding.Left;
            int y = this.Padding.Top;

            foreach (ButtonInfo buttonPosition in buttons)
            {
                buttonPosition.Button.Click += DialogButton_Click;

                buttonPosition.Button.Location = new Point(x, y);

                x += buttonPosition.Button.Width + DefaultButtonPadding;
            }
        }

        private void PositionRightButtons(IOrderedEnumerable<ButtonInfo> buttons)
        {
            int x = this.Width - this.Padding.Right;
            int y = this.Padding.Top;

            foreach (ButtonInfo buttonPosition in buttons)
            {
                buttonPosition.Button.Click += DialogButton_Click;

                x -= buttonPosition.Button.Width;

                buttonPosition.Button.Location = new Point(x, y);

                x -= DefaultButtonPadding;
            }
        }

        private void DialogButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            var formStateButton = _buttonSet.SequentialButtons.FirstOrDefault(b => b.Button == button);

            if (formStateButton.Button.Text == formStateButton.ButtonText[0] && formStateButton.Result != DialogResult.None)
            {
                OnDialogResultClicked(formStateButton.Result);
            }

            if (RaiseFormStateEvents)
            {
                if (formStateButton != null)
                {
                    switch (formStateButton.ButtonType)
                    {
                        case ButtonTypes.Ok:
                            break;
                        case ButtonTypes.Cancel:
                            break;
                        case ButtonTypes.Apply:
                            break;
                        case ButtonTypes.Yes:
                            break;
                        case ButtonTypes.No:
                            break;
                        case ButtonTypes.Save:
                            {
                                FormState = FormStates.SavingAndClosing;
                                break;
                            }
                        case ButtonTypes.Open:
                            break;
                        case ButtonTypes.Edit_Save:
                            {
                                if (button.Text == formStateButton.ButtonText[0])
                                {
                                    // edit button clicked
                                    FormState = FormStates.Editing;
                                }
                                else
                                {
                                    // save button clicked
                                    FormState = FormStates.Saving;
                                }
                                break;
                            }
                        case ButtonTypes.Delete:
                            {
                                FormState = FormStates.Deleting;
                                break;
                            }
                        case ButtonTypes.Copy:
                            {
                                FormState = FormStates.Copying;
                                break;
                            }
                        case ButtonTypes.Close:
                            break;
                        case ButtonTypes.New:
                            {
                                FormState = FormStates.Creating;
                                break;
                            }
                        case ButtonTypes.Close_Cancel:
                            {
                                if (button.Text == formStateButton.ButtonText[0])
                                {
                                    // close button clicked
                                    FormState = FormStates.Closing;
                                }
                                else
                                {
                                    // cancel button clicked
                                    FormState = FormStates.Cancelling;
                                }
                                break;
                            }
                        case ButtonTypes.Blank:
                            break;
                        case ButtonTypes.YesNo:
                            break;
                        case ButtonTypes.OkCancel:
                            break;
                        case ButtonTypes.OpenCancel:
                            break;
                        case ButtonTypes.SaveCancel:
                            break;
                        case ButtonTypes.EditForm:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Dialog_FormStateChanged(object sender, FormStateChangedEventArgs e)
        {
            if (!RaiseFormStateEvents)
                return;

            var editSaveButton = _buttonSet.SequentialButtons.FirstOrDefault(b => b.ButtonType == ButtonTypes.Edit_Save);
            var closeCancelButton = _buttonSet.SequentialButtons.FirstOrDefault(b => b.ButtonType == ButtonTypes.Close_Cancel);
            var newButton = _buttonSet.SequentialButtons.FirstOrDefault(b => b.ButtonType == ButtonTypes.New);
            var copyButton = _buttonSet.SequentialButtons.FirstOrDefault(b => b.ButtonType == ButtonTypes.Copy);
            var deleteButton = _buttonSet.SequentialButtons.FirstOrDefault(b => b.ButtonType == ButtonTypes.Delete);
            var saveAndCloseButton = _buttonSet.SequentialButtons.FirstOrDefault(b => b.ButtonType == ButtonTypes.SaveAndClose);

            var hasSelection = OnHasSelectionQuery();
            var hasChanges = OnHasChangesQuery();

            switch (e.State)
            {
                case FormStates.Loading:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[0];
                        editSaveButton.Button.Enabled = false;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[0];
                        closeCancelButton.Button.Enabled = false;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = false;
                        break;
                    }
                case FormStates.Ready:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[0];
                        editSaveButton.Button.Enabled = false;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[0];
                        closeCancelButton.Button.Enabled = true;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = hasChanges;

                        if (hasSelection)
                            FormState = FormStates.Viewing;
                        break;
                    }
                case FormStates.Viewing:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[0];
                        editSaveButton.Button.Enabled = true;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[0];
                        closeCancelButton.Button.Enabled = true;
                        newButton.Button.Enabled = true;
                        copyButton.Button.Enabled = true;
                        deleteButton.Button.Enabled = true;
                        saveAndCloseButton.Button.Visible = hasChanges;
                        break;
                    }
                case FormStates.Editing:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[1];
                        editSaveButton.Button.Enabled = true;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[1];
                        closeCancelButton.Button.Enabled = true;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = false;
                        break;
                    }
                case FormStates.Creating:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[1];
                        editSaveButton.Button.Enabled = true;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[1];
                        closeCancelButton.Button.Enabled = true;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = false;
                        break;
                    }
                case FormStates.Copying:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[1];
                        editSaveButton.Button.Enabled = true;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[1];
                        closeCancelButton.Button.Enabled = true;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = false;
                        break;
                    }
                case FormStates.Deleting:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[1];
                        editSaveButton.Button.Enabled = true;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[1];
                        closeCancelButton.Button.Enabled = true;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = false;
                        break;
                    }
                case FormStates.Saving:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[0];
                        editSaveButton.Button.Enabled = false;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[0];
                        closeCancelButton.Button.Enabled = false;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = false;

                        FormState = FormStates.Ready;
                        break;
                    }
                case FormStates.Cancelling:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[0];
                        editSaveButton.Button.Enabled = false;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[0];
                        closeCancelButton.Button.Enabled = false;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = false;
                        break;
                    }
                case FormStates.SavingAndClosing:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[0];
                        editSaveButton.Button.Enabled = false;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[0];
                        closeCancelButton.Button.Enabled = false;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = false;
                        break;
                    }
                case FormStates.Closing:
                    {
                        editSaveButton.Button.Text = editSaveButton.ButtonText[0];
                        editSaveButton.Button.Enabled = false;
                        closeCancelButton.Button.Text = closeCancelButton.ButtonText[0];
                        closeCancelButton.Button.Enabled = false;
                        newButton.Button.Enabled = false;
                        copyButton.Button.Enabled = false;
                        deleteButton.Button.Enabled = false;
                        saveAndCloseButton.Button.Visible = false;
                        break;
                    }
                default:
                    break;
            }
        }

        private void DialogButtons_StyleChanged(object sender, EventArgs e)
        {
            SetButtonPositions();
        }

        #endregion
    }
}
