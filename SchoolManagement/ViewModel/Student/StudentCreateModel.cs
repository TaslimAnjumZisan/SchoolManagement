using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.ViewModel.Student
{
    public class StudentCreateModel
    {
        public StudentCreateModel()
        {
            
            Teachers = new List<SelectListItem>();
            GenderList = new List<SelectListItem>();

        }

        [Key]
        public int StudentId { get; set; }
        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Student Name")]
        public string Name { get; set; }

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



        
        public virtual IEnumerable<SelectListItem> Teachers { get; set; }
        public virtual IEnumerable<SelectListItem> GenderList { get; set; }

    }
}
