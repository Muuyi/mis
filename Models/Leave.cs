using System;
namespace mis.Models
{
    public class Leave : Base
    {
        public string ApplicationUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type {get; set; }
        public ApplicationUser ApplicationUser {get; set;}
    }
}