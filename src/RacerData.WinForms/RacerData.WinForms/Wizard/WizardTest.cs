using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RacerData.WinForms.Controls.Wizard
{
    public partial class WizardTest : Form
    {
        IDictionary<string, WizardStepControl<TestContext>> _controls = new Dictionary<string, WizardStepControl<TestContext>>();

        public WizardController<TestContext> Controller { get; set; }

        public WizardTest()
        {
            InitializeComponent();
        }

        private void WizardTest_Load(object sender, EventArgs e)
        {
            try
            {
                SetBindings();

                Controller.PropertyChanged += Controller_PropertyChanged;

                Controller.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Controller_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == nameof(Controller.CurrentStep))
                {
                    SetWizardControl(Controller.CurrentStep);
                }
                else if (e.PropertyName == nameof(Controller.StepIndex))
                {
                    SetCurrentStepIndex(Controller.StepIndex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void SetBindings()
        {
            try
            {
                MoveNextButton.DataBindings.Add("Enabled", Controller, "CanGoNext");
                MovePreviousButton.DataBindings.Add("Enabled", Controller, "CanGoBack");

                SetStepList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void SetStepList()
        {
            lstSteps.DataSource = null;
            lstSteps.DisplayMember = "Title";
            lstSteps.DataSource = Controller.Steps.ToList();
            lstSteps.SelectedIndex = 0;
        }

        public void SetCurrentStepIndex(int index)
        {
            lstSteps.SelectedIndex = index;
        }

        private void lstSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HelpTextLabel.Text = "";
                DescriptionLabel.Text = "";
                TitleLabel.Text = "";

                if (lstSteps.SelectedItem == null)
                    return;

                IWizardStepInfo selectedStep = (IWizardStepInfo)lstSteps.SelectedItem;

                HelpTextLabel.Text = selectedStep.HelpText;
                DescriptionLabel.Text = selectedStep.Description;
                TitleLabel.Text = selectedStep.Title;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void SetWizardControl(IWizardStep<TestContext> currentStep)
        {
            try
            {
                foreach (var wizardStepControl in WizardStepPanel.Controls.OfType<WizardStepControl<TestContext>>().ToList())
                {
                    WizardStepPanel.Controls.Remove(wizardStepControl);
                }

                var key = $"Step{currentStep.Index}";

                WizardStepControl<TestContext> control = null;

                if (!_controls.ContainsKey(key))
                {
                    control = (WizardStepControl<TestContext>)Activator.CreateInstance(currentStep.WizardStepControlType);
                    _controls.Add(key, control);
                    control.WizardStep = currentStep;
                }
                else
                {
                    control = _controls[key];
                }

                control.Dock = DockStyle.Fill;

                this.WizardStepPanel.Controls.Add(control);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void SaveAndCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MoveNextButton_Click(object sender, EventArgs e)
        {
            Controller.Next();
        }

        private void MovePreviousButton_Click(object sender, EventArgs e)
        {
            Controller.Back();
        }
    }
}
