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

        public async Task<Boolean> CreateTeacherAsync(TeacherCreateModel model)
        {
            var teacher = _mapper.Map<TeacherCreateModel,Teacher>(model);
            Boolean result = await _teachersRepository.CreateTeacherAsync(teacher);
            return result;
        }
        public async Task<TeacherEditModel> GetTeacherBy(int id)
        {
            var teacherDb= await _teachersRepository.GetTeacherBy(id);
            var result = _mapper.Map<Teacher, TeacherEditModel>(teacherDb);
            return result;
        }
        public async Task<Boolean>UpdateTeacher(TeacherEditModel model)
        {
            var teacher = _mapper.Map<TeacherEditModel,Teacher>(model);
            var result = await _teachersRepository.UpdateTeacher(teacher);
            return result;
        }

        public async Task<TeacherDeleteModel>GetTeacherById(int id)
        {
            var teacherDb = await _teachersRepository.GetTeacherById(id); 
            var result= _mapper.Map<Teacher,TeacherDeleteModel>(teacherDb);
            return result;
        }

        public async Task<Boolean> DeleteTeacherAsync(TeacherDeleteModel model)
        {
            var teacher = _mapper.Map<TeacherDeleteModel,Teacher>(model) ;
            var result = await _teachersRepository.DeleteTeacher(teacher);
            return result;
        }


    }
}
