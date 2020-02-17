using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RacerData.iRacing.Sessions.Ui.ViewModels;
using static RacerData.iRacing.Sessions.Ui.ViewModels.SetupGridViewModel;

namespace RacerData.iRacing.Sessions.Ui.SetupGrid
{
    public partial class SetupGridView : UserControl
    {
        private IDictionary<string, SetupSectionView> _views = new Dictionary<string, SetupSectionView>();

        private SetupGridViewModel _viewModel;
        public SetupGridViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                if (_viewModel != null)
                {
                    _viewModel.PropertyChanged -= _viewModel_PropertyChanged;
                }
                _viewModel = value;

                if (_viewModel != null)
                {
                    _viewModel.PropertyChanged += _viewModel_PropertyChanged;
                    DisplayViewModel(_viewModel);
                }
            }
        }

        public bool HasFrontArb { get; set; }
        public SetupGridView()
        {
            InitializeComponent();
        }

        private void SetupView_Load(object sender, EventArgs e)
        {
            ClearDisplay();

            LodViews();
        }

        private void _viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ViewModel != null)
                DisplayViewModel(ViewModel);
        }

        private void LodViews()
        {
            BuildView("Chassis.Front", tblSetupSections, 0, 0);
            BuildView("Chassis.FrontArb", tblSetupSections, 0, 1);
            BuildView("Chassis.LeftFront", tblFront, 0, 0);
            BuildView("Chassis.RightFront", tblFront, 1, 0);
            BuildView("Chassis.LeftRear", tblRear, 0, 0);
            BuildView("Chassis.RightRear", tblRear, 1, 0);
            BuildView("Chassis.Rear", tblSetupSections, 0, 4);

            _views["Chassis.FrontArb"].Visible = HasFrontArb;
        }

        private SetupSectionView BuildView(string key, TableLayoutPanel table, int column, int row)
        {
            var view = new SetupSectionView(key);

            if (key.Contains(".Left"))
            {
                view.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            }
            else if (key.Contains(".Right"))
            {
                view.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            }
            else
            {
                view.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            }

            _views.Add(key, view);

            table.Controls.Add(view);
            table.SetCellPosition(view, new TableLayoutPanelCellPosition(column, row));

            return view;
        }

        private void ClearDisplay()
        {
            lblSetup.Text = "";
            lblPreviousSetup.Text = "";
        }

        private void DisplayViewModel(SetupGridViewModel viewModel)
        {
            lblSetup.Text = viewModel.SetupName;
            lblPreviousSetup.Text = viewModel.PreviousSetupName;

            _views["Chassis.FrontArb"].Visible = viewModel.SetupSections.Any(s => s.SectionKey.Contains("FrontArb"));

            foreach (SetupSectionViewModel setupSectionViewModel in viewModel.SetupSections)
            {
                if (_views.ContainsKey(setupSectionViewModel.SectionKey))
                    _views[setupSectionViewModel.SectionKey].ViewModel = setupSectionViewModel;
            }
        }
    }
}
