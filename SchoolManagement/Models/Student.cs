using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class Student
    {
       
        [Key]
        public int Std_Id { get; set; }

        
        public string Name { get; set; }
        
        public DateTime AdmitionDate { get; set; } = DateTime.Now;
        
        public int Age { get; set; }

        
        public Boolean IsGender { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public double Cgpa { get; set; }
        
        
        public string Password { get; set; }
        public virtual int TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teachers { get; set; }

    }
}
