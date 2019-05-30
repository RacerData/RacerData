﻿using System;
using System.Drawing;
using System.Windows.Forms;
using rNascarApp.UI.Models;

namespace rNascarApp.UI.Views
{
    public partial class View : UserControl
    {
        #region events

        public event EventHandler<RemoveViewRequestEventArgs> RemoveViewRequest;
        protected virtual void OnRemoveViewRequest()
        {
            var handler = RemoveViewRequest;
            handler?.Invoke(this, new RemoveViewRequestEventArgs(Index));
        }

        public event EventHandler<BeginViewResizeRequestEventArgs> BeginViewResizeRequest;
        protected virtual void OnBeginViewResizeRequest(Point point, ResizeDirection resizeDirection)
        {
            _isResizing = true;
            _resizeDirection = resizeDirection;
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
            _isResizing = false;
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

        private bool _isResizing = false;
        private ResizeDirection _resizeDirection;

        #endregion

        #region properties

        public int Index { get; set; }
        public string Header { get { return lblHeader.Text; } set { lblHeader.Text = value; } }

        #endregion

        #region ctor

        public View()
        {
            InitializeComponent();
        }

        #endregion

        #region private

        private void Header_DoubleClick(object sender, EventArgs e)
        {
            OnRemoveViewRequest();
        }
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void ResizeVertical_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                OnBeginViewResizeRequest(e.Location, ResizeDirection.Vertical);
        }
        private void ResizeHorizontal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                OnBeginViewResizeRequest(e.Location, ResizeDirection.Horizontal);
        }
        private void ResizeBoth_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                OnBeginViewResizeRequest(e.Location, ResizeDirection.Both);
        }
        private void Resize_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isResizing && e.Button == MouseButtons.Left)
                OnViewResizeRequest(e.Location, _resizeDirection);
        }
        private void Resize_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isResizing && e.Button == MouseButtons.Left)
                OnEndViewResizeRequest(false, e.Location, _resizeDirection);
        }
        private void Resize_MouseLeave(object sender, EventArgs e)
        {
            if (_isResizing)
                OnEndViewResizeRequest(true, Point.Empty, _resizeDirection);
        }

        #endregion

        private void tableLayoutPanel1_DoubleClick(object sender, EventArgs e)
        {
            Header = this.Size.ToString();
        }
    }
}
