using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Editors
{
    public partial class ButtonAppearanceEditor : UserControl
    {
        #region events

        public ColorRequestHandler ColorRequest;
        protected virtual void OnColorRequest(ref Color color)
        {
            var handler = ColorRequest;
            handler?.Invoke(ref color);
        }

        public FontRequestHandler FontRequest;
        protected virtual void OnFontRequest(ref Font font)
        {
            var handler = FontRequest;
            handler?.Invoke(ref font);
        }

        #endregion

        #region properties

        ButtonAppearance _buttonAppearance;
        public ButtonAppearance ButtonAppearance
        {
            get
            {
                return _buttonAppearance;
            }
            set
            {
                _buttonAppearance = value;
                DisplayAppearance(_buttonAppearance);
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

        public string Caption
        {
            get
            {
                return lblCaption?.Text;
            }
            set
            {
                if (lblCaption != null)
                    lblCaption.Text = value;
            }
        }

        #endregion

        #region ctor

        public ButtonAppearanceEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void ApplyChanges()
        {
            ButtonAppearance = UpdateAppearance(ButtonAppearance);
        }

        public void Clear()
        {
            ClearAppearance();
        }

        #endregion

        #region protected

        protected virtual void ClearAppearance()
        {
            foreColorEditor.SelectedColor = default(Color);
            backColorEditor.SelectedColor = default(Color);
            fontEditor.SelectedFont = default(Font);

            cboButtonStyle.SelectedItem = FlatStyle.Standard.ToString();
            textAlignEditor.Alignment = ContentAlignment.MiddleLeft;

            mouseDownColorEditor.SelectedColor = default(Color);
            mouseOverColorEditor.SelectedColor = default(Color);
            borderColorEditor.SelectedColor = default(Color);
            numBorderSize.Value = 1;
        }

        protected virtual void DisplayAppearance(ButtonAppearance appearance)
        {
            ClearAppearance();

            if (appearance == null)
                return;

            foreColorEditor.SelectedColor = appearance.ForeColor;
            backColorEditor.SelectedColor = appearance.BackColor;
            fontEditor.SelectedFont = appearance.Font;

            cboButtonStyle.SelectedValue = (int)appearance.FlatStyle;

            textAlignEditor.Alignment = appearance.Alignment;

            mouseDownColorEditor.SelectedColor = appearance.FlatAppearance.MouseDownBackColor;
            mouseOverColorEditor.SelectedColor = appearance.FlatAppearance.MouseOverBackColor;
            borderColorEditor.SelectedColor = appearance.FlatAppearance.BorderColor;
            numBorderSize.Value = appearance.FlatAppearance.BorderSize;
        }

        protected virtual ButtonAppearance UpdateAppearance(ButtonAppearance appearance)
        {
            if (appearance == null)
                return new ButtonAppearance();

            appearance.ForeColor = foreColorEditor.SelectedColor;
            appearance.BackColor = backColorEditor.SelectedColor;
            appearance.Font = fontEditor.SelectedFont;

            appearance.Alignment = textAlignEditor.Alignment;

            appearance.FlatAppearance.MouseDownBackColor = mouseDownColorEditor.SelectedColor;
            appearance.FlatAppearance.MouseOverBackColor = mouseOverColorEditor.SelectedColor;
            appearance.FlatAppearance.BorderColor = borderColorEditor.SelectedColor;
            appearance.FlatAppearance.BorderSize = (int)numBorderSize.Value;

            FlatStyle flatStyle = FlatStyle.Standard;
            if (cboButtonStyle.SelectedItem != null)
            {
                var flatStyleItem = (EnumListItem<FlatStyle>)cboButtonStyle.SelectedItem;
                flatStyle = flatStyleItem.EnumValue;
            }
            appearance.FlatStyle = flatStyle;


            return appearance;
        }

        #endregion

        #region private

        private void ButtonAppearanceEditor_Load(object sender, EventArgs e)
        {
            backColorEditor.ColorRequest += OnColorRequest;
            foreColorEditor.ColorRequest += OnColorRequest;
            mouseDownColorEditor.ColorRequest += OnColorRequest;
            mouseOverColorEditor.ColorRequest += OnColorRequest;
            borderColorEditor.ColorRequest += OnColorRequest;
            fontEditor.FontRequest += OnFontRequest;

            var styleList = new List<EnumListItem<FlatStyle>>();
            styleList.Add(new EnumListItem<FlatStyle>()
            {
                EnumValue = FlatStyle.Standard,
                Value = (int)FlatStyle.Standard
            });
            styleList.Add(new EnumListItem<FlatStyle>()
            {
                EnumValue = FlatStyle.Flat,
                Value = (int)FlatStyle.Flat
            });

            cboButtonStyle.DisplayMember = "Name";
            cboButtonStyle.ValueMember = "Value";
            cboButtonStyle.DataSource = styleList;

            cboButtonStyle.SelectedIndex = -1;
        }

        private void cboButtonStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboButtonStyle.SelectedItem == null)
                return;

            var flatStyleItem = (EnumListItem<FlatStyle>)cboButtonStyle.SelectedItem;

            if (flatStyleItem.EnumValue == FlatStyle.Flat)
            {
                numBorderSize.Enabled = true;
                borderColorEditor.Enabled = true;
                mouseDownColorEditor.Enabled = true;
                mouseOverColorEditor.Enabled = true;
            }
            else
            {
                numBorderSize.Enabled = false;
                borderColorEditor.Enabled = false;
                mouseDownColorEditor.Enabled = false;
                mouseOverColorEditor.Enabled = false;
            }
        }

        #endregion

        #region classes

        private class EnumListItem<T>
        {
            public T EnumValue { get; set; }
            public string Name
            {
                get
                {
                    return EnumValue.ToString();
                }
            }
            public int Value { get; set; }
        }

        #endregion
    }
}
