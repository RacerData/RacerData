using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacerData.rNascarApp.Controls
{
    public interface IWizardStep
    {
        int Index { get; set; }
        string Name { get; set; }
        string Caption { get; set; }
        string Details { get; set; }
        string Error { get; set; }
        bool IsComplete { get; set; }

        object GetDataSource();
        void SetDataObject(object data);
        void ActivateStep();
        void DeactivateStep();
    }
}
