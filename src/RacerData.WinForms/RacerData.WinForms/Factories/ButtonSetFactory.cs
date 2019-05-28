using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Factories
{
    internal class ButtonSetFactory
    {
        #region fields

        private ButtonFactory _buttonFactory;
        private IDictionary<ButtonTypes, string[]> _buttonTextMap;
        private IDictionary<ButtonTypes, DialogResult> _buttonResultMap;

        #endregion

        #region properties

        public int ButtonHeight { get; set; }
        public int ButtonWidth { get; set; }

        #endregion

        #region ctor

        public ButtonSetFactory()
            : this(
                ControlDefaults.DefaultButtonWidth,
                ControlDefaults.DefaultButtonHeight)
        {

        }
        public ButtonSetFactory(int defaultWidth, int defaultHeight)
        {
            _buttonFactory = new ButtonFactory(defaultWidth, defaultHeight);

            _buttonTextMap = new Dictionary<ButtonTypes, string[]>();
            _buttonTextMap.Add(ButtonTypes.Edit_Save, new string[] { "Edit", "Save" });
            _buttonTextMap.Add(ButtonTypes.Close_Cancel, new string[] { "Close", "Cancel" });
            _buttonTextMap.Add(ButtonTypes.SaveAndClose, new string[] { "Save and Close", "Save and Close" });

            _buttonResultMap = new Dictionary<ButtonTypes, DialogResult>();
            _buttonResultMap.Add(ButtonTypes.Ok, DialogResult.OK);
            _buttonResultMap.Add(ButtonTypes.Yes, DialogResult.Yes);
            _buttonResultMap.Add(ButtonTypes.No, DialogResult.No);
            _buttonResultMap.Add(ButtonTypes.Cancel, DialogResult.Cancel);
            _buttonResultMap.Add(ButtonTypes.Save, DialogResult.OK);
            _buttonResultMap.Add(ButtonTypes.SaveAndClose, DialogResult.OK);
            _buttonResultMap.Add(ButtonTypes.Close_Cancel, DialogResult.Cancel);
        }

        #endregion

        #region public

        public ButtonSet BuildButtonSet(ButtonTypes buttons)
        {
            ButtonSet _buttonSet = null;

            if (buttons == ButtonTypes.EditForm)
            {
                _buttonSet = BuildEditButtonSet();
            }
            else if (buttons == ButtonTypes.YesNo)
            {
                _buttonSet = BuildYesNoButtonSet();
            }
            else if (buttons == ButtonTypes.YesNoCancel)
            {
                _buttonSet = BuildYesNoCancelButtonSet();
            }
            else if (buttons == ButtonTypes.OkCancel)
            {
                _buttonSet = BuildOkCancelButtonSet();
            }
            else if (buttons == ButtonTypes.SaveCancel)
            {
                _buttonSet = BuildSaveCancelButtonSet();
            }
            else if (buttons == ButtonTypes.OpenCancel)
            {
                _buttonSet = BuildOpenCancelButtonSet();
            }
            else
            {
                _buttonSet = BuildCustomButtonSet(buttons);
            }

            int tabIndex = 0;

            foreach (ButtonInfo buttonPosition in _buttonSet.SequentialButtons)
            {
                buttonPosition.Button.TabIndex = tabIndex;
                tabIndex++;
            }

            return _buttonSet;
        }

        #endregion

        #region protected

        private void AddLeftButton(int index, ButtonSet buttonSet, ButtonTypes buttonType)
        {
            var text = GetButtonText(buttonType);

            var result = GetButtonDialogResult(buttonType);

            var button = _buttonFactory.BuildButton(
                index,
                ButtonAlign.Left,
                DialogResult.None,
                text[0]);

            buttonSet.AddLeftButton(button, buttonType, text, result);
        }

        private void AddRightButton(int index, ButtonSet buttonSet, ButtonTypes buttonType)
        {
            var text = GetButtonText(buttonType);

            var result = GetButtonDialogResult(buttonType);

            var button = _buttonFactory.BuildButton(
                index,
                ButtonAlign.Right,
                DialogResult.None,
                text[0]);

            buttonSet.AddRightButton(button, buttonType, text, result);
        }

        /// <summary>
        /// |[Edit/Save][New][Copy][Delete]   [Save][Close/Cancel]|
        /// </summary>
        protected virtual ButtonSet BuildEditButtonSet()
        {
            ButtonSet buttonSet = new ButtonSet();

            // left buttons
            int leftIndex = 0;
            AddLeftButton(leftIndex++, buttonSet, ButtonTypes.Edit_Save);
            AddLeftButton(leftIndex++, buttonSet, ButtonTypes.New);
            AddLeftButton(leftIndex++, buttonSet, ButtonTypes.Copy);
            AddLeftButton(leftIndex++, buttonSet, ButtonTypes.Delete);

            // right buttons
            int rightIndex = 0;
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.SaveAndClose);
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Close_Cancel);

            return buttonSet;
        }
        /// <summary>
        /// |    [Yes][No] |
        /// </summary>
        protected virtual ButtonSet BuildYesNoButtonSet()
        {
            ButtonSet buttonSet = new ButtonSet();

            int rightIndex = 0;
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Yes);
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.No);

            return buttonSet;
        }
        /// <summary>
        /// |    [Open][Cancel] |
        /// </summary>
        protected virtual ButtonSet BuildOpenCancelButtonSet()
        {
            ButtonSet buttonSet = new ButtonSet();

            int rightIndex = 0;
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Open);
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Cancel);

            return buttonSet;
        }
        /// <summary>
        /// |    [Save][Cancel] |
        /// </summary>
        protected virtual ButtonSet BuildSaveCancelButtonSet()
        {
            ButtonSet buttonSet = new ButtonSet();

            int rightIndex = 0;
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Save);
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Cancel);

            return buttonSet;
        }
        /// <summary>
        /// |    [Ok][Cancel] |
        /// </summary>
        protected virtual ButtonSet BuildOkCancelButtonSet()
        {
            ButtonSet buttonSet = new ButtonSet();

            int rightIndex = 0;
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Ok);
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Cancel);

            return buttonSet;
        }

        /// <summary>
        /// |    [Yes][No][Cancel] |
        /// </summary>
        protected virtual ButtonSet BuildYesNoCancelButtonSet()
        {
            ButtonSet buttonSet = new ButtonSet();

            int rightIndex = 0;
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Yes);
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.No);
            AddRightButton(rightIndex++, buttonSet, ButtonTypes.Cancel);

            return buttonSet;
        }
        /// <summary>
        /// |    [A][B][C]... |
        /// </summary>
        protected virtual ButtonSet BuildCustomButtonSet(ButtonTypes buttons)
        {
            ButtonSet buttonSet = new ButtonSet();

            int rightIndex = 0;

            foreach (ButtonTypes buttonType in (ButtonTypes[])Enum.GetValues(typeof(ButtonTypes)))
            {
                if (buttonType < ButtonTypes.Blank && buttons.HasFlag(buttonType))
                {
                    AddRightButton(rightIndex++, buttonSet, buttonType);
                }
            }

            return buttonSet;
        }

        protected virtual string[] GetButtonText(ButtonTypes button)
        {
            if (_buttonTextMap.ContainsKey(button))
                return _buttonTextMap[button];
            else
                return new string[] { button.ToString(), button.ToString() };
        }

        protected virtual DialogResult GetButtonDialogResult(ButtonTypes button)
        {
            if (_buttonResultMap.ContainsKey(button))
                return _buttonResultMap[button];
            else
                return DialogResult.None;
        }

        #endregion
    }
}
