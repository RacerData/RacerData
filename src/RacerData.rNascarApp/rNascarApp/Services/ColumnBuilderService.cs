using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Services
{
    internal class ColumnBuilderService
    {
        public static void BuildGridColumns(
            ListSettings listSettings,
            Control.ControlCollection headerControls,
            Control.ControlCollection rowControls)
        {
            ClearControlCollection(headerControls);
            ClearControlCollection(rowControls);

            foreach (ListColumn column in listSettings.OrderedColumns)
            {
                if (headerControls != null)
                {
                    var columnHeaderLabel = BuildColumnLabel(column, true);
                    headerControls.Add(columnHeaderLabel);
                }

                if (rowControls != null)
                {
                    var columnRowLabel = BuildColumnLabel(column);
                    rowControls.Add(columnRowLabel);
                }
            }

            if (headerControls != null)
                AlignControls(headerControls, listSettings.FillColumnIndex);

            if (rowControls != null)
                AlignControls(rowControls, listSettings.FillColumnIndex);
        }

        public static void AlignControls(Control.ControlCollection controls, int? fillColumnIndex)
        {
            ListColumn[] columns = new ListColumn[controls.OfType<Label>().Count()];
            Label[] labels = new Label[controls.OfType<Label>().Count()];
            
            foreach (Label label in controls.OfType<Label>())
            {
                if (label.Tag != null && label.Tag is ListColumn)
                {
                    ListColumn column = (ListColumn)label.Tag;
                    columns[column.Index] = column;
                    labels[column.Index] = label;
                }
            }

            // set the dock styles
            for (int idx = 0; idx < controls.Count; idx++)
            {
                var label = controls.OfType<Label>().FirstOrDefault(c => c.Tag != null && c.Tag is ListColumn && ((ListColumn)c.Tag).Index == idx);

                if (fillColumnIndex.HasValue)
                {
                    if (idx < fillColumnIndex.Value)
                    {
                        label.Dock = DockStyle.Left;
                        label.BringToFront();
                    }
                    else if (idx > fillColumnIndex.Value)
                    {
                        label.Dock = DockStyle.Right;
                        label.SendToBack();
                    }
                }
                else
                {
                    label.Dock = DockStyle.Left;
                    label.BringToFront();
                }
            }

            if (fillColumnIndex.HasValue)
            {
                var label = controls.OfType<Label>().FirstOrDefault(c => c.Tag != null && c.Tag is ListColumn && ((ListColumn)c.Tag).Index == fillColumnIndex.Value);

                label.Dock = DockStyle.Fill;
                label.BringToFront();
            }
        }

        public static void AlignControls(IList<Label> controls, int? fillColumnIndex)
        {
            foreach (Label label in controls)
            {
                label.Dock = DockStyle.None;
            }

            ListColumn[] columns = new ListColumn[controls.Count()];
            Label[] labels = new Label[controls.Count()]; int cIdx = 0;
            foreach (Label label in controls)
            {
                if (label.Tag != null && label.Tag is ListColumn)
                {
                    ListColumn column = (ListColumn)label.Tag;
                    columns[cIdx] = column;
                    labels[cIdx] = label;
                }
            }

            // set the dock styles
            for (int idx = 0; idx < controls.Count; idx++)
            {
                var label = controls.FirstOrDefault(c => c.Tag != null && c.Tag is ListColumn && ((ListColumn)c.Tag).Index == idx);

                if (fillColumnIndex.HasValue)
                {
                    if (idx < fillColumnIndex.Value)
                    {
                        label.Dock = DockStyle.Left;
                        label.BringToFront();
                    }
                    else if (fillColumnIndex.Value == idx)
                    {

                    }
                    else if (idx > fillColumnIndex.Value)
                    {
                        label.Dock = DockStyle.Right;
                        label.SendToBack();
                    }
                }
                else
                {
                    label.Dock = DockStyle.Left;
                    label.BringToFront();
                }
            }

            // position the labels
            //for (int idx = 0; idx < controls.Count; idx++)
            //{
            //    var label = controls.OfType<Label>().FirstOrDefault(c => c.Tag != null && c.Tag is ListColumn && ((ListColumn)c.Tag).Index == idx);

            //    if (fillColumnIndex.HasValue)
            //    {
            //        if (fillColumnIndex.Value < idx)
            //        {
            //            label.BringToFront();
            //        }
            //        else if (fillColumnIndex.Value > idx)
            //        {
            //            label.SendToBack();
            //        }
            //    }
            //    else
            //    {
            //        label.BringToFront();
            //    }
            //}

            if (fillColumnIndex.HasValue)
            {
                var label = controls.FirstOrDefault(c => c.Tag != null && c.Tag is ListColumn && ((ListColumn)c.Tag).Index == fillColumnIndex.Value);

                label.Dock = DockStyle.Fill;
                label.BringToFront();
            }

            //if (fillColumnIndex.HasValue)
            //{
            //    for (int i = 0; i < fillColumnIndex.Value; i++)
            //    {
            //        controls[i].Dock = DockStyle.Left;
            //    }

            //    for (int i = fillColumnIndex.Value + 1; i < controls.Count; i++)
            //    {
            //        controls[i].Dock = DockStyle.Right;
            //    }

            //    controls[fillColumnIndex.Value].Dock = DockStyle.Fill;
            //    controls[fillColumnIndex.Value].BringToFront();
            //}
            //else
            //{
            //    for (int i = controls.Count - 1; i >= 0; i--)
            //    {
            //        if (i == 0)
            //        {
            //            controls[i].Dock = DockStyle.Left;
            //        }
            //        else
            //        {
            //            controls[i].Dock = DockStyle.Right;
            //        }

            //        controls[0].Dock = DockStyle.Fill;
            //        controls[0].BringToFront();
            //    }
            //}

        }
        public static Label BuildColumnLabel(ListColumn column, bool isHeader = false)
        {
            var columnLabel = new Label()
            {
                Name = isHeader ?
                    $"lbl{column.DataMember}Caption" :
                    $"lbl{column.DataMember}",
                Text = isHeader ?
                    column.Caption :
                    string.Empty,
                TextAlign = column.Alignment,
                AutoSize = false,
                BackColor = Color.FromKnownColor(KnownColor.Control),
                BorderStyle = column.HasBorder ? BorderStyle.FixedSingle : BorderStyle.None,
                Margin = new Padding(0, 0, 0, 0),
                Tag = column
            };

            if (column.Width.HasValue)
                columnLabel.Size = new Size(column.Width.Value, columnLabel.Height == 0 ? 24 : columnLabel.Height);

            return columnLabel;
        }

        private static void ClearControlCollection(Control.ControlCollection controls)
        {
            if (controls == null)
                return;

            for (int i = controls.Count - 1; i >= 0; i--)
            {
                var control = controls[i];
                controls.RemoveAt(i);
                control.Dispose();
            }
        }
    }
}
