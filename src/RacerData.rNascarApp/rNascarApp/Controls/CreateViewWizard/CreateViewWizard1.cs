using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    public partial class CreateViewWizard1 : WizardStep
    {
        private TreeNode _selectedNode = null;

        private ViewDataSource _selectedDataSource = null;
        public ViewDataSource SelectedDataSource
        {
            get
            {
                return _selectedDataSource;
            }
            set
            {
                _selectedDataSource = value;
                OnPropertyChanged(nameof(SelectedDataSource));
            }
        }
        public IList<ViewDataSource> DataSources { get; set; }

        public CreateViewWizard1()
            : base()
        {
            InitializeComponent();

            Index = 0;
            Name = "Select Data Source";
            Caption = "Select the data source from the list to continue...";
            Details = "Select the NASCAR API feed to display in the view.";
            Error = String.Empty;
        }

        public override void ActivateStep()
        {
            base.ActivateStep();

            this.PropertyChanged += CreateViewWizard1_PropertyChanged;

            if (trvDataSources.Nodes.Count == 0)
                DisplayDataSources(DataSources);

            CanGoNext = ValidateStep();
            CanGoPrevious = false;

            trvDataSources.Focus();
        }

        private void CreateViewWizard1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedDataSource))
                CanGoNext = ValidateStep();
        }

        public override object GetDataSource()
        {
            return SelectedDataSource;
        }

        public override void SetDataObject(object data)
        {

        }

        public override void DeactivateStep()
        {
            base.DeactivateStep();

            this.PropertyChanged -= CreateViewWizard1_PropertyChanged;
        }

        public override bool ValidateStep()
        {
            bool isValid = true;
            Error = "";

            if (DataSources == null)
            {
                isValid = false;
                Error += "Data sources empty\r\n";
            }
            else if (DataSources.Count == 0)
            {
                isValid = false;
                Error += "No data sources\r\n";
            }
            else if (SelectedDataSource == null)
            {
                isValid = false;
                Error += "No data source selected\r\n";
            }
            return isValid;
        }

        private void CreateViewWizard1_Load(object sender, EventArgs e)
        {
            lblCaption.Text = Caption;
        }

        protected virtual void DisplayDataSources(IList<ViewDataSource> dataSources)
        {
            trvDataSources.Nodes.Clear();

            foreach (ViewDataSource dataSource in dataSources)
            {
                var dataSourceNode = new TreeNode(dataSource.Caption)
                {
                    Tag = dataSource
                };

                int baseIdx = 10;
                int imageIndex = 0;

                switch (dataSource.Name)
                {
                    case "LiveFeedData":
                        {
                            imageIndex = baseIdx + 1;
                            break;
                        }
                    case "LivePitData[]":
                        {
                            imageIndex = baseIdx + 2;
                            break;
                        }
                    case "LiveFlagData[]":
                        {
                            imageIndex = baseIdx + 3;
                            break;
                        }
                    case "LivePointsData[]":
                        {
                            imageIndex = baseIdx + 4;
                            break;
                        }
                    case "LiveQualifyingData[]":
                        {
                            imageIndex = baseIdx + 5;
                            break;
                        }
                }
                dataSourceNode.ImageIndex = imageIndex;
                dataSourceNode.SelectedImageIndex = imageIndex;

                trvDataSources.Nodes.Add(dataSourceNode);
            }
        }

        private void trvDataSources_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
                return;

            if (e.Node.Tag is ViewDataSource)
            {
                SelectedDataSource = (ViewDataSource)e.Node.Tag;
                _selectedNode = e.Node;
            }
        }
    }
}
