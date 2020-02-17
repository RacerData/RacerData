using System.Collections.Generic;

namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    public class SetupViewModel
    {
        public string Name { get; set; }
        public IList<SetupValueViewModel> Values { get; set; }
    }
}
