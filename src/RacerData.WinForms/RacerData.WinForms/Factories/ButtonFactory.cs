using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Factories
{
    internal class ButtonFactory
    {
        #region const

        private const AnchorStyles LeftAnchor = AnchorStyles.Left | AnchorStyles.Top;
        private const AnchorStyles RightAnchor = AnchorStyles.Right | AnchorStyles.Top;

        #endregion

        #region properties

        public int ButtonHeight { get; set; }
        public int ButtonWidth { get; set; }

        #endregion

        #region ctor

        public ButtonFactory()
            : this(
                ControlDefaults.DefaultButtonWidth,
                ControlDefaults.DefaultButtonHeight)
        {

        }
        public ButtonFactory(int defaultWidth, int defaultHeight)
        {
            ButtonWidth = defaultWidth;
            ButtonHeight = defaultHeight;
        }

        #endregion

        #region public

        public Button BuildButton(int index, ButtonAlign alignment, string text)
        {
            return BuildButton(index, alignment, new string[] { text });
        }
        public Button BuildButton(int index, ButtonAlign alignment, string[] text)
        {
            return BuildButton(index, alignment, DialogResult.None, text);
        }

        public Button BuildButton(int index, ButtonAlign alignment, DialogResult result, string text)
        {
            return BuildButton(index, alignment, result, new string[] { text });
        }
        public Button BuildButton(int index, ButtonAlign alignment, DialogResult result, string[] text)
        {
            return BuildButton(index, ButtonWidth, ButtonHeight, alignment, result, text);
        }

        public Button BuildButton(int index, int width, int height, ButtonAlign alignment, DialogResult result, string text)
        {
            return BuildButton(index, width, height, alignment, result, new string[] { text });
        }
        public Button BuildButton(int index, int width, int height, ButtonAlign alignment, DialogResult result, string[] text)
        {
            return new Button()
            {
                Anchor = alignment == ButtonAlign.Left ? LeftAnchor : RightAnchor,
                Location = new Point(8, 8),
                Name = $"button{index}{alignment}_{text[0].Replace(" ", "")}",
                Size = new Size(width, height),
                Text = text[0],
                UseVisualStyleBackColor = true,
                DialogResult = result
            };
        }

        #endregion
    }
}
