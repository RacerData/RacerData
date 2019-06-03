using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Controls.Models.VideoView;

namespace RacerData.WinForms.Controls.Ports
{
    public interface IVideoChannelService
    {
        Task<IResult<IList<VideoChannelModel>>> GetChannelsAsync();
    }
}
