using System;
using System.Windows.Forms;
using RacerData.WinForms.Controls;

namespace rNascarApp.UI.Controls
{
    class StaticView : UserControl, IStaticView
    {
        #region events

        public event EventHandler<string> SetViewHeaderRequest;
        protected virtual void OnSetViewHeaderRequest(string headerText)
        {
            var handler = SetViewHeaderRequest;
            handler?.Invoke(this, headerText);
        }

        #endregion

        #region ctor

        public StaticView()
        {
            InitializeComponent();          
        }

        #endregion

        #region private

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // StaticView
            // 
            this.Name = "StaticView";
            this.Size = new System.Drawing.Size(591, 287);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
