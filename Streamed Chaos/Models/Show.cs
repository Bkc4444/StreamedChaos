using Humanizer;
using Newtonsoft.Json;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Streamed_Chaos.Models
{
    public class Show
    {
        public string? Id { get; set; }
        public string? Title { get; set; }

        public string? Topic { get; set; }

        public bool HasDisplayTitle { get; set; }

        public string? DisplayTitle { get; set; }

        public string? CommunityLinksUrl { get; set; }

        public string? Description { get; set; }

        public DateTime? ScheduledStartTime {get; set;}

        public DateTime? ActualStartTime {get; set;}

        public DateTime? ActualEndTime { get; set;}

        public bool HasLinks { get; set; }

        public string? Url { get; set; }

        public string? ThumbnailUrl { get; set; }

        public string? Category { get; set; }


        // Humanizer is used in .NET to manipulate and display strings, enums, dates, times, timespans
        // numbers, and quantities. 
        // https://github.com/Humanizr/Humanizer
        // This gets the start time of streams
        [JsonIgnore]
        public string ScheduledStartTimeHumanized
        {
            get
            {
                if ((DateTime.UtcNow - ScheduledStartTime.Value).TotalDays <= 7)
                    return ScheduledStartTime.Humanize();

                var culture = CultureInfo.CurrentCulture;
                var regex = new Regex("dddd[,]{0,1}");
                var shortDatePattern = regex.Replace(culture.DateTimeFormat.LongDatePattern.Replace("MMMM", "MMM"), string.Empty).Trim();
                return ScheduledStartTime.Value.ToString($"{shortDatePattern}", culture);
            }
        }

        [JsonIgnore]
        public bool IsNew => !IsInFuture &&
                     !IsOnAir &&
                     (DateTime.UtcNow - ScheduledStartTime.Value).TotalDays <= 14;

        [JsonIgnore]
        public bool IsInFuture => ScheduledStartTime.Value > DateTime.UtcNow;

        [JsonIgnore]
        public bool IsOnAir
        {
            get
            {
                // If stream has started and then ended and is not on air
                if (ActualStartTime.HasValue && ActualEndTime.HasValue)
                    return false;

                // If live stream is started but has not ended
                if (ActualStartTime.HasValue && !ActualEndTime.HasValue)
                    return true;

                // If data is not fresh use scedualed time
                var scheduled = ScheduledStartTime.Value;
                return CheckHasStarted(DateTime.UtcNow, scheduled);
            }
        }

        public static bool CheckHasStarted(DateTime dateTimeNow, DateTime scheduled)
        {
            return dateTimeNow > scheduled.AddMinutes(-5) && dateTimeNow < scheduled.AddHours(2);
        }

    }
}
