using System;
namespace mis.Models
{
    public class Tickets : Base
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}