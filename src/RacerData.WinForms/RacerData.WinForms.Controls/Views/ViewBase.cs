using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Views
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ViewBase : UserControl
    {
        #region consts

        private const int HeaderTextLeftPadding = 2;

        #endregion

        #region events

        public event EventHandler<string> SetViewHeaderRequest;
        protected virtual void OnSetViewHeaderRequest(string headerText)
        {
            var handler = SetViewHeaderRequest;
            handler?.Invoke(this, headerText);
        }

        public event EventHandler<RemoveViewRequestEventArgs> RemoveViewRequest;
        protected virtual void OnRemoveViewRequest(int index)
        {
            var handler = RemoveViewRequest;
            handler?.Invoke(this, new RemoveViewRequestEventArgs(index));
        }

        public event EventHandler<BeginViewResizeRequestEventArgs> BeginViewResizeRequest;
        protected virtual void OnBeginViewResizeRequest(Point point, ResizeDirection resizeDirection)
        {          
            var handler = BeginViewResizeRequest;
            handler?.Invoke(this, new BeginViewResizeRequestEventArgs(point, resizeDirection));
        }

        public event EventHandler<ViewResizeRequestEventArgs> ViewResizeRequest;
        protected virtual void OnViewResizeRequest(Point point, ResizeDirection resizeDirection)
        {
            var handler = ViewResizeRequest;
            handler?.Invoke(this, new ViewResizeRequestEventArgs(point, resizeDirection));
        }

        public event EventHandler<EndViewResizeRequestEventArgs> EndViewResizeRequest;
        protected virtual void OnEndViewResizeRequest(bool cancelled, Point point, ResizeDirection resizeDirection)
        {
            var handler = EndViewResizeRequest;
            if (cancelled)
            {
                handler?.Invoke(this, new EndViewResizeRequestEventArgs(cancelled));
            }
            else
            {
                handler?.Invoke(this, new EndViewResizeRequestEventArgs(point, resizeDirection));
            }
        }

        #endregion

        #region fields



        #endregion

        #region properties

        protected virtual bool IsResizing { get; set; }

        protected virtual ResizeDirection ResizeDirection { get; set; }

        public int Index { get; set; }

        public string Header
        {
            get
            {
                return lblHeader.Text.Substring(HeaderTextLeftPadding);
            }
            set
            {
                lblHeader.Text = $"{new string(' ', HeaderTextLeftPadding)}{value}";
            }
        }

        private bool _useHeaderHighlight = true;
        public bool UseHeaderHighlight
        {
            get
            {
                return _useHeaderHighlight;
            }
            set
            {
                _useHeaderHighlight = value;
                lblHeader.Image = _useHeaderHighlight ? WinForms.Controls.Properties.Resources.headerHighlight : null;
            }
        }

        private Color _borderColor = Color.FromArgb(0, 122, 204);
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
            }
        }

        private int? _borderSize = 1;
        public int? BorderSize
        {
            get
            {
                return _borderSize;
            }
            set
            {
                _borderSize = value;
            }
        }

        #endregion

        #region ctor

        public ViewBase()
        {
            InitializeComponent();
        }

        #endregion

        #region internal

        internal virtual void SetViewControl<TView>(TView control) where TView : IViewControl
        {
            pnlControl.Controls.Add(control as Control);

            IViewControl viewControl = control as IViewControl;

            viewControl.SetViewHeaderRequest += ViewControl_SetViewHeaderRequest;

            if (control is IListView)
            {
                IListView listView = (IListView)control;

            }
        }

        private void ViewControl_SetViewHeaderRequest(object sender, string e)
        {
            Header = e;
        }

        #endregion

        #region protected

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion

        #region private

        private void Header_DoubleClick(object sender, EventArgs e)
        {
            OnRemoveViewRequest(Index);
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void ResizeVertical_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsResizing = true;
                ResizeDirection = ResizeDirection.Vertical;
                OnBeginViewResizeRequest(e.Location, ResizeDirection);
            }
        }

        private void ResizeHorizontal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsResizing = true;
                ResizeDirection = ResizeDirection.Horizontal;
                OnBeginViewResizeRequest(e.Location, ResizeDirection);
            }
        }

        private void ResizeBoth_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsResizing = true;
                ResizeDirection = ResizeDirection.Both;
                OnBeginViewResizeRequest(e.Location, ResizeDirection);
            }
        }

        private void Resize_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsResizing && e.Button == MouseButtons.Left)
                OnViewResizeRequest(e.Location, ResizeDirection);
        }

        private void Resize_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsResizing && e.Button == MouseButtons.Left)
            {
                IsResizing = false;
                OnEndViewResizeRequest(false, e.Location, ResizeDirection);
            }
        }

        private void Resize_MouseLeave(object sender, EventArgs e)
        {
            if (IsResizing)
            {
                IsResizing = false;
                OnEndViewResizeRequest(true, Point.Empty, ResizeDirection);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnRemoveViewRequest(Index);
        }

        #endregion

        #region paint

        private void Border_Paint(object sender, PaintEventArgs e)
        {
            if (_borderSize.HasValue && _borderSize.Value > 0)
            {
                Control control = (Control)sender;
                int borderSize = _borderSize.Value;

                ControlPaint.DrawBorder(e.Graphics, control.DisplayRectangle,
                   _borderColor, borderSize, ButtonBorderStyle.Solid,
                   _borderColor, borderSize, ButtonBorderStyle.Solid,
                   _borderColor, borderSize, ButtonBorderStyle.Solid,
                   _borderColor, borderSize, ButtonBorderStyle.Solid);
            }
        }

        #endregion
    }
}
