namespace mis.Models
{
    public class ApplicationUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }       
        public string Password { get; set; }
        public string PhoneNumber {get; set;}
        public string FullName { get; set; }
        public int DepartmentId {get; set;}
        // // public Department Department {get;set;}
    }
}