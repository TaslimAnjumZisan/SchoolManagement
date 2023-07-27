using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Repository.RepositoryInterface;

namespace SchoolManagement.Repository.RepositoryImplementation
{
    public class TeachersRepository:ITeachersRepository
    {
        private readonly SchoolManagementDbContext _schoolManagementDbContext;
        public TeachersRepository(SchoolManagementDbContext schoolManagementDbContext)
        {
            _schoolManagementDbContext = schoolManagementDbContext;
        }
        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            List<Teacher> teachers=new List<Teacher>();
            teachers= _schoolManagementDbContext.Teachers.ToList();
            return teachers;
        }

        public async Task<Boolean> CreateTeacherAsync(Teacher model, CancellationToken cancellationToken = default)
        {
            var isCreate = false;
            var exists = await _schoolManagementDbContext.Teachers.AnyAsync(x=> x.Email.Trim().ToLower()==model.Email.Trim().ToLower());
            if(cancellationToken.IsCancellationRequested==false)
            {
                if(!exists)
                {
                    await _schoolManagementDbContext.Teachers.AddAsync(model);
                    await _schoolManagementDbContext.SaveChangesAsync();
                    return isCreate = true;

                }
            }
            return isCreate;
        }

        public async Task<Teacher> GetTeacherBy(int id)
        {
            var teacher= await _schoolManagementDbContext.Teachers.FindAsync(id);
            return teacher;
        }

        public async Task<Boolean> UpdateTeacher(Teacher model, CancellationToken cancellationToken = default)
        {
            var isUpdate = false;
            var exists= await _schoolManagementDbContext.Teachers.AnyAsync(x=> x.Email.Trim().ToLower()== model.Email.Trim().ToLower());
            if(cancellationToken.IsCancellationRequested==false)
            {
                if(exists)
                {
                     _schoolManagementDbContext.Teachers.Update(model);
                    await _schoolManagementDbContext.SaveChangesAsync();
                    return isUpdate = true;

                }
            }
            return isUpdate;

        }

        public async Task<Teacher>GetTeacherById(int id)
        {
           var teacher =await _schoolManagementDbContext.Teachers.FindAsync(id);
            return teacher;
        }

        public async Task<Boolean>DeleteTeacher(Teacher model, CancellationToken cancellationToken=default)
        {
            var isDelete = false;
            var exist= await _schoolManagementDbContext.Teachers.Where(x=> x.TeacherId== model.TeacherId).FirstOrDefaultAsync();
            if(cancellationToken.IsCancellationRequested == false)
            {
                _schoolManagementDbContext.Teachers.Remove(model);
                await _schoolManagementDbContext.SaveChangesAsync();
                return isDelete = true;
            }
            return isDelete;
        }
    }
}
