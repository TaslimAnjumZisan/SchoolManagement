using AutoMapper;
using SchoolManagement.Models;
using SchoolManagement.ViewModel.Student;

namespace SchoolManagement.Map
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentIndexModel>().ReverseMap();
            CreateMap<Student, StudentCreateModel>().ReverseMap();
            CreateMap<Student, StudentEditModel>().ReverseMap();
            CreateMap<Student, StudentDeleteModel>().ReverseMap();

        }
    }
}
