using System;
using System.ComponentModel;
using System.Windows.Forms;
using RacerData.iRacing.Extensions;
using RacerData.iRacing.Setups.ClassBuilder.Models;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class SetupRearView : UserControl, INotifyPropertyChanged
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

        private SetupRearModel _setup1 = new SetupRearModel();
        public SetupRearModel Setup1
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

        private SetupRearModel _setup2 = new SetupRearModel();
        public SetupRearModel Setup2
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

        private SetupRearModel _setupDiff = new SetupRearModel();
        public SetupRearModel SetupDiff
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

        public SetupRearView()
        {
            InitializeComponent();

            this.PropertyChanged += SetupRearView_PropertyChanged;
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

        protected virtual void SetupRearView_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
            lblGear0.Text = "";
            lblFuel0.Text = "";
            lblStagger0.Text = "";
        }

        protected virtual void ClearSetup2()
        {
            lblGear1.Text = "";
            lblFuel1.Text = "";
            lblStagger1.Text = "";
        }

        protected virtual void ClearSetupDiff()
        {
            lblGearDiff.Text = "";
            lblFuelDiff.Text = "";
            lblStaggerDiff.Text = "";
        }

        protected virtual void DisplaySetup1(SetupRearModel setup)
        {
            if (setup == null)
                return;

            lblGear0.Text = Math.Round(setup.Gear, 2).ToString();
            lblFuel0.Text = Math.Round(setup.Fuel, 2).ToString();
            lblStagger0.Text = setup.Stagger.NearestEighth().ToString();
        }

        protected virtual void DisplaySetup2(SetupRearModel setup)
        {
            if (setup == null)
                return;

            lblGear1.Text = Math.Round(setup.Gear, 2).ToString();
            lblFuel1.Text = Math.Round(setup.Fuel, 2).ToString();
            lblStagger1.Text = setup.Stagger.NearestEighth().ToString();
        }

        protected virtual void DisplaySetupDiff(SetupRearModel setup)
        {
            if (setup == null)
                return;

            lblGearDiff.Text = GetDiffDisplayValue(setup.Gear);
            lblFuelDiff.Text = GetDiffDisplayValue(setup.Fuel);
            lblStaggerDiff.Text = GetDiffDisplayValue(setup.Stagger);
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
