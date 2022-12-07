using Streamed_Chaos.Models;

namespace Streamed_Chaos.Pages.Services
{
    /// <summary>
    /// How many users can be shown at one time
    /// </summary>
    public interface IYouTubeShowsService
    {
        Task<IEnumerable<Show>> GetShows(int numberOfShows = 25);
    }
}
