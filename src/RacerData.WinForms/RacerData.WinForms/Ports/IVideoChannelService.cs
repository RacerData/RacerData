using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Ports
{
    public interface IVideoChannelService
    {
        Task<IResult<IList<VideoChannelModel>>> GetChannelsAsync();
    }
}
