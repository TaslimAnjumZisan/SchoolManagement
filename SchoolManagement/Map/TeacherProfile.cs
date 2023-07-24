using AutoMapper;
using SchoolManagement.Models;
using SchoolManagement.ViewModel.Teacher;

namespace SchoolManagement.Map
{
    public class TeacherProfile:Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherIndexModel>().ReverseMap();
           
        }
    }
}
