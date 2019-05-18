using System.Collections.Generic;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Factories
{
    public interface IViewDataSourceFactory
    {
        IList<ViewDataSource> GetDataSources();
    }
}