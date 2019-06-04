using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Models;
using ContentAlignment = RacerData.WinForms.Models.ContentAlignment;

namespace RacerData.WinForms.Controls
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

        #region fields

        private Label _valueControl = new Label();

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

        public string Value
        {
            get
            {
                return _valueControl.Text;
            }
            set
            {
                _valueControl.Text = value;
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

                Label captionControl = null;

                if (field.ShowCaption)
                {
                    captionControl = GetCaptionControl(field.Name, runningX, runningY, field.Alignment);

                    if (field.CaptionAlignment == CaptionAlignment.Above)
                    {
                        captionControl.Dock = DockStyle.Top;
                        runningY += captionControl.Height + ControlSpacing;
                    }
                    else if (field.CaptionAlignment == CaptionAlignment.Left)
                    {
                        captionControl.Dock = DockStyle.Left;
                        runningX += captionControl.Width + ControlSpacing;
                    }
                }

                _valueControl = GetValueControl(runningX, runningY, field.Alignment);
                _valueControl.Dock = field.CaptionAlignment == CaptionAlignment.Above ? DockStyle.Top : DockStyle.Left;

                Controls.Add(_valueControl);

                if (captionControl != null)
                    Controls.Add(captionControl);
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

        protected virtual Label GetCaptionControl(string caption, int x, int y, ContentAlignment alignment)
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

        protected virtual Label GetValueControl(int x, int y, ContentAlignment alignment)
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
