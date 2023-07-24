using AutoMapper;
using SchoolManagement.Manager.ManagerInterface;
using SchoolManagement.Models;
using SchoolManagement.Repository.RepositoryInterface;
using SchoolManagement.ViewModel.Student;

namespace SchoolManagement.Manager.ManagerImplementation
{
    public class StudentManager : IStudentsManager
    {
        private readonly IStudentsRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentManager(IStudentsRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<List<StudentIndexModel>> GetAllStudentsAsync()
        {
            var existListOfStudent = await _studentRepository.GetAllStudentsAsync();
            var studentList = _mapper.Map<List<Student>, List<StudentIndexModel>>(existListOfStudent);
            return studentList;
        }
        public async Task<Boolean> CreateStudentAsync(StudentCreateModel model)

        {
            var student = _mapper.Map<StudentCreateModel, Student>(model);
            Boolean result = await _studentRepository.CreateStudentAsync(student);
            return result;
        }
        public async Task<StudentEditModel> GetStudentBy(int id)
        {
            var StudentDb = await _studentRepository.GetStudentBy(id);
            var student = _mapper.Map<Student, StudentEditModel>(StudentDb);
            return student;
        }

        public async Task<Boolean> UpdateStudent(StudentEditModel model)
        {
            var student = _mapper.Map<StudentEditModel, Student>(model);
            Boolean result = await _studentRepository.UpdateStudent(student);
            return result;

        }

        public async Task<StudentDeleteModel> GetStudentById(int id)
        {
            var StudentDb= await _studentRepository.GetStudentById(id);
            var student= _mapper.Map<Student,StudentDeleteModel>(StudentDb) ;
            return student; 
        }

        public async Task<bool> DeleteStudent(StudentDeleteModel model)
        {
            var student = _mapper.Map<StudentDeleteModel, Student>(model);
            Boolean result= await _studentRepository.DeleteStudent(student);
            return result;
        }

         

    }
}
