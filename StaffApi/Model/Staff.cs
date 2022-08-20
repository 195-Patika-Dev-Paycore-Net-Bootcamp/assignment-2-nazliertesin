using System.ComponentModel.DataAnnotations;

namespace StaffApi.Model
{
    public class Staff
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }

    }
}
