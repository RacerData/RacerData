using System;
using System.ComponentModel;
using RacerData.Themes.Models;

namespace RacerData.Themes.Ports
{
    public interface IThemeDefinition
    {
        Appearance Appearance { get; set; }
        Guid Key { get; set; }
        string Name { get; set; }
        bool IsReadOnly { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}