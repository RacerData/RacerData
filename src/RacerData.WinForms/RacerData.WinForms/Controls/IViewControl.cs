﻿using System;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public interface IViewControl
    {
        event EventHandler<string> SetViewHeaderRequest;
        event EventHandler<RemoveViewRequestEventArgs> RemoveViewRequest;
        event EventHandler<BeginViewResizeRequestEventArgs> BeginViewResizeRequest;
        event EventHandler<ViewResizeRequestEventArgs> ViewResizeRequest;
        event EventHandler<EndViewResizeRequestEventArgs> EndViewResizeRequest;

        ApplicationAppearance Appearance { get; set; }
    }
}