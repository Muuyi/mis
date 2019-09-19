using System;
using System.ComponentModel.DataAnnotations;
namespace mis.Models
{
    public class Meetings : Base
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime MeetingTime { get; set; }
    }
}