using AutoMapper;
using SchoolManagement.Manager.ManagerInterface;
using SchoolManagement.Models;
using SchoolManagement.Repository.RepositoryInterface;
using SchoolManagement.ViewModel.Teacher;

namespace SchoolManagement.Manager.ManagerImplementation
{
    public class TeacherManager:ITeachersManager
    {
        private readonly ITeachersRepository _teachersRepository;
        private readonly IMapper _mapper;
        public TeacherManager(ITeachersRepository teacherRepository,IMapper mapper)
        {
            _teachersRepository = teacherRepository;
            _mapper = mapper;
        }
        public async Task<List<TeacherIndexModel>>GetAllTeacherAsync()
        {
            var existListOfTeacher = await _teachersRepository.GetAllTeachersAsync();
            var teacherList = _mapper.Map<List<Teacher>, List<TeacherIndexModel>>(existListOfTeacher);
            return teacherList;
        }
    }
}
