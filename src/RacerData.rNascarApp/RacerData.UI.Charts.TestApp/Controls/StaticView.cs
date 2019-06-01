using System;
using System.Windows.Forms;
using RacerData.WinForms.Controls;
using rNascarApp.UI.Data;

namespace rNascarApp.UI.Controls
{
    class StaticView<TModel> : UserControl, IStaticView<TModel>
    {
        #region events

        public event EventHandler<string> SetViewHeaderRequest;
        protected virtual void OnSetViewHeaderRequest(string headerText)
        {
            var handler = SetViewHeaderRequest;
            handler?.Invoke(this, headerText);
        }

        #endregion

        public TModel Model { get; set; }

        public StaticView()
        {
            InitializeComponent();

            var reader = new WeekendScheduleReader();

            var schedule = reader.GetScheduleAsync().Result;

          
        }

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
    }
}
