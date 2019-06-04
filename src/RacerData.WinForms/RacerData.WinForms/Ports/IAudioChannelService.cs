using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Ports
{
    public interface IAudioChannelService
    {
        Task<IResult<IList<AudioChannelModel>>> GetChannelsAsync(int seriesId);
        Task<IResult<IList<AudioChannelModel>>> GetDefaultChannelsAsync();
    }
}
