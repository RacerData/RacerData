using System.Drawing;
using System.Windows.Forms;
using rNascarApp.UI.Models;

namespace rNascarApp.UI.Controls
{
    public partial class StaticViewField : UserControl
    {
        #region consts

        private const int StartingX = 8;
        private const int StartingY = 8;
        private const int ControlSpacing = 8;
        private const string CaptionControlName = "ctrlCaption";
        private const string ValueControlName = "ctrlValue";

        #endregion

        #region properties

        private StaticField _field;
        public StaticField Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;
                DisplayField(_field);
            }
        }

        #endregion

        #region ctor

        public StaticViewField()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void DisplayField(StaticField field)
        {
            ClearControls();

            if (field == null)
                return;

            this.SuspendLayout();

            try
            {
                this.Location = new Point(field.X, field.Y);
                this.Size = new Size(field.Width, field.Height);

                int runningX = StartingX;
                int runningY = StartingY;

                Label captionLabel = null;

                if (field.ShowCaption)
                {
                    captionLabel = GetCaptionControl(field.Name, runningX, runningY, field.Alignment);

                    if (field.CaptionAlignment == CaptionAlignment.Above)
                    {
                        captionLabel.Dock = DockStyle.Top;
                        runningY += captionLabel.Height + ControlSpacing;
                    }
                    else if (field.CaptionAlignment == CaptionAlignment.Left)
                    {
                        captionLabel.Dock = DockStyle.Left;
                        runningX += captionLabel.Width + ControlSpacing;
                    }
                }

                var valueTextBox = GetValueControl(runningX, runningY, field.Alignment);
                valueTextBox.Dock = field.CaptionAlignment == CaptionAlignment.Above ? DockStyle.Top : DockStyle.Left;

                Controls.Add(valueTextBox);

                if (captionLabel != null)
                    Controls.Add(captionLabel);
            }
            finally
            {
                this.ResumeLayout(false);
            }
        }

        protected virtual void ClearControls()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                var control = this.Controls[i];
                this.Controls.RemoveAt(i);
                control.Dispose();
            }
        }

        protected virtual Label GetCaptionControl(string caption, int x, int y, Models.ContentAlignment alignment)
        {
            return new Label()
            {
                Name = CaptionControlName,
                Text = caption,
                Location = new Point(x, y),
                AutoSize = false,
                TextAlign = (System.Drawing.ContentAlignment)alignment,
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        protected virtual Label GetValueControl(int x, int y, Models.ContentAlignment alignment)
        {
            return new Label()
            {
                Name = ValueControlName,
                Location = new Point(x, y),
                AutoSize = false,
                TextAlign = (System.Drawing.ContentAlignment)alignment,
                BackColor = Color.Silver,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        #endregion
    }
}
