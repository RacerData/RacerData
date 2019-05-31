using System;
using System.Windows.Forms;
using rNascarApp.UI.Controls;
using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI.Factories
{
    class ViewControlFactory : IViewControlFactory
    {
        public Control GetViewControl(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Graph:
                    return new GraphView();
                case ViewType.List:
                    return new ListView();
                case ViewType.Static:
                    return new VideoView();
                case ViewType.Audio:
                    return new AudioView();
                case ViewType.Video:
                    return new VideoView();
                default:
                    throw new ArgumentException($"Unrecognized view type: {viewType.ToString()}", nameof(viewType));
            }

        }
    }
}
