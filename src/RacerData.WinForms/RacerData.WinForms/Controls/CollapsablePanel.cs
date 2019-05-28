using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CollapsablePanel : UserControl
    {
        #region events

        public event EventHandler<CollapsablePanelChangedEventArgs> CollapsablePanelChanged;
        protected virtual void OnCollapsablePanelChanged(int oldHeight, int newHeight)
        {
            var handler = CollapsablePanelChanged;
            handler?.Invoke(this, new CollapsablePanelChangedEventArgs() { OldHeight = oldHeight, NewHeight = newHeight });
        }

        #endregion

        #region fields

        private bool _isResizing = false;

        #endregion

        #region protected properties

        protected int ExpandedHeight { get; set; } = 0;
        protected int CollapsedHeight { get; set; } = 0;

        private bool _isCollapsed = false;
        protected bool IsCollapsed
        {
            get
            {
                return this.Height == CollapsedHeight;
            }
        }

        #endregion

        #region public properties

        public string Caption
        {
            get
            {
                return lblCaption.Text;
            }
            set
            {
                if (lblCaption != null)
                    lblCaption.Text = value;
            }
        }

        public Color CaptionForeColor
        {
            get
            {
                return lblCaption.ForeColor;
            }
            set
            {
                if (lblCaption.ForeColor != null)
                    lblCaption.ForeColor = value;
            }
        }

        public Color CaptionBackColor
        {
            get
            {
                return lblCaption.BackColor;
            }
            set
            {
                if (lblCaption != null)
                    lblCaption.BackColor = value;
            }
        }

        private bool _canCollapse = true;
        public bool CanCollapse
        {
            get
            {
                return _canCollapse;
            }
            set
            {
                _canCollapse = value;

                btnShowHide.Enabled = _canCollapse;

                UpdateControlState();
            }
        }

        private CollapsablePanelState _collapsedState = CollapsablePanelState.Expanded;
        public CollapsablePanelState State
        {
            get
            {
                return _collapsedState;
            }
            set
            {
                if (value == CollapsablePanelState.Collapsed && !CanCollapse)
                    return;

                _collapsedState = value;

                UpdateControlState();
            }
        }

        #endregion

        #region ctor

        public CollapsablePanel()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ToggleShowHideState()
        {
            if (State == CollapsablePanelState.Collapsed)
                State = CollapsablePanelState.Expanded;
            else if (State == CollapsablePanelState.Expanded && CanCollapse)
                State = CollapsablePanelState.Collapsed;
        }

        protected virtual void UpdateControlState()
        {
            var originalHeight = this.Height;

            try
            {
                if (!CanCollapse && IsCollapsed)
                {
                    ExpandControl();
                }
                else if (State == CollapsablePanelState.Expanded && IsCollapsed)
                {
                    ExpandControl();
                }
                else if (State == CollapsablePanelState.Collapsed && !IsCollapsed)
                {
                    CollapseControl();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                OnCollapsablePanelChanged(originalHeight, this.Height);
            }
        }

        protected virtual void ExpandControl()
        {
            ResizeControl(ExpandedHeight);

            btnShowHide.ImageIndex = (int)CollapsablePanelState.Expanded;
        }

        protected virtual void CollapseControl()
        {
            ExpandedHeight = this.Height;

            ResizeControl(CollapsedHeight);

            btnShowHide.ImageIndex = (int)CollapsablePanelState.Collapsed;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is CollapsablePanel)
            {
                ((CollapsablePanel)e.Control).CollapsablePanelChanged += ChildPanel_CollapsablePanelChanged;
            }
        }

        protected virtual void ResizeControl(int newHeight)
        {
            try
            {
                _isResizing = true;

                this.SuspendLayout();

                this.Size = new Size(this.Width, newHeight);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _isResizing = false;

                this.ResumeLayout();
            }
        }

        #endregion

        #region private

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            ToggleShowHideState();
        }

        private void CollapsablePanel_Load(object sender, EventArgs e)
        {
            CollapsedHeight = pnlCaption.Height + this.Padding.Bottom;

            ExpandedHeight = this.Height;
        }

        private void ChildPanel_CollapsablePanelChanged(object sender, CollapsablePanelChangedEventArgs e)
        {
            var heightDifference = e.NewHeight - e.OldHeight;

            var thisNewHeight = this.Height + heightDifference;

            ResizeControl(thisNewHeight);
        }

        private void lblCaption_BackColorChanged(object sender, EventArgs e)
        {
            pnlCaption.BackColor = lblCaption.BackColor;
        }

        #endregion
    }
}
