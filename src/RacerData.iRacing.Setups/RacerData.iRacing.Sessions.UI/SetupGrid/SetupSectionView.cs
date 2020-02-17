using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RacerData.iRacing.Extensions;
using static RacerData.iRacing.Sessions.Ui.ViewModels.SetupGridViewModel;

namespace RacerData.iRacing.Sessions.Ui.SetupGrid
{
    public partial class SetupSectionView : UserControl
    {
        private SetupSectionViewModel _viewModel;
        public SetupSectionViewModel ViewModel
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

        public SetupSectionView()
        {
            InitializeComponent();

            ClearDisplay();
        }

        public SetupSectionView(string title)
            : this()
        {
            lblSectionName.Text = GetTitle(title);
        }

        private void _viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ClearDisplay();

            if (ViewModel != null)
                DisplayViewModel(ViewModel);
        }

        private void ClearDisplay()
        {
            lblSectionName.Text = "";

            SetupValuesListView.Items.Clear();
        }

        private void DisplayViewModel(SetupSectionViewModel viewModel)
        {
            lblSectionName.Text = GetTitle(viewModel.SectionName);

            foreach (SetupValueViewModel setupValue in viewModel.SetupValues.OrderBy(v => v.DisplayIndex))
            {
                ListViewItem lvi = new ListViewItem
                    (
                        new string[]
                        {
                            setupValue.Property.SplitWords(),
                            setupValue.Value,
                            setupValue.PreviousValue,
                            setupValue.Delta
                        }
                    );

                lvi.Tag = setupValue;

                SetupValuesListView.Items.Add(lvi);
            }

            int totalWidth = 0;
            foreach (ColumnHeader col in SetupValuesListView.Columns)
            {
                totalWidth += col.Width;
            }
            var viewHeight = lblSectionName.Height + (SetupValuesListView.Items.Count * 20) + 4;
            if (SetupValuesListView.HeaderStyle != ColumnHeaderStyle.None)
            {
                viewHeight += 25;
            }
            this.Height = viewHeight;

            this.Width = totalWidth + 4;
        }

        private string GetTitle(string value)
        {
            return (value.IndexOf('.') > 0 ? value.Split('.')[1] : value).SplitWords();
        }
    }
}
