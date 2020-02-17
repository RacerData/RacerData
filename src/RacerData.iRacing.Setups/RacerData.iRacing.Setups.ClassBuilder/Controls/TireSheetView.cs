using System;
using System.Windows.Forms;
using RacerData.iRacing.Setups.ClassBuilder.Models;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class TireSheetView : UserControl
    {
        #region fields

        public bool _loaded = false;

        #endregion

        #region properties

        private TireSheetValues _model;
        public TireSheetValues Model
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

        #endregion

        #region ctor

        public TireSheetView()
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

        protected virtual void DisplayModel(TireSheetValues model)
        {
            lfTireView.Model = model.Tires[TirePosition.LeftFront];
            lrTireView.Model = model.Tires[TirePosition.LeftRear];
            rfTireView.Model = model.Tires[TirePosition.RightFront];
            rrTireView.Model = model.Tires[TirePosition.RightRear];

            lblLeftTempDelta.Text = model.LeftTempDelta.ToString();
            lblLeftWearDelta.Text = model.LeftWearDelta.ToString();
            lblLeftPsiDelta.Text = model.LeftPsiDelta.ToString();
            lblLeftPsiGainDelta.Text = model.LeftPsiGainDelta.ToString();

            lblRightTempDelta.Text = model.RightTempDelta.ToString();
            lblRightWearDelta.Text = model.RightWearDelta.ToString();
            lblRightPsiDelta.Text = model.RightPsiDelta.ToString();
            lblRightPsiGainDelta.Text = model.RightPsiGainDelta.ToString();

            lfTireView.TempWarning = model.LeftTempDelta < -2;
            lrTireView.TempWarning = model.LeftTempDelta > 2;

            rfTireView.TempWarning = model.RightTempDelta < -2;
            rrTireView.TempWarning = model.RightTempDelta > 2;
        }

        #endregion

        #region private

        private void TireSheetView_Load(object sender, EventArgs e)
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
