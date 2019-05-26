using System.Windows.Forms;

namespace RacerData.WinForms.Models
{
    class ButtonInfo
    {
        public int Index { get; set; }
        public string[] ButtonText { get; set; }
        public ButtonTypes ButtonType { get; set; }
        public ButtonAlign ButtonAlign { get; set; }
        public DialogResult Result { get; set; }
        public Button Button { get; set; }
    }
}
