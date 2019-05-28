using System;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Dialogs
{
    public partial class EditorBase : Form
    {
        #region ctor

        public EditorBase()
        {
            InitializeComponent();

            dialogButtons1.HasSelectionQuery += DialogHasSelectionQuery;
            dialogButtons1.HasChangesQuery += DialogHasChangesQuery;

            dialogButtons1.RaiseFormStateEvents = dialogButtons1.ButtonTypes == ButtonTypes.EditForm;
        }

        #endregion

        #region protected

        /// <summary>
        /// For Edit Forms, set hasChanges=true if there are pending changes to be saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="hasSelection"></param>
        protected virtual void DialogHasChangesQuery(object sender, ref bool hasChanges)
        {

        }

        /// <summary>
        /// For Edit Forms, set hasSelection=true if the main selection control has a selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="hasSelection"></param>
        protected virtual void DialogHasSelectionQuery(object sender, ref bool hasSelection)
        {

        }

        /// <summary>
        /// Fires after the form state changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DialogStateChanged(object sender, Events.FormStateChangedEventArgs e)
        {

        }

        /// <summary>
        /// Fires before the form state changes.
        /// User can cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DialogStateChanging(object sender, Events.FormStateChangingEventArgs e)
        {

        }

        /// <summary>
        /// Sets the DialogResult of the form. 
        /// Override to perform any pre-close processing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DialogResultClicked(object sender, Events.DialogResultEventArgs e)
        {
            this.DialogResult = e.Result;
        }

        /// <summary>
        /// Set FormState to Ready if overriding this method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void EditorBase_Load(object sender, EventArgs e)
        {
            dialogButtons1.FormState = Models.FormStates.Ready;
        }

        protected virtual void ItemSelected()
        {
            dialogButtons1.FormState = FormStates.Viewing;
        }

        #endregion
    }
}
