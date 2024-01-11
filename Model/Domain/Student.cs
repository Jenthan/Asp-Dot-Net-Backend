using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Model.Domain
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
      
        public string DateOfBirth { get; set; }

        public string ParentName { get; set; }
        public string ParentPhoneNumber { get; set; }

        public string Address { get; set; }

       
    }
}
