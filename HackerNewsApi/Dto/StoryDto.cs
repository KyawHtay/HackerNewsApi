using System;

public class StoryDto
{
    public string Title { get; set; }
    public string Uri { get; set; }
    public string PostedBy { get; set; }
    public long TimeUnix { get; set; } // Property for the Unix timestamp

    // Calculated property for the converted timestamp
    public DateTime Time => DateTimeOffset.FromUnixTimeSeconds(TimeUnix).UtcDateTime;

    public int Score { get; set; }
    public int CommentCount { get; set; }
}
