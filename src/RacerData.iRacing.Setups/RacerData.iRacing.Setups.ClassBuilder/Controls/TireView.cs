using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.iRacing.Setups.ClassBuilder.Models;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class TireView : UserControl
    {
        #region fields

        public bool _loaded = false;
        private static Color WarningOnColor = Color.OrangeRed;
        private static Color WarningOffColor = Color.White;


        #endregion

        #region properties

        private TirePosition _position;
        public TirePosition Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;

                string positionName = "";

                switch (_position)
                {
                    case TirePosition.LeftFront:
                        {
                            positionName = "Left Front";
                            break;
                        }
                    case TirePosition.LeftRear:
                        {
                            positionName = "Left Rear";
                            break;
                        }
                    case TirePosition.RightFront:
                        {
                            positionName = "Right Front";
                            break;
                        }
                    case TirePosition.RightRear:
                        {
                            positionName = "Right Rear";
                            break;
                        }
                }

                lblPosition.Text = positionName;
            }
        }

        private TireViewModel _model;
        public TireViewModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                if (_loaded)
                {
                    DisplayModel(_model);
                }
            }
        }

        private bool _tempWarning = false;
        public bool TempWarning
        {
            get
            {
                return _tempWarning;
            }
            set
            {
                _tempWarning = value;
                if (_loaded)
                {
                    UpdateTempWarning(_tempWarning);
                }
            }
        }

        private bool _wearWarning = false;
        public bool WearWarning
        {
            get
            {
                return _wearWarning;
            }
            set
            {
                _wearWarning = value;
                if (_loaded)
                {
                    UpdateWearWarning(_wearWarning);
                }
            }
        }

        #endregion

        #region ctor

        public TireView()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message);
        }

        protected virtual void DisplayModel(TireViewModel model)
        {
            if (Position != model.Position)
            {
                throw new ArgumentException($"Attempting to display values for incorrect position: {model.Position.ToString()}");
            }

            if (model.Position == TirePosition.LeftFront || model.Position == TirePosition.LeftRear)
            {
                lblRightTemp.Text = model.Temperatures.Inside.ToString();
                lblMiddleTemp.Text = model.Temperatures.Middle.ToString();
                lblLeftTemp.Text = model.Temperatures.Outside.ToString();

                lblRightWear.Text = model.Wear.Inside.ToString();
                lblMiddleWear.Text = model.Wear.Middle.ToString();
                lblLeftWear.Text = model.Wear.Outside.ToString();
            }
            else if (model.Position == TirePosition.RightFront || model.Position == TirePosition.RightRear)
            {
                lblLeftTemp.Text = model.Temperatures.Inside.ToString();
                lblMiddleTemp.Text = model.Temperatures.Middle.ToString();
                lblRightTemp.Text = model.Temperatures.Outside.ToString();

                lblLeftWear.Text = model.Wear.Inside.ToString();
                lblMiddleWear.Text = model.Wear.Middle.ToString();
                lblRightWear.Text = model.Wear.Outside.ToString();
            }

            lblColdPsi.Text = model.ColdPsi.ToString();
            lblHotPsi.Text = model.HotPsi.ToString();
            lblDeltaPsi.Text = model.DeltaPsi.ToString();
        }

        protected virtual void UpdateTempWarning(bool warningOn)
        {
            if (warningOn)
            {
                lblLeftTemp.BackColor = WarningOnColor;
                lblMiddleTemp.BackColor = WarningOnColor;
                lblRightTemp.BackColor = WarningOnColor;
            }
            else
            {
                lblLeftTemp.BackColor = WarningOffColor;
                lblMiddleTemp.BackColor = WarningOffColor;
                lblRightTemp.BackColor = WarningOffColor;
            }
        }

        protected virtual void UpdateWearWarning(bool warningOn)
        {
            if (warningOn)
            {
                lblLeftWear.BackColor = WarningOnColor;
                lblMiddleWear.BackColor = WarningOnColor;
                lblRightWear.BackColor = WarningOnColor;
            }
            else
            {
                lblLeftWear.BackColor = WarningOffColor;
                lblMiddleWear.BackColor = WarningOffColor;
                lblRightWear.BackColor = WarningOffColor;
            }
        }

        #endregion

        #region private

        private void LeftTireView_Load(object sender, EventArgs e)
        {
            try
            {
                if (Model != null)
                {
                    DisplayModel(Model);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
            finally
            {
                _loaded = true;
            }
        }

        #endregion
    }
}
