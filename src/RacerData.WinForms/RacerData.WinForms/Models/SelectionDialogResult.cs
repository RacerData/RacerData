using System.Windows.Forms;

namespace RacerData.WinForms.Models
{
    public class SelectionDialogResult<TItem>
    {
        public DialogResult DialogResult { get; set; }
        public TItem SelectedItem { get; set; }
    }
}
