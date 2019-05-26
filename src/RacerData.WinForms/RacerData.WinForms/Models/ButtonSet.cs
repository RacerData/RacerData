using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RacerData.WinForms.Models
{
    class ButtonSet
    {
        #region consts

        private const int LastRightIndex = 20;
        #endregion

        #region properties

        private IList<ButtonInfo> _buttons = new List<ButtonInfo>();
        public virtual IEnumerable<ButtonInfo> DialogResultButtons
        {
            get
            {
                return _buttons.Where(b => b.Result != DialogResult.None);
            }
        }

        /// <summary>
        /// Gets sequentially ordered buttons in this order: 0, 1, 2, 0, 1, 2
        /// Left buttons first, then right buttons
        /// Where buttons appear |[0] [1] [2]    [0] [1] [2] |
        /// </summary>
        public virtual IEnumerable<ButtonInfo> SequentialButtons
        {
            get
            {
                return _buttons.OrderBy(b => b.ButtonAlign).ThenBy(b => b.Index);
            }
        }
        /// <summary>
        /// Gets left-aligned buttons in this order: 0, 1, 2
        /// Where buttons appear |[0] [1] [2]    |
        /// </summary>
        public virtual IOrderedEnumerable<ButtonInfo> LeftButtons
        {
            get
            {
                return _buttons
                    .Where(b => b.ButtonAlign == ButtonAlign.Left)
                    .Select(b => b)
                    .OrderBy(b => b.Index);
            }
        }
        /// <summary>
        /// Gets right-aligned in this order: 2, 1, 0
        /// Where buttons appear |   [0] [1] [2]|
        /// </summary>
        public virtual IOrderedEnumerable<ButtonInfo> RightButtons
        {
            get
            {
                return _buttons
                    .Where(b => b.ButtonAlign == ButtonAlign.Right)
                    .Select(b => b)
                    .OrderByDescending(b => b.Index);
            }
        }

        #endregion

        #region public

        public ButtonSet()
        {
        }

        #endregion

        #region public

        public void AddLeftButton(Button button, ButtonTypes buttonType, string[] buttonText, DialogResult result)
        {
            AddButton(LeftButtons.Count(), ButtonAlign.Left, button, buttonType, buttonText, result);
        }
        public void AddRightButton(Button button, ButtonTypes buttonType, string[] buttonText, DialogResult result)
        {
            AddButton(RightButtons.Count(), ButtonAlign.Right, button, buttonType, buttonText, result);
        }

        public void AddButton(int index, ButtonAlign alignment, Button button, ButtonTypes buttonType, string[] buttonText, DialogResult result)
        {
            _buttons.Add(new ButtonInfo()
            {
                Button = button,
                ButtonAlign = alignment,
                ButtonType = buttonType,
                ButtonText = buttonText,
                Result = result,
                Index = index
            });
        }

        #endregion
    }
}
