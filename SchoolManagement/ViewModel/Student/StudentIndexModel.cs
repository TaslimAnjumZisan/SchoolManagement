using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagement.ViewModel.Student
{
    public class StudentIndexModel
    {
        

        

        [Key]
        public int StudentId { get; set; }
        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Student Name")]
        public string Name { get; set; }
        public string TeacherName { get; set; }

        public DateTime AdmitionDate { get; set; } = DateTime.Now;
        [Required]
        public int Age { get; set; }

        [Required]

        public string Gender { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Phone { get; set; }
        [Required]

        public double Cgpa { get; set; }

        [Required]

        public string Password { get; set; }


       
    }
}
