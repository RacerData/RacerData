using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.WinForms.Controls.AudioView;

namespace RacerData.WinForms.Controls.Ports
{
    public interface IAudioChannelService
    {
        Task<IResult<IList<AudioChannelInfo>>> GetChannelsAsync(int seriesId);
        Task<IResult<IList<AudioChannelInfo>>> GetDefaultChannelsAsync();
    }
}
