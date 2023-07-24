using SchoolManagement.Models;

namespace SchoolManagement.Repository.RepositoryInterface
{
    public interface ITeachersRepository
    {
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Boolean> CreateTeacherAsync(Teacher model, CancellationToken cancellationToken = default);
    }
}
