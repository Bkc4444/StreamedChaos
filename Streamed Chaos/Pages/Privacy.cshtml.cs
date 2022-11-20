using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Streamed_Chaos.Models;
using Streamed_Chaos.Pages.Services;
using static System.Net.WebRequestMethods;

namespace Streamed_Chaos.Pages
{
    public class PrivacyModel : PageModel
    {
        // This is making a to say if there is no pages to show it will already be an empty list of shows 
        public IEnumerable<Show> Shows { get; private set; } = new List<Show>();
        public Show? UpcomingShow { get; private set; }
        public Show? OnAirShow { get; private set; }
        public bool HasUpcomingShow => UpcomingShow != null;
        public bool IsOnAir => OnAirShow != null;
        // This portion we want to have an array of different
        // playlists and randomize them each time the page starts up
        // or is refreshed
        public string? MoreShowsUrl => showPlaylists();

        public string? showPlaylists()
        {
            var randomGenerator = new Random();
            string[] playlist = new string[] {
                                      "https://youtube.com/playlist?list=PLYH8WvNV1YElPneq3cmmexAdmQf2pnICT", //Pewdipie
                                      "https://youtube.com/playlist?list=PL3tRBEVW0hiBSFOFhTC5wt75P2BES0rAo", // Markiplier
                                      "https://youtube.com/playlist?list=PLJtitKU0CAehsdcybehbPFHObmWsKtQcY", // Adam Savage Tested
                                      "https://youtube.com/playlist?list=PLRsapyZqDs1o2_cfJNIxQzb-X1-mpYbdA", // Doug Meruno
                                      "https://www.youtube.com/playlist?list=PLrZ2zKOtC_-C4rWfapgngoe9o2-ng8ZBr", // Product Design Online
                                      "https://www.youtube.com/playlist?list=PLUUk3Kbfv-_q1SKE776edGIYaAhkrKLu2" // SKS Props
            };

            string showPlaylists = playlist[randomGenerator.Next(playlist.Length)];
            return showPlaylists;
        }

        IYouTubeShowsService youTubeService;
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(IYouTubeShowsService youTubeService, ILogger<PrivacyModel> logger)
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