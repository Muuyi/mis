using System;
namespace mis.Models
{
    public class Base
    {
        public Base(){
            CreatedDate=DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime CreatedDate {get; set;}
    }
}