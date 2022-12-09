using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Streamed_Chaos.Models;
using Streamed_Chaos.Pages.Services;
using System.Collections.Generic;
using System;
using static System.Net.WebRequestMethods;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Data.SqlClient;
using System.Data;

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
        
       /* public void showPlaylists()
        {
 
        } */

        IYouTubeShowsService youTubeService;
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(IYouTubeShowsService youTubeService, ILogger<PrivacyModel> logger)
        {
            this.youTubeService = youTubeService;
            _logger = logger;
        }

        public async void OnGet()
        {

            var randomGenerator = new Random();

            Dictionary<string, string> map = new Dictionary<string, string>();

            // var map = new Dictionary<string, string>();
            map.Add("https://youtube.com/playlist?list=PLYH8WvNV1YElPneq3cmmexAdmQf2pnICT", "UC-lHJZR3Gqxm24_Vd_AJ5Yw"); //Pewdipie
            map.Add("https://youtube.com/playlist?list=PL3tRBEVW0hiBSFOFhTC5wt75P2BES0rAo", "UC7_YxT-KID8kRbqZo7MyscQ"); // Markiplier
            map.Add("https://youtube.com/playlist?list=PLJtitKU0CAehsdcybehbPFHObmWsKtQcY", "UCiDJtJKMICpb9B1qf7qjEOA"); // Adam Savage Tested
            map.Add("https://youtube.com/playlist?list=PLRsapyZqDs1o2_cfJNIxQzb-X1-mpYbdA", "UCsqjHFMB_JYTaEnfvmTNqg"); // Doug Meruno
            map.Add("https://www.youtube.com/playlist?list=PLrZ2zKOtC-C4rWfapgngoe9o2-ng8ZBr", "UCooViVfi0DaWk_eqxIXXiOQ"); // Product Design Online
            map.Add("https://www.youtube.com/playlist?list=PLUUk3Kbfv-_q1SKE776edGIYaAhkrKLu2", "UCGITwYebyH_lE_HF3QeH1cg");  // SKS Props

            int index = randomGenerator.Next(map.Count);

            string playlist = map.Keys.ElementAt(index);
            string channelId = map.Values.ElementAt(index);

            //KeyValuePair<string, string> pair = map.ElementAt(index);

            // Change and try viewData again as TempData is only one redirect
            ViewData["PlaylistRes"] = playlist;
            ViewData["ChannelId"] = channelId;

            // ViewData["PlaylistRes"] = pair.Key;
            // ViewData["Channel"] = pair.Value;

            Shows = await youTubeService.GetShows();
            UpcomingShow = Shows.LastOrDefault(show => show.IsInFuture && !show.IsOnAir);
            OnAirShow = Shows.FirstOrDefault(show => show.IsOnAir);
            }

            /*public async void OnGet() //Modify this to input the datasbe bdata to populate the view data
            {

            var randomGenerator = new Random();

            Dictionary<string, string> map = new Dictionary<string, string>();

            // var map = new Dictionary<string, string>();
            map.Add("https://youtube.com/playlist?list=PLYH8WvNV1YElPneq3cmmexAdmQf2pnICT", "UC-lHJZR3Gqxm24_Vd_AJ5Yw"); //Pewdipie
            map.Add("https://youtube.com/playlist?list=PL3tRBEVW0hiBSFOFhTC5wt75P2BES0rAo", "UC7_YxT-KID8kRbqZo7MyscQ"); // Markiplier
            map.Add("https://youtube.com/playlist?list=PLJtitKU0CAehsdcybehbPFHObmWsKtQcY", "UCiDJtJKMICpb9B1qf7qjEOA"); // Adam Savage Tested
            map.Add("https://youtube.com/playlist?list=PLRsapyZqDs1o2_cfJNIxQzb-X1-mpYbdA", "UCsqjHFMB_JYTaEnfvmTNqg"); // Doug Meruno
            map.Add("https://www.youtube.com/playlist?list=PLrZ2zKOtC-C4rWfapgngoe9o2-ng8ZBr", "UCooViVfi0DaWk_eqxIXXiOQ"); // Product Design Online
            map.Add("https://www.youtube.com/playlist?list=PLUUk3Kbfv-_q1SKE776edGIYaAhkrKLu2", "UCGITwYebyH_lE_HF3QeH1cg");  // SKS Props

            int index = randomGenerator.Next(map.Count);

            string playlist = map.Keys.ElementAt(index);
            string channelId = map.Values.ElementAt(index);

            //KeyValuePair<string, string> pair = map.ElementAt(index);

            // Change and try viewData again as TempData is only one redirect
            ViewData["PlaylistRes"] = playlist;
            ViewData["ChannelId"] = channelId;

            // ViewData["PlaylistRes"] = pair.Key;
            // ViewData["Channel"] = pair.Value;

            Shows = await youTubeService.GetShows();
            UpcomingShow = Shows.LastOrDefault(show => show.IsInFuture && !show.IsOnAir);
            OnAirShow = Shows.FirstOrDefault(show => show.IsOnAir);


            SqlConnection cn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Streamed_Chaos;Trusted_Connection=True;MultipleActiveResultSets=true");
            SqlCommand cmd = new SqlCommand("RandomChannel", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();*/
        }
    }
}