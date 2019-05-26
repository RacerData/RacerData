using System.Windows.Forms;

namespace RacerData.WinForms.Ports
{
    public interface IRacerDataDialog
    {
        DialogResult ShowDialog(IWin32Window parent);
    }
}
