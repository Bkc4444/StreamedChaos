using Newtonsoft.Json;
using Streamed_Chaos.Models;

namespace Streamed_Chaos.Pages.Services
{
    public class YoutubeService : IYouTubeShowsService
    {
        private HttpClient httpClient;
        private IConfiguration config;

        public YoutubeService(IHttpClientFactory httpClient, IConfiguration config)
        {
            this.httpClient = httpClient.CreateClient();
            this.config = config;
        }

        public async Task<IEnumerable<Show>> GetShows(int numberOfShows = 25)
        {
            var shows = await httpClient.GetStringAsync(config["FunctionGetShowsUrl"]);
            return JsonConvert.DeserializeObject<IEnumerable<Show>>(shows);
        }

    }
}
