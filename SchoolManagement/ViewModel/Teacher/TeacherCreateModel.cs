using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SchoolManagement.ViewModel.Student;

namespace SchoolManagement.ViewModel.Teacher
{
    public class TeacherCreateModel
    {
        public TeacherCreateModel()
        {
            //Students = new HashSet<Student>();
        }
        [Key]
        public int TeacherId { get; set; }
        [Required]
        [RegularExpression("([A-Z*a-z]+)", ErrorMessage = "Please enter valid Last Name")]
        [DisplayName("Teacher Name")]
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        //public ICollection<Student> Students { get; set; }
    }
}
