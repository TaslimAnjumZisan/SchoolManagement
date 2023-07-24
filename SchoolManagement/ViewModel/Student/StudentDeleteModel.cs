
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagement.ViewModel.Student
{
    public class StudentDeleteModel
    {
        public StudentDeleteModel()
        {
            CoordinateList = new List<SelectListItem>();

        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Student Name")]
        public string Name { get; set; }
        [Required]
        public DateTime AdmitionDate { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required]
        public bool IsGender { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Contact Number")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("CGPA")]
        public double Cgpa { get; set; }
        public string Coordinate { get; set; }


        [Required]
        public string Password { get; set; }
        public List<SelectListItem> CoordinateList { get; set; }


    }
}
