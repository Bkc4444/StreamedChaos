using Streamed_Chaos.Models;

namespace Streamed_Chaos.Pages.Services
{
    public interface IYouTubeShowsService
    {
        Task<IEnumerable<Show>> GetShows(int numberOfShows = 25);
    }
}
