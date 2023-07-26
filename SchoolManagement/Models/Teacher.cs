using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Students=new HashSet<Student>();
        }
        [Key]
        public int TeacherId { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        
        public string Password { get; set; }

        public ICollection<Student> Students { get; set; }



    }
}
