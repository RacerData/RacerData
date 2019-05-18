using System.Collections.Generic;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Services
{
    public interface IDisplayFormatMapService
    {
        IList<ViewDisplayFormat> DisplayFormats { get; set; }
        IDictionary<ViewDataMember, ViewDisplayFormat> Map { get; set; }

        void AddNewFormatToMap(ViewDataMember member, ViewDisplayFormat format);
        void Save();
    }
}