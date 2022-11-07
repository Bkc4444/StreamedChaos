using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Streamed_Chaos.Models;
using Streamed_Chaos.Pages.Services;

namespace Streamed_Chaos.Pages
{
    public class PrivacyModel : PageModel
    {
        public IEnumerable<Show>? Shows { get; private set; }
        public Show? UpcomingShow { get; private set; }
        public Show? OnAirShow { get; private set; }
        public bool HasUpcomingShow => UpcomingShow != null;
        public bool IsOnAir => OnAirShow != null;
        public string? MoreShowsUrl => "https://www.youtube.com/playlist?list=PL1rZQsJPBU2St9-Mz1Kaa7rofciyrwWVx";

        IYouTubeShowsService youTubeService;
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(YouTubeShowService youTubeService, ILogger<PrivacyModel> logger)
        {
            this.youTubeService = youTubeService;
            _logger = logger;
        }

        public async void OnGet()
        {
            Shows = await youTubeService.GetShows();
            UpcomingShow = Shows.LastOrDefault(show => show.IsInFuture && !show.IsOnAir);
            OnAirShow = Shows.FirstOrDefault(show => show.IsOnAir);

        }
    }
}