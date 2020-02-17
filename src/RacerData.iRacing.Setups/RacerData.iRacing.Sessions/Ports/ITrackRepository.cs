using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Sessions.Ports
{
    public interface ITrackRepository
    {
        Task<Track> GetTrackAsync(long id);
        Task<IList<Track>> GetTracksAsync();
        Task<Track> InsertTrackAsync(Track track);
        Task<Track> UpdateTrackAsync(Track track);
    }
}
