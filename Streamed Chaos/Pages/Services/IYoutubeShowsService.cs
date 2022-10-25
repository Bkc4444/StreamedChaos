using Streamed_Chaos.Models;

namespace Streamed_Chaos.Pages.Services
{
    public class IYoutubeShowsService
    {
        Task<IEnumerable<Show>> GetShows(int numberOfShows = 25);
    }
}
