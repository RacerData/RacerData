﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public partial class StaticView : UserControl, IStaticView
    {
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

        private readonly StaticViewModel _viewModel;
        private IDictionary<int, StaticViewField> _staticViewFields;

        #endregion

        #region properties

        private ApplicationAppearance _appearance;
        public virtual ApplicationAppearance Appearance
        {
            get
            {
                return _appearance;
            }
            set
            {
                _appearance = value;
                ApplyTheme(_appearance);
            }
        }

        #endregion

        #region ctor

        public StaticView(StaticViewModel viewModel)
            : this()
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        internal StaticView()
        {
            InitializeComponent();
        }

        #endregion

        #region protected

        protected virtual void ApplyTheme(ApplicationAppearance appearance)
        {
            if (appearance != null)
            {
                this.BackColor = appearance.DialogAppearance.BackColor;
                this.ForeColor = appearance.DialogAppearance.ForeColor;
                this.Font = appearance.DialogAppearance.Font;

                if (_staticViewFields != null)
                {
                    foreach (IStaticViewField fieldControl in _staticViewFields.Values)
                    {
                        fieldControl.CaptionBackColor = appearance.DarkAccentAppearance.BackColor;
                        fieldControl.CaptionForeColor = appearance.DarkAccentAppearance.ForeColor;
                        fieldControl.CaptionFont = appearance.DarkAccentAppearance.Font;

                        fieldControl.ValueBackColor = appearance.LightAccentAppearance.BackColor;
                        fieldControl.ValueForeColor = appearance.LightAccentAppearance.ForeColor;
                        fieldControl.ValueFont = appearance.LightAccentAppearance.Font;
                    }
                }
            }
        }

        protected virtual void SetDataBindings(StaticViewModel model)
        {
            model.PropertyChanged += ViewModel_PropertyChanged;
        }

        protected virtual void LoadFieldControls(IList<StaticField> fields)
        {
            ClearControls();

            if (fields == null || fields.Count == 0)
                return;

            this.BorderStyle = BorderStyle.FixedSingle;

            foreach (StaticField field in fields)
            {
                var fieldControl = new StaticViewField()
                {
                    Field = field
                };

                fieldControl.BackColor = Color.Gray;
                fieldControl.BorderStyle = BorderStyle.FixedSingle;

                this.Controls.Add(fieldControl);

                _staticViewFields.Add(field.Index, fieldControl);
            }

            ApplyTheme(Appearance);
        }

        protected virtual void ClearControls()
        {
            _staticViewFields = new Dictionary<int, StaticViewField>();

            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                var control = this.Controls[i];
                this.Controls.RemoveAt(i);
                control.Dispose();
            }
        }

        protected virtual void DisplayStaticData(IDictionary<int, string> staticData)
        {
            for (int i = 0; i < _staticViewFields.Count; i++)
            {
                _staticViewFields[i].Value = staticData[i];
            }
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
            this.Load += new System.EventHandler(this.StaticView_Load);
            this.ResumeLayout(false);

        }

        private async void StaticView_Load(object sender, EventArgs e)
        {
            SetDataBindings(_viewModel);

            _viewModel.GetFieldsCommand();

            await _viewModel.GetStaticDataCommandAsync();
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(StaticViewModel.StaticData))
            {
                DisplayStaticData(_viewModel.StaticData);
            }
            if (e.PropertyName == nameof(StaticViewModel.Fields))
            {
                LoadFieldControls(_viewModel.Fields);
            }
        }

        #endregion
    }
}