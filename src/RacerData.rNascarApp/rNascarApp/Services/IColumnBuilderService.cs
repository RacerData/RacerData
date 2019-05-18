using System.Windows.Forms;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp.Services
{
    public interface IColumnBuilderService
    {
        void AlignControls(Control.ControlCollection controls, int? fillColumnIndex);
        Label BuildColumnLabel(ListColumn column, bool isHeader = false);
        void BuildGridColumns(ListDefinition listDefinition, Control.ControlCollection headerControls, Control.ControlCollection rowControls);
        void BuildGridColumns(ListDefinition listDefinition, Control.ControlCollection headerControls, Control.ControlCollection rowControls, Theme theme);
    }
}