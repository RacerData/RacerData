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
    public partial class ViewDesignerDialog2 : Form, IViewDesigner
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

        #endregion

        #region ctor/load

        public ViewDesignerDialog2()
        {
            InitializeComponent();
        }

        private void ViewDesignerDialog2_Load(object sender, EventArgs e)
        {
            _log = LogManager.GetLogger("View Designer");

            var step1 = new CreateViewWizard1();
            step1.DataSources = this.DataSources;
            step1.Log = _log;

            _wizardSteps.Add(0, step1);
            var step2 = new CreateViewWizard2();
            step2.Log = _log;

            _wizardSteps.Add(1, step2);

            var step3 = new CreateViewWizard3();
            step3.Log = _log;

            _wizardSteps.Add(2, step3);

            DisplayStepCaptions();

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
            label.Size = new System.Drawing.Size(150, 23);
            label.Text = step.Caption;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label.ForeColor = Color.Silver;

            return label;
        }

        protected virtual void ActivateWizardStep(int index)
        {
            try
            {
                object data = null;

                btnNext.DataBindings.Clear();
                lblError.DataBindings.Clear();

                foreach (var item in pnlStepBody.Controls.OfType<IWizardStep>().ToList())
                {
                    data = item.GetDataSource();
                    item.DeactivateStep();
                    pnlStepBody.Controls.Remove((Control)item);
                }

                var activeStep = _wizardSteps[index];

                Control activeControl = (Control)activeStep;
                activeControl.Dock = DockStyle.Fill;

                pnlStepBody.Controls.Add(activeControl);

                btnNext.DataBindings.Add(new Binding("Enabled", activeStep, "IsComplete"));
                lblError.DataBindings.Add(new Binding("Text", activeStep, "Error"));

                btnPrevious.Enabled = (index > 0);

                lblStepDetails.Text = activeStep.Details;

                UpdateStepCaptions(index);

                if (data != null)
                    activeStep.SetDataObject(data);

                activeStep.ActivateStep();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error changing steps", ex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_wizardIndex >= _wizardSteps.Count - 1)
                return;

            _wizardIndex++;

            ActivateWizardStep(_wizardIndex);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_wizardIndex == 0)
                return;

            _wizardIndex--;

            ActivateWizardStep(_wizardIndex);
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

    }
}
