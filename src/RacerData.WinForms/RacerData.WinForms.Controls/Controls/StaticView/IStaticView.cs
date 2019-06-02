﻿using System.Collections.Generic;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Controls
{
    public interface IStaticView : IViewControl
    {
        IList<StaticField> Fields { get; set; }
    }
}