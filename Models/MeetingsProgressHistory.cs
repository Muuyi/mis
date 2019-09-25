namespace mis.Models
{
    public class MeetingsProgressHistory:Base
    {
        public int MeetingsId {get;set;}
         public Meetings Meetings {get; set;}
        public string MeetingStatus { get; set; }
    }
}