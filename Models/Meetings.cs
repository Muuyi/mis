using System;
namespace mis.Models
{
    public class Meetings : Base
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime MeetingDate { get; set; }
    }
}