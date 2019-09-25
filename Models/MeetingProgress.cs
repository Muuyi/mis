using System;
namespace mis.Models
{
    public class MeetingProgress : Base
    {
       public int MeetingsId {get;set;} 
       public Meetings Meetings {get; set;}
       public string MeetingStatus { get; set; }
       public string Description { get; set; }
    }
}