using System.Collections.Generic;
using rNascarApp.UI.Models;

namespace RacerData.WinForms.Controls
{
    public interface IStaticView : IViewControl
    {
        IList<StaticField> Fields { get; set; }
    }
}