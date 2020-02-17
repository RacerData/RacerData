using System;
using System.ComponentModel;
using System.Windows.Forms;
using RacerData.iRacing.Extensions;
using RacerData.iRacing.Setups.ClassBuilder.Models;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class SetupRearCornerView : UserControl, INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

        public string Caption
        {
            get
            {
                return lblCaption.Text;
            }
            set
            {
                lblCaption.Text = value;
            }
        }

        private SetupRearCornerModel _setup1 = new SetupRearCornerModel();
        public SetupRearCornerModel Setup1
        {
            get
            {
                return _setup1;
            }
            set
            {
                _setup1 = value;
                OnPropertyChanged(nameof(Setup1));
            }
        }

        private SetupRearCornerModel _setup2 = new SetupRearCornerModel();
        public SetupRearCornerModel Setup2
        {
            get
            {
                return _setup2;
            }
            set
            {
                _setup2 = value;
                OnPropertyChanged(nameof(Setup2));
            }
        }

        private SetupRearCornerModel _setupDiff = new SetupRearCornerModel();
        public SetupRearCornerModel SetupDiff
        {
            get
            {
                return _setupDiff;
            }
            set
            {
                _setupDiff = value;
                OnPropertyChanged(nameof(SetupDiff));
            }
        }

        #endregion

        #region ctor

        public SetupRearCornerView()
        {
            InitializeComponent();

            this.PropertyChanged += SetupRearCornerView_PropertyChanged;
        }

        #endregion

        #region public

        public void ClearDisplay()
        {
            ClearSetup1();
            ClearSetup2();
            ClearSetupDiff();
        }

        #endregion

        #region protected

        protected virtual void SetupRearCornerView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Setup1))
            {
                ClearSetup1();
                ClearSetup2();
                ClearSetupDiff();
                DisplaySetup1(Setup1);
            }
            else if (e.PropertyName == nameof(Setup2))
            {
                ClearSetup2();
                ClearSetupDiff();
                DisplaySetup2(Setup2);
            }
            else if (e.PropertyName == nameof(SetupDiff))
            {
                ClearSetupDiff();
                DisplaySetupDiff(SetupDiff);
            }
        }

        protected virtual void ClearSetup1()
        {
            lblPsi0.Text = "";
            lblWeight0.Text = "";
            lblCollar0.Text = "";
            lblHeight0.Text = "";
            lblRebound0.Text = "";
            lblTrackBar0.Text = "";
            lblSpring0.Text = "";
        }

        protected virtual void ClearSetup2()
        {
            lblPsi1.Text = "";
            lblWeight1.Text = "";
            lblCollar1.Text = "";
            lblHeight1.Text = "";
            lblRebound1.Text = "";
            lblTrackBar1.Text = "";
            lblSpring1.Text = "";
        }

        protected virtual void ClearSetupDiff()
        {
            lblPsiDiff.Text = "";
            lblWeightDiff.Text = "";
            lblCollarDiff.Text = "";
            lblHeightDiff.Text = "";
            lblReboundDiff.Text = "";
            lblTrackBarDiff.Text = "";
            lblSpringDiff.Text = "";
        }

        protected virtual void DisplaySetup1(SetupRearCornerModel setup)
        {

            if (setup == null)
                return;

            lblPsi0.Text = setup.Psi.NearestHalf().ToString();
            lblWeight0.Text = Math.Round(setup.Weight, 0).ToString();
            lblCollar0.Text = Math.Round(setup.Collar, 3).ToString();
            lblHeight0.Text = Math.Round(setup.Height, 3).ToString();
            lblRebound0.Text = Math.Round(setup.Rebound, 0).ToString();
            lblTrackBar0.Text = setup.TrackBar.NearestQuarter().ToString();
            lblSpring0.Text = setup.Spring.NearestTwentyFive().ToString();
        }

        protected virtual void DisplaySetup2(SetupRearCornerModel setup)
        {
            ClearSetup2();
            ClearSetupDiff();

            if (setup == null)
                return;

            lblPsi1.Text = setup.Psi.NearestHalf().ToString();
            lblWeight1.Text = Math.Round(setup.Weight, 0).ToString();
            lblCollar1.Text = Math.Round(setup.Collar, 3).ToString();
            lblHeight1.Text = Math.Round(setup.Height, 3).ToString();
            lblRebound1.Text = Math.Round(setup.Rebound, 0).ToString();
            lblTrackBar1.Text = setup.TrackBar.NearestQuarter().ToString();
            lblSpring1.Text = setup.Spring.NearestTwentyFive().ToString();
        }

        protected virtual void DisplaySetupDiff(SetupRearCornerModel setup)
        {
            if (setup == null)
                return;

            lblPsiDiff.Text = GetDiffDisplayValue(setup.Psi);
            lblWeightDiff.Text = GetDiffDisplayValue(setup.Weight);
            lblCollarDiff.Text = GetDiffDisplayValue(setup.Collar);
            lblHeightDiff.Text = GetDiffDisplayValue(setup.Height);
            lblReboundDiff.Text = GetDiffDisplayValue(setup.Rebound);
            lblTrackBarDiff.Text = GetDiffDisplayValue(setup.TrackBar);
            lblSpringDiff.Text = GetDiffDisplayValue(setup.Spring);
        }

        protected virtual string GetDiffDisplayValue(int value)
        {
            return GetDiffDisplayValue((double)value);
        }
        protected virtual string GetDiffDisplayValue(double value)
        {
            if (value != 0)
                return value.ToString();
            else
                return String.Empty;
        }

        #endregion
    }
}
