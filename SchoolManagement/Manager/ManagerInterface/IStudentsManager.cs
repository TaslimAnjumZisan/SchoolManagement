using SchoolManagement.Models;
using SchoolManagement.ViewModel.Student;

namespace SchoolManagement.Manager.ManagerInterface
{
    public interface IStudentsManager
    {
        Task<List<StudentIndexModel>> GetAllStudentsAsync();
        Task<Boolean> CreateStudentAsync(StudentCreateModel student, CancellationToken cancellationToken = default);
        Task<StudentEditModel> GetStudentBy(int id);
        Task<Boolean>UpdateStudent(StudentEditModel student, CancellationToken cancellationToken = default);
        Task<StudentDeleteModel>GetStudentById(int id);
        Task<Boolean> DeleteStudent(StudentDeleteModel model, CancellationToken cancellationToken = default);
        Task<List<StudentIndexModel>> GetAllTeacherStudentsAsync();

    }
}
