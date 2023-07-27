using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Student
    {
        public Student()
        {
              Teacher  = new Teacher();
        }

        [Key]
        public int StudentId { get; set; }
        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }
        public string Name { get; set; }
        
        public DateTime AdmitionDate { get; set; } = DateTime.Now;
        
        public int Age { get; set; }

        
        public string Gender { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public double Cgpa { get; set; }
        
        
        public string Password { get; set; }
      

   
        public virtual Teacher Teacher { get; set; }

    }
}
