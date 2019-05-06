﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class DisplayFormatMapDialog : Form
    {
        #region consts

        private const int NoFormatImageIndex = 3;
        private const int ClosedFolderImageIndex = 4;
        private const int OpenFolderImageIndex = 5;

        #endregion

        #region fields

        private ILog _log { get; set; }
        private bool _isEditMode = false;

        #endregion

        #region properties

        public IList<ViewDataSource> DataSources { get; set; } = new List<ViewDataSource>();
        public DisplayFormatMapService MapService { get; set; }

        #endregion

        #region ctor/load

        public DisplayFormatMapDialog()
        {
            InitializeComponent();
        }

        private void DisplayFormatMapDialog_Load(object sender, EventArgs e)
        {
            _log = LogManager.GetLogger("Display Format Map Dialog");

            DisplayDataSources(DataSources);

            LoadDisplayFormats(MapService.DisplayFormats);
        }

        #endregion

        #region public

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            _log?.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            MessageBox.Show($"{message}: {ex.Message}");
        }

        protected virtual void LoadDisplayFormats(IList<ViewDisplayFormat> displayFormats)
        {
            lstDisplayFormats.DataSource = null;
            lstDisplayFormats.DisplayMember = "Name";
            lstDisplayFormats.DataSource = displayFormats;
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

                BuildDataSourceTreeView(dataSourceNode, dataSource);

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

        protected virtual void BuildDataSourceTreeView(TreeNode dataSourceNode, ViewDataSource dataSource)
        {
            foreach (ViewDataMember field in dataSource.Fields)
            {
                var fieldNode = new TreeNode(field.Caption);

                var mapItem = new DataFormatMapItem()
                {
                    DataMember = field
                };

                if (MapService.Map.ContainsKey(field))
                {
                    mapItem.DisplayFormat = MapService.Map[field];
                }

                fieldNode.Tag = mapItem;

                UpdateNodeState(fieldNode, mapItem.DisplayFormat);

                dataSourceNode.Nodes.Add(fieldNode);
            }

            foreach (ViewDataSource dataList in dataSource.Lists)
            {
                var listNode = new TreeNode(dataList.Caption + "[]")
                {
                    Tag = dataList,
                    ImageIndex = ClosedFolderImageIndex,
                    SelectedImageIndex = ClosedFolderImageIndex,

                };

                BuildDataSourceTreeView(listNode, dataList);

                dataSourceNode.Nodes.Add(listNode);
            }

            foreach (ViewDataSource dataList in dataSource.NestedClasses)
            {
                var listNode = new TreeNode(dataList.Caption)
                {
                    Tag = dataList,
                    ImageIndex = ClosedFolderImageIndex,
                    SelectedImageIndex = ClosedFolderImageIndex,
                };

                BuildDataSourceTreeView(listNode, dataList);

                dataSourceNode.Nodes.Add(listNode);
            }
        }

        #endregion

        #region private

        private void trvDataSources_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            UpdateMapPanelState();
        }

        private void lstDisplayFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMapPanelState();

            ViewDisplayFormat format = (ViewDisplayFormat)lstDisplayFormats.SelectedItem;

            DisplayFormat(format);

            UpdateUsedByList(format);
        }

        private void UpdateUsedByList(ViewDisplayFormat format)
        {
            lstUsedBy.Items.Clear();

            if (format == null)
                return;

            foreach (var item in MapService.Map.Where(m => m.Value.Name == format.Name))
            {
                lstUsedBy.Items.Add(item.Key.Caption);
            }
        }

        private void UpdateMapPanelState()
        {
            btnSetFormat.Enabled = (
                trvDataSources.SelectedNode != null &&
                lstDisplayFormats.SelectedItem != null);

            btnClearFormat.Enabled = (
                trvDataSources.SelectedNode != null &&
                trvDataSources.SelectedNode.Tag is DataFormatMapItem &&
                ((DataFormatMapItem)trvDataSources.SelectedNode.Tag).DisplayFormat != null &&
                lstDisplayFormats.SelectedItem != null);

            grpDisplayFormat.Enabled = false;
        }

        private void trvDataSources_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataSourceSelected(e.Node);
        }

        private void trvDataSources_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            NodeExpansionChanged(e.Node, true);
        }

        private void NodeExpansionChanged(TreeNode node, bool isExpanding)
        {
            if (node.ImageIndex > ClosedFolderImageIndex)
                return;

            if (node.Tag is ViewDataSource)
            {
                if (!isExpanding)
                {
                    node.ImageIndex = OpenFolderImageIndex;
                    node.SelectedImageIndex = OpenFolderImageIndex;
                }
                else
                {
                    node.ImageIndex = ClosedFolderImageIndex;
                    node.SelectedImageIndex = ClosedFolderImageIndex;
                }
            }
        }

        private void trvDataSources_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            NodeExpansionChanged(e.Node, false);
        }

        private void DataSourceSelected(TreeNode dataSourceNode)
        {
            if (dataSourceNode.Tag == null)
            {
                lstDisplayFormats.SelectedIndex = -1;
            }
            else if (dataSourceNode.Tag is ViewDataSource)
            {
                lstDisplayFormats.SelectedIndex = -1;
            }
            else if (dataSourceNode.Tag is DataFormatMapItem)
            {
                var mapItem = (DataFormatMapItem)dataSourceNode.Tag;

                if (mapItem.DisplayFormat != null)
                {
                    lstDisplayFormats.SelectedIndex = lstDisplayFormats.FindStringExact(mapItem.DisplayFormat.Name);
                }
                else
                {
                    lstDisplayFormats.SelectedIndex = -1;
                }

                DisplayMember(mapItem.DataMember);
            }
        }

        private void btnClearFormat_Click(object sender, EventArgs e)
        {
            ClearSelectedDataFormat();
        }

        private void ClearSelectedDataFormat()
        {
            if (trvDataSources.SelectedNode == null)
                return;

            var node = trvDataSources.SelectedNode;

            var mapItem = (DataFormatMapItem)node.Tag;

            mapItem.DisplayFormat = null;

            UpdateNodeState(node, null);

            btnClearFormat.Enabled = false;

            MapService.Map.Remove(mapItem.DataMember);
        }

        private void btnSetFormat_Click(object sender, EventArgs e)
        {
            SetSelectedDataFormat();
        }

        private void SetSelectedDataFormat()
        {
            if (trvDataSources.SelectedNode == null)
                return;

            if (lstDisplayFormats.SelectedItem == null)
                return;

            var node = trvDataSources.SelectedNode;

            var mapItem = (DataFormatMapItem)node.Tag;

            var selectedFormat = (ViewDisplayFormat)lstDisplayFormats.SelectedItem;

            mapItem.DisplayFormat = selectedFormat;

            UpdateNodeState(node, selectedFormat);

            btnClearFormat.Enabled = true;

            if (MapService.Map.ContainsKey(mapItem.DataMember))
            {
                MapService.Map[mapItem.DataMember] = mapItem.DisplayFormat;
            }
            else
            {
                MapService.Map.Add(mapItem.DataMember, mapItem.DisplayFormat);
            }

            UpdateUsedByList(selectedFormat);
        }

        private void UpdateNodeState(TreeNode node, ViewDisplayFormat format)
        {
            int imageIndex;

            if (format == null)
            {
                imageIndex = NoFormatImageIndex;
            }
            else
            {
                imageIndex = (int)format.Alignment;
            }

            node.ImageIndex = imageIndex;
            node.SelectedImageIndex = imageIndex;
        }

        private void btnNewFormat_Click(object sender, EventArgs e)
        {
            if (btnNewFormat.Text == "Save")
            {
                if (_isEditMode)
                    SaveEditedFormat();
                else
                    SaveNewFormat();
            }
            else
            {
                BeginNewFormat();
            }
        }

        private void btnCancelNewFormat_Click(object sender, EventArgs e)
        {
            CancelNewFormat();
        }

        private void BeginNewFormat()
        {
            ClearFormatDisplay();

            btnNewFormat.Text = "Save";
            btnClearFormat.Enabled = false;
            btnSetFormat.Enabled = false;
            btnCancelNewFormat.Visible = true;
            trvDataSources.Enabled = false;
            lstDisplayFormats.Enabled = false;

            lblDfMaxWidth.Visible = true;
            txtDfMaxWidth.Visible = true;

            grpDisplayFormat.Enabled = true;

            _isEditMode = false;
        }

        private void SaveEditedFormat()
        {
            btnNewFormat.Text = "New Format";
            btnClearFormat.Enabled = false;
            btnSetFormat.Enabled = false;
            btnCancelNewFormat.Visible = false;
            grpDisplayFormat.Enabled = false;
            trvDataSources.Enabled = true;
            lstDisplayFormats.Enabled = true;

            ViewDisplayFormat format = (ViewDisplayFormat)lstDisplayFormats.SelectedItem;

            var originalName = format.Name;

            format.Name = txtDfName.Text;
            format.Format = txtDfFormat.Text;
            format.Alignment = rbLeft.Checked ? HorizontalAlignment.Left : rbCenter.Checked ? HorizontalAlignment.Center : HorizontalAlignment.Right;
            int maxWidth;
            if (Int32.TryParse(txtDfMaxWidth.Text, out maxWidth))
            {
                format.MaxWidth = maxWidth;
            }

            ClearFormatDisplay();

            LoadDisplayFormats(MapService.DisplayFormats);

            lstDisplayFormats.SelectedIndex = -1;

            lstDisplayFormats.SelectedItem = format;

            _isEditMode = false;

            foreach (var item in MapService.Map.Where(v => v.Value.Name == originalName).ToList())
            {
                MapService.Map[item.Key] = format;
            }

            DisplayDataSources(DataSources);
        }

        private void SaveNewFormat()
        {
            btnNewFormat.Text = "New Format";
            btnClearFormat.Enabled = false;
            btnSetFormat.Enabled = false;
            btnCancelNewFormat.Visible = false;
            grpDisplayFormat.Enabled = false;
            trvDataSources.Enabled = true;
            lstDisplayFormats.Enabled = true;

            ViewDisplayFormat format = null;

            if (string.IsNullOrEmpty(txtDfMaxWidth.Text))
            {
                format = new ViewDisplayFormat()
                {
                    Name = txtDfName.Text,
                    Format = txtDfFormat.Text,
                    Alignment = rbLeft.Checked ? HorizontalAlignment.Left : rbCenter.Checked ? HorizontalAlignment.Center : HorizontalAlignment.Right
                };
            }
            else
            {
                format = new ViewDisplayFormat()
                {
                    Name = txtDfName.Text,
                    Format = txtDfFormat.Text,
                    Alignment = rbLeft.Checked ? HorizontalAlignment.Left : rbCenter.Checked ? HorizontalAlignment.Center : HorizontalAlignment.Right
                };

                int maxWidth;
                if (Int32.TryParse(txtDfMaxWidth.Text, out maxWidth))
                {
                    format.MaxWidth = maxWidth;
                }
            }

            MapService.DisplayFormats.Add(format);

            ClearFormatDisplay();

            LoadDisplayFormats(MapService.DisplayFormats);

            lstDisplayFormats.SelectedItem = format;
        }

        private void CancelNewFormat()
        {
            btnNewFormat.Text = "New Format";
            btnClearFormat.Enabled = true;
            btnSetFormat.Enabled = true;
            btnCancelNewFormat.Visible = false;
            grpDisplayFormat.Enabled = false;
            trvDataSources.Enabled = true;
            lstDisplayFormats.Enabled = true;

            lstDisplayFormats.SelectedIndex = -1;

            UpdateMapPanelState();

            _isEditMode = false;
        }

        private void DisplayFormat(ViewDisplayFormat format)
        {
            ClearFormatDisplay();

            if (format == null)
                return;

            txtDfName.Text = format.Name;
            txtDfFormat.Text = format.Format;

            rbLeft.Checked = (format.Alignment == HorizontalAlignment.Left);
            rbCenter.Checked = (format.Alignment == HorizontalAlignment.Center);
            rbRight.Checked = (format.Alignment == HorizontalAlignment.Right);

            txtDfMaxWidth.Text = format.MaxWidth.ToString();
        }

        private void ClearFormatDisplay()
        {
            txtDfName.Clear();
            txtDfFormat.Clear();
            rbLeft.Checked = true;
            rbCenter.Checked = false;
            rbRight.Checked = false;
            txtDfMaxWidth.Clear();
        }

        private void ClearMemberDisplay()
        {
            lblDsField.Text = "";
            lblDsType.Text = "";
        }

        private void DisplayMember(ViewDataMember member)
        {
            ClearMemberDisplay();

            if (member == null)
                return;

            lblDsField.Text = member.Name;
            lblDsType.Text = member.Type;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveMap();
            MessageBox.Show("Changes saved");
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            SaveMap();
            DialogResult = DialogResult.OK;
        }

        private void SaveMap()
        {
            MapService.Save();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstDisplayFormats.SelectedItem == null)
                return;

            BeginEditFormat((ViewDisplayFormat)lstDisplayFormats.SelectedItem);
        }

        private void BeginEditFormat(ViewDisplayFormat format)
        {
            ClearFormatDisplay();

            btnNewFormat.Text = "Save";
            btnClearFormat.Enabled = false;
            btnSetFormat.Enabled = false;
            btnCancelNewFormat.Visible = true;
            trvDataSources.Enabled = false;
            lstDisplayFormats.Enabled = false;

            lblDfMaxWidth.Visible = true;
            txtDfMaxWidth.Visible = true;

            grpDisplayFormat.Enabled = true;

            DisplayFormat(format);

            _isEditMode = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstDisplayFormats.SelectedItem == null)
                return;

            DeleteFormat((ViewDisplayFormat)lstDisplayFormats.SelectedItem);
        }

        private void DeleteFormat(ViewDisplayFormat format)
        {
            foreach (var item in MapService.Map.Where(v => v.Value.Name == format.Name).ToList())
            {
                MapService.Map.Remove(item);
            }

            MapService.DisplayFormats.Remove(format);

            LoadDisplayFormats(MapService.DisplayFormats);

            DisplayDataSources(DataSources);
        }
        #endregion
    }
}
