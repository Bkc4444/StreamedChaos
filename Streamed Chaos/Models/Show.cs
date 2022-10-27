using System;

namespace Streamed_Chaos.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Topic { get; set; }

        public bool HasDisplayTitle { get; set; }

        public int DisplayTitle { get; set; }

        public string CommunityLinksUrl { get; set; }

        public string Description { get; set; }

        public DateTime? ScheduledStartTime {get; set;}

        public DateTime? ActualStartTime {get; set;}

        public DateTime? ActualEndTime { get; set;}

        public bool HasLinks { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }

        public string Category { get; set; }

    }
}
