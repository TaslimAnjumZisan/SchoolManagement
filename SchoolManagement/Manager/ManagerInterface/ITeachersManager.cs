using SchoolManagement.ViewModel.Teacher;

namespace SchoolManagement.Manager.ManagerInterface
{
    public interface ITeachersManager
    {
        Task<List<TeacherIndexModel>> GetAllTeacherAsync();
        Task<Boolean> CreateTeacherAsync(TeacherCreateModel model);
        Task<TeacherEditModel> GetTeacherBy(int id);
        Task<Boolean>UpdateTeacher(TeacherEditModel model);
        Task<TeacherDeleteModel>GetTeacherById(int id);
        Task<Boolean> DeleteTeacherAsync(TeacherDeleteModel model);
    }
}
