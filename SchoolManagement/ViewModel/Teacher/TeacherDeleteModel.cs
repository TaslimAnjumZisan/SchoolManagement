using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolManagement.ViewModel.Teacher
{
    public class TeacherDeleteModel
    {
        public int TeacherId { get; set; }
        [Required]
        [RegularExpression("([A-Z*a-z]+)", ErrorMessage = "Please enter valid Name")]
        [DisplayName("Teacher Name")]
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }
    }
}
