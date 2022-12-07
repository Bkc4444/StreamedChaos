namespace Streamed_Chaos.Pages.Services
{
    public class UserPlaylist
    {
        /// <summary>
        /// The ID of the user
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The link to the playlist of the content creator
        /// </summary>
        public string PlaylistLink { get; set; }
        /// <summary>
        /// The Id of the content creator playlist
        /// </summary>
        public string PlaylistId { get; set; }
        /// <summary>
        /// The id of the channel being shown
        /// </summary>
        public string ChannelId { get; set; }
        /// <summary>
        /// The name of the channel being shown
        /// </summary>
        public string ChannelName { get; set; }
    }
}
