using System;

namespace RacerData.WinForms.Controls
{
    public interface IViewControl
    {
        event EventHandler<string> SetViewHeaderRequest;
    }
}