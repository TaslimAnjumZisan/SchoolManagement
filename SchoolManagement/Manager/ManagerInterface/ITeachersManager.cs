using SchoolManagement.ViewModel.Teacher;

namespace SchoolManagement.Manager.ManagerInterface
{
    public interface ITeachersManager
    {
        Task<List<TeacherIndexModel>> GetAllTeacherAsync();
    }
}
