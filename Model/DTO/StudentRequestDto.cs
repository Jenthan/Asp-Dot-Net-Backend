using WebApplication1.Model.Domain;

namespace WebApplication1.Model.DTO
{
    public class StudentRequestDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public string dateOfBirth { get; set; }

        public string parentName { get; set; }
        public string parentPhoneNumber { get; set; }

        public string address { get; set; }
    }
}
