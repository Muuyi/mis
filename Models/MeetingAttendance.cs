using System;
namespace mis.Models
{
    public class MeetingAttendance : Base
    {
        public int MeetingsId {get; set;}
        public int EmployeeId {get; set; }
        public bool Status {get; set; } = false;
        public Meetings Meetings { get; set; } 
        public Employee Employee { get;set; }   
    }
}