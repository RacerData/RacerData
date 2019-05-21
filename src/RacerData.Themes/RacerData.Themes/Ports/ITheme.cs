using System;
using System.ComponentModel;
using RacerData.Themes.Models;

namespace RacerData.Themes.Ports
{
    public interface ITheme
    {
        Appearance Appearance { get; set; }
        Guid Key { get; set; }
        string Name { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}