using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using log4net;
using RacerData.rNascarApp.Controls;
using RacerData.rNascarApp.Controls.CreateViewWizard;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class CreateViewWizard : Form, IViewDesigner
    {
        #region consts

        private const int NoFormatImageIndex = 3;
        private const int ClosedFolderImageIndex = 4;
        private const int OpenFolderImageIndex = 5;

        #endregion

        #region fields

        private ILog _log { get; set; }
        private int _wizardIndex = 0;
        private IDictionary<int, IWizardStep> _wizardSteps = new Dictionary<int, IWizardStep>();

        #endregion

        #region properties

        public Guid? ViewStateId { get; set; }
        public IList<Theme> Themes { get; set; }
        public IList<ViewDataSource> DataSources { get; set; } = new List<ViewDataSource>();
        public IList<ViewState> ViewStates { get; set; } = new List<ViewState>();
        public DisplayFormatMapService MapService { get; set; }

        public CreateViewContext Context { get; set; }

        public ViewState ViewState { get; set; }

        #endregion

        #region ctor/load

        public CreateViewWizard()
        {
            InitializeComponent();
        }

        private void ViewDesignerDialog2_Load(object sender, EventArgs e)
        {
            _log = LogManager.GetLogger("View Designer");

            var step1 = new CreateViewWizard1();
            step1.DataSources = this.DataSources;
            step1.AdvanceStepRequest += (s, a) =>
            {
                AdvanceStep();
            };
            step1.Log = _log;

            _wizardSteps.Add(0, step1);
            var step2 = new CreateViewWizard2();
            step2.Log = _log;

            _wizardSteps.Add(1, step2);

            var step3 = new CreateViewWizard3();
            step3.Log = _log;

            _wizardSteps.Add(2, step3);

            var step4 = new CreateViewWizard4();
            step4.Log = _log;

            _wizardSteps.Add(3, step4);

            step4.PropertyChanged += WizardLastStep_PropertyChanged;
            DisplayStepCaptions();

            if (Context != null && Context.IsEditing == true)
            {
                _wizardIndex = 2;
            }

            ActivateWizardStep(_wizardIndex);
        }

        #endregion

        #region protected

        protected virtual void DisplayStepCaptions()
        {
            pnlStepCaptions.Controls.Clear();

            foreach (var item in _wizardSteps)
            {
                var label = GetStepLabel(item.Value);
                pnlStepCaptions.Controls.Add(label);
            }
        }

        protected virtual void UpdateStepCaptions(int index)
        {
            foreach (var item in pnlStepCaptions.Controls.OfType<Label>())
            {
                item.ForeColor = Color.Silver;
            }

            pnlStepCaptions.Controls[index].ForeColor = Color.Black;
        }

        protected virtual Label GetStepLabel(IWizardStep step)
        {
            Label label = new Label();

            label.Location = new System.Drawing.Point(11, 8);
            label.Name = "lblStepCaption" + step.Name;
            label.Size = new Size(pnlStepCaptions.Width, (int)((pnlStepCaptions.Height * .75) / _wizardSteps.Count));
            label.Text = $"{step.Index + 1}.  {step.Name}";
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.ForeColor = Color.Silver;

            return label;
        }

        protected virtual void ActivateWizardStep(int index)
        {
            try
            {
                btnNext.DataBindings.Clear();
                btnPrevious.DataBindings.Clear();
                lblError.DataBindings.Clear();

                foreach (var item in pnlStepBody.Controls.OfType<IWizardStep>().ToList())
                {
                    item.DeactivateStep();
                    pnlStepBody.Controls.Remove((Control)item);
                }

                var activeStep = _wizardSteps[index];

                Control activeControl = (Control)activeStep;

                activeControl.Dock = DockStyle.Fill;

                pnlStepBody.Controls.Add(activeControl);

                btnPrevious.DataBindings.Add(new Binding("Enabled", activeStep, "CanGoPrevious"));
                btnNext.DataBindings.Add(new Binding("Enabled", activeStep, "CanGoNext"));
                lblError.DataBindings.Add(new Binding("Text", activeStep, "Error"));

                btnPrevious.Enabled = (index > 0);

                lblStepDetails.Text = activeStep.Details;

                UpdateStepCaptions(index);

                if (Context != null && Context.IsEditing == true && index == 2)
                {
                    activeStep.SetDataObject(Context);
                }

                activeStep.ActivateStep();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error changing steps", ex);
            }
        }

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            _log?.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            MessageBox.Show($"{message}: {ex.Message}");
        }

        #endregion

        #region private

        private void btnNext_Click(object sender, EventArgs e)
        {
            AdvanceStep();
        }

        private void AdvanceStep()
        {
            if (_wizardIndex >= _wizardSteps.Count - 1)
                return;

            _wizardIndex++;

            ActivateWizardStep(_wizardIndex);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            BackStep();
        }

        private void BackStep()
        {
            if (_wizardIndex == 0)
                return;

            _wizardIndex--;

            ActivateWizardStep(_wizardIndex);
        }

        private void WizardLastStep_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsComplete")
            {
                IWizardStep lastStep = (WizardStep)sender;
                var context = lastStep.GetDataSource();
                ViewState = context.ViewState;

                DialogResult = DialogResult.OK;
            }
        }

        #endregion
    }
}
