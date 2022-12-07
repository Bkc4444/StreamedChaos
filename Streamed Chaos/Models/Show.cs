using Humanizer;
using Newtonsoft.Json;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Streamed_Chaos.Models
{
    public class Show
    {
        /// <summary>
        /// The Id of the show
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Title of the show
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// What the show will focus on
        /// </summary>
        public string? Topic { get; set; }


        public bool HasDisplayTitle { get; set; }

        /// <summary>
        /// Shows the title of the stream
        /// </summary>
        public string? DisplayTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? CommunityLinksUrl { get; set; }
        /// <summary>
        /// Description of the stream
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// What time th show says it will start
        /// </summary>
        public DateTime? ScheduledStartTime {get; set;}
        /// <summary>
        /// What time the show actually starts at
        /// </summary>
        public DateTime? ActualStartTime {get; set;}

        /// <summary>
        /// What time the show actually ends at
        /// </summary>
        public DateTime? ActualEndTime { get; set;}

        /// <summary>
        /// Links to other shows
        /// </summary>
        public bool HasLinks { get; set; }
        
        /// <summary>
        /// The url for the show
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// The thumbnail of the show
        /// </summary>
        public string? ThumbnailUrl { get; set; }

        /// <summary>
        /// What the show is categorized as
        /// </summary>
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

        /// <summary>
        /// Checks to see when content creators are set to go live
        /// </summary>
        public static bool CheckHasStarted(DateTime dateTimeNow, DateTime scheduled)
        {
            return dateTimeNow > scheduled.AddMinutes(-5) && dateTimeNow < scheduled.AddHours(2);
        }

    }
}
