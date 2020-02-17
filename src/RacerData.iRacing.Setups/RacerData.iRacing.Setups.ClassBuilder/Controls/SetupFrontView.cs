using System;
using System.ComponentModel;
using System.Windows.Forms;
using RacerData.iRacing.Extensions;
using RacerData.iRacing.Setups.ClassBuilder.Models;

namespace RacerData.iRacing.Setups.ClassBuilder.Controls
{
    public partial class SetupFrontView : UserControl, INotifyPropertyChanged
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

        private SetupFrontModel _setup1 = new SetupFrontModel();
        public SetupFrontModel Setup1
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

        private SetupFrontModel _setup2 = new SetupFrontModel();
        public SetupFrontModel Setup2
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

        private SetupFrontModel _setupDiff = new SetupFrontModel();
        public SetupFrontModel SetupDiff
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

        public SetupFrontView()
        {
            InitializeComponent();

            this.PropertyChanged += SetupFrontView_PropertyChanged;
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

        protected virtual void SetupFrontView_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
            lblBallast0.Text = "";
            lblFront0.Text = "";
            lblCross0.Text = "";
            lblToe0.Text = "";
            lblSwayBar0.Text = "";
            lblPreload0.Text = "";
            lblStagger0.Text = "";
        }

        protected virtual void ClearSetup2()
        {
            lblBallast1.Text = "";
            lblFront1.Text = "";
            lblCross1.Text = "";
            lblToe1.Text = "";
            lblSwayBar1.Text = "";
            lblPreload1.Text = "";
            lblStagger1.Text = "";
        }

        protected virtual void ClearSetupDiff()
        {
            lblBallastDiff.Text = "";
            lblFrontDiff.Text = "";
            lblCrossDiff.Text = "";
            lblToeDiff.Text = "";
            lblSwayBarDiff.Text = "";
            lblPreloadDiff.Text = "";
            lblStaggerDiff.Text = "";
        }

        protected virtual void DisplaySetup1(SetupFrontModel setup)
        {
            if (setup == null)
                return;

            lblBallast0.Text = setup.Ballast.ToString();
            lblFront0.Text = Math.Round(setup.Front, 2).ToString();
            lblCross0.Text = Math.Round(setup.Cross, 2).ToString();
            lblToe0.Text = setup.Toe.NearestSixteenthAsFraction();
            lblSwayBar0.Text = setup.SwayBar.NearestEighth().ToString();
            lblPreload0.Text = setup.Preload.NearestSixteenthAsFraction();
            lblStagger0.Text = setup.Stagger.NearestEighth().ToString();
        }

        protected virtual void DisplaySetup2(SetupFrontModel setup)
        {
            if (setup == null)
                return;

            lblBallast1.Text = setup.Ballast.ToString();
            lblFront1.Text = Math.Round(setup.Front, 2).ToString();
            lblCross1.Text = Math.Round(setup.Cross, 2).ToString();
            lblToe1.Text = setup.Toe.NearestSixteenthAsFraction();
            lblSwayBar1.Text = setup.SwayBar.NearestEighth().ToString();
            lblPreload1.Text = setup.Preload.NearestSixteenthAsFraction();
            lblStagger1.Text = setup.Stagger.NearestEighth().ToString();
        }

        protected virtual void DisplaySetupDiff(SetupFrontModel setup)
        {
            if (setup == null)
                return;

            lblBallastDiff.Text = GetDiffDisplayValue(setup.Ballast);
            lblFrontDiff.Text = GetDiffDisplayValue(setup.Front);
            lblCrossDiff.Text = GetDiffDisplayValue(setup.Cross);
            lblToeDiff.Text = setup.Toe == 0 ?
                String.Empty :
                setup.Toe.NearestSixteenthAsFraction();
            lblSwayBarDiff.Text = GetDiffDisplayValue(setup.SwayBar);
            lblPreloadDiff.Text = setup.Preload == 0 ?
                String.Empty :
                setup.Preload.NearestSixteenthAsFraction();
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

        //protected virtual void DiffModels()
        //{
        //    ClearModelDiff();

        //    if (Setup1 != null && Setup2 != null)
        //    {
        //        lblBallastDiff.Text = Setup1.Ballast == Setup2.Ballast ? "" : (Setup2.Ballast - Setup1.Ballast).ToString();
        //        lblFrontDiff.Text = Setup1.Front == Setup2.Front ? "" : Math.Round(Setup2.Front - Setup1.Front, 2).ToString();
        //        lblCrossDiff.Text = Setup1.Cross == Setup2.Cross ? "" : Math.Round(Setup2.Cross - Setup1.Cross, 2).ToString();
        //        lblToeDiff.Text = Setup1.Toe.NearestSixteenth() == Setup2.Toe.NearestSixteenth() ? "" : (Setup2.Toe.NearestSixteenth() - Setup1.Toe.NearestSixteenth()).NearestSixteenthAsFraction();
        //        lblSwayBarDiff.Text = Setup1.SwayBar.NearestEighth() == Setup2.SwayBar.NearestEighth() ? "" : (Setup2.SwayBar.NearestEighth() - Setup1.SwayBar.NearestEighth()).ToString();
        //        lblPreloadDiff.Text = Setup1.Preload.NearestSixteenth() == Setup2.Preload.NearestSixteenth() ? "" : (Setup2.Preload.NearestSixteenth() - Setup1.Preload.NearestSixteenth()).NearestSixteenthAsFraction();
        //        lblStaggerDiff.Text = Setup1.Stagger.NearestEighth() == Setup2.Stagger.NearestEighth() ? "" : (Setup2.Stagger.NearestEighth() - Setup1.Stagger.NearestEighth()).ToString();
        //    }
        //}

        #endregion
    }
}
