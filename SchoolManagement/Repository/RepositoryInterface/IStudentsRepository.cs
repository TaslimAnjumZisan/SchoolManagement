using SchoolManagement.Models;
using SchoolManagement.ViewModel.Student;

namespace SchoolManagement.Repository.RepositoryInterface
{
    public interface IStudentsRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Boolean> CreateStudentAsync(Student model, CancellationToken cancellationToken = default);
        Task<Student> GetStudentBy(int id);
        Task<Boolean> UpdateStudent(Student model, CancellationToken cancellationToken = default);
        Task<Student> GetStudentById(int id);
        Task<Boolean> DeleteStudent(Student student,CancellationToken cancellationToken=default);

      
    }
}
