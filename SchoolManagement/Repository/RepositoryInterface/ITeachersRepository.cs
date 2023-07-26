using SchoolManagement.Models;

namespace SchoolManagement.Repository.RepositoryInterface
{
    public interface ITeachersRepository
    {
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Boolean> CreateTeacherAsync(Teacher model, CancellationToken cancellationToken = default);
        Task<Teacher> GetTeacherBy(int id);
        Task<Boolean> UpdateTeacher(Teacher model, CancellationToken cancellationToken = default);
        Task<Teacher> GetTeacherById(int id);
        Task<Boolean> DeleteTeacher(Teacher teacher, CancellationToken cancellationToken = default);



    }
}
