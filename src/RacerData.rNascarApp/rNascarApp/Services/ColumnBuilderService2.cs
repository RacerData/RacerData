using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp.Services
{
    internal class ColumnBuilderService2 : IColumnBuilderService
    {
        #region public

        public void BuildGridColumns(
         ListDefinition listDefinition,
         Control.ControlCollection headerControls,
         Control.ControlCollection rowControls)
        {
            BuildGridColumns(listDefinition, headerControls, rowControls, null);
        }

        public void BuildGridColumns(
            ListDefinition listDefinition,
            Control.ControlCollection headerControls,
            Control.ControlCollection rowControls,
            Theme theme)
        {
            ClearControlCollection(headerControls);
            ClearControlCollection(rowControls);

            var baseHeaderHeight = listDefinition.RowHeight.HasValue ? listDefinition.RowHeight.Value : headerControls.Owner.Height;

            headerControls.Owner.Height = listDefinition.MultilineHeader ? baseHeaderHeight * 2 : baseHeaderHeight;
            rowControls.Owner.Height = baseHeaderHeight;

            if (!listDefinition.RowHeight.HasValue)
                listDefinition.RowHeight = baseHeaderHeight;

            var columnIndex = 0;

            foreach (ListColumn column in listDefinition.OrderedColumns)
            {
                if (column.Index != columnIndex)
                    column.Index = columnIndex;

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

                columnIndex++;
            }

            foreach (Label captionLabel in headerControls.OfType<Label>())
            {
                Bitmap stringLengthBitmap = new Bitmap(1, 1);
                SizeF stringSize = new SizeF();
                using (Graphics g = Graphics.FromImage(stringLengthBitmap))
                {
                    stringSize = g.MeasureString(captionLabel.Text, captionLabel.Font);
                }

                if (stringSize.Width > (captionLabel.Width - 4) &&
                    listDefinition.MultilineHeader == false &&
                    listDefinition.RowHeight.HasValue)
                {
                    listDefinition.MultilineHeader = true;
                    headerControls.Owner.Height = listDefinition.RowHeight.Value * 2;
                }
                else if (stringSize.Width < (captionLabel.Width + 4) &&
                    listDefinition.MultilineHeader == true &&
                    listDefinition.RowHeight.HasValue)
                {
                    headerControls.Owner.Height = listDefinition.RowHeight.Value;
                }
            }

            if (headerControls.Owner is Panel && theme != null)
            {
                ApplyTheme(
                  (Panel)headerControls.Owner,
                  (Panel)rowControls.Owner,
                  theme);
            }

            if (headerControls != null)
                AlignControls(headerControls, listDefinition.FillColumnIndex);

            if (rowControls != null)
                AlignControls(rowControls, listDefinition.FillColumnIndex);
        }

        public void AlignControls(Control.ControlCollection controls, int? fillColumnIndex)
        {
            try
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
            catch (System.Exception ex)
            {
                throw new System.Exception($"Error aligning columns: {ex.Message}", ex);
            }
        }

        public Label BuildColumnLabel(ListColumn column, bool isHeader = false)
        {
            var columnLabel = new Label()
            {
                Name = isHeader ?
                    $"lbl{column.DataMember}Caption" :
                    $"lbl{column.DataMember}",
                Text = isHeader ?
                    column.Caption :
                    FieldFormatService.FormatValue(column.ConvertedType, column.Format, column.Sample),
                TextAlign = column.Alignment,
                AutoSize = false,
                BorderStyle = column.HasBorder ? BorderStyle.FixedSingle : BorderStyle.None,
                Margin = new Padding(0, 0, 0, 0),
                Tag = column
            };

            if (column.Width.HasValue)
                columnLabel.Size = new Size(column.Width.Value, columnLabel.Height == 0 ? 24 : columnLabel.Height);

            return columnLabel;
        }

        private void ClearControlCollection(Control.ControlCollection controls)
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

        #endregion

        #region protected

        protected void ApplyTheme(
            Panel pnlCaptions,
            Panel pnlFields,
            Theme theme)
        {
            if (theme == null)
                return;

            pnlCaptions.BackColor = theme.GridColumnHeaderBackColor;
            pnlCaptions.ForeColor = theme.GridColumnHeaderForeColor;
            pnlCaptions.Font = theme.GridColumnHeaderFont;

            pnlFields.BackColor = theme.PrimaryBackColor;
            pnlFields.ForeColor = theme.PrimaryForeColor;
            pnlFields.Font = theme.GridFont;
        }

        #endregion
    }
}
