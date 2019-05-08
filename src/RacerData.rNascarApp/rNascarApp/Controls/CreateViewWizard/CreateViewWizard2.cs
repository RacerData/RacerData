﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    public partial class CreateViewWizard2 : WizardStep
    {
        #region fields

        private BindingList<ViewDataMember> _selectedDataMembers;

        #endregion

        #region properties

        private ViewDataSource _dataSource = null;
        public ViewDataSource DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                if (_dataSource != null && _dataSource.Name != value.Name)
                {
                    _selectedDataMembers = new BindingList<ViewDataMember>();
                }

                _dataSource = value;
                OnPropertyChanged(nameof(DataSource));
            }
        }

        #endregion

        #region ctor/load

        public CreateViewWizard2()
            : base()
        {
            InitializeComponent();

            Index = 1;
            Name = "Select Fields";
            Caption = "Add columns to the view from the fields in the data source";
            Details = "Select the specific fields from the data source to display in the view.";
            Error = String.Empty;
        }

        private void CreateViewWizard2_Load(object sender, EventArgs e)
        {
            lblCaption.Text = Caption;

            _selectedDataMembers = new BindingList<ViewDataMember>();

            lstSelected.DisplayMember = "Caption";
            lstSelected.DataSource = _selectedDataMembers;
        }

        #endregion

        #region public

        public override object GetDataSource()
        {
            return _selectedDataMembers.ToList();
        }

        public override void SetDataObject(object data)
        {
            if (data is ViewDataSource)
                DataSource = (ViewDataSource)data;
        }

        public override void ActivateStep()
        {
            base.ActivateStep();

            DisplayDataSource(DataSource);

            _selectedDataMembers.ListChanged += SelectedDataMembers_ListChanged;

            UpdateValidation();
        }

        public override void DeactivateStep()
        {
            base.DeactivateStep();

            _selectedDataMembers.ListChanged -= SelectedDataMembers_ListChanged;
        }

        public override bool ValidateStep()
        {
            bool isValid = true;
            Error = "";

            if (DataSource == null)
            {
                isValid = false;
                Error += "Data source empty\r\n";
            }
            else if (_selectedDataMembers.Count == 0)
            {
                isValid = false;
                Error += "No fields selected\r\n";
            }

            return isValid;
        }

        #endregion

        #region protected

        protected virtual void UpdateValidation()
        {
            CanGoPrevious = true;
            CanGoNext = ValidateStep();
        }

        protected virtual void DisplayDataSource(ViewDataSource dataSource)
        {
            trvDataSources.Nodes.Clear();

            var dataSourceNode = new TreeNode(dataSource.Caption)
            {
                Tag = dataSource
            };

            BuildDataSourceTreeView(dataSourceNode, dataSource, "");

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

            trvDataSources.ExpandAll();

            trvDataSources.SelectedNode = dataSourceNode;
        }

        protected virtual void BuildDataSourceTreeView(TreeNode dataSourceNode, ViewDataSource dataSource, string path)
        {
            foreach (ViewDataMember field in dataSource.Fields)
            {
                var fieldNode = new TreeNode(field.Caption);

                field.DataFeed = dataSource.Name;
                field.Path = $"{path}{field.Name}";
                var mapItem = new DataFormatMapItem()
                {
                    DataMember = field,
                };

                fieldNode.Tag = mapItem;

                dataSourceNode.Nodes.Add(fieldNode);
            }

            foreach (ViewDataSource dataList in dataSource.Lists)
            {
                var dataListPath = $"{path}{dataList.Caption}[]\\";
                var listNode = new TreeNode(dataList.Caption + "[]")
                {
                    Tag = dataList
                };

                BuildDataSourceTreeView(listNode, dataList, dataListPath);

                dataSourceNode.Nodes.Add(listNode);
            }

            foreach (ViewDataSource dataList in dataSource.NestedClasses)
            {
                var dataListPath = $"{path}{dataList.Caption}\\";
                var listNode = new TreeNode(dataList.Caption)
                {
                    Tag = dataList
                };

                BuildDataSourceTreeView(listNode, dataList, dataListPath);

                dataSourceNode.Nodes.Add(listNode);
            }
        }

        #endregion

        #region private

        private void SelectedDataMembers_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateValidation();
        }

        private void trvDataSources_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnAdd.Enabled = (trvDataSources.SelectedNode != null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddField();
        }

        private void lstSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = (lstSelected.SelectedItem != null);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedItem == null)
                return;

            var member = (ViewDataMember)lstSelected.SelectedItem;

            if (_selectedDataMembers.Contains(member))
                _selectedDataMembers.Remove(member);
        }

        private void trvDataSources_DoubleClick(object sender, EventArgs e)
        {
            AddField();
        }

        private void AddField()
        {
            if (trvDataSources.SelectedNode == null)
                return;

            if (!(trvDataSources.SelectedNode.Tag is DataFormatMapItem))
                return;

            var member = ((DataFormatMapItem)trvDataSources.SelectedNode.Tag).DataMember;

            TreeNode root = trvDataSources.Nodes[0];
            ViewDataSource data = (ViewDataSource)root.Tag;

            member.DataFeed = data.Name;

            member.Path = trvDataSources.SelectedNode.FullPath.Replace($"{trvDataSources.Nodes[0].FullPath}\\", "");
            member.Path = member.Path.Replace(member.Caption, member.Name);

            if (!_selectedDataMembers.Contains(member))
                _selectedDataMembers.Add(member);
        }

        #endregion
    }
}
