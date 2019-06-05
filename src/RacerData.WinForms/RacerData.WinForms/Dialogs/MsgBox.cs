using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Dialogs
{
    public partial class MsgBox : DialogBase, IRacerDataDialog
    {
        #region properties

        public string Title { get; set; }
        public string Message { get; set; }
        public MsgIcon MessageIcon { get; set; }

        #endregion

        #region ctor

        public MsgBox(string title, string message, ButtonTypes buttonTypes)
           : this()
        {
            Title = title;
            Message = message;
            DialogType = buttonTypes;
        }

        public MsgBox(ApplicationAppearance appearance, string title, string message, ButtonTypes buttonTypes)
          : this(appearance)
        {
            Title = title;
            Message = message;
            DialogType = buttonTypes;
        }

        public MsgBox(string title, string message, ButtonTypes buttonTypes, MsgIcon messageIcon)
           : this()
        {
            Title = title;
            Message = message;
            DialogType = buttonTypes;
            MessageIcon = messageIcon;
        }

        public MsgBox(ApplicationAppearance appearance, string title, string message, ButtonTypes buttonTypes, MsgIcon messageIcon)
           : this(appearance)
        {
            Title = title;
            Message = message;
            DialogType = buttonTypes;
            MessageIcon = messageIcon;
        }

        internal MsgBox(ApplicationAppearance appearance)
           : base(appearance)
        {
            InitializeComponent();

            DialogType = ButtonTypes.Ok;
        }

        internal MsgBox()
            :base()
        {
            InitializeComponent();

            DialogType = ButtonTypes.Ok;
        }

        #endregion

        #region private

        private void MsgBox_Load(object sender, EventArgs e)
        {
            Text = Title;

            switch (MessageIcon)
            {
                case MsgIcon.None:
                    {
                        this.Icon = SystemIcons.Application;
                        break;
                    }
                case MsgIcon.Error:
                    {
                        this.Icon = SystemIcons.Error;
                        break;
                    }
                case MsgIcon.Information:
                    {
                        this.Icon = SystemIcons.Information;
                        break;
                    }
                case MsgIcon.Question:
                    {
                        this.Icon = SystemIcons.Question;
                        break;
                    }
                case MsgIcon.Warning:
                    {
                        this.Icon = SystemIcons.Warning;
                        break;
                    }
                default:
                    break;
            }

            pictureBox1.Image = Bitmap.FromHicon(this.Icon.Handle);

            lblMessage.Text = Message;


            SizeF result;
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            {
                result = g.MeasureString(Message, lblMessage.Font);
            }

            var widthDelta = (int)(lblMessage.Width - result.Width);
            var heightDelta = (int)(lblMessage.Height - result.Height);

            var newHeight = heightDelta > 0 ?
                 this.Height + heightDelta :
                this.Height;

            this.Size = new Size(
                this.Size.Width - widthDelta,
                this.Height - heightDelta);

            if (Appearance != null)
            {
                this.BackColor = Appearance.DialogAppearance.BackColor;
                this.ForeColor = Appearance.DialogAppearance.ForeColor;
                this.Font = Appearance.DialogAppearance.Font;

                foreach (Button button in Controls.OfType<Button>())
                {
                    button.BackColor = Appearance.DialogAppearance.ButtonAppearance.BackColor;
                    button.ForeColor = Appearance.DialogAppearance.ButtonAppearance.ForeColor;
                    button.Font = Appearance.DialogAppearance.ButtonAppearance.Font;
                    button.FlatStyle = Appearance.DialogAppearance.ButtonAppearance.FlatStyle; ;
                    button.FlatAppearance.BorderColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderColor;
                    button.FlatAppearance.BorderSize = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderSize;
                    button.FlatAppearance.MouseDownBackColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseDownBackColor;
                    button.FlatAppearance.MouseOverBackColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseOverBackColor;
                }
            }
        }

        #endregion
    }
}
