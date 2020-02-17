﻿using System.Windows.Forms;
using static RacerData.iRacing.Sessions.Ui.TireSheet.TireSheetViewModel;

namespace RacerData.iRacing.Sessions.Ui.TireSheet
{
    public partial class GoodyearTireSheet : UserControl
    {
        #region properties

        public double TempWarning
        {
            get
            {
                return currentTireSheet.TempWarning;
            }
            set
            {
                currentTireSheet.TempWarning = value;
            }
        }
        public double WearWarning
        {
            get
            {
                return currentTireSheet.WearWarning;
            }
            set
            {
                currentTireSheet.WearWarning = value;
            }
        }

        public TireSheetValues CurrentModel
        {
            get
            {
                return currentTireSheet.Model;
            }
            set
            {
                currentTireSheet.Model = value;
            }
        }
        public TireSheetValues PreviousModel
        {
            get
            {
                return previousTireView.Model;
            }
            set
            {
                previousTireView.Model = value;
                previousTireView.DiffModel = CurrentModel;
                previousTireView.Visible = true;
            }
        }

        #endregion

        #region ctor

        public GoodyearTireSheet()
        {
            InitializeComponent();

            previousTireView.Visible = false;
        }

        #endregion
    }
}
