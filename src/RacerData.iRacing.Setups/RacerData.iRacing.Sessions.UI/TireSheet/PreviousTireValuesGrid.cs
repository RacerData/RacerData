using System;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.iRacing.Sessions.Ui.TireSheet
{
    public partial class PreviousTireValuesGrid : UserControl
    {
        #region fields

        private static Color WarningOnColor = Color.OrangeRed;
        private static Color WarningOffColor = Color.White;

        #endregion

        #region properties

        public TirePosition Position { get; set; }

        public double LeftValue { get; private set; }
        public double MiddleValue { get; private set; }
        public double RightValue { get; private set; }
        public double EffectiveValue { get; private set; }
        public double DiffValue { get; private set; }

        private bool _warning = false;
        public bool Warning
        {
            get
            {
                return _warning;
            }
            set
            {
                _warning = value;
                UpdateWarning(_warning);
            }
        }

        #endregion

        #region ctor

        public PreviousTireValuesGrid()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void DisplayValues(double left, double middle, double right, double effective, double diff)
        {
            LeftValue = left;
            MiddleValue = middle;
            RightValue = right;
            EffectiveValue = effective;
            DiffValue = diff;

            DisplayModel();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        protected virtual void DisplayModel()
        {
            lblRight.Text = $"{Math.Round(RightValue, 1)}";
            lblMiddle.Text = $"{Math.Round(MiddleValue, 1)}";
            lblLeft.Text = $"{Math.Round(LeftValue, 1)}";

            lblEffective.Text = $"{Math.Round(EffectiveValue, 1)}";
            lblDiff.Text = $"{EffectiveValue - DiffValue}";
        }

        protected virtual void UpdateWarning(bool warningOn)
        {
            if (warningOn)
            {
                lblLeft.BackColor = WarningOnColor;
                lblMiddle.BackColor = WarningOnColor;
                lblRight.BackColor = WarningOnColor;
            }
            else
            {
                lblLeft.BackColor = WarningOffColor;
                lblMiddle.BackColor = WarningOffColor;
                lblRight.BackColor = WarningOffColor;
            }
        }

        #endregion

        #region private

        private void LeftTireView_Load(object sender, EventArgs e)
        {
            try
            {
                DisplayModel();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion
    }
}
